using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
   public  class Player
    {
        public List<Card> Hand { get; private set; }
        public Player()
        {
            Hand = new List<Card>();
        }
        public void PutCardHand(Card c)
        {   
            Hand.Add(c);
        }
        public void DropCard(Card c)
        {
            Hand.Remove(c);
        }
        public void DropAll()
        {
            Hand.Clear();
        }
        public void GetCards(CardDesk d,int count)
        {
            for (int i = 0; i < count; i++)
            {
                Card c = d.GetCardOnTop();
                if (c != null) Hand.Add(c); else break;
            }
        }
    }
}
