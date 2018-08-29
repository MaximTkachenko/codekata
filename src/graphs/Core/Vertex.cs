using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core
{
    //todo moved structure
    internal sealed class Vertex : IVertex
    {
        private readonly AdjacencyMatrix _graph;

        private IEdge _edge;

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

        public IVertex AddEdge(string endVertexName, short weight = 1)
        {
            if (!_graph.Vertexes.TryGetValue(endVertexName, out var endVertex))
            {
                endVertex = new Vertex(endVertexName, _graph);
                _graph.Vertexes.Add(endVertexName, endVertex);
            }

            var edge = new Edge(this, endVertex, weight);
            _graph.Edges.Add(edge);
            if (_edge == null)
            {
                _edge = edge;
            }
            else
            {
                ((Edge)GetEdges().Last()).Next = edge;
            }

            return this;
        }

        public IEnumerable<IEdge> GetEdges()
        {
            if (_edge == null)
            {
                yield break;
            }

            yield return _edge;

            var edge = _edge;
            while (edge.Next != null)
            {
                yield return edge.Next;
                edge = edge.Next;
            }
        }
    }
}
