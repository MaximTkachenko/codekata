using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SortingAlgorithms.Tests
{
    public class SortingTests
    {
        [Theory]
        [MemberData(nameof(Sortings))]
        public void Basic(ISorting sorting)
        {
            var input = new[] { 8, 5, 3, 0, 7 };
            sorting.Sort(input);
            input.Should().BeEquivalentTo(new[] { 0, 3, 5, 7, 8 });
        }

        public static IEnumerable<object[]> Sortings =>
            new List<object[]>
            {
                new object[] {new BubbleSorting()},
                new object[] {new MergeSorting()},
                new object[] {new QuickSorting()}
            };
    }
}
