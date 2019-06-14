using System;
using System.Collections.Generic;
using FluentAssertions;
using Mtk.AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace Mtk.AlgorithmsAndDataStructures.Tests.Algorithms
{
    public class SortingTests
    {
        [Theory]
        [MemberData(nameof(Sorts))]
        public void Basic(Action<int[]> sort)
        {
            var input = new[] { 8, 5, 3, 0, 7 };
            sort.Invoke(input);
            input.Should().BeEquivalentTo(new[] { 0, 3, 5, 7, 8 });
        }

        public static IEnumerable<object[]> Sorts =>
            new List<Action<int[]>[]>
            {
                new Action<int[]>[] { arr => arr.BubbleSort() },
                new Action<int[]>[] { arr => arr.QuickSort() },
                new Action<int[]>[] { arr => arr.MergeSort() }
            };
    }
}
