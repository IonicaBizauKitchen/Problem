using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class Start
    {
        static Random r = new Random();
        public static List<Card> myCard;

        public static void NewDeck()
        {
            myCard = new List<Card>();
            for (int i = 0; i < 4; i++)
                for (int j = 2; j < 15; j++)
                {
                    myCard.Add(new Card(j, i, 0, 0, null, false, 0, 0));
                }
        }

        public static void Shuffle(int n)
        {
            int temp, c1, c2;
            for (int i = 0; i < n; i++)
            {
                c1 = r.Next() % 52;
                c2 = r.Next() % 52;

                temp = myCard[c1].value;
                myCard[c1].value = myCard[c2].value;
                myCard[c2].value = temp;

                temp = myCard[c1].color;
                myCard[c1].color = myCard[c2].color;
                myCard[c2].color = temp;
            }
        }

        public static Card PickCard()
        {
            Card c = myCard[0];
            myCard.RemoveAt(0);
            return c;
        }
    }
}
