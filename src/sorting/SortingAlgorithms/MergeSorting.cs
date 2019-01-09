using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class MergeSorting : ISorting
    {
        public void Sort(int[] input)
        {
            var temp = new int[input.Length];
            MergeSort(input, temp, 0, input.Length - 1);
        }

        private void MergeSort(int[] array, int[] temp, int from, int to)
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
            
            MergeSort(array, temp, leftFrom, leftTo);
            MergeSort(array, temp, rightFrom, rightTo);
            MergeHalves(array, temp, leftFrom, leftTo, rightFrom, rightTo);
        }

        private void MergeHalves(int[] array, int[] temp, int leftFrom, int leftTo, int rightFrom, int rightTo)
        {

        }
    }
}
