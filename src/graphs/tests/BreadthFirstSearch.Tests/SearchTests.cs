using Core;
using FluentAssertions;
using Xunit;

namespace BreadthFirstSearch.Tests
{
    public class SearchTests
    {
        [Fact]
        public void Find_ValidInput_ShouldFindPath()
        {
            var graph = AdjacencyMatrixFactory.CreateDirected();
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
            var result = string.Join("", search.BuildPath("a").GetPath("e"));

            (result == "ace" || result == "agfce").Should().BeTrue();
        }

        [Fact]
        public void Find_FromVertexDisonnectedFromToVertex_EmptyPath()
        {
            var graph = AdjacencyMatrixFactory.CreateDirected();
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
            var result = string.Join("", search.BuildPath("a").GetPath("n"));

            result.Should().Be("");
        }
    }
}
