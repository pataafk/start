using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Broadcast
{
    class Program
    {
        private const int ListenPort = 11000;

        static void Main(string[] args)
        {
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
                Console.Write(">");
                string msg = Console.ReadLine();

                //skicka meddelandet
                byte[] sendbuff = Encoding.UTF8.GetBytes(msg);
                socket.SendTo(sendbuff, ep);

                // gör en pause
                Thread.Sleep(200);
            }
        }

        static void Listener()
        {
            //skapar ett object som ska lyssna efter meddelanden
            UdpClient listener = new UdpClient(ListenPort);

            try
            {
                while (true)
                {
                    //skapa object som lyssnar efter trafik från valfri tp-addres men via port
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);

                    //lyssnar och tar emot msg
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine("Received broadcast from {0} : {1}\n", groupEP.ToString(), Encoding.UTF8.GetString(bytes, 0, bytes.Length));

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
