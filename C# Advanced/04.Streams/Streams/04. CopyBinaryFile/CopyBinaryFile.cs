namespace _04.CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        const string SorcePath = "../../djeri.jpg";
        const string DestinationPath = "../../Copied.jpg";

        public static void Main()
        {
            if (IsFileExists(SorcePath) && IsFileExists((DestinationPath)))
            {
                CopyImage();
            }
            else
            {
                ErrorMasage();
            }
        }
        
        private static void CopyImage()
        {
            Console.WriteLine("Start Coping...");

            using (var reader = new FileStream(SorcePath, FileMode.Open))
            {
                using (var writer = new FileStream(DestinationPath, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }

            OutputMasage();
        }

        private static void OutputMasage()
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            FileInfo path = new FileInfo(DestinationPath);
            string fullPath = path.FullName;
            Console.WriteLine("Files is Copied!");
            Console.WriteLine("Your full path is:");
            Console.WriteLine($"{fullPath}");
            Console.ForegroundColor = currentColor;
        }

        private static void ErrorMasage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Some of the files missing in your computer. Check folder for this files!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool IsFileExists(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }
    }
}
