using FluentAssertions;
using Xunit;

namespace SortingAlgorithms.Tests
{
    public class SortingTests
    {
        [Fact]
        public void Basic()
        {
            ISorting bubble = new BubbleSorting();
            var input = new[] { 8, 5, 3, 0, 7 };
            bubble.Sort(input);
            input.Should().BeEquivalentTo(new[] { 0, 3, 5, 7, 8 });

            ISorting merge = new MergeSorting();
            input = new[] { 8, 5, 3, 0, 7 };
            merge.Sort(input);
            input.Should().BeEquivalentTo(new[] { 0, 3, 5, 7, 8 });

            ISorting quick = new QuickSorting();
            input = new[] { 8, 5, 3, 0, 7 };
            quick.Sort(input);
            input.Should().BeEquivalentTo(new[] { 0, 3, 5, 7, 8 });
        }
    }
}
