using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class CardDesk
    {
        public static readonly byte COUNT_TYPES = 13; 
        public List<Card> Cards { get; private set; }
        Random r;
        public CardDesk()
        {
            Cards = new List<Card>();
            r = new Random();
            for (byte i = 0; i < COUNT_TYPES; i++)
            {
                Cards.Add(new Card() { mark = 0, power = i });
                Cards.Add(new Card() { mark = 1, power = i });
                Cards.Add(new Card() { mark = 2, power = i });
                Cards.Add(new Card() { mark = 3, power = i });
            }
        }
        public void MixDesk(int countMix)
        {
            for (int i = 0; i < countMix; i++)
            {
                int j = r.Next(Cards.Count);
                int numCards = r.Next(Cards.Count - j);
                List<Card> buff = Cards.GetRange(j, numCards);
                Cards.RemoveRange(j, numCards);
                Cards.InsertRange(r.Next(Cards.Count), buff);
            }
        }
        public Card GetCardOnTop()
        {
            if (Cards.Count == 0) return null;
            Card c = Cards[0];
            Cards.Remove(c);
            return c;
        }
        public void PutCardToDown(Card card)
        {
            Cards.Add(card);
        }
        public Card GetRandomCard()
        {
            Card c = Cards[r.Next(Cards.Count)];
            Cards.Remove(c);
            return c;
        }
    }
    public class Card : IComparable
    {
        public byte power;
        public byte mark;

        public int CompareTo(object obj)
        {
            Card c = obj as Card;
            if (c.power > power) return -1;
            if (c.power < power) return 1;
            return 0;
        }
        public override string ToString()
        {
            string s = "";
            switch(power)
            {
                case 0: s = "2"; break;
                case 1: s = "3"; break;
                case 2: s = "4"; break;
                case 3: s = "5"; break;
                case 4: s = "6"; break;
                case 5: s = "7"; break;
                case 6: s = "8"; break;
                case 7: s = "9"; break;
                case 8: s = "10"; break;
                case 9: s = "J"; break;
                case 10: s = "Q"; break;
                case 11: s = "K"; break;
                case 12: s = "A"; break;
            }
            switch(mark)
            {
                case 0: s += '\u2663'; break;
                case 1: s += '\u2660'; break;
                case 2: s += '\u2666'; break;
                case 3: s += '\u2665'; break;
            }
            return s;
        }
    }
}
