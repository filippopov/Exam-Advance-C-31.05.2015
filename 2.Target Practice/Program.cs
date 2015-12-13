using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Target_Practice
{
    class Program
    {
        private static char[,] matrix;

        private static string nameInput;

        private static int[] cordinats;

        static void Main(string[] args)
        {
            ReadFromConsole();
            FullMatrixWithLetters();
            ShootArea();
            MoveLetters();
            PrintMatrix();
        }

        private static void MoveLetters()
        {
            bool checker = false;

            while (!checker)
            {
                checker = true;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row + 1, col] == ' ' && matrix[row, col] != ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                            checker = false;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ShootArea()
        {
            int rowCordinats = cordinats[0];
            int colCordinats = cordinats[1];
            int radius = cordinats[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsInRadius(row, col, rowCordinats, colCordinats, radius))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static bool IsInRadius(int row, int col, int rowCordinats, int colCordinats, int radius)
        {
            int deltaRow = row - rowCordinats;
            int deltaCol = col - colCordinats;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= radius * radius;
            return isInRadius;
        }

        private static void FullMatrixWithLetters()
        {
            bool checkDirection = true;
            int counterLetter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (checkDirection)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = nameInput[counterLetter];
                        counterLetter++;
                        if (counterLetter > nameInput.Length - 1)
                        {
                            counterLetter = 0;
                        }
                    }
                    checkDirection = false;
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = nameInput[counterLetter];
                        counterLetter++;
                        if (counterLetter > nameInput.Length - 1)
                        {
                            counterLetter = 0;
                        }
                    }
                    checkDirection = true;
                }
            }
        }

        private static void ReadFromConsole()
        {
            string matrixInput = Console.ReadLine();
            nameInput = Console.ReadLine();
            cordinats =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] matrixData = matrixInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix = new char[matrixData[0], matrixData[1]];
        }
    }
}
