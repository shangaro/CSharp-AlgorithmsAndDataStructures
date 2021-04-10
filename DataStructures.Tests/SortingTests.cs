using CSharpAlgorithmAndDataStructure.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructures.Tests
{
    public class SortingTests
    {
        public static IEnumerable<object[]> SortTestData = new List<object[]>
        {
            new object[]{ new int[] {4,2,3,1 }, new int[] { 1,2,3,4} },
            new object[]{new int[] {6,5,5,3,10}, new int[] {3,5,5,6,10}}
        };
        [Theory]
        [MemberData(nameof(SortTestData))]
        public void BubbleSortTest(int[] arr, int[] expected)
        {
            var sut = new BubbleSort<int>();
            var result = sut.Sort(arr);
            Assert.Equal(expected, result);
        }
        [Theory]
        [MemberData(nameof(SortTestData))]
        public void InsertionSortTest(int[] arr, int[] expected)
        {
            var sut = new InsertionSort<int>();
            var result = sut.Sort(arr);
            Assert.Equal(expected, result);
        }
        [Theory]
        [MemberData(nameof(SortTestData))]
        public void QuickSort(int[] arr, int[] expected)
        {
            var sut = new QuickSort<int>();
            var result = sut.Sort(arr);
            Assert.Equal(expected, result);
        }
    }
}
