using System.Collections.Generic;
using FluentAssertions;
using Mtk.AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace Mtk.AlgorithmsAndDataStructures.Tests.Algorithms
{
    public class SortingTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void BubbleSort_Basic(int[] input, int[] output)
        {
            input.BubbleSort();
            input.Should().BeEquivalentTo(output, opt => opt.WithStrictOrdering());
        }

        [Theory(Skip = "not finished")]
        [MemberData(nameof(Data))]
        public void HeapSort_Basic(int[] input, int[] output)
        {
            input.HeapSort();
            input.Should().BeEquivalentTo(output, opt => opt.WithStrictOrdering());
        }

        [Theory(Skip = "not finished")]
        [MemberData(nameof(Data))]
        public void QuickSort_Basic(int[] input, int[] output)
        {
            input.QuickSort();
            input.Should().BeEquivalentTo(output, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void MergeSort_Basic(int[] input, int[] output)
        {
            input.MergeSort();
            input.Should().BeEquivalentTo(output, opt => opt.WithStrictOrdering());
        }

        public static IEnumerable<object[]> Data => new List<object[]>
            {
                new object[] { new[] { 0, 3, 5, 7, 8 }, new[] { 0, 3, 5, 7, 8 } },
                new object[] { new[] { 8, 5, 3, 0, 7 }, new[] { 0, 3, 5, 7, 8 } },
                new object[] { new[] { 0, 3, 7, 5, 8 }, new[] { 0, 3, 5, 7, 8 } }
            };
    }
}
