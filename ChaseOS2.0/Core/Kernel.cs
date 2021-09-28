using ChaseOS2._0.ChaseGraphicsAPI;
using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;
using ChaseOS2._0.Core;

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
                if (FileManager.GetFile(@"0:\login.sys") != null && FileManager.GetFile(@"0:\loginData.sys") != null && FileManager.GetFile(@"0:\root.sys") != null && FileManager.GetFile(@"0:\rootData.sys") != null)
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
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 1/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 2/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 3/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 4/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 5/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 6/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 7/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 8/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 9/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome... 10/10 scripts loaded.");
                            WaitSeconds(1);
                            Console.Clear();
                            Console.WriteLine("Welcome. Loading...");
                            Console.WriteLine("Copyright ChaseOS2.0");
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
                        Console.WriteLine("Try it or install it or skip install?");
                        string a = Console.ReadLine();
                        try
                        {
                            if (a == "install")
                            {
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\login.sys");
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\loginData.sys");
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\root.sys");
                                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\rootData.sys");
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
                                Console.WriteLine("Setup your admin username:");
                                string user3 = Console.ReadLine();
                                Console.WriteLine("Setup your admin password:");
                                string password4 = Console.ReadLine();
                                Console.WriteLine("Preparing root...");
                                var file3 = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\root.sys");
                                var filestream4 = file3.GetFileStream();
                                string contents3 = @"" + user3 + "" + password4;
                                byte[] data4 = Encoding.ASCII.GetBytes(contents3);
                                filestream4.Write(data4, 0, (int)contents3.Length);
                                Console.WriteLine("Preparing root data...");
                                var file4 = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\rootData.sys");
                                var filestream5 = file4.GetFileStream();
                                string contents6 = @"" + user3.Length + "" + password4.Length;
                                byte[] data7 = Encoding.ASCII.GetBytes(contents6);
                                filestream5.Write(data7, 0, (int)contents6.Length);
                                Console.WriteLine("We are all setup! Now we just need to setup the computer.");
                                Console.WriteLine("This will take a few seconds...");

                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 1/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 2/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 3/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 4/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 5/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 6/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 7/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 8/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 9/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... 10/10 scripts loaded.");
                                WaitSeconds(1);
                                Console.Clear();
                                Console.WriteLine("Setting up... Loading...");
                                Sys.Power.Reboot();
                                break;
                            }
                            if (a == "skip")
                            {
                            Begin:

                                Console.Write("Time: " + DateTime.Now + " Path: " + cddefault + " ChaseOS>");
                                string cmd = Console.ReadLine();
                                if (cddefault.EndsWith(@"/"))
                                {

                                }
                                else
                                {
                                    cddefault = cddefault + @"/";
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
                                    Console.WriteLine(CPU.GetCPUCycleSpeed() + " GHz");
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
                                    Console.WriteLine("Version: 0.0.5, ChaseOS is an Operating system which is a small project, there is no gui design.");
                                    Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
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
                                                double bruh = Convert.ToInt32(Console.ReadLine()) / 100;
                                                Console.WriteLine("Number?");
                                                int nub = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine(bruh * nub);
                                                break;
                                        }
                                        // Wait for the user to respond before closing.

                                        goto Begin;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("ERROR OCCURED. PLEASE TRY AGAIN");
                                        goto Begin;
                                    }
                                }
                                if (cmd == "")
                                {
                                    goto Begin;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid cmd. Please try again. Type help for a list of commands.");
                                }
                                goto Begin;
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
                Console.Clear();
                Console.WriteLine("A system error has occured. This can potentially mean that you should reinstall ChaseOS.");
                Console.WriteLine(e);
                Console.WriteLine("Preparing automatic repair...");
                try
                {
                    var file1 = FileManager.GetFile(@"0:\loginData.sys");
                    FileManager.DeleteFile(file1);
                    var file2 = FileManager.GetFile(@"0:\login.sys");
                    FileManager.DeleteFile(file2);
                    Console.WriteLine("Repaired");
                } catch
                {
                    
                    Console.WriteLine("A system repair error has occured. This can potentially mean that you should reinstall ChaseOS.");
                    Console.WriteLine(e);
                }
                WaitSeconds(10);
                Sys.Power.Reboot();
            }
            Console.WriteLine("Loaded.");
            Console.WriteLine("Boot into graphical or non-graphical or code mode? G/N/C");
            string bootmode = Console.ReadLine();
            if (bootmode == "G")
            {
                gui = new Graphics();
            } else if (bootmode == "N")
            {

            } else
            {
                InternalParse internalParse= new InternalParse();
                Console.WriteLine("Welcome to the ChaseOS interpreter.");
                while (true)
                {
                    internalParse.Program(Console.ReadLine());
                }
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
