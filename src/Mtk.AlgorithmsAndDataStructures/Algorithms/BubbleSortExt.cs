using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms
{
    public static class BubbleSortExt
    {
        public static void BubbleSort<T>(this T[] input, IComparer<T> comparison = null)
        {
            var comparer = comparison ?? Comparer<T>.Default;

            bool isSorted = false;
            var lastUnsorted = input.Length - 1;
            while (!isSorted)
            {
                isSorted = true;
                for (var i = 0; i < lastUnsorted; i++)
                {
                    int result = comparer.Compare(input[i], input[i + 1]);
                    if (result <= 0)
                    {
                        continue;
                    }

                    isSorted = false;
                    var temp = input[i];
                    input[i] = input[i + 1];
                    input[i + 1] = temp;
                }

                lastUnsorted--;
            }
        }
    }
}
