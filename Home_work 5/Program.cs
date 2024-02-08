using System.Text.RegularExpressions;
using System.Text;

namespace Home_work_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Введите строку текста:");
            string input = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nМеню выбора действий:");
                Console.WriteLine("1. Найти слова, содержащие максимальное количество цифр.");
                Console.WriteLine("2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.");
                Console.WriteLine("3. Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».");
                Console.WriteLine("4. Выйти из программы.");
                Console.Write("Выберите действие (1-4): ");
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindWordsWithMaxDigits(input);
                        break;

                    case "2":
                        FindLongestWordAndOccurrences(input);
                        break;

                    case "3":
                        input = ReplaceDigitsWithWords(input);
                        Console.WriteLine($"Цифры успешно заменены на слова. Итоговая строка {input}");

                        break;

                    case "4":
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 4.");
                        break;
                }
            }
        }

        static void FindWordsWithMaxDigits(string input)
        {
            string[] words = input.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int maxDigitCount = 0;
            List<string> maxDigitWords = new List<string>();

            foreach (string word in words)
            {
                int digitCount = Regex.Matches(word, @"\d").Count;
                if (digitCount > maxDigitCount)
                {
                    maxDigitCount = digitCount;
                    maxDigitWords.Clear();
                    maxDigitWords.Add(word);
                }
                else if (digitCount == maxDigitCount)
                {
                    maxDigitWords.Add(word);
                }
            }

            Console.WriteLine($"Слова с максимальным количеством цифр ({maxDigitCount}):");
            foreach (string word in maxDigitWords)
            {
                if (maxDigitWords == null)
                {
                    Console.WriteLine("Таких слов нет.");
                }
                else
                {
                    Console.WriteLine(word);
                }

            }
        }

        static void FindLongestWordAndOccurrences(string input)
        {
            string[] words = input.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            int maxWordLength = 0;
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (word.Length > maxWordLength)
                {
                    maxWordLength = word.Length;
                    longestWord = word;
                }

                if (wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences[word]++;
                }
                else
                {
                    wordOccurrences[word] = 1;
                }
            }

            Console.WriteLine($"Самое длинное слово: {longestWord}");
            Console.WriteLine($"В тексте всретилось {wordOccurrences[longestWord]} раз.");
        }

        static string ReplaceDigitsWithWords(string input)
        {
            string[] digitWords = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

            for (int i = 0; i <= 9; i++)
            {
                input = input.Replace(i.ToString(), digitWords[i]);
            }

            return input;
        }



    }
}

