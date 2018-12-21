using Core.AdjacencyList;
using Core.Search;
using FluentAssertions;
using Xunit;

namespace Core.Tests.Search
{
    public class BreadthFirstSearchTests
    {
        [Fact]
        public void Find_ValidInput_ShouldFindPath()
        {
            var graph = AdjacencyListFactory.CreateDirected();
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

            var search = new BreadthFirstSearch(graph);
            var result = search.BuildPath("a").GetPathString("e");

            (result == "ace" || result == "agfce").Should().BeTrue();
        }

        [Fact]
        public void Find_FromVertexDisonnectedFromToVertex_EmptyPath()
        {
            var graph = AdjacencyListFactory.CreateDirected();
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

            var search = new BreadthFirstSearch(graph);
            var result = search.BuildPath("a").GetPathString("n");

            result.Should().Be("");
        }
    }
}
