using System.Linq;
using FluentAssertions;
using Xunit;

namespace Core.Tests
{
    public class AdjacencyMatrixTests
    {
        [Fact]
        public void AdjacencyMatrix_Init_Empty()
        {
            var graph = new AdjacencyMatrix();

            graph.Edges.Count.Should().Be(0);
            graph.Vertexes.Count.Should().Be(0);
        }

        [Fact]
        public void AdjacencyMatrix_AddVertex_VertexAvailable()
        {
            var graph = new AdjacencyMatrix();

            graph.AddVertex("a");

            graph.Edges.Count.Should().Be(0);
            graph.Vertexes.Count.Should().Be(1);
            graph.GetVertexes().Count().Should().Be(1);
        }

        [Fact]
        public void AdjacencyMatrix_AddVertexAndEdges_DataConsistent()
        {
            var graph = new AdjacencyMatrix();

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
            edges[0].Weight.Should().Be(1);
            edges[0].Next.Vertex1.Name.Should().Be("a");
            edges[0].Next.Vertex2.Name.Should().Be("c");
            edges[0].Next.Weight.Should().Be(1);
            edges[0].Next.Next.Should().BeNull();

            graph.Edges.Count.Should().Be(2);
            graph.Vertexes.Count.Should().Be(4);
            graph.GetVertexes().Count().Should().Be(4);
        }

        [Fact]
        public void AdjacencyMatrix_FromString_DataConsistent()
        {
            var graph = new AdjacencyMatrix("a-b-c-g,c-d-e-f,f-g");

            var vertex = graph.GetVertex("a");
            vertex.Name.Should().Be("a");
            var edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(3);
            edges[0].Vertex2.Name.Should().Be("b");
            edges[0].Next.Vertex2.Name.Should().Be("c");
            edges[1].Vertex2.Name.Should().Be("c");
            edges[1].Next.Vertex2.Name.Should().Be("g");
            edges[2].Vertex2.Name.Should().Be("g");
            edges[2].Next.Should().BeNull();

            vertex = graph.GetVertex("c");
            vertex.Name.Should().Be("c");
            edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(3);
            edges[0].Vertex2.Name.Should().Be("d");
            edges[0].Next.Vertex2.Name.Should().Be("e");
            edges[1].Vertex2.Name.Should().Be("e");
            edges[1].Next.Vertex2.Name.Should().Be("f");
            edges[2].Vertex2.Name.Should().Be("f");
            edges[2].Next.Should().BeNull();

            vertex = graph.GetVertex("f");
            vertex.Name.Should().Be("f");
            edges = vertex.GetEdges().ToArray();
            edges.Length.Should().Be(1);
            edges[0].Vertex2.Name.Should().Be("g");
            edges[0].Next.Should().BeNull();

            graph.Edges.Count.Should().Be(7);
            graph.Vertexes.Count.Should().Be(7);
            graph.GetVertexes().Count().Should().Be(7);
        }
    }
}
