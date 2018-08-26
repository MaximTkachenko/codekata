using System.Collections.Generic;
using System.Linq;
using Core;

namespace BreadthFirstSearch
{
    public sealed class Search
    {
        private readonly IAdjacencyMatrix _graph;
        private readonly Dictionary<string, string> _prev = new Dictionary<string, string>();
        private readonly HashSet<string> _visited = new HashSet<string>();

        public Search(IAdjacencyMatrix graph)
        {
            _graph = graph;
        }

        public IEnumerable<string> Start(string from, string to)
        {
            if (from == to)
            {
                return Enumerable.Empty<string>();
            }

            var start = _graph.GetVertex(from);
            BfsSeacrh(start);

            if (!_prev.TryGetValue(to, out var current))
            {
                return Enumerable.Empty<string>();
            }

            var path = new List<string> { to };
            while (current != from)
            {
                path.Add(current);
                current = _prev[current];
            }
            path.Add(from);

            path.Reverse();
            return path;
        }

        private void BfsSeacrh(IVertex start)
        {
            var queue = new Queue<IVertex>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var edges = current.GetEdges().ToArray();
                _visited.Add(current.Name);
                if (edges.Length == 0)
                {
                    continue;
                }

                foreach (var edge in edges)
                {
                    if (!_visited.Contains(edge.Vertex2.Name))
                    {
                        queue.Enqueue(edge.Vertex2);
                        _prev.Add(edge.Vertex2.Name, current.Name);
                    }
                }
            }
        }
    }
}
