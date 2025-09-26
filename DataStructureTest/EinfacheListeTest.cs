using NUnit.Framework;
using DataStructure;
using Common;

namespace DataStructureTest
{
    public class Tests
    {
        private SingleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new SingleLinkedList<Person>();
        }

        [Test]
        public void AddPerson_ShouldAddPersonToList()
        {
            Person anna = new Person("Anna", "Schmidt", "Weiblich", 25);
            list.Add(anna);
            Assert.IsTrue(list.Contains(anna), "Die Person sollte in der Liste enthalten sein.");
        }

        [Test]
        public void ContainsPerson_WhenPersonNotInList_ShouldReturnFalse()
        {
            Person anna = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person ben = new Person("Ben", "Müller", "Männlich", 30);
            list.Add(anna);
            Assert.IsFalse(list.Contains(ben), "Die Person sollte nicht in der Liste enthalten sein.");
        }

        [Test]
        public void ContainsPerson_WhenListEmpty_ShouldReturnFalse()
        {
            Person anna = new Person("Anna", "Schmidt", "Weiblich", 25);
            Assert.IsFalse(list.Contains(anna), "Die leere Liste sollte keine Person enthalten.");
        }

        [Test]
        public void AddMultiplePersons_ShouldContainAll()
        {
            Person anna = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person ben = new Person("Ben", "Müller", "Männlich", 30);
            Person clara = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(anna);
            list.Add(ben);
            list.Add(clara);
            Assert.IsTrue(list.Contains(anna), "Anna sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(ben), "Ben sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(clara), "Clara sollte in der Liste enthalten sein.");
        }
    }
}