using System.Collections.Generic;
using System.IO;

namespace MergeSort
{
    class DataIO
    {
        public static List<string> ReadFile(List<string> strings)
        {
            List<string> list = new List<string>();

            foreach (var item in strings)
            {
                using (StreamReader reader = new StreamReader(item))
                {
                    while (!reader.EndOfStream)
                    {
                        list.Add(reader.ReadLine());
                    }
                }
            }

            return list;
        }

        public static void WriteFile<T>(string fileNameOut, List<T> list)
        {
            using (StreamWriter writer = new StreamWriter(fileNameOut))
            {
                foreach (T e in list)
                {
                    writer.WriteLine(e);
                }
            }
        }
    }
}
