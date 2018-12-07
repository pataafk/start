using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace highscore
{
    public partial class Form1 : Form
    {
        List<Score> scores;
        //SortedList<string, int> scores;
        public Form1()
        {
            InitializeComponent();
            scores = new List<Score>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lägg till ett resultat
            Score tmp = new Score(txtname.Text, int.Parse(txtPoints.Text));

            scores.Add(tmp);
            PrintScoreList();
        }
        private void PrintScoreList()
        {
            foreach(Score score in scores)
            {
                lblhighscore.Text = score.Name + " \t" + score.Points + "\r\n";
            }
        }
    }

    class Score
    {
        string name;
        int points;
        
        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get => name; set => name = value; }
        public int Points { get => points; set => points = value; }
    }
}
