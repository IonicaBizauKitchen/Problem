using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cards
{
    public class Card : PictureBox
    {
        public int value;
        public int color;
        public int row;
        public int column;

        public Card(int val, int col, int top, int left, Panel parent, bool isMain, int row, int column)
        {
            this.value = val;
            this.color = col;
            this.row = row;
            this.column = column;
            this.Parent = parent;
            this.Width = 80;
            this.Height = 110;
            this.Top = top;
            this.Left = left;
            if (val > 0 && col > 0)
                ShowCard();
            else
                ShowBackCard();
            if (isMain)
                this.MouseDown += pb_MouseDown;
            else
            {
                this.AllowDrop = true;
                this.DragEnter += pb_DragEnter;
                this.DragDrop += pb_DragDrop;
            }
        }

        public void pb_DragDrop(object sender, DragEventArgs e)
        {
            int currentRow = Engine.GetMinUnsetRow();
            if (this.row == currentRow && currentRow < 5 && this.value<2)
            {
                Card c = (Card)e.Data.GetData(typeof(Card));
                this.Image = c.Image;
                SetCard(c);
                Card tmp = Start.PickCard();
                c.SetCard(tmp);
            }
            else
            {
                if (currentRow != 5)
                    MessageBox.Show("Please complete each row starting from the top.");
            }

            currentRow = Engine.GetMinUnsetRow();
            if (currentRow == 5)
            {
                Engine.AllWin();
                Engine.SetWin();
                MessageBox.Show(Engine.win.ToString());
            }

        }

        public static void pb_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public void pb_MouseDown(object sender, MouseEventArgs e)
        {
            DataObject dt = new DataObject((Card)sender);
            this.DoDragDrop(dt, DragDropEffects.Copy);
        }

        public void ShowCard()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            string msg = "";
            switch (color)
            {
                case 0: msg = "Trefla"; break;
                case 1: msg = "Pica"; break;
                case 2: msg = "Caro"; break;
                case 3: msg = "Cupa"; break;
            }
            this.Image = System.Drawing.Image.FromFile(@"..\Cards\" + msg + value.ToString() + ".png");
        }

        public void ShowBackCard()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Image = System.Drawing.Image.FromFile(@"..\Cards\Back.png");
        }

        public void SetCard(Card c)
        {
            this.value = c.value;
            this.color = c.color;
            ShowCard();
        }
    }
    }

