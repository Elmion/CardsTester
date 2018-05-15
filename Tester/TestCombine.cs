using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
   public class TestCombine 
    {
        public static string Test(Board desk, Player p)
        {
            List<Card> buff = new List<Card>();
            buff.AddRange(desk.Desktop);
            buff.AddRange(p.Hand);
            buff.Sort();
            string OUT = "None";
            if (Flash(buff).Count != 0)
            {
                OUT = "Flash";
            }
            else if (Street(buff).Count != 0)
            {
                OUT = "Street";
            }
            else if (CountTwoPlusTree(buff).Count != 0)
            {
                OUT = "3+2";
            }
            else if (CountFour(buff).Count != 0)
            {
                OUT = "4";
            }
            else if (CountThree(buff).Count != 0)
            {
                OUT = "3";
            }
            else if (CountPair(buff).Count != 0)
            {
                OUT = "2";
            }
            else { }

            return OUT;
        }
        private static List<Card[]> CountPair(List<Card> cards)
        {
            List<Card[]> OUT = new List<Card[]>();
            for (int i = 0; i < CardDesk.COUNT_TYPES; i++)
            {
                List<Card> sel = cards.Where(x => x.power == i).ToList();
                if (sel.Count == 2)
                {
                    OUT.Add(sel.ToArray());
                }
            }
            return OUT;
        }
        private static List<Card[]> CountThree(List<Card> cards)
        {
            List<Card[]> OUT = new List<Card[]>();
            for (int i = 0; i < CardDesk.COUNT_TYPES; i++)
            {
                List<Card> sel = cards.Where(x => x.power == i).ToList();
                if (sel.Count == 3)
                {
                    OUT.Add(sel.ToArray());
                }
            }
            return OUT;
        }
        private static List<Card[]> CountFour(List<Card> cards)
        {
            List<Card[]> OUT = new List<Card[]>();
            for (int i = 0; i < CardDesk.COUNT_TYPES; i++)
            {
                List<Card> sel = cards.Where(x => x.power == i).ToList();
                if (sel.Count == 4)
                {
                    OUT.Add(sel.ToArray());
                }
            }
            return OUT;
        }
        private static List<Card[]> Flash(List<Card> cards)
        {
            List<Card[]> OUT = new List<Card[]>();
            int marks = cards.GroupBy(x => x.mark).Select(x => x.Count()).ToList().FindLastIndex(x => x >= 5);
            if (marks != -1)
                OUT.Add(cards.GroupBy(x => x.mark).Where(x => x.Count() > 5).Select(x => x.First()).ToArray());
            return OUT;
        }
        private static List<Card> Street(List<Card> cards)
        {
            List<Card> OUT = new List<Card>();
            List<byte> powers = cards.GroupBy(x => x.power).Select(x => x.First().power).ToList();
            int counter = 1;

            OUT.Add(cards.Where(x => x.power == powers[powers.Count - 1]).First());
            for (int i = powers.Count-1; i < 0; i++)
            {
                if(powers[i] == powers[i-1]-1)
                {
                    OUT.Add(cards.Where(x => x.power == powers[i-1]).First());
                    counter++;
                }
                else
                {
                    OUT.Clear();
                    OUT.Add(cards.Where(x => x.power == powers[i - 1]).First());
                    counter=1;
                }
            }
            if (OUT.Count < 5)
                     OUT.Clear();
            return OUT;
        }
        private static List<Card> CountTwoPlusTree(List<Card> cards)
        {
            List<Card> OUT = new List<Card>();
            List<Card[]> pairs = CountPair(cards);
            List<Card[]> three = CountThree (cards);
            if ((pairs.Count > 0 && three.Count > 0)||three.Count > 1)
            {
                if (three.Count > 1 && pairs[pairs.Count - 1][0].power < three[three.Count - 1][0].power)
                {
                    OUT.Add(three[three.Count - 2].ToList()[0]);
                    OUT.Add(three[three.Count - 2].ToList()[1]);
                    OUT.AddRange(three[three.Count - 1].ToList());
                }
                else
                {

                    OUT.AddRange(pairs[pairs.Count - 1].ToList());
                    OUT.AddRange(three[three.Count - 1].ToList());
                }
            }
            return OUT;
        }
        private List<Card[]> RoylFlesh()
        {
            throw new NotImplementedException();
        }
        private List<Card[]> FleshStreet()
        {
            throw new NotImplementedException();
        }
    }

}
