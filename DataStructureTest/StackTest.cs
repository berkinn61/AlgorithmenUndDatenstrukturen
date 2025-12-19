using NUnit.Framework;
using System;

namespace DataStructureTest
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void NewStack_IsEmpty_ShouldBeTrue()
        {
            var stack = new Stack<int>();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void Push_ThenPeek_ReturnsLastPushed()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.AreEqual(20, stack.Peek());
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void Pop_OnEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_OnEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void PushPop_LifoOrder_IsCorrect()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void Count_OnEmpty_IsZero()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Count());
        }

        [Test]
        public void Count_AfterPushes_IsCorrect()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);

            Assert.AreEqual(3, stack.Count());
        }

        [Test]
        public void Get_WithValidIndex_ReturnsCorrectElement()
        {
            // top -> 30 -> 20 -> 10
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.AreEqual(30, stack.Get(0));
            Assert.AreEqual(20, stack.Get(1));
            Assert.AreEqual(10, stack.Get(2));
        }

        [Test]
        public void Get_WithNegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => stack.Get(-1));
        }

        [Test]
        public void Get_WithTooLargeIndex_ThrowsArgumentOutOfRangeException()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => stack.Get(1));
        }

        [Test]
        public void Swap_SameIndex_DoesNothing()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Swap(1, 1);

            Assert.AreEqual(30, stack.Get(0));
            Assert.AreEqual(20, stack.Get(1));
            Assert.AreEqual(10, stack.Get(2));
        }

        [Test]
        public void Swap_ValidIndices_SwapsValues()
        {
            // top -> 3 -> 2 -> 1
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // swap top (index 0) with bottom (index 2): top -> 1 -> 2 -> 3
            stack.Swap(0, 2);

            Assert.AreEqual(1, stack.Get(0));
            Assert.AreEqual(2, stack.Get(1));
            Assert.AreEqual(3, stack.Get(2));
        }

        [Test]
        public void Swap_IndicesInReverseOrder_StillSwaps()
        {
            // top -> 3 -> 2 -> 1
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // reverse order indices should also work
            stack.Swap(2, 0);

            Assert.AreEqual(1, stack.Get(0));
            Assert.AreEqual(2, stack.Get(1));
            Assert.AreEqual(3, stack.Get(2));
        }

        [Test]
        public void Swap_IndexOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => stack.Swap(0, 5));
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.Swap(5, 0));
        }

        [Test]
        public void Pop_DecreasesCount()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count());
            stack.Pop();
            Assert.AreEqual(2, stack.Count());
            stack.Pop();
            Assert.AreEqual(1, stack.Count());
        }

        [Test]
        public void Peek_DoesNotRemoveElement()
        {
            var stack = new Stack<int>();
            stack.Push(100);
            stack.Push(200);

            Assert.AreEqual(200, stack.Peek());
            Assert.AreEqual(2, stack.Count());
            Assert.AreEqual(200, stack.Peek());
            Assert.AreEqual(2, stack.Count());
        }
    }
}
