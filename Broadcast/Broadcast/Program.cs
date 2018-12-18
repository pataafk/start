using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Broadcast
{
    class Program
    {
        private const int ListenPort = 11000;
        private static Random rnd = new Random();

        static void Main(string[] args)
        {



            //Text och bakgrund's färg vall
            Console.ForegroundColor = GetRandomConsoleColor();


            //skapar en tråd som körs samtidigt med huvudprogrammet
            var listenThread = new Thread(Listener);
            listenThread.Start();

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.EnableBroadcast = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, 11000);

            Thread.Sleep(1000);

            while(true)
            {
                //Användare skriver meddelande
                Console.Write("Write>");
                string msg = Console.ReadLine();

                //skicka meddelandet
                byte[] sendbuff = Encoding.UTF8.GetBytes(msg);
                socket.SendTo(sendbuff, ep);

                // gör en pause
                Thread.Sleep(200);
            }
        }
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(rnd.Next(consoleColors.Length));    
        }


        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd HH:mm:ss:ff  ");
        }

        static void Listener()
        {
            //skapar ett object som ska lyssna efter meddelanden
            UdpClient listener = new UdpClient(ListenPort);

            String timeStamp = GetTimestamp(DateTime.Now);
            try
            {
                while (true)
                {
                    //skapa object som lyssnar efter trafik från valfri tp-addres men via port
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);

                    //lyssnar och tar emot msg
                    byte[] bytes = listener.Receive(ref groupEP);


                    Console.WriteLine(timeStamp + "Received broadcast from {0} : {1}\n", groupEP.ToString(), Encoding.UTF8.GetString(bytes, 0, bytes.Length));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
