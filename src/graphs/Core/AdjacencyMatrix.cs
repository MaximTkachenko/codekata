using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core
{
    //todo need to mirror edges for not directed graph
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
}
