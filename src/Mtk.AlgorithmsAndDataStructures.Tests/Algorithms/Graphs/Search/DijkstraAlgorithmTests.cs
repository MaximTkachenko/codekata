using FluentAssertions;
using Mtk.AlgorithmsAndDataStructures.Algorithms.Graphs.Search;
using Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList;
using Xunit;

namespace Mtk.AlgorithmsAndDataStructures.Tests.Algorithms.Graphs.Search
{
    public class DijkstraAlgorithmTests
    {
        [Fact]
        public void Find_ValidInput_ShouldFindPath()
        {
            var graph = AdjacencyListFactory.CreateUndirected();
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

            var search = new DijkstraAlgorithm(graph);
            var result = search.BuildPath("a").GetPathString("e");

            result.Should().Be("abcde");
        }

        [Fact]
        public void Find_ValidInputUsingStringStructure_ShouldFindPath()
        {
            var graph = AdjacencyListFactory.CreateUndirectedFromStructure("1-[14]6-[9]3-[7]2,6-[9]5-[2]3,2-[10]3-[15]4,3-[11]4,4-[6]5");

            var search = new DijkstraAlgorithm(graph);
            var result = search.BuildPath("1").GetPathString("5");

            result.Should().Be("1365");
        }
    }
}
