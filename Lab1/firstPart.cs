using First;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class FirstPart
    {
        private readonly int[] array;
        private List<int> list;


        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 2);
            }

            list = array.ToList();
        }

        public FirstPart(int[] arr)
        {
            array = arr;
            list = arr.ToList();
        }



        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }

        public IReadOnlyList<int> List
        {
            get
            {
                return list;
            }
        }

        public int[] Arr { get; }



        public int Sum()
        {
            int c1 = 0;
            int c2 = array.Length - 1;
            int p = 0;

            while (c1 < array.Length && array[c1] != 0)
            {
                c1++;
            }
            while (c2 > 0 && array[c2] != 0)
            {
                c2--;
           }

            int sum = 0;
            for (int i = c1; i < c2; i++)
            {
                sum += array[i];
            }
            return sum;
        }


        public void Sort()
        {
            var comparer = new DescendingComparer();
            Array.Sort(array, comparer);
        }


        public int Multiplication()
        {
            int p = 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    p *= array[i];
                }
            }

            return p;
        }
    }
}
