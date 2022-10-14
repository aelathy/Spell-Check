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

            if (menuOption == "1")
            {
                // LinearSearch()
            }
            else if (menuOption == "2")
            {
                Stopwatch stopwatch = new Stopwatch();
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
            else if (menuOption == "4")
            {
                Stopwatch stopwatch = new Stopwatch();
                Console.Write("Please enter the word you're looking for: ");
                string aliceBSearch = Console.ReadLine();
                stopwatch.Start();
                if (binarySearch(aliceWords, aliceBSearch) > -1)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"{aliceBSearch} found at position: {binarySearch(aliceWords, aliceBSearch)} (time: {stopwatch.Elapsed})");
                }
                else
                {
                    Console.WriteLine($"{aliceBSearch} not found in Alice in Wonderland.");
                }
            }
            else if (menuOption == "5")
            {
                break;
            }


        }
    }

    static int binarySearch<T>(IList<T> aList, T item) where T : IComparable
    {
        var lIndex = 0;
        var hIndex = aList.Count - 1;

        while (lIndex < hIndex)
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

    public static void printStringArray(String[] array, int start, int stop)
    {
        // Print out array elements at index values from start to stop 
        for (int i = start; i < stop; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

}
