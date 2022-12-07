// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

#nullable disable

using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;


class Program
{
    public static void Main(string[] args)
    {
        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");

        // Print first 50 values of each list to verify contents
        Console.WriteLine("***DICTIONARY***");
        printStringArray(dictionary, 0, 50);

        Console.WriteLine("***ALICE WORDS***");
        printStringArray(aliceWords, 0, 50);

        bool loop = true;
        while (loop)
        {
            // Main Menu
            Console.WriteLine("\n Main Menu");
            Console.WriteLine("1: Spell Check a Word (Linear Search");
            Console.WriteLine("2: Spell Check a Word (Binary Search)");
            Console.WriteLine("3: Spell Check Alice in Wonderland (Linear Search)");
            Console.WriteLine("4: Spell Check Alice in WonderLand (Binary Search)");
            Console.WriteLine("5: Exit");
            Console.Write("Please enter a numerical menu option: ");
            string menuOption = Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();



            if (menuOption == "1")
            {
                // LinearSearch()
                Console.Write("Please enter the word you are looking for: ");
                string dictionaryLSearch = Console.ReadLine();
                stopwatch.Start();
                if (linearSearch(dictionary, dictionaryLSearch) > -1)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"{dictionaryLSearch} found at position: {linearSearch(dictionary, dictionaryLSearch)} (time : {stopwatch.Elapsed})");
                }
                else
                {
                    Console.WriteLine($"{dictionaryLSearch} not found in the dictionary. ");
                }
            }
            else if (menuOption == "2")
            {
                Console.Write("PLease enter the word you are looking for: ");
                string dictionaryBSearch = Console.ReadLine();
                stopwatch.Start();
                if (binarySearch(dictionary, dictionaryBSearch) > -1)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"{dictionaryBSearch} found at position: {binarySearch(dictionary, dictionaryBSearch)} (time: {stopwatch.Elapsed})");
                }
                else
                {
                    Console.WriteLine($"{dictionaryBSearch} not found in the dictionary.");
                }
            }
            else if (menuOption == "3")
            {
                stopwatch.Start();
                int notFound = 0;
                for (int i = 0; i < aliceWords.Length; i++)
                {
                    int search = linearSearch(dictionary, aliceWords[i].ToLower());
                    if (search == -1)
                    {
                        notFound++;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Number of words not found in dictionary: {notFound} ({stopwatch.Elapsed} seconds)");
            }
            else if (menuOption == "4")
            {
                stopwatch.Start();
                int notFound = 0;
                foreach (string w in aliceWords)
                {
                    int search = binarySearch(dictionary, w.ToLower());
                    if (search == -1)
                    {
                        notFound++;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Number of words not found in dictionary: {notFound} ({stopwatch.Elapsed} seconds)");
            }
            else if (menuOption == "5")
            {
                break;
            }
        }
    }

    static int linearSearch<T>(IList<T> aList, T item) where T : IComparable
    {
        int index = -1;
        foreach (T element in aList)
        {
            index++;
            if (element.Equals(item))
            {
                return index;
            }
        }
        return -1;
    }

    static int binarySearch<T>(IList<T> aList, T item) where T : IComparable
    {
        var lIndex = 0;
        var hIndex = aList.Count - 1;

        while (lIndex <= hIndex)
        {
            var mIndex = (int)Math.Floor(((lIndex + hIndex) / 2.0));
            var compare = item.CompareTo(aList[mIndex]);
            if (compare == 0)
            {
                return mIndex;
            }
            else if (compare == -1)
            {
                hIndex = mIndex - 1;
            }
            else
            {
                lIndex = mIndex + 1;
            }
        }
        return -1;

    }

    static int bubbleSort<T>(IList<T> aList) where T : IComparable
    {
        for (int i = 0; i < aList.Count - 1; i++)
        {
            for (int j = 0; j < aList.Count - (i + 1); j++)
            {
                int compare = aList[j].CompareTo(aList[j + 1]);
                if (compare == 1)
                {
                    T chng = aList[j + 1];
                    aList[j + 1] = aList[j];
                    aList[j] = chng;
                }
            }
        }
        return -1;
    }

    public static void printStringArray(String[] array, int start, int stop)
    {
        // Print out array elements at index values from start to stop 
        for (int i = start; i < stop; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

}
