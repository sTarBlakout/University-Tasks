

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void TestSaldo()
        {
            var bank = new Lab7.Bank();
            Assert.IsTrue(0d == bank.Saldo());
        }

        [Test]
        public void TestWplata()
        {
            var bank = new Lab7.Bank();
            var wplata = 80d;
            bank.Wplata(wplata);
            Assert.IsTrue(wplata == bank.Saldo());
        }

        [Test]
        public void TestWyplata()
        {
            var bank = new Lab7.Bank();
            var wyplata = 80d;
            bank.Wyplata(wyplata);
            Assert.IsTrue(0 == bank.Saldo());
        }

        [Test]
        public void TestDivideByZero()
        {
            var zbior = new Lab7.Zbior();

            try
            {
                zbior.iloraz_elem(0);
                Assert.Fail();
            }
            catch (InvalidDataException) 
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestNoSuchElement()
        {
            var zbior = new Lab7.Zbior();

            try
            {
                zbior.usun(4);
                Assert.Fail();
            }
            catch (InvalidDataException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestSprewdz()
        {
            var zbior = new Lab7.Zbior();
            zbior.dodaj(5);
            Assert.IsTrue(zbior.sprawdz(5) == true);
        }

        [Test]
        public void TestUsub()
        {
            var zbior = new Lab7.Zbior();
            zbior.dodaj(5);
            zbior.usun(5);
            Assert.IsTrue(zbior.sprawdz(5) == false);
        }

        [Test]
        public void TestStackPop()
        {
            var stos = new Lab7.Stos();
            stos.push(":)");
            stos.push(":(");
            Assert.IsTrue(stos.pop() == ":(");
        }

        [Test]
        public void TestStackPopError()
        {
            var stos = new Lab7.Stos();

            try
            {
                stos.pop();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestStackTopError()
        {
            var stos = new Lab7.Stos();

            try
            {
                stos.top();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestStackPush()
        {
            var stos = new Lab7.Stos();
            stos.push(":)");
            Assert.IsTrue(stos.pop() == ":)");
        }

        [Test]
        public void TestStackTop()
        {
            var stos = new Lab7.Stos();
            stos.push(":)");
            Assert.IsTrue(stos.top() == ":)");
        }

        [Test]
        public void TestStackEmpty()
        {
            var stos = new Lab7.Stos();
            stos.push(":)");
            stos.pop();
            Assert.IsTrue(stos.isEmpty());
        }
    }
}