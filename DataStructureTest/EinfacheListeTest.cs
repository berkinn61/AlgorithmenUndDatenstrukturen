using NUnit.Framework;
using DataStructure;
using Common;

namespace DataStructureTest
{
    public class Tests
    {
        private SingleLinkedList list;

        [SetUp]
        public void Setup()
        {
            list = new SingleLinkedList();
        }

        [Test]
        public void InsertPerson_ShouldInsertPersonInList()
        {
            Person person = new Person("Sophie", "Meier", "Weiblich", 28);
            list.Add(person);
            Assert.IsTrue(list.Contains(person), "Die Person sollte in der Liste enthalten sein.");
        }

        [Test]
        public void CheckPersonNotInList_ShouldReturnFalse()
        {
            Person person1 = new Person("Sophie", "Meier", "Weiblich", 28);
            Person person2 = new Person("Lukas", "Fischer", "Männlich", 35);
            list.Add(person1);
            Assert.IsFalse(list.Contains(person2), "Die Person sollte nicht in der Liste enthalten sein.");
        }

        [Test]
        public void CheckEmptyList_ShouldReturnFalse()
        {
            Person person = new Person("Sophie", "Meier", "Weiblich", 28);
            Assert.IsFalse(list.Contains(person), "Die leere Liste sollte keine Person enthalten.");
        }

        [Test]
        public void InsertMultiplePersons_ShouldContainAll()
        {
            Person person1 = new Person("Sophie", "Meier", "Weiblich", 28);
            Person person2 = new Person("Lukas", "Fischer", "Männlich", 35);
            Person person3 = new Person("Emma", "Schulz", "Weiblich", 19);
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person2 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person3), "Person3 sollte in der Liste enthalten sein.");
        }
    }
}