using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using CSharpAlgorithmAndDataStructure.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarkSuite
{
    [SimpleJob(RunStrategy.ColdStart, targetCount: -1, id: "SortingAlgorithTimeComplexityJob")]
    //[MinColumn, Q1Column, Q3Column, MaxColumn]
    public class TimeComplexityTest
    {
        private int[] randomArray = TestUtils.RandomArray(1000);
        private int[] randomArrayBig = TestUtils.RandomArray(100000);
        public int[] data = new int[] { 4, 3, 2, 1 };  
        [Benchmark]
        public int[] SortByBubble()
        {
            var sut = new BubbleSort<int>();
            return sut.Sort(randomArray);

        }
        [Benchmark]
        public int[] SortByBubbleHugeData()
        {
            var sut = new BubbleSort<int>();
            return sut.Sort(randomArrayBig);

        }
        [Benchmark]
        public int[] SortByInsertion()
        {
            var sut = new InsertionSort<int>();
            return sut.Sort(randomArray);

        }
        [Benchmark]
        public int[] SortByInsertionHugeData()
        {
            var sut = new InsertionSort<int>();
            return sut.Sort(randomArrayBig);

        }
        [Benchmark]
        public int[] SortByQuickSort()
        {
            var sut = new QuickSort<int>();
            return sut.Sort(randomArray);

        }
        [Benchmark]
        public int[] SortByQuickSortHugeData()
        {
            var sut = new QuickSort<int>();
            return sut.Sort(randomArrayBig);

        }
    }
}
