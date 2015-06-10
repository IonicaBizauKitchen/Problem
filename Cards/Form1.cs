using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.NewGame(panel2, panel1, textBox1, button1);
            Start.NewDeck();
            Start.Shuffle(250);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "START")
            {
               
                    for (int i = 0; i < 5; i++)
                    {
                        Card tmp = Start.PickCard();
                        Engine.c[0, i].SetCard(tmp);
                    }
                    button1.Text = "New";
                    Card temp = Start.PickCard();
                    Engine.cs.SetCard(temp);

               
            }
            else if (button1.Text == "New")
            {
                int win = int.Parse(textBox1.Text);
                Engine.TotalScore(win);

                textBox1.Text = string.Empty;
                button1.Text = "START";

                Engine.NewGame(panel1, panel2, textBox1, button1);
                Start.NewDeck();
                Start.Shuffle(250);
                textBox1.Text = "0";
            }
        }
    }
}
