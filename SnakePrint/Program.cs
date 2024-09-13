using System;
using System.Linq;

namespace SnakePrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start:
            while (true)
            {
             
                
                    Console.WriteLine("Enter the array dimension:");
                    int n = int.Parse(Console.ReadLine());

                    EnterArray:
                    try { 
                    Console.WriteLine("Enter comma-separated integers:");
                    int[] array = Console.ReadLine()
                                         .Split(',')
                                         .Select(s => int.Parse(s.Trim()))
                                         .ToArray();

                    int[,] twoDArray = new int[n, n];
                    for (int i = 0; i < n * n; i++)
                    {
                        twoDArray[i / n, i % n] = i < array.Length ? array[i] : 0;
                    }

                    Console.WriteLine("Snake Pattern:");
                    for (int i = 0; i < n; i++)
                    {
                        if (i % 2 == 0)
                        {
                            for (int j = 0; j < n; j++)
                                Console.Write(twoDArray[i, j] + " ");
                        }
                        else
                        {
                            for (int j = n - 1; j >= 0; j--)
                                Console.Write(twoDArray[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                    goto EnterArray;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine("Do you want to input another array? (y/n)");
                string continueInput = Console.ReadLine();
                if (continueInput?.ToLower() != "y")
                {
                   
                    break;
                }
            }
        }
    }
}
