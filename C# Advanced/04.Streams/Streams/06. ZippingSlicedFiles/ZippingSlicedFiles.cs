namespace _06.ZippingSlicedFiles
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        const string SlicePath = "../../images.jpg";
        const string SliceDirectoryPath = "../../SliceDirectory/";
        const string AssembleDirectoryPath = "../../AssembleDirectory";
        public static void Main()
        {
            ChooseYourAction();
        }

        private static void ChooseYourAction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose your options:");
            Console.WriteLine("1 - for Slice a file");
            Console.WriteLine($"2 - for Assemble files");

            int number = 0;
            while (true)
            {
                try
                {
                    Console.Write($"Enter the digit of your choice: ");
                    number = int.Parse(Console.ReadLine());

                    if (number == 1 || number == 2)
                    {
                        Console.WriteLine();
                        break;
                    }

                    ErrorMasage("Wrong Number! Try again...");
                }
                catch
                {
                    ErrorMasage("Wrong Input! Try again...");
                }
            }

            switch (number)
            {
                case 1:
                    var directory = SlicePath.Substring(0, SlicePath.LastIndexOf('/'));

                    Console.Write("Enter number of parts: ");
                    var parts = 0;
                    while (true)
                    {

                        try
                        {
                            parts = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            ErrorMasage("Wrong Number!");
                            Console.Write("Enter number of parts: ");
                        }

                    }


                    if (IsFileExist(SlicePath))
                    {
                        Slice(SlicePath, AssembleDirectoryPath, parts);
                    }

                    break;

                case 2:
                    var files = new List<string>();

                    using (var writer = new StreamReader(SlicePath))
                    {
                        var dir = AssembleDirectoryPath;
                        files = Directory.GetFiles(dir).ToList();
                    }

                    if (files.Count == 0)
                    {
                        return;
                    }

                    Assemble(files);
                    break;
            }

        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            var extension = Path.GetExtension(sourceFile);

            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var partSize = reader.Length / parts + 1;

                for (int i = 1; i <= parts; i++)
                {
                    var outputFile = Path.Combine(destinationDirectory, $"Part {i}{extension}.gz");

                    using (var writer = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            var buffer = new byte[4096];

                            while (writer.Length < partSize)
                            {
                                var readBytes = reader.Read(buffer, 0, buffer.Length);

                                if (readBytes == 0)
                                {
                                    break;
                                }

                                compressionStream.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }

            OutputMasage("Slice is ready!");
        }

        private static void Assemble(List<string> files)
        {
            var extension = Path.GetExtension(files[0]);
            var outputFile = Path.Combine(SliceDirectoryPath, $"Assembled {DateTime.Now:dd-MM-yyyy - hh-mm-ss}{extension}");

            try
            {
                using (var writer = new FileStream(outputFile, FileMode.CreateNew))
                {
                    foreach (var file in files)
                    {
                        if (Path.GetExtension(file) != ".gz")
                        {
                            ErrorMasage("The following file is nog GZip and the operation cannot be completed.");
                            return;
                        }

                        try
                        {
                            using (var reader = new FileStream(file, FileMode.Open))
                            {
                                using (var decompressionStram = new GZipStream(reader, CompressionMode.Decompress, false))
                                {
                                    var buffer = new byte[4096];
                                    var readBytesCount = decompressionStram.Read(buffer, 0, buffer.Length);

                                    while (readBytesCount != 0)
                                    {
                                        writer.Write(buffer, 0, readBytesCount);
                                        readBytesCount = decompressionStram.Read(buffer, 0, buffer.Length);
                                    }
                                }
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            ErrorMasage($"File {file} cannot be found.{Environment.NewLine}The Assemble will be completed without this file.");
                        }
                    }
                }

                OutputMasage("Assamble is ready!");
            }
            catch (IOException)
            {
                ErrorMasage("No files to Assamble, first  Slice !");
                ChooseYourAction();
            }
        }

        private static void ErrorMasage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{error}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void OutputMasage(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = currentColor;
        }

        public static bool IsFileExist(string path)
        {
            if (!File.Exists(path))
            {
                ErrorMasage($"File doesn't exist! Put file in project directory with name images.jpg");
                return false;
            }

            return true;
        }
    }
}
