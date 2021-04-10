using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithmAndDataStructure.Algorithms.Sorting
{
    public class InsertionSort<T> : SortingMetrics<T> where T : IComparable<T>
    {
        public override T[] MetricSort(T[] data)
        {
            for(int i = 1; i < data.Length; i++)
            {
               if(GreaterThan(data, i-1, i))
                {
                    for(int p = i; p > 0; p--)
                    {
                        if (GreaterThan(data, p - 1, p))
                        {
                            Swap(data, p - 1, p);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return data;
        }
    }
}
