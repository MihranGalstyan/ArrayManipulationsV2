using System;

namespace ArrayManipulationsV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintAssistant printer = new PrintAssistant();
            ArrayManager manager = new ArrayManager();

            int[,] array = manager.Create(3, 3, 10, 99);
            printer.Print("Here is your array!", array);

            int[] diagonal = manager.GetDiagonal(array);
            printer.Print("Here is your arrays Diagonal", diagonal);

            int maxDiagonal = manager.GetMax(diagonal);
            int minDiagonal = manager.GetMin(diagonal);

            int maxIndexDiag = manager.GetIndex(diagonal, maxDiagonal);
            int minIndexDiag = manager.GetIndex(diagonal, minDiagonal);

            printer.Print("Here is Maximum of diagonal!", maxDiagonal, maxIndexDiag);
            printer.Print("Here is Minimum of diagonal!", minDiagonal, minIndexDiag);

            int[] swappedDiagonal = manager.Swapp(diagonal, minDiagonal, maxDiagonal);
            printer.Print("Here is your swapped Diagonal", swappedDiagonal);

            int max2D = manager.GetMax(array);
            int min2D = manager.GetMin(array);

            int max2D_i = manager.GetIndexI(array, max2D);
            int max2D_j = manager.GetIndexJ(array, max2D);
            int min2D_i = manager.GetIndexI(array, min2D);
            int min2D_j = manager.GetIndexJ(array, min2D);

            printer.Print("Here is Maximum of array with index", max2D, max2D_i, max2D_j);
            Console.WriteLine();
            printer.Print("Here is Minimum of array with index", min2D, min2D_i, min2D_j);
        }

        public class PrintAssistant
        {
            /// <summary>
            /// Prints 2D array
            /// </summary>
            /// <param name="comment">Comment for array</param>
            /// <param name="array">Given array</param>
            public void Print(string comment, int[,] array)
            {
                Console.WriteLine($"{comment} \n");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]} ");
                    }
                    Console.WriteLine("\n");
                }
            }

            /// <summary>
            /// Prints arrays value and index
            /// </summary>
            /// <param name="comment">Comment for value</param>
            /// <param name="value">Given arrays value</param>
            /// <param name="index_i">Given higth index</param>
            /// <param name="index_j">Given width index</param>
            public void Print(string comment, int value, int index_i, int index_j)
            {
                Console.WriteLine($"{comment} [{index_i},{index_j}] {value}\n");
            }

            /// <summary>
            /// Prints 1D array
            /// </summary>
            /// <param name="comment">Comment for array</param>
            /// <param name="array">Given array</param>
            public void Print(string comment, int[] array)
            {
                Console.WriteLine($"{comment}\n");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }
                Console.WriteLine("\n");
            }

            /// <summary>
            /// Prints given value and index
            /// </summary>
            /// <param name="comment">Comment for value</param>
            /// <param name="value">Given value</param>
            /// <param name="index">Given index</param>
            public void Print(string comment, int value, int index)
            {
                Console.WriteLine($"{comment} [{index}] {value}\n");
            }
        }

        class ArrayManager
        {
            /// <summary>
            /// Creates 2D array
            /// </summary>
            /// <param name="hight">Hight of array</param>
            /// <param name="width">Width of array</param>
            /// <param name="lowerLimit">Lower limit of random numbers</param>
            /// <param name="upperLimit">Upper limit of random numbers</param>
            /// <returns>2D array</returns>
            public int[,] Create(int hight, int width, int lowerLimit, int upperLimit)
            {
                int[,] arr = new int[hight, width];
                Random rnd = new Random();
                for (int i = 0; i < hight; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        arr[i, j] = rnd.Next(lowerLimit, upperLimit);
                    }
                }
                return arr;
            }

            /// <summary>
            /// Finds given arrays Diagonal
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>1D array</returns>
            public int[] GetDiagonal(int[,] array)
            {
                int[] arrayDiag = new int[array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    arrayDiag[i] = array[i, i];
                }
                return arrayDiag;
            }

            /// <summary>
            /// Finds 2D arrays maximum value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Integer value</returns>
            public int GetMax(int[,] array)
            {
                int max = array[0, 0];
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    for (int j = 1; j < array.GetLength(1); j++)
                        if (array[i, j] > max)
                            max = array[i, j];
                }
                return max;
            }

            /// <summary>
            /// Finds 2D arrays minimum value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Integer value</returns>
            public int GetMin(int[,] array)
            {
                int min = array[0, 0];
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    for (int j = 1; j < array.GetLength(1); j++)
                        if (array[i, j] < min)
                            min = array[i, j];
                }
                return min;
            }

            /// <summary>
            /// Finds 1D arrays maximum value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Integer value</returns>
            public int GetMax(int[] array)
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                        max = array[i];
                }
                return max;
            }

            /// <summary>
            /// Finds 1D arrays minimum value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Integer value</returns>
            public int GetMin(int[] array)
            {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                        min = array[i];
                }
                return min;
            }

            /// <summary>
            /// Finds index of 1D arrays value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <param name="value">Given value</param>
            /// <returns>Integer</returns>
            public int GetIndex(int[] array, int value)
            {
                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == value)
                        index = i;
                }
                return index;
            }

            /// <summary>
            /// Finds "i" index of 2D arrays value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <param name="value">Given value</param>
            /// <returns>Integer</returns>
            public int GetIndexI(int[,] array, int value)
            {
                int index = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] == value)
                            index = i;
                }
                return index;
            }

            /// <summary>
            /// Finds "j" index of 2D arrays value
            /// </summary>
            /// <param name="array">Given array</param>
            /// <param name="value">Given value</param>
            /// <returns>Integer</returns>
            public int GetIndexJ(int[,] array, int value)
            {
                int index = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] == value)
                            index = j;
                }
                return index;
            }

            /// <summary>
            /// Swappes 1D arrays maximum and minimum values
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>1D array</returns>
            public int[] Swapp(int[] array, int min, int max)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == max)
                        array[i] = min;
                    else if (array[i] == min)
                        array[i] = max;
                }
                return array;
            }

            /// <summary>
            /// Swappes 2D arrays maximum and minimum values
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>1D array</returns>
            public int[,] Swapp(int[,] array, int min, int max)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] == max)
                            array[i, j] = min;
                        else if (array[i, j] == min)
                            array[i, j] = max;
                }
                return array;
            }
        }
    }
}
