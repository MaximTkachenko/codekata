using System;
using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms
{
    public static class InsertionSortExt
    {
        public static void InsertionSort<T>(this T[] input, IComparer<T> comparison = null)
        {
            var comparer = comparison ?? Comparer<T>.Default;
            for (int indexToSort = 1; indexToSort < input.Length; indexToSort++)
            {
                var current = input[indexToSort];
                var indexToInsert = -1;
                for (int i = 0; i < indexToSort; i++)
                {
                    //find 1st item in sorted part which is greater than current
                    if (comparer.Compare(current, input[i]) == -1)
                    {
                        indexToInsert = i;
                        break;
                    }
                }

                if (indexToInsert == -1)
                {
                    continue;
                }

                var temp = input[indexToSort];
                //move sorted part to free position to insert for current item
                Array.Copy(input, indexToInsert, input, indexToInsert + 1, indexToSort - indexToInsert);
                input[indexToInsert] = temp;
            }
        }
    }
}
