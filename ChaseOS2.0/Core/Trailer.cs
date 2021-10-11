using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseOS2._0
{
    public class Trailer
{
        public Trailer()
        {
            
            
        }
        public static void Run()
        {
            Console.Clear();
            TypeLetters("Hi there! Welcome to ChaseOS. Before you get started, lets show you some of the features!");
            Console.Clear();
            TypeLetters("Lets start off with the new and improved editor! I will show you what it looks like.");
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 80; i++) Console.Write(" ");
            Console.SetCursorPosition(0, 0);
            Console.Write("ChaseOS Notepad - " + "ChaseOSRocks.txt" + "\n");
            for (int i = 0; i < 80; i++) Console.Write("_");
            Console.SetCursorPosition(0, 1);
            Console.Write("Press ESC to exit.");
            Console.SetCursorPosition(0, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            int xint = Console.CursorLeft;
            int yint = Console.CursorTop;
            string tosav = "";
            Console.Write(tosav);

            
                TypeLetters("This is the ChaseOS Notepad!");

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            TypeLetters("We also have a graphical mode, code mode, a filesystem, a calculator, an appstore, and optimized experience so you can get more done.");
            Console.Clear();
            TypeLetters("But we will leave those for you to try out. Hopefully you enjoy your experience using this operating system!");
            Console.Clear();
            TypeLetters("Now that you have seen all the features, we can get back to the setup.");
            Console.Clear();
        }
        public static void TypeLetters(string type)
        {
            foreach (char c in type)
            {
                Console.Write(c);
                DelayInMS(50);
            }
            WaitSeconds(5);
            Console.Write("\n");
        }
        public static void DelayInMS(int ms) // Stops the code for milliseconds and then resumes it (Basically It's delay)
        {
            for (int i = 0; i < ms * 100000; i++)
            {
                ;
                ;
                ;
                ;
                ;
            }
        }
        public static void WaitSeconds(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                // Loop round
            }
        }
    }
}
