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
            var number = "87678545";
            Assert.ThrowsException<ArgumentException>(() => {new Phone(owner, number); });
        }
        [TestMethod]
        public void konstruktor_iloscmiejsc_phonebook()
        {
            var phoneBookCapacity = 100;
            var owner = "piotr";
            var number = "876785453";
            var phoneBook = new Dictionary<int, Phone>();
            for (int i = 0; i <= phoneBookCapacity; i++)
            {
                var tel1 = new Phone(owner, number);
                phoneBook.Add(i, tel1);
            }
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var tel1 = new Phone(owner, number);
                phoneBook.Add(phoneBookCapacity, tel1);
            }
            );
        }
    }
}