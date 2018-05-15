using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tester;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CardDesk d = new CardDesk();
            d.MixDesk(100000);
            Player p1 = new Player();
            Board b = new Board();
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            p1.PutCardHand(d.GetCardOnTop());
            p1.PutCardHand(d.GetCardOnTop());
            TestCombine.Test(b, p1);
        }
    }
}
