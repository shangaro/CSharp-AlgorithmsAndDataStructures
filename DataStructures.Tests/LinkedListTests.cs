using CSharpAlgorithmAndDataStructure.DataStructures;
using System;
using System.Collections;
using Xunit;

namespace DataStructures.Tests
{

    public class LinkedListTests
    {

        [Fact]
        public void InitializeEmptyTest()
        {
            var ints = new LinkedList<int>();
            Assert.Empty(ints);
        }
        [Fact]
        public void AddHeadTest()
        {
            var expected = 5;
            var ints = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddHead(i);
                Assert.Equal(i, ints.Count);
            }
            foreach (var x in ints)
            {
                Assert.Equal(expected--, x);
            }
        }
        /// <summary>
        /// Add to the tail of the linked list
        /// </summary>
        [Fact]
        public void AddTailTest()
        {
            var expected = 1;
            var ints = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddTail(i);
                Assert.Equal(i, ints.Count);
            }
            foreach (var x in ints)
            {
                Assert.Equal(expected++, x);
            }
        }

        [Fact]
        public void RemoveTest()
        {
            var ints = create(1, 5);
            var removed = ints.Remove(2);
            Assert.True(removed);
            // see if removing 2 second time returns false
            Assert.False(ints.Remove(2));


        }


        private LinkedList<int> create(int start, int end)
        {
            var ints = new LinkedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.AddTail(i);
            }
            return ints;
        }
    }
}
