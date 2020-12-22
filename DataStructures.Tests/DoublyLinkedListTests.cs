using CSharpAlgorithmAndDataStructure.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructures.Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void CreateEmptyList()
        {
            var ints = new DoublyLinkedList<int>();
            Assert.NotNull(ints);
            Assert.Empty(ints);
        }
        [Fact]
        public void AddHeadTest()
        {
            var ints = new DoublyLinkedList<int>();
            var expected = 5;
            for (int i = 1; i <= 5; i++)
            {
                ints.AddHead(i);
                Assert.Equal(i, ints.Count);
            }

            foreach (var item in ints)
            {
                Assert.Equal(expected--, item);
            }



        }

        [Fact]
        public void AddTailTest()
        {
            var ints = new DoublyLinkedList<int>();
            var expected = 1;
            for (int i = 1; i <= 5; i++)
            {
                ints.AddTail(i);
                Assert.Equal(i, ints.Count);
            }
            // test enumerator
            foreach (var item in ints)
            {
                Assert.Equal(expected++, item);
            }
        }

        [Fact]
        public void RemoveItemTest()
        {
            // For one item in the list
            var oneItemList = createList(1, 1);
            Assert.True(oneItemList.Remove(1));
            Assert.Empty(oneItemList);

            var ints = createList(1, 5);
            var success = ints.Remove(2);
            Assert.True(success);
            Assert.DoesNotContain(2, ints);

        }

        [Fact]
        public void GetHeadTest()
        {

            var emptyList = new DoublyLinkedList<int>();
            var success = emptyList.GetHead(out var h);
            Assert.False(success);
            Assert.Equal(0, h);


            var ints = createList(1, 5);
            success = ints.GetHead(out var head);
            Assert.True(success);
            Assert.Equal(1, head);
        }

        [Fact]
        public void GetTailTest()
        {

            var emptyList = new DoublyLinkedList<int>();
            var success = emptyList.GetTail(out var t);
            Assert.False(success);
            Assert.Equal(0, t);


            var ints = createList(1, 5);
            success = ints.GetTail(out var tail);
            Assert.True(success);
            Assert.Equal(5, tail);
        }

        private DoublyLinkedList<int> createList(int start, int end)
        {
            var ints = new DoublyLinkedList<int>();

            for (int i = start; i <= end; i++)
            {
                ints.AddTail(i);

            }
            return ints;
        }
    }
}
