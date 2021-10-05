using System;
using System.Collections.Generic;
using System.Text;
using ChaseOS2._0.Apps;
using Cosmos.Core;
namespace ChaseOS2._0.Apps
{
    
    public class AppHandler
{
        
        public AppHandler()
        {
            
        }
        public void FindApp(string appname)
        {
            switch (appname)
            {
                case "guessinggame":
                    Console.WriteLine("Guess the number 1-10");
                    Random random = new Random();
                    int randnum = random.Next(1, 10);
                    string guess = Console.ReadLine();
                    if (int.Parse(guess) == randnum)
                    {
                        Console.WriteLine("You guessed the number!");
                    } else
                    {
                        Console.WriteLine("Incorrect. The number was "+randnum);
                    }
                    break;
                case "pcchecker":
                    Console.WriteLine("RAM MB: " + CPU.GetAmountOfRAM());
                    Console.WriteLine("CPU Cycle Speed: "+CPU.GetCPUCycleSpeed());
                    break;
            }
        }
        
}
}
