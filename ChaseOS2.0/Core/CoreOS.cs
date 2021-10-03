﻿using Cosmos.Core;
using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.Drawing;
using Cosmos.System.Graphics;
using ChaseOS2._0.ChaseGraphicsAPI;
using Cosmos.Core;
using System.Threading;
using ChaseOS2._0.Core;
using Cosmos.HAL;
using System.Net.Sockets;
using ChaseOS2._0;
using ChaseOS2._0.Core;
namespace ChaseOS2._0.Core
{
    class Commands
    {

        public string cddefault;
        public CosmosVFS FileManager;
        public string rootUser;
        public string rootPass;
        public static bool admin;
        public static bool adminScript;
        public static string globalVar;
        public static bool bootAnimation;
        public static bool systemReserved;
        public InternalParse internalParse = new InternalParse();
        public Commands()
        {

            systemReserved = true;
            FileManager = Kernel.FileManager;
        cddefault = @"0:/";
            var thing = FileManager.GetFile(@"0:\root.sys");
            var thingr = FileManager.GetFile(@"0:\rootData.sys");
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
            rootPass = pass;
            rootUser = UsernameReal;

        }

        public void ChaseOSRun()
        {
            try
            {
            Begin:
                if (bootAnimation == true)
                {
                    Console.Write("Time: " + DateTime.Now + " Path: " + cddefault + " ChaseOS>");
                } else
                {
                    string start = "Time: " + DateTime.Now + " Path: " + cddefault + " ChaseOS>";
                    string Pre = "";
                    foreach (char c in start)
                    {
                        string character = c.ToString();
                        Pre = Pre + character;
                        
                        Console.Write(Pre);
                        DelayInMS(250);
                        Console.Clear();
                    }
                    Console.Write(start);
                    bootAnimation = true;
                }
                string cmd = Console.ReadLine();
                if (cddefault.EndsWith(@"/"))
                {

                }
                else
                {
                    cddefault = cddefault + @"/";
                }
                if (cmd == "runfile")
                {
                    Console.WriteLine("File?");
                    string prefile = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    string script = Encoding.Default.GetString(data);
                    string[] commands = script.Split("\n");
                    foreach (string command in commands)
                    {
                        internalParse.Program(command);
                    }
                }
                if  (cmd == "admin")
                {
                    if (admin == false)
                    {
                        bool login = false;
                        while (login == false)
                        {
                            Console.WriteLine("Username?");
                            string user = Console.ReadLine();
                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();
                            if (user == rootUser && password == rootPass)
                            {
                                login = true;
                                Console.WriteLine("Welcome " + user);
                                admin = true;
                            }
                            else
                            {
                                Console.WriteLine("The username or password you entered is incorrect, try again");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("You are already admin!");
                    }
                    goto Begin;
                    }
                if (cmd == "reese")
                {
                    goto Begin;
                }
                if (cmd == "checkram")
                {
                    Console.WriteLine(CPU.GetAmountOfRAM() + " MB");
                    goto Begin;
                }
                if (cmd == "checkcycles")
                {
                    Console.WriteLine(CPU.GetCPUCycleSpeed() / 100000000000 + " GHz");
                    goto Begin;
                }

                if (cmd == "checkuptime")
                {
                    Console.WriteLine(CPU.GetCPUUptime());
                    goto Begin;
                }
                if (cmd == "checkvendorname")
                {
                    Console.WriteLine(CPU.GetCPUVendorName());
                    goto Begin;
                }
                if (cmd == "clear")
                {
                    Console.Clear();
                    goto Begin;
                }
                if (cmd == "shutdown")
                {
                    Sys.Power.Shutdown();
                    goto Begin;
                }
                if (cmd == "quickformat")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveId = Console.ReadLine();
                    FileManager.Format(driveId, "FAT32", true);
                    goto Begin;
                }
                if (cmd == "format")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveId = Console.ReadLine();
                    FileManager.Format(driveId, "FAT32", false);
                    goto Begin;
                }
                if (cmd == "restart")
                {
                    Sys.Power.Reboot();
                    goto Begin;
                }
                if (cmd == "help")
                {
                    Console.WriteLine("cmds: version, calc, readfile, ls, createfile, editfile, deletefile, help, createdirectory, removedirectory, cd, cdfullpath, time, settings, pwd, graphics, clear, setdrive, quickformat, format");
                    goto Begin;
                }
                if (cmd == "pwd")
                {
                    Console.WriteLine(cddefault);
                    goto Begin;
                }
                if (cmd == "version")
                {
                    Console.WriteLine("Version: 21.0, ChaseOS is an Operating system which is a small project, there is no gui design.");
                    Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
                    goto Begin;
                }
                if (cmd == "createdirectory")
                {
                    Console.WriteLine("directory name?");
                    string prefolder = Console.ReadLine();
                    FileManager.CreateDirectory(@cddefault + prefolder);
                    Console.WriteLine("Directory created.");
                    goto Begin;
                }
                if (cmd == "cd")
                {
                    Console.WriteLine("Path to get to?");
                    string precd = Console.ReadLine();
                    cddefault = @cddefault + precd;
                    Console.WriteLine("Now in path directory");
                    goto Begin;
                }
                if (cmd == "cdfullpath")
                {
                    Console.WriteLine("full path?");
                    string predest = Console.ReadLine();
                    cddefault = @predest;
                    goto Begin;
                }
                if (cmd == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString());
                    goto Begin;
                }
                if (cmd == "echo")
                {
                    Console.WriteLine("Text?");
                    string text = Console.ReadLine();
                    Console.WriteLine(text);
                    goto Begin;
                }
                if (cmd == "settings")
                {
                    string setting;
                    Console.WriteLine("What setting to adjust?");
                    Console.WriteLine("1.) text color \n2.) background color \n3.) memory dump 4.) choose to hide system files");
                    setting = Console.ReadLine();
                    if (setting == "text color")
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
                        goto Begin;
                    }
                    if (setting == "background color")
                    {
                        string bgc;
                        Console.WriteLine("What color to set the background as?");
                        bgc = Console.ReadLine();
                        if (bgc == "blue")
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Clear();
                        }
                        if (bgc == "red")
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                        }
                        if (bgc == "yellow")
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                        }
                        if (bgc == "green")
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Clear();
                        }
                        if (bgc == "black")
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                        }
                        if (bgc == "cyan")
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Clear();
                        }
                        if (bgc == "darkblue")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Clear();
                        }
                        if (bgc == "darkred")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Clear();
                        }
                        if (bgc == "darkyellow")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Clear();
                        }
                        if (bgc == "gray")
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Clear();
                        }
                        if (bgc == "magenta")
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Clear();
                        }
                        if (bgc == "white")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                        }
                        goto Begin;
                    }
                    if (setting == "memory dump")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Console.WriteLine("All memory contents: ");
                        Console.WriteLine(cmd + cddefault + FileManager);
                        Console.WriteLine("Restarting in 15 seconds...");
                        WaitSeconds(15);
                        Sys.Power.Reboot();
                    }
                    if (setting == "choose to hide system files")
                    {
                        Console.WriteLine("Should this feature be on? Y/N");
                        string yn = Console.ReadLine();
                        if (yn == "Y")
                        {
                            systemReserved = true;
                        }
                    }
                }
                if (cmd == "calc")
                {
                    try
                    {
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
                                double bruh = Convert.ToInt32(Console.ReadLine())/100;
                                Console.WriteLine("Number?");
                                int nub = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(bruh * nub);
                                break;
                        }
                        // Wait for the user to respond before closing.

                        goto Begin;
                    } catch
                    {
                        Console.WriteLine("ERROR OCCURED. PLEASE TRY AGAIN");
                        goto Begin;
                    }
                }
                if (cmd == "rainbow")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Clear();
                }
                if (cmd == "removedirectory")
                {
                    Console.WriteLine("Directory?");
                    string predir = Console.ReadLine();
                    FileManager.DeleteDirectory(FileManager.GetDirectory(@cddefault + predir));
                    Console.WriteLine("The directory " + predir + " was removed succesfully");
                    goto Begin;
                }
                if (cmd == "createfile")
                {
                    Console.WriteLine("filename?");
                    string filename = Console.ReadLine();

                    if (filename.EndsWith(".sys"))
                    {
                        Console.WriteLine("This is a system or protected file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            if (admin == true)
                            {
                                FileManager.CreateFile(filename);
                                goto Begin;
                            }
                            else
                            {
                                Console.WriteLine("You must be an admin to do this action.");
                            }
                        }
                        goto Begin;
                    }
                    FileManager.CreateFile(filename);
                    goto Begin;
                }
                if (cmd == "editfile")
                {
                    Console.WriteLine("filename?");
                    string filename1 = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename1);
                    if (filename1.EndsWith(".sys"))
                    {
                        Console.WriteLine("This is a system or protected file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            if (admin == true)
                            {
                                var filestream231 = file.GetFileStream();
                                Console.WriteLine("contents");
                                string contents231 = Console.ReadLine();
                                byte[] data231 = Encoding.ASCII.GetBytes(contents231);
                                string newLine31 = "\n";
                                byte[] data331 = Encoding.ASCII.GetBytes("\n");
                                var file21 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename1).GetFileStream();
                                byte[] data1 = new byte[file21.Length];
                                file21.Read(data1, 0, (int)file21.Length);
                                string script1 = Encoding.Default.GetString(data1);
                                filestream231.Write(data331, 0, (int)newLine31.Length);

                                filestream231.Write(data231, 0, (int)contents231.Length);
                                Console.WriteLine("file edited sucessfully");
                                goto Begin;
                            }
                            else
                            {
                                Console.WriteLine("You must be an admin to do this action.");
                            }
                        }
                        goto Begin;
                    }

                    var filestream23 = file.GetFileStream();
                    Console.WriteLine("contents");
                    string contents23 = Console.ReadLine();
                    byte[] data23 = Encoding.ASCII.GetBytes(contents23);
                    string newLine3 = "\n";
                    byte[] data33 = Encoding.ASCII.GetBytes("\n");
                    var file2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename1).GetFileStream();
                    byte[] data = new byte[file2.Length];
                    file2.Read(data, 0, (int)file2.Length);
                    string script = Encoding.Default.GetString(data);
                    filestream23.Write(data33, 0, (int)newLine3.Length);

                    filestream23.Write(data23, 0, (int)contents23.Length);
                    Console.WriteLine("file edited sucessfully");
                    goto Begin;
                }
                if (cmd == "deletefile")
                {
                    Console.WriteLine("Enter the name of the file");
                    string prefilename2 = Console.ReadLine();
                    var preprefilename2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefilename2);
                    if (prefilename2.EndsWith(".sys"))
                    {
                        Console.WriteLine("This is a system or protected file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            if (admin == true)
                            {
                                var preprefilename3 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefilename2);

                                FileManager.DeleteFile(preprefilename3);
                                goto Begin;
                            }
                            else
                            {
                                Console.WriteLine("You must be an admin to do this action.");
                            }
                        }
                        goto Begin;
                    }

                    FileManager.DeleteFile(preprefilename2);
                    Console.WriteLine("The file " + prefilename2 + " has been deleted");

                    goto Begin;
                }
                if (cmd == "copy")
                {
                    Console.WriteLine("filename of file to copy");
                    var prefile = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    string content = Encoding.Default.GetString(data);

                    if (prefile.EndsWith(".sys"))
                    {
                        Console.WriteLine("This is a system or protected file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            if (admin == true)
                            {

                                string filename2 = Console.ReadLine();
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@cddefault + filename2);
                                var filenew2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename2);
                                var filestream2 = filenew2.GetFileStream();
                                byte[] data12 = Encoding.ASCII.GetBytes(content);
                                filestream2.Write(data12, 0, (int)content.Length);


                                Console.WriteLine("file copied succesfully");
                                goto Begin;
                            }
                            else
                            {
                                Console.WriteLine("You must be an admin to do this action.");
                            }
                        }
                        goto Begin;
                    }

                    Console.WriteLine("filename of the new file");
                    string filename = Console.ReadLine();
                    Sys.FileSystem.VFS.VFSManager.CreateFile(@cddefault + filename);
                    var filenew = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename);
                    var filestream = filenew.GetFileStream();
                    byte[] data1 = Encoding.ASCII.GetBytes(content);
                    filestream.Write(data, 0, (int)content.Length);
                    
                    
                    Console.WriteLine("file copied succesfully");
                    goto Begin;
                }
                if (cmd == "box")
                {
                    ChaseOS2._0.ChaseGraphicsAPI.Graphics.THE = true;
                    goto Begin;
                }
                if (cmd == "chasecode")
                {

                    Console.WriteLine("Welcome to the ChaseOS interpreter. Enter a line of code.");
                    internalParse.Program(Console.ReadLine());
                    goto Begin;
                }
                if (cmd == "chase")
                {
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(294);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(196, 500);
                    Sys.PCSpeaker.Beep(220, 250);
                    Sys.PCSpeaker.Beep(221);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(196);
                    Sys.PCSpeaker.Beep(392, 250);
                    Sys.PCSpeaker.Beep(392);
                    Sys.PCSpeaker.Beep(294, 500);
                    Sys.PCSpeaker.Beep(220, 250);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(294);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(196, 500);
                    Sys.PCSpeaker.Beep(220, 250);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(247);
                    Sys.PCSpeaker.Beep(262);
                    Sys.PCSpeaker.Beep(220);
                    Sys.PCSpeaker.Beep(196);
                    Sys.PCSpeaker.Beep(294);
                    Sys.PCSpeaker.Beep(294);
                    Sys.PCSpeaker.Beep(294);
                    Sys.PCSpeaker.Beep(330);
                    Sys.PCSpeaker.Beep(294, 500);
                    goto Begin;
                }
                if (cmd == "ls")
                {
                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(@cddefault);
                    if (admin == false)
                    {
                        foreach (var directoryEntry in directory_list)
                        {
                            if (directoryEntry.mName.EndsWith(".hid"))
                            {
                                Console.WriteLine("[THIS FILE CAN ONLY BE VIEWED BY AN ADMIN]");
                            }
                            else
                            {
                                Console.WriteLine(directoryEntry.mName);
                            }
                        }
                    } else
                    {
                        foreach (var directoryEntry in directory_list)
                        {
                            {
                                Console.WriteLine(directoryEntry.mName);
                            }
                        }
                    }
                    goto Begin;
                }
                if (cmd == "readfile")
                {
                    Console.WriteLine("filename?");
                    var prefile = Console.ReadLine();
                    if (prefile.EndsWith(".sys"))
                    {
                        Console.WriteLine("This is a system or protected file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            if (admin == true)
                            {

                                var file2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                                byte[] data2 = new byte[file2.Length];
                                file2.Read(data2, 0, (int)file2.Length);
                                Console.WriteLine(Encoding.Default.GetString(data2));
                                goto Begin;
                            }
                            else
                            {
                                Console.WriteLine("You must be an admin to do this action.");
                            }
                        }
                        goto Begin;
                    }

                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    Console.WriteLine(Encoding.Default.GetString(data));
                    goto Begin;
                }
                if (cmd == "setdrive")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveid = Console.ReadLine();
                    bool validDrive = FileManager.IsValidDriveId(driveid);
                    if (validDrive)
                    {
                        Console.WriteLine("Warning: Drive can be corrupted when changes are made to the drive. Continue? Y/N");
                        string confirm = Console.ReadLine();
                        if (confirm == "Y")
                        {
                            cddefault = driveid;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The drive name you entered is invalid.");
                    }
                    goto Begin;
                }
                if (cmd == "")
                {
                    goto Begin;
                }
                else
                {
                    Console.WriteLine("Invalid cmd. Please try again. Type help for a list of commands.");
                }


            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("Your computer ran into a problem, and the errorcode is");
                Console.WriteLine(e);
                Console.WriteLine("Restarting in 5 seconds...");
                WaitSeconds(5);
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
        void DelayInMS(int ms) // Stops the code for milliseconds and then resumes it (Basically It's delay)
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
    }
}
