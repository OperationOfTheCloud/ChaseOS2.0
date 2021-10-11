using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseOS2._0.Core
{
     class ArrowMode
{
        public static Commands commandSystem = new Commands();
        public static List<Tuple<string, string, int, int, int>> Choices = new List<Tuple<string, string, int, int, int>>();
        public ArrowMode() {
            Console.Clear();
            Choices.Add(new Tuple<string, string, int, int, int>("CMD", "DOS", 1, 1, 3));
            Choices.Add(new Tuple<string, string, int, int, int>("CALCULATOR", "CALC", 3, 1, 10));
        }
    public void GO()
        {
            foreach (Tuple<string, string, int, int, int> cord in Choices)
            {
                Console.SetCursorPosition(cord.Item3, cord.Item4);
                Console.WriteLine(cord.Item1);
            }
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    Mode();
                    Console.SetCursorPosition(0, 0);
                }
            }
        }
        public static void Mode()
        {
            string mod = "";
            foreach (Tuple<string, string, int, int, int> choice in Choices)
            {
                if (Console.CursorTop == choice.Item4 && Console.CursorLeft >= choice.Item3)
                {
                    mod = choice.Item2;
                }
            }
            switch (mod)
            {
                case "DOS":
                    commandSystem.ChaseOSRun();
                    break;
                case "CALC":

                        // Declare variables and then initialize to zero.
                        int num1 = 0; int num2 = 0;

                        // Display title as the C# console calculator app.
                        Console.WriteLine("Welcome to the ChaseOS calculator\r");
                        Console.WriteLine("------------------------\n");

                        // Ask the user to type the first number.
                        Console.WriteLine("Type a number, and then press Enter");


                        // Ask the user to choose an option.
                        Console.WriteLine("Choose an option from the following list:");
                        Console.WriteLine("\ta - Add");
                        Console.WriteLine("\ts - Subtract");
                        Console.WriteLine("\tm - Multiply");
                        Console.WriteLine("\td - Divide");
                        Console.WriteLine("\tsq - Square");
                        Console.WriteLine("\tsqr - Square root");
                        Console.Write("Which option do you want to do? ");

                        // Use a switch statement to do the math.
                        switch (Console.ReadLine())
                        {
                            case "a":
                                Console.WriteLine("Enter a number");
                                num1 = Convert.ToInt32(Console.ReadLine());
                                // Ask the user to type the second number.
                                Console.WriteLine("Type another number, and then press Enter");
                                num2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                                break;
                            case "s":
                                Console.WriteLine("Enter a number");
                                num1 = Convert.ToInt32(Console.ReadLine());

                                // Ask the user to type the second number.
                                Console.WriteLine("Type another number, and then press Enter");
                                num2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                                break;
                            case "m":
                                Console.WriteLine("Enter a number");
                                num1 = Convert.ToInt32(Console.ReadLine());

                                // Ask the user to type the second number.
                                Console.WriteLine("Type another number, and then press Enter");
                                num2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                                break;
                            case "d":
                                Console.WriteLine("Enter a number");
                                num1 = Convert.ToInt32(Console.ReadLine());

                                // Ask the user to type the second number.
                                Console.WriteLine("Type another number, and then press Enter");
                                num2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                                break;
                            case "sq":
                                Console.WriteLine("What number to square?");
                                num1 = Convert.ToInt32(Console.ReadLine());
                                // Ask the user to type the second number.
                                Console.WriteLine($"Your result: " + num1 + " * " + num1 + " = " + (num1 * num1));
                                break;
                            case "sqr":
                                Console.WriteLine("What number to find the square root of?");
                                num1 = Convert.ToInt32(Console.ReadLine());
                                double hi = Math.Sqrt(num1);
                                Console.WriteLine($"Your result: " + hi);
                                break;
                            case "per":
                                Console.WriteLine("Percent?");
                                double bruh = Convert.ToInt32(Console.ReadLine()) / 100;
                                Console.WriteLine("Number?");
                                int nub = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(bruh * nub);
                                break;
                        }
                        // Wait for the user to respond before closing.

                        break;
                    }

        }
}
}
