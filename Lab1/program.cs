using System.Collections.Generic;
using System;
using First;

namespace First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Произведение четных: " + firstPart.Multiplication());
            Console.WriteLine("Сумма элементов, расположенных м/у первым и последним 0 эл-ми: " + firstPart.Sum());

            firstPart.Sort();
            Console.WriteLine("После сортировки по возрастанию:");
            PrintVector(firstPart.Vector);


            Console.WriteLine("Часть 2:");

            Console.Write("Введите размер массива: ");

            int size_1 = int.Parse(Console.ReadLine());
            int size_2 = int.Parse(Console.ReadLine());


            var secondPart = new SecondPart(size_1, size_2);
            PrintMatrix(secondPart.Matrix);


            var maxRepeating = secondPart.GetMaxRepeatingNumber();
            Console.WriteLine("Наибольшее повторяющееся количество: " + maxRepeating);

            Console.WriteLine("Столбцов с 0: " + secondPart.ColsWithZerosCount());

            Console.ReadKey();
        }

        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
