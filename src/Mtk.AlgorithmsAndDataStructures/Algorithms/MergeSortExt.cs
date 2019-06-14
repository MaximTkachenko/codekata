using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms
{
    public static class MergeSortExt
    {
        public static void MergeSort<T>(this T[] input)
        {
            var temp = new T[input.Length];
            MergeSortImpl(input, temp, 0, input.Length - 1);
        }

        private static void MergeSortImpl<T>(T[] array, T[] temp, int from, int to)
        {
            if (to - from == 0)
            {
                return;
            }

            var middle = (to - from) / 2;
            var leftFrom = from;
            var leftTo = from + middle;
            var rightFrom = leftTo + 1;
            var rightTo = to;

            MergeSortImpl(array, temp, leftFrom, leftTo);
            MergeSortImpl(array, temp, rightFrom, rightTo);
            MergeHalves(array, temp, leftFrom, leftTo, rightFrom, rightTo);
        }

        private static void MergeHalves<T>(T[] array, T[] temp, int leftFrom, int leftTo, int rightFrom, int rightTo)
        {
            var comparer = Comparer<T>.Default;
        }
    }
}
