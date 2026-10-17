using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace C_Fundamentals.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(">> ");
                var input = Console.ReadLine().Trim();
                var whiteSpaceIndex = input.IndexOf(' ');
                var command = input.Substring(0, whiteSpaceIndex).ToLower();
                var path = input.Substring(whiteSpaceIndex + 1).Trim();

                if (command == "read")
                {
                    var content = File.ReadAllText(path);
                    Console.WriteLine(content);
                }
                else if (command == "write")
                {
                    Console.WriteLine("Enter content to write:");
                    var content = Console.ReadLine();
                    File.WriteAllText(path, content);
                    Console.WriteLine("Content written to file.");
                }
                else if (command == "append")
                {
                    Console.WriteLine("Enter content to append:");
                    var content = Console.ReadLine();
                    File.AppendAllText(path, content);
                    Console.WriteLine("Content appended to file.");
                }
                else if (command == "list")
                {
                    foreach (var entry in Directory.GetFileSystemEntries(path))
                    {
                        Console.WriteLine($"\t [Dir] {entry}");
                    }
                    foreach (var entry in Directory.GetFiles(path))
                    {
                        Console.WriteLine($"\t [Files] {entry}");
                    }

                }
                else if (command == "Info")
                {
                    if (Directory.Exists(path))
                    {
                        var dirInfo = new DirectoryInfo(path);
                        Console.WriteLine("Type : Directory");
                        Console.WriteLine($"Created At : {dirInfo.CreationTime}");
                        Console.WriteLine($"Last Modified At : {dirInfo.LastWriteTime}");
                    }
                    else if (File.Exists(path))
                    {
                        var fileInfo = new FileInfo(path); Console.WriteLine("Type : File");
                        Console.WriteLine($"Created At : {fileInfo.CreationTime}");
                        Console.WriteLine($"Last Modified At : {fileInfo.LastWriteTime}");
                        Console.WriteLine($"File Size in Bytes : {fileInfo.Length}");
                    }
                    else
                    {
                        Console.WriteLine("The specified path does not exist.");
                    }
                }
                else if (command == "mkdir")
                {
                    Directory.CreateDirectory(path);
                }
                else if (command == "remove")
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    else if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                    }
                    else
                    {
                        Console.WriteLine("The specified path does not exist.");
                    }
                }

                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command. Please use 'read', 'write', 'append', or 'exit'.");
                }
            }
        }
    }
}
