using CSharpAlgorithmAndDataStructure.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructures.Tests
{
    public class SortedItemListTests
    {
        /// <summary>
        /// Add items in descending order and tests if sortedlist is in ascending order
        /// </summary>
        [Fact]
        public void AddTest()
        {
            var expected = 1;
            var ints = new SortedItemList<int>();
            for (int i = 5, j = 1; i >= 1; i--, j++)
            {
                ints.Add(i);
                Assert.Equal(j, ints.Count);
            }

            foreach (var item in ints)
            {
                Assert.Equal(expected++, item);
            }

        }

        /// <summary>
        /// Removes an item from the list and rearrange the list successfully
        /// </summary>
        [Fact]
        public void RemoveItem()
        {
            var ints = new SortedItemList<int> { 5, 4, 4, 3, 2, 1 };
            var success = ints.Remove(4);
            Assert.True(success);
            Assert.Equal(5, ints.Count);

        }

        /// <summary>
        /// Tests whether the given node exists
        /// </summary>
        [Fact]
        public void FindNodeTest()
        {

            var ints = new SortedItemList<int> { 5, 4, 3, 2, 1 };
            var result = ints.FindNode(4);

            Assert.NotNull(result);
            Assert.Equal(4, result.data);
        }


    }
}
