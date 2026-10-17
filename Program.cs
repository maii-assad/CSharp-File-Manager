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

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                input = input.Trim();

                var whiteSpaceIndex = input.IndexOf(' ');

                var command = whiteSpaceIndex == -1
                    ? input.ToLower()
                    : input.Substring(0, whiteSpaceIndex).ToLower();

                var path = whiteSpaceIndex == -1
                    ? ""
                    : input.Substring(whiteSpaceIndex + 1).Trim();

                if (command == "read")
                {
                    try
                    {
                        var content = File.ReadAllText(path);
                        Console.WriteLine(content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (command == "write")
                {
                    try
                    {
                        Console.WriteLine("Enter content to write:");
                        var content = Console.ReadLine() ?? "";

                        File.WriteAllText(path, content);

                        Console.WriteLine("Content written to file.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (command == "append")
                {
                    try
                    {
                        Console.WriteLine("Enter content to append:");
                        var content = Console.ReadLine() ?? "";

                        File.AppendAllText(path, content);

                        Console.WriteLine("Content appended to file.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (command == "remove")
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        Console.WriteLine("File deleted successfully.");
                    }
                    else if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                        Console.WriteLine("Directory deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("The specified path does not exist.");
                    }
                }
                else if (command == "info")
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
                    try
                    {
                        Directory.CreateDirectory(path);
                        Console.WriteLine("Directory created successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (command == "remove")
                {
                    try
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            Console.WriteLine("File deleted successfully.");
                        }
                        else if (Directory.Exists(path))
                        {
                            Directory.Delete(path);
                            Console.WriteLine("Directory deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("The specified path does not exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
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
