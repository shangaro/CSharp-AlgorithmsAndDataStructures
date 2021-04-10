using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarkSuite
{
    public static class TestUtils
    {
        
        public static int[] RandomArray(int length)
        {
            var rng = new Random();
            int[] data = new int[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rng.Next();
            }

            return data;
        }
    }
}
