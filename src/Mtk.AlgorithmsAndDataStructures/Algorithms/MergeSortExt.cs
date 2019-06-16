using System;
using System.Buffers;
using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms
{
    public static class MergeSortExt
    {
        public static void MergeSort<T>(this T[] input, IComparer<T> comparison = null)
        {
            var comparer = comparison ?? Comparer<T>.Default;

            //optimize memory allocation of temporary array
            var temp = ArrayPool<T>.Shared.Rent(input.Length);
            try
            {
                MergeSortImpl(input, temp, 0, input.Length - 1, comparer);
            }
            finally
            {
                ArrayPool<T>.Shared.Return(temp);
            }
        }

        private static void MergeSortImpl<T>(T[] array, T[] temp, int from, int to, IComparer<T> comparer)
        {
            if (from >= to)
            {
                return;
            }

            var middle = (to + from) / 2;
            var leftFrom = from;
            var leftTo = middle;
            var rightFrom = leftTo + 1;
            var rightTo = to;

            MergeSortImpl(array, temp, leftFrom, leftTo, comparer);
            MergeSortImpl(array, temp, rightFrom, rightTo, comparer);
            MergeHalves(array, temp, leftFrom, leftTo, rightFrom, rightTo, comparer);
        }

        private static void MergeHalves<T>(T[] array, T[] temp, int leftFrom, int leftTo, int rightFrom, int rightTo, IComparer<T> comparer)
        {
            int leftIndex = leftFrom;
            int rightIndex = rightFrom;
            int index = leftFrom;

            while (index <= rightTo)
            {
                //left part is finished, copy data from right part
                if (leftIndex > leftTo)
                {
                    temp[index] = array[rightIndex];
                    rightIndex++;
                    index++;
                    continue;
                }

                //right part is finished, copy data from left part
                if (rightIndex > rightTo)
                {
                    temp[index] = array[leftIndex];
                    leftIndex++;
                    index++;
                    continue;
                }

                //compare current items from left and right parts
                //copy the small one
                if (comparer.Compare(array[leftIndex], array[rightIndex]) == 1)
                {
                    temp[index] = array[rightIndex];
                    rightIndex++;
                }
                else
                {
                    temp[index] = array[leftIndex];
                    leftIndex++;
                }

                index++;
            }

            //put processed items back into source array
            Array.Copy(temp, leftFrom, array, leftFrom, rightTo - leftFrom + 1);
        }
    }
}
