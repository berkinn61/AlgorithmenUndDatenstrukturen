using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Common;

namespace DataStructureTest
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        private DoubleLinkedList<Person> list;
        private Person alice;
        private Person bob;
        private Person charlie;

        [SetUp]
        public void SetUp()
        {
            list = new DoubleLinkedList<Person>();
            alice = new Person("Alice", "Keller", "w", 24);
            bob = new Person("Bob", "Meyer", "m", 31);
            charlie = new Person("Charlie", "Becker", "m", 27);
        }

        [Test]
        public void InsertAfter_WhenListIsEmpty_AddsFirstNode()
        {
            list.InsertAfter(alice, bob);
            Assert.IsNotNull(list);
        }

        [Test]
        public void InsertBefore_WhenListIsEmpty_AddsFirstNode()
        {
            list.InsertBefore(alice, bob);
            Assert.IsNotNull(list);
        }

        [Test]
        public void InsertAfter_WithSingleElement_AddsElementAfter()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            int posAlice = list.PosOfElement(alice);
            int posBob = list.PosOfElement(bob);
            Assert.AreEqual(0, posAlice);
            Assert.AreEqual(1, posBob);
        }

        [Test]
        public void InsertBefore_WithSingleElement_AddsElementBefore()
        {
            list.InsertAfter(alice, alice);
            list.InsertBefore(alice, bob);
            int posBob = list.PosOfElement(bob);
            int posAlice = list.PosOfElement(alice);
            Assert.AreEqual(0, posBob);
            Assert.AreEqual(1, posAlice);
        }

        [Test]
        public void InsertAfter_WithMultipleElements_InsertsInCorrectOrder()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            list.InsertAfter(bob, charlie);
            Assert.AreEqual(0, list.PosOfElement(alice));
            Assert.AreEqual(1, list.PosOfElement(bob));
            Assert.AreEqual(2, list.PosOfElement(charlie));
        }

        [Test]
        public void InsertBefore_WithMultipleElements_InsertsInCorrectOrder()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            list.InsertBefore(bob, charlie);
            Assert.AreEqual(0, list.PosOfElement(alice));
            Assert.AreEqual(1, list.PosOfElement(charlie));
            Assert.AreEqual(2, list.PosOfElement(bob));
        }

        [Test]
        public void InsertAfter_WhenReferenceNotFound_DoesNothing()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(bob, charlie);
            Assert.AreEqual(0, list.PosOfElement(alice));
            Assert.AreEqual(-1, list.PosOfElement(bob));
            Assert.AreEqual(-1, list.PosOfElement(charlie));
        }

        [Test]
        public void InsertBefore_WhenReferenceNotFound_DoesNothing()
        {
            list.InsertAfter(alice, alice);
            list.InsertBefore(bob, charlie);
            Assert.AreEqual(0, list.PosOfElement(alice));
            Assert.AreEqual(-1, list.PosOfElement(bob));
            Assert.AreEqual(-1, list.PosOfElement(charlie));
        }

        [Test]
        public void PosOfElement_WhenListIsEmpty_ReturnsMinusOne()
        {
            int position = list.PosOfElement(alice);
            Assert.AreEqual(-1, position);
        }

        [Test]
        public void PosOfElement_WhenElementExists_ReturnsCorrectIndex()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            list.InsertAfter(bob, charlie);
            Assert.AreEqual(0, list.PosOfElement(alice));
            Assert.AreEqual(1, list.PosOfElement(bob));
            Assert.AreEqual(2, list.PosOfElement(charlie));
        }

        [Test]
        public void PosOfElement_WhenElementNotInList_ReturnsMinusOne()
        {
            list.InsertAfter(alice, alice);
            int position = list.PosOfElement(bob);
            Assert.AreEqual(-1, position);
        }

        [Test]
        public void PosOfElement_WithDuplicateValues_ReturnsFirstMatch()
        {
            Person duplicateAlice = new Person("Alice", "Keller", "w", 24);
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            list.InsertAfter(bob, duplicateAlice);
            int position = list.PosOfElement(alice);
            Assert.AreEqual(0, position);
        }

        [Test]
        public void InsertBefore_ListIntegrity_RemainsValidAfterMultipleInserts()
        {
            list.InsertAfter(alice, alice);
            list.InsertAfter(alice, bob);
            list.InsertBefore(alice, charlie);
            var david = new Person("David", "Schneider", "m", 36);
            list.InsertBefore(bob, david);
            Assert.AreEqual(0, list.PosOfElement(charlie));
            Assert.AreEqual(1, list.PosOfElement(alice));
            Assert.AreEqual(2, list.PosOfElement(david));
            Assert.AreEqual(3, list.PosOfElement(bob));
        }
    }
}
