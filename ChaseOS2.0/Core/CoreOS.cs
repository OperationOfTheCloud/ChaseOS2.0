using Cosmos.Core;
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
using ChaseOS.Core;
using Cosmos.HAL;
using System.Net.Sockets;
using ChaseOS2._0;
namespace ChaseOS.Core
{
    class Commands
    {

        public string cddefault;
        public CosmosVFS FileManager;

        public Commands()
        {


            FileManager = Kernel.FileManager;
        cddefault = @"0:/";
            

        }

        public void ChaseOSRun()
        {
            try
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
                        }
                        // Wait for the user to respond before closing.

                        goto Begin;
                    } catch
                    {
                        Console.WriteLine("ERROR OCCURED. PLEASE TRY AGAIN");
                        goto Begin;
                    }
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
                        Console.WriteLine("This is a system file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            FileManager.CreateFile(filename);
                            goto Begin;
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
                        Console.WriteLine("This is a system file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            var filestream1 = file.GetFileStream();
                            Console.WriteLine("contents");
                            string contents1 = Console.ReadLine();
                            byte[] data1 = Encoding.ASCII.GetBytes(contents1);
                            filestream1.Write(data1, 0, (int)contents1.Length);
                            Console.WriteLine("file edited sucessfully");
                            goto Begin;
                        }
                        goto Begin;
                    }
                    var filestream = file.GetFileStream();
                    Console.WriteLine("contents");
                    string contents = Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(contents);
                    filestream.Write(data, 0, (int)contents.Length);
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
                        Console.WriteLine("This is a system file. Are you sure you want to do something with it? Y/N");
                        string con = Console.ReadLine();
                        if (con == "Y")
                        {
                            FileManager.DeleteFile(preprefilename2);
                            goto Begin;
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
                if (cmd == "ls")
                {
                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(@cddefault);
                    foreach (var directoryEntry in directory_list)
                    {
                        Console.WriteLine(directoryEntry.mName);
                    }
                    goto Begin;
                }
                if (cmd == "readfile")
                {
                    Console.WriteLine("filename?");
                    var prefile = Console.ReadLine();
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
    }
}
