using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList.Interfaces;

namespace Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList
{
    internal sealed class AdjacencyList : IAdjacencyList
    {
        private static readonly Regex WeightRegex = new Regex(@"^\[([0-9]{1,3})\]", RegexOptions.Compiled);

        internal readonly Dictionary<string, Vertex> Vertexes;

        public AdjacencyList(bool isDirected)
        {
            IsDirected = isDirected;
            Vertexes = new Dictionary<string, Vertex>();
        }

        public bool IsDirected { get; }

        public int VertexCount { get; private set; }

        /// <summary>
        /// Should be in format like
        /// a-b-c,b-d-f,f-c
        /// or with weights
        /// a-[1]b-[2]c,b-[4]d-[5]f,f-[3]c
        /// </summary>
        public AdjacencyList(string structure, bool isDirected) : this(isDirected)
        {
            if (string.IsNullOrEmpty(structure))
            {
                throw new ArgumentException(nameof(structure));
            }

            var vertexItems = structure.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var vi in vertexItems)
            {
                var vertices = vi.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (vertices.Length == 0)
                {
                    continue;
                }

                var vertex = AddVertex(vertices[0]);

                for (int i = 1; i < vertices.Length; i++)
                {
                    var match = WeightRegex.Match(vertices[i]);
                    var name = match.Success ? vertices[i].Substring(match.Length) : vertices[i];
                    var weight = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                    vertex.AddEdge(name, weight);
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
            VertexCount++;
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
