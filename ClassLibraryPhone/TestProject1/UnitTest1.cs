using ClassLibrary;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void konstruktor_dane_poprawne_ok()
        {
            var owner = "piotr";
            var number = "876678545";
            var tel1 = new Phone(owner, number);
            Assert.AreEqual(owner, tel1.Owner);
        }
        [TestMethod]
        public void konstruktor_zakrotkinumertel_arhumentexeption()
        {
            var owner = "piotr";
            var number = "8768545";
            Assert.ThrowsException<ArgumentException>(() => {new Phone(owner, number); });
           

        }

    }
}