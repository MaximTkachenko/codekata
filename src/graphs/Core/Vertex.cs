using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core
{
    internal sealed class Vertex : IVertex
    {
        private readonly AdjacencyMatrix _graph;
        private readonly List<IEdge> _edges = new List<IEdge>();

        public Vertex(string name, AdjacencyMatrix graph)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
            _graph = graph;
        }

        public string Name { get; }

        public IVertex AddEdge(string endVertexName, short weight = 0)
        {
            if (endVertexName == Name)
            {
                return this;
            }

            if (_edges.Any(e => e.Vertex2.Name == endVertexName && e.Weight == weight))
            {
                return this;
            }

            if (!_graph.Vertexes.TryGetValue(endVertexName, out var endVertex))
            {
                endVertex = new Vertex(endVertexName, _graph);
                _graph.Vertexes.Add(endVertexName, endVertex);
            }

            var edge = new Edge(this, endVertex, weight);
            _edges.Add(edge);

            if (!_graph.IsDirected)
            {
                endVertex.AddEdge(Name, weight);
            }

            return this;
        }

        public IReadOnlyList<IEdge> GetEdges() => _edges;
    }
}
