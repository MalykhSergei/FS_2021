using System;
using System.Collections.Generic;

namespace MergeSort
{
    class Sort
    {
        public static void MergeSort<T>(List<T> list, bool increase) where T : IComparable
        {
            Merge(list, 0, list.Count, increase);
        }

        private static void Merge<T>(List<T> list, int lowIndex, int highIndex, bool increase) where T : IComparable
        {
            int size = highIndex - lowIndex;

            if (size <= 1)
            {
                return;
            }

            int middleIndex = lowIndex + size / 2;

            Merge(list, lowIndex, middleIndex, increase);
            Merge(list, middleIndex, highIndex, increase);

            T[] array = new T[size];

            int i = lowIndex;
            int j = middleIndex;

            for (int k = 0; k < size; k++)
            {
                if (i == middleIndex)
                {
                    array[k] = list[j++];
                }
                else if (j == highIndex)
                {
                    array[k] = list[i++];
                }
                else if (Compare(list[j], list[i], increase))
                {
                    array[k] = list[j++];
                }
                else
                {
                    array[k] = list[i++];
                }
            }

            for (int k = 0; k < size; k++)
            {
                list[lowIndex + k] = array[k];
            }
        }

        private static bool Compare<T>(T data1, T data2, bool increase) where T : IComparable
        {
            if (increase)
            {
                return data1.CompareTo(data2) < 0;
            }

            return data2.CompareTo(data1) < 0;
        }
    }
}

