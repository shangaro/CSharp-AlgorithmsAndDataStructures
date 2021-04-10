using System;

namespace CSharpAlgorithmAndDataStructure.Algorithms.Sorting
{
    public interface ISorting<T>
    {
        T[] Sort(T[] data);
    }
}