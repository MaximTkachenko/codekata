using Core;
using FluentAssertions;
using Xunit;

namespace DepthFirstSearch.Tests
{
    public class SearchTests
    {
        [Fact]
        public void Find_ValidInput_ShouldFindPath()
        {
            var graph = AdjacencyMatrixFactory.Create();
            graph.AddVertex("a")
                .AddEdge("b")
                .AddEdge("c")
                .AddEdge("g");
            graph.AddVertex("c")
                .AddEdge("d")
                .AddEdge("e")
                .AddEdge("f");
            graph.AddVertex("f")
                .AddEdge("g");

            var search = new Search(graph);
            var result = string.Join("", search.Find("a", "e"));

            (result == "ace" || result == "agfce").Should().BeTrue();
        }

        [Fact]
        public void Find_FromVertexDisonnectedFromToVertex_EmptyPath()
        {
            var graph = AdjacencyMatrixFactory.Create();
            graph.AddVertex("a")
                .AddEdge("b")
                .AddEdge("c")
                .AddEdge("g");
            graph.AddVertex("c")
                .AddEdge("d")
                .AddEdge("e")
                .AddEdge("f");
            graph.AddVertex("f")
                .AddEdge("g");
            //path of graph not cennected with others
            graph.AddVertex("m")
                .AddEdge("n");
            graph.AddVertex("n")
                .AddEdge("o");

            var search = new Search(graph);
            var result = string.Join("", search.Find("a", "n"));

            result.Should().Be("");
        }
    }
}
