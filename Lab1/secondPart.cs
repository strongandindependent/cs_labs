using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, 5);
                }
            }


        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }




        public int ColsWithZerosCount()
        {
            int counter = 0;

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        counter ++;
                        continue;
                    }
                }
            }

            return counter;
        }

        public int GetMaxRepeatingNumber()
        {
            //int maxSeriesLen = 1;
            //int maxSeriesIdx = 0;

            int maxRepeatsCount = 1;
            int currentRepeatsCount = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        currentRepeatsCount++;
                    }
                    else
                    {
                        if (currentRepeatsCount > maxRepeatsCount)
                            maxRepeatsCount = currentRepeatsCount;

                        currentRepeatsCount = 1;
                    }
                }
            }

            //инженерное решение.
            return maxRepeatsCount + 1;
        }

    }
}
