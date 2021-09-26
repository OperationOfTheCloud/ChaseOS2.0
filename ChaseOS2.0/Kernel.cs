using ChaseOS2._0.ChaseGraphicsAPI;
using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;
using ChaseOS.Core;

namespace ChaseOS2._0
{
    public class Kernel : Sys.Kernel
    {


        public string cddefault;
        public bool login;
        public bool driveCon;
        public static CosmosVFS FileManager = new Sys.FileSystem.CosmosVFS();
        public static Graphics gui;
        private static Commands OS;
        protected override void BeforeRun()
        {
            try
            {
                Console.WriteLine("Welcome to ChaseOS 2.0, a revamp of ChaseOS");
                Console.WriteLine("Preparing...");
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileManager);
                Console.WriteLine("Welcome.");
                Sys.PCSpeaker.Beep();
            }
            catch
            {

            }

            cddefault = @"0:\";

            try
            {
                int shutdown = 0;
                if (FileManager.GetFile(@"0:\login.sys") != null && FileManager.GetFile(@"0:\loginData.sys") != null)
                {
                    var thing = FileManager.GetFile(@"0:\login.sys");
                    var thingr = FileManager.GetFile(@"0:\loginData.sys");
                    var check = thing.GetFileStream();

                    byte[] dataread1 = new byte[1];
                    byte[] dataread2 = new byte[1];
                    var datastream1 = thingr.GetFileStream();
                    datastream1.Read(dataread1, 0, 1);
                    datastream1.Read(dataread2, 0, 1);
                    int data1 = Convert.ToInt32(Encoding.Default.GetString(dataread1));
                    int data2 = Convert.ToInt32(Encoding.Default.GetString(dataread2));
                    byte[] buffer = new byte[data1];
                    string UsernameReal = "";





                    check.Read(buffer, 0, (data1));
                    UsernameReal = Encoding.Default.GetString(buffer);

                    string pass;
                    byte[] passWordReal = new byte[data2];
                    check.Read(passWordReal, 0, (data2));
                    pass = Encoding.Default.GetString(passWordReal);
                    check.Close();

                    while (login == false)
                    {
                        Console.WriteLine("Username?");
                        string user = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string password = Console.ReadLine();
                        if (user == UsernameReal && password == pass)
                        {
                            login = true;
                            Console.WriteLine("Welcome " + user);
                        }
                        else
                        {
                            Console.WriteLine("The username or password you entered is incorrect, try again");
                            shutdown += 1;
                            if (shutdown == 6)
                            {
                                Console.WriteLine("Failed to login more than 6 times...");
                                WaitSeconds(5);
                                Sys.Power.Shutdown();
                            }
                        }

                    }

                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Try it or install it?");
                        string a = Console.ReadLine();
                        try
                        {
                            if (a == "install")
                            {
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\login.sys");
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\loginData.sys");
                                Console.WriteLine("Welcome to Chase OS! Lets get some things started.");
                                Console.WriteLine("Setup your username:");

                                string user = Console.ReadLine();
                                Console.WriteLine("Setup password for login:");
                                string password = Console.ReadLine();
                                Console.WriteLine("Preparing...");
                                var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\login.sys");
                                var filestream = file.GetFileStream();
                                string contents = @"" + user + "" + password;
                                byte[] data = Encoding.ASCII.GetBytes(contents);
                                filestream.Write(data, 0, (int)contents.Length);
                                Console.WriteLine("Preparing first boot...");
                                var file2 = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\loginData.sys");
                                var filestream2 = file2.GetFileStream();
                                string contents2 = @"" + user.Length + "" + password.Length;
                                byte[] data2 = Encoding.ASCII.GetBytes(contents2);
                                filestream2.Write(data2, 0, (int)contents2.Length);
                                break;
                            }
                            if (a == "try")
                            {
                                while (true)
                                {
                                A:
                                    try
                                    {
                                        Console.Write("ChaseOS>");
                                        string cmd = Console.ReadLine();


                                        if (cmd == "graphics")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "reese")
                                        {
                                            goto A;
                                        }
                                        if (cmd == "checkram")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "checkcycles")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }

                                        if (cmd == "checkuptime")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "checkvendorname")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "clear")
                                        {
                                            Console.Clear();
                                            goto A;
                                        }
                                        if (cmd == "shutdown")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "quickformat")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "format")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "restart")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "help")
                                        {
                                            Console.WriteLine("cmds: version, calc, readfile, ls, createfile, editfile, deletefile, help, createdirectory, removedirectory, cd, cdfullpath, time, settings, pwd, graphics, clear, setdrive, quickformat, format");
                                            goto A;
                                        }
                                        if (cmd == "pwd")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "version")
                                        {
                                            Console.WriteLine("Version: 21.0, ChaseOS is an Operating system which is a small project, there is no gui design.");
                                            Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
                                            goto A;
                                        }
                                        if (cmd == "createdirectory")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "cd")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "cdfullpath")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "time")
                                        {
                                            Console.WriteLine(DateTime.Now);
                                            goto A;
                                        }
                                        if (cmd == "echo")
                                        {
                                            Console.WriteLine("Text?");
                                            string text = Console.ReadLine();
                                            Console.WriteLine(text);
                                            goto A;
                                        }
                                        if (cmd == "settings")
                                        {
                                            Console.WriteLine("What color for text color?");
                                            string color = Console.ReadLine();
                                            if (color.ToLower() == "blue")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                            }
                                            if (color.ToLower() == "red")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                            }
                                            if (color.ToLower() == "yellow")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                            }
                                            if (color.ToLower() == "green")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            }
                                            if (color.ToLower() == "black")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Black;
                                            }
                                            if (color.ToLower() == "blue")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                            }
                                            if (color.ToLower() == "cyan")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                            }
                                            if (color.ToLower() == "darkblue")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            }
                                            if (color.ToLower() == "darkred")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                            }
                                            if (color.ToLower() == "darkyellow")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            }
                                            if (color.ToLower() == "gray")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                            }
                                            if (color.ToLower() == "magenta")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                            }
                                            if (color.ToLower() == "white")
                                            {
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            goto A;
                                        }
                                        if (cmd == "calc")
                                        {
                                        B:
                                            try
                                            {
                                                // Declare variables and then initialize to zero.
                                                int num1; int num2;

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
                                                        num1 = (Convert.ToInt32(Console.ReadLine()));
                                                        // Ask the user to type the second number.
                                                        Console.WriteLine("Type another number, and then press Enter");
                                                        num2 = (Convert.ToInt32(Console.ReadLine()));
                                                        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                                                        break;
                                                    case "s":
                                                        Console.WriteLine("Enter a number");
                                                        num1 = (Convert.ToInt32(Console.ReadLine()));
                                                        // Ask the user to type the second number.
                                                        Console.WriteLine("Type another number, and then press Enter");
                                                        num2 = (Convert.ToInt32(Console.ReadLine()));
                                                        Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                                                        break;
                                                    case "m":
                                                        Console.WriteLine("Enter a number");
                                                        num1 = (Convert.ToInt32(Console.ReadLine()));
                                                        // Ask the user to type the second number.
                                                        Console.WriteLine("Type another number, and then press Enter");
                                                        num2 = (Convert.ToInt32(Console.ReadLine()));
                                                        Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                                                        break;
                                                    case "d":
                                                        Console.WriteLine("Enter a number");
                                                        num1 = (Convert.ToInt32(Console.ReadLine()));
                                                        // Ask the user to type the second number.
                                                        Console.WriteLine("Type another number, and then press Enter");
                                                        num2 = (Convert.ToInt32(Console.ReadLine()));
                                                        Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                                                        break;
                                                    case "sq":
                                                        Console.WriteLine("What number to square?");
                                                        num1 = (Convert.ToInt32(Console.ReadLine()));
                                                        // Ask the user to type the second number.
                                                        Console.WriteLine($"Your result: " + num1 + " * " + num1 + " = " + (num1 * num1));
                                                        break;

                                                }
                                                // Wait for the user to respond before closing.

                                                goto A;
                                                // bruh
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Something went wrong, try again");
                                                goto B;
                                            }
                                        }
                                        if (cmd == "removedirectory")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                        }
                                        if (cmd == "createfile")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                        }
                                        if (cmd == "editfile")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "deletefile")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "copy")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "box")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                        }
                                        if (cmd == "ls")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "readfile")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "setdrive")
                                        {
                                            Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                            goto A;
                                        }
                                        if (cmd == "")
                                        {
                                            goto A;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid cmd. Please try again. Type help for a list of commands.");
                                        }


                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("An error has occured.");
                                        Console.WriteLine(e);

                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("The input " + a + " is not valid");
                            return;
                        }
                    }
                }

                Console.WriteLine("Loading ChaseOS2.0 ...");
                OS = new Commands();
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("The error '" + e + "' occured on startup, attempting to contine with os, some features will be broken due to this.");
                Console.ReadLine();
                Run();
            }
            Console.WriteLine("Loaded.");
            Console.WriteLine("Boot into graphical or non-graphical mode? G/N");
            string bootmode = Console.ReadLine();
            if (bootmode == "G")
            {
                gui = new Graphics();
            }
        }
        protected override void Run()
        {
            if (Kernel.gui != null)
            {
                Kernel.gui.MouseHandler();
                return;
            }
            try
            {
                OS.ChaseOSRun();
            }
            catch (Exception e)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("A system error has occured. This can potentially mean that you should reinstall ChaseOS.");
                Console.WriteLine(e);
                Console.WriteLine("Restarting in 10 seconds...");
                WaitSeconds(10);
                Sys.Power.Reboot();
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
