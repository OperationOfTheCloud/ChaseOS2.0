using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
namespace ChaseOS2._0.Core
{
    
    public class Programming
    {
        public Programming()
        {

        }
        public string[] ParseProgram(string text)
        {
            string[] vs;
            if (text.StartsWith(" "))
            {

            } else
            {
                text = " " + text;
            }
            vs = text.Split(" ");
            return vs;
        }
    }
    public class InternalParse {
        
        public InternalParse()
        {

        }
        public void Program(string parseText)
        {
            Programming parser = new Programming();
            string[] commandsplit = parser.ParseProgram(parseText);
            Library libraries = new Library();
            try
            {

                libraries.Command(commandsplit);
            }
            catch
            {

            }
        }
        }
    public class Library
    {

        
        


        public Library()
        {
        }
        public void Command(string[] segment)
        {
            

            switch (segment[1])
            {
                case "print":
                    Console.WriteLine(segment[2]);
                    break;
                case "createfile":
                    Kernel.FileManager.CreateFile(segment[2]);
                    break;
                case "bsod":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine("Your computer ran into a problem, and the errorcode is");
                    Console.WriteLine(segment[2]);
                    Console.WriteLine("Restarting in 5 seconds...");
                    WaitSeconds(5);
                    Sys.Power.Reboot();
                    break;
                case "wait":
                    WaitSeconds(int.Parse(segment[2]));
                    break;
                case "nothing":
                    break;
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
