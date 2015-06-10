using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public enum Win {Zero = 0,Val2=50, Val3=60, Val4=70, Val5=80,Val6=90,Flush=100}
   public class Engine
    {
        public static Card[,] c;
        public static Card cs;
        public static int win;
        public static TextBox wint;
        public static TextBox twint;
        public static Button newGame;

        public static void NewGame(Panel parentcs, Panel parent, TextBox winT, Button btn)
        {
            if (c != null && c[0, 0] != null)
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        c[i, j].Dispose();
                    }
            }
            c = new Card[5, 5];
            if (cs != null)
                cs.Dispose();
            cs = new Card(0, 0, 5, 5, parentcs, true, 0, 0);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    Card ca = new Card(0, 0, 10 + 115 * i, 10 + 85 * j, parent, false, i, j);
                    c[i, j] = ca;
                }
            wint = winT;
            newGame = btn;
        }

        public static int GetMinUnsetRow()
        {
            int x = 5;
            for (int i = 1; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (c[i, j].value < 2)
                    {
                        return i;
                    }
                }
            return x;
        }

        public static void TotalScore(int score)
        {

            int allScore = int.Parse(twint.Text);
            allScore += score;
            twint.Text = allScore.ToString();
        }

        public static void SetWin()
        {
            newGame.Enabled = true;
        }
        public static void AllWin()
        {
            win = 0;
            for (int i = 0; i < 5; i++)
            {
                win += WinLine(c[0, i], c[1, i], c[2, i], c[3, i], c[4, i]);
                win += WinLine(c[i, 0], c[i, 1], c[i, 2], c[i, 3], c[i, 4]);
            }
            win += WinLine(c[0, 0], c[1, 1], c[2, 2], c[3, 3], c[4, 4]);
            win += WinLine(c[0, 4], c[1, 3], c[2, 2], c[3, 1], c[4, 0]);
        }

        public static int WinLine(Card card1, Card card2, Card card3, Card card4, Card card5)
        {
             Win answer = Win.Zero;
            Card[] myCards = new Card[5];
            myCards[0] = card1;
            myCards[1] = card2;
            myCards[2] = card3;
            myCards[3] = card4;
            myCards[4] = card5;

            int s = 0;
            for (int i = 0; i < 4; i++)
                for (int j = i + 1; j < 5; j++)
                {
                    if (myCards[i].value == myCards[j].value)
                    {
                        s++;
                    }
                }
            if (s == 1)
                answer = Win.Val2;
            if (s == 2)
            {
                answer = Win.Val3;
            }
            if (s == 3)
            {
                answer = Win.Val4;
            }
            if (s == 4)
            {
                answer = Win.Val5;
            }
            if (s == 6)
            {
                answer = Win.Val6;
            }
            int isFlush = 1;

            for (int k = 0; k < 4; k++)
                if (myCards[k].color != myCards[k + 1].color)
                    isFlush = 0;
           
            if (isFlush == 1)
                answer = Win.Flush;
            return (int)answer;
        }
        }
    }
