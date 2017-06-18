namespace _03.WordCount
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    public class WordCount
    {
        const string WordsPath = "../../words.txt";
        const string TextPath = "../../text.txt";
        const string ResultPath = "../../result.txt";

        public static void Main()
        {
            CreateFile(WordsPath);
            CreateFile(TextPath);
            CreateFile(ResultPath);

            InitializeFirstFile(WordsPath);
            InitializeSecondFile(TextPath);
            CheckCountOnWords(WordsPath, TextPath, ResultPath);
        }

        private static void CreateFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
        }

        private static void InitializeFirstFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("quick");
                writer.WriteLine("is");
                writer.WriteLine("fault");
            }
        }

        private static void InitializeSecondFile(string newPath)
        {
            using (var writer = new StreamWriter(newPath))
            {
                writer.WriteLine("-I was quick to judge him, but it wasn't his fault.");
                writer.WriteLine("-Is this some kind of joke?! Is it?");
                writer.WriteLine("-Quick, hide here…It is safer.");
            }
        }

        private static void CheckCountOnWords(string path, string newPath, string resultPath)
        {
            using (StreamReader firstreader = new StreamReader(path))
            {
                using (StreamReader secondReader = new StreamReader(newPath))
                {
                    var checkWords = new Dictionary<string, int>();
                    var word = firstreader.ReadLine();

                    while (word != null)
                    {
                        if (!checkWords.ContainsKey(word))
                        {
                            checkWords[word] = 0;
                        }

                        word = firstreader.ReadLine();
                    }

                    string textLine = secondReader.ReadLine();

                    while (textLine != null)
                    {
                        string[] text = textLine
                            .Split(new[] { ' ', ',', '`', '-', '_', '!', '?', '.', '|', '\\', '/', '\'', '"' },
                                StringSplitOptions.RemoveEmptyEntries);


                        for (int i = 0; i < text.Length; i++)
                        {
                            var currentWord = text[i].ToLower();

                            if (!checkWords.ContainsKey(currentWord))
                            {
                                continue;
                            }
                            else
                            {
                                checkWords[currentWord]++;
                            }
                        }

                        using (var writer = new StreamWriter(resultPath))
                        {
                            foreach (var checkWord in checkWords.OrderByDescending(x => x.Value))
                            {
                                writer.WriteLine($"{checkWord.Key} - {checkWord.Value}");
                            }
                        }

                        textLine = secondReader.ReadLine();
                    }
                }
            }
        }
    }
}
