using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core
{
    internal sealed class AdjacencyMatrix : IAdjacencyMatrix
    {
        internal readonly Dictionary<string, Vertex> Vertexes;

        public AdjacencyMatrix(bool isDirected)
        {
            IsDirected = isDirected;
            Vertexes = new Dictionary<string, Vertex>();
        }

        public bool IsDirected { get; }

        /// <summary>
        /// Should be in format like
        /// a-b-c,b-d-f,f-c
        /// or with weights
        /// a-[1]b-[2]c,b-[4]d-[5]f,f-[3]c
        /// </summary>
        public AdjacencyMatrix(string structure, bool isDirected) : this(isDirected)
        {
            if (string.IsNullOrEmpty(structure))
            {
                throw new ArgumentException(nameof(structure));
            }

            //todo parse weights

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

        public IReadOnlyList<IVertex> GetVertexes() => Vertexes.Values.ToList();
    }
}
