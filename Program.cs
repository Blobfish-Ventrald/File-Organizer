using System;
using System.IO;

namespace FileOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Organizer");

            Console.Write("Enter The Path To Organize : ");
            string directoryPath = Console.ReadLine();

            if (Directory.Exists(directoryPath))
            {
                OrganizeFiles(directoryPath);
                Console.WriteLine("Files have been organized.");
            }
            else
            {
                Console.WriteLine("The directory does not exist.");
            }
        }

        static void OrganizeFiles(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                try
                {
                    string fileExtension = Path.GetExtension(file).TrimStart('.');
                    string folderName = string.IsNullOrEmpty(fileExtension) ? "No Extension" : fileExtension;
                    string newFolderPath = Path.Combine(directoryPath, folderName);
                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                    }
                    string newFilePath = Path.Combine(newFolderPath, Path.GetFileName(file));
                    File.Move(file, newFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error file '{file}': {ex.Message}");
                }
            }
        }
    }
}
