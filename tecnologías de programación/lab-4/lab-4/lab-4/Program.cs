using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите полный путь к файлу или интернет-ссылку:");
        string path = Console.ReadLine();

        
        ProcessPath(path);
    }

    static void ProcessPath(string path)
    {
        
        string[] folders = path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);


        bool isUrl = path.StartsWith("http://") || path.StartsWith("ftp://");
        int startIndex = isUrl ? 1 : 0; //для URL пропускаем протокол

        var foldersWithDigits = folders
            .Skip(startIndex)
            .Where(f => f.Any(char.IsDigit))
            .ToList();

        Console.WriteLine($"1. Количество папок с цифрами в именах: {foldersWithDigits.Count}");

        for (int i = startIndex; i < folders.Length; i++)
        {
            folders[i] = ReplaceDigitsWithLetters(folders[i]);
        }

        Console.WriteLine($"2. Путь после замены цифр: {string.Join("/", folders)}");

        if (folders.Length > startIndex + 1)
        {
            string firstFolder = folders[startIndex];
            string lastFolder = folders[folders.Length - 1];

            folders[startIndex] = lastFolder;
            folders[folders.Length - 1] = firstFolder;
        }

        Console.WriteLine($"3. Путь после замены первой и последней папки: {string.Join("/", folders)}");

        var foldersEndingWithUnderscore = folders
            .Skip(startIndex)
            .Where(f => f.EndsWith("_"))
            .ToList();

        Console.WriteLine("4. Папки, заканчивающиеся на символ '_':");
        foreach (var folder in foldersEndingWithUnderscore)
        {
            Console.WriteLine($"   - {folder}");
        }
    }

    static string ReplaceDigitsWithLetters(string input)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                // Заменяем цифры на буквы: 0->A, 1->B, ..., 9->J
                char replacement = (char)('A' + (c - '0'));
                result.Append(replacement);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}