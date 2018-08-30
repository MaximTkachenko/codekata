using System.Linq;
using FluentAssertions;
using Xunit;

namespace Core.Tests
{
    public class AdjacencyMatrixTests
    {
        [Fact]
        public void AdjacencyMatrix_InitDirectedGraph_Empty()
        {
            var graph = new AdjacencyMatrix(true);

            graph.Vertexes.Count.Should().Be(0);
        }

        [Fact]
        public void AdjacencyMatrix_AddVertexToDirected_VertexAvailable()
        {
            var graph = new AdjacencyMatrix(true);

            graph.AddVertex("a");

            graph.Vertexes.Count.Should().Be(1);
            graph.Vertexes["a"].GetEdges().Count.Should().Be(0);
            graph.GetVertexes().Count.Should().Be(1);
        }

        [Fact]
        public void AdjacencyMatrix_AddVertexAndEdgesToDirectedGraph_DataConsistent()
        {
            var graph = new AdjacencyMatrix(true);

            graph.AddVertex("a")
                .AddEdge("b")
                .AddEdge("c");
            graph.AddVertex("d");

            var vertex = graph.GetVertex("a");
            vertex.Name.Should().Be("a");
            var edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(2);
            edges[0].Vertex1.Name.Should().Be("a");
            edges[0].Vertex2.Name.Should().Be("b");
            edges[0].Weight.Should().Be(0);
            edges[1].Vertex1.Name.Should().Be("a");
            edges[1].Vertex2.Name.Should().Be("c");
            edges[1].Weight.Should().Be(0);

            graph.Vertexes.Count.Should().Be(4);
            graph.Vertexes["a"].GetEdges().Count.Should().Be(2);
            graph.Vertexes["d"].GetEdges().Count.Should().Be(0);
            graph.GetVertexes().Count.Should().Be(4);
        }

        [Fact]
        public void AdjacencyMatrix_DirectedGraphFromString_DataConsistent()
        {
            var graph = new AdjacencyMatrix("a-b-c-g,c-d-e-f,f-g", true);

            graph.Vertexes.Count.Should().Be(7);
            graph.GetVertexes().Count().Should().Be(7);

            var vertex = graph.GetVertex("a");
            vertex.Name.Should().Be("a");
            var edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(3);
            edges[0].Vertex2.Name.Should().Be("b");
            edges[1].Vertex2.Name.Should().Be("c");
            edges[2].Vertex2.Name.Should().Be("g");

            vertex = graph.GetVertex("c");
            vertex.Name.Should().Be("c");
            edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(3);
            edges[0].Vertex2.Name.Should().Be("d");
            edges[1].Vertex2.Name.Should().Be("e");
            edges[2].Vertex2.Name.Should().Be("f");

            vertex = graph.GetVertex("f");
            vertex.Name.Should().Be("f");
            edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(1);
            edges[0].Vertex2.Name.Should().Be("g");
        }

        [Fact]
        public void AdjacencyMatrix_DirectedGraphFromStringWithWeights_DataConsistent()
        {
            var graph = new AdjacencyMatrix("a-[2]b-[3]c,c-[4]d-[55]e", true);

            graph.Vertexes.Count.Should().Be(5);
            graph.GetVertexes().Count.Should().Be(5);

            var vertex = graph.GetVertex("a");
            vertex.Name.Should().Be("a");
            var edges = vertex.GetEdges();
            edges.Count.Should().Be(2);
            edges[0].Vertex2.Name.Should().Be("b");
            edges[0].Weight.Should().Be(2);
            edges[1].Vertex2.Name.Should().Be("c");
            edges[1].Weight.Should().Be(3);

            vertex = graph.GetVertex("c");
            vertex.Name.Should().Be("c");
            edges = vertex.GetEdges();
            edges.Count.Should().Be(2);
            edges[0].Vertex2.Name.Should().Be("d");
            edges[0].Weight.Should().Be(4);
            edges[1].Vertex2.Name.Should().Be("e");
            edges[1].Weight.Should().Be(55);
        }

        //todo add tests for fluent api with directions + for string structure with weights + tests for directed
    }
}
