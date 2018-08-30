using System;
using Core;
using FluentAssertions;
using Xunit;

namespace DijkstraAlgorithm.Tests
{
    public class SearchTests
    {
        [Fact]
        public void Find_ValidInput_ShouldFindPath()
        {
            var graph = AdjacencyMatrixFactory.CreateUndirected();
            graph.AddVertex("a")
                .AddEdge("b", 5)
                .AddEdge("d", 10)
                .AddEdge("e", 19);
            graph.AddVertex("b")
                .AddEdge("c", 1)
                .AddEdge("d", 8);
            graph.AddVertex("d")
                .AddEdge("c", 1)
                .AddEdge("e", 9);

            var search = new Search(graph);
            var result = string.Join("", search.Find("a", "e"));

            result.Should().Be("abcde");
        }
    }
}
