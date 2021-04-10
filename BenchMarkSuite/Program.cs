using BenchmarkDotNet.Running;
using System;

namespace BenchMarkSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
