using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms
{
    public static class QuickSortExt
    {
        public static void QuickSort<T>(this T[] input, IComparer<T> comparison = null)
        {
            var comparer = comparison ?? Comparer<T>.Default;
            QuickSortImpl(input, 0, input.Length - 1, comparer);
        }

        private static void QuickSortImpl<T>(T[] arr, int from, int to, IComparer<T> comparer)
        {
            if (from >= to)
            {
                return;
            }

            int partitionIndex = MakePartition(arr, from, to, comparer);
            QuickSortImpl(arr, from, partitionIndex, comparer);
            QuickSortImpl(arr, partitionIndex + 1, to, comparer);
        }

        private static int MakePartition<T>(T[] arr, int from, int to, IComparer<T> comparer)
        {
            //get the most right element as a pivot
            var pivotIndex = to;
            var pivot = arr[pivotIndex];
            to--;

            while (from < to)
            {
                //in the left part: find the 1st item greater than pivot
                while (comparer.Compare(arr[from], pivot) == -1 && from < to)
                {
                    from++;
                }

                //in the right part: find the 1st item lower than pivot
                while (comparer.Compare(arr[to], pivot) == 1 && from < to)
                {
                    to--;
                }

                //swap
                var temp = arr[from];
                arr[from] = arr[to];
                arr[to] = temp;
            }

            //swap pivot and final item if pivot is lower than final item
            if (comparer.Compare(arr[from], pivot) == 1)
            {
                var temp = arr[from];
                arr[from] = arr[pivotIndex];
                arr[pivotIndex] = temp;
            }

            return from;
        }
    }
}
