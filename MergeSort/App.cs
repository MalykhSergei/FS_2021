using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MergeSort
{
    class App
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<string> argsList = new List<string>(args);

            if (argsList.Count == 0)
            {
                Console.WriteLine("You did not enter arguments! For help, type: -help");

                Console.ReadKey();
                return;
            }

            if (argsList[0] == "-help")
            {
                Console.WriteLine("You must enter two or one options, name output file and names input files");
                Console.WriteLine("You can enter the folowing options: ");
                Console.WriteLine();
                Console.WriteLine("-a -i or -i for ascending sort numbers");
                Console.WriteLine("-d -i for descending sort numbers");
                Console.WriteLine("-a -s or -s for ascending sort strings");
                Console.WriteLine("-d -s for descending sort strings");

                Console.ReadKey();
                return;
            }

            if (argsList[0] == "-i" || argsList[0] == "-s")
            {
                argsList.Insert(0, "-a");
            }

            if (argsList.Count < 4)
            {
                Console.WriteLine("You must enter at least four arguments! For help, type: -help");
                Console.ReadKey();
                return;
            }

            bool increase = argsList[0].Equals("-a");
            bool decrease = argsList[0].Equals("-d");
            bool numbers = argsList[1].Equals("-i");
            bool strings = argsList[1].Equals("-s");

            if (!increase && !decrease)
            {
                Console.WriteLine("The data type specified by the arguments: -a for for ascending sort or -d for descending sort. For help, type: -help");
                Console.ReadKey();
                return;
            }

            List<string> inputFilesList = new List<string>();

            for (int i = 3; i < argsList.Count; i++)
            {
                inputFilesList.Add(argsList[i]);
            }

            try
            {
                inputFilesList = DataIO.ReadFile(inputFilesList);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found! Check files: {string.Join(", ", inputFilesList)}");
                Console.ReadKey();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Files read error!");
                Console.ReadKey();
                return;
            }

            if (numbers)
            {
                try
                {
                    List<int> numbersList = inputFilesList.ConvertAll(Convert.ToInt32);

                    Sort.MergeSort(numbersList, increase);

                    inputFilesList = numbersList.ConvertAll(Convert.ToString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("It is impossible to convert the data into the number");
                    Console.ReadKey();
                    return;
                }
            }
            else if (strings)
            {
                Sort.MergeSort(inputFilesList, increase);
            }
            else
            {
                Console.WriteLine("The data type specified by the arguments: -i for numbers and -s for strings. For help, type: -help");
                Console.ReadKey();
                return;
            }

            try
            {
                DataIO.WriteFile(argsList[2], inputFilesList);
            }
            catch (Exception)
            {
                Console.WriteLine($"File write error {argsList[2]}");
                Console.ReadKey();
                return;
            }
        }
    }
}
