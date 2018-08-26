using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    internal sealed class AdjacencyMatrix : IAdjacencyMatrix
    {
        internal readonly Dictionary<string, Vertex> Vertexes;
        internal readonly List<Edge> Edges;

        public AdjacencyMatrix()
        {
            Vertexes = new Dictionary<string, Vertex>();
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Should be in format like
        /// a-b-c,b-d-f,f-c
        /// </summary>
        public AdjacencyMatrix(string structure) : this()
        {
            if (string.IsNullOrEmpty(structure))
            {
                throw new ArgumentException(nameof(structure));
            }

            var vertexItems = structure.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var vi in vertexItems)
            {
                var verteces = vi.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (verteces.Length == 0)
                {
                    continue;
                }

                var vertex = AddVertex(verteces[0]);

                for (int i = 1; i < verteces.Length; i++)
                {
                    vertex.AddEdge(verteces[i]);
                }
            }
        }

        public IVertex AddVertex(string name)
        {
            if (Vertexes.TryGetValue(name, out var vertex))
            {
                return vertex;
            }

            vertex = new Vertex(name, this);
            Vertexes.Add(name, vertex);
            return vertex;
        }

        public IVertex GetVertex(string name)
        {
            if (!Vertexes.TryGetValue(name, out var vertex))
            {
                throw new ArgumentException(nameof(name));
            }

            return vertex;
        }

        public IEnumerable<IVertex> GetVertexes()
        {
            foreach (var vertex in Vertexes.Values)
            {
                yield return vertex;
            }
        }
    }

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

    internal sealed class Edge : IEdge
    {
        public Edge(IVertex vertex1, IVertex vertex2, short weight)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = weight;
            Next = null;
        }

        public short Weight { get; }

        public IVertex Vertex1 { get; }

        public IVertex Vertex2 { get; }

        public IEdge Next { get; internal set; }
    }
}
