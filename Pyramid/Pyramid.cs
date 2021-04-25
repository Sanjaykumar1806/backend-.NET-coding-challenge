using System;

/*
 
    *
   ***
  *****
 *******
*********

ACCEPTANCE CRITERIA:
Write a script to output this pyramid on console (with leading spaces)

*/
namespace Pyramid
{
    public class Program
    {
        private static void Pyramid(int height)
        {
            if (height == 0)
            {
                Console.WriteLine($"Pyramid height cannot be {height}");
                return;
            }
            int rows, columns;
            for (rows = 1; rows <= height; rows++)
            {
                for (columns = 1; columns <= height - rows; columns++)
                    Console.Write(" ");
                for (columns = 1; columns <= 2 * rows - 1; columns++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Pyramid(5);
        }
    }
}