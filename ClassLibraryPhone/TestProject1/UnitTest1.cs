using ClassLibrary;
using System.Xml.Linq;

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
        public void test_zly_nrtel_argumentexception()
        {
            var owner = "piotr";
            var number = "77588888u";
            Assert.ThrowsException<ArgumentException>(() => {new Phone(owner, number); });
        }
        [TestMethod]
        public void test_iloscmiejsc_phonebook()
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
        [TestMethod]
        public void test_niewlasciwa_nazwa_owner()
        {
            var owner = "";
            var number = "876785453";
            Assert.ThrowsException<ArgumentException>(() => { new Phone(owner, number); });
        }
        [TestMethod]
        public void test_call_numer_istnieje()
        {
            var owner = "piotr";
            var number = "876785453";
            var tel1 = new Phone(owner, number);
            var name1 = "kasia";
            var number1 = "876785453";
            tel1.AddContact(name1, number1);
            var res = tel1.Call(name1);
            Assert.AreEqual($"Calling {number1} ({name1}) ...", res);

        }
        [TestMethod]
        public void test_call_numer_nie_istnieje()
        {
            var owner = "piotr";
            var number = "876785453";
            var tel1 = new Phone(owner, number);
            var name1 = "kasia";
            var number1 = "876785453";
            Assert.ThrowsException<InvalidOperationException>(() => { tel1.Call(name1); });
        }

        [TestMethod]
        public void addExistingContact_returnsFalse()
        {

            var owner = "piotr";
            var number = "876678545";
            var phone = new Phone(owner, number);
            var name1 = "asdjhads";
            var number1 = "878733888";
            phone.AddContact(name1, number1);
            var result = phone.AddContact(name1, number1);
            Assert.IsFalse(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void addNewContact_returnsTrue()
        {

            var owner = "piotr";
            var number = "876678545";
            var phone = new Phone(owner, number);
            var name1 = "asdjhads";
            var number1 = "878733888";
            var result = phone.AddContact(name1, number1);
            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }
    }
}