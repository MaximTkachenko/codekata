using System.Collections.Generic;
using System.Linq;
using Core;

namespace DepthFirstSearch
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
            DfsSeacrh(start);

            if (!_prev.TryGetValue(to, out var current))
            {
                return Enumerable.Empty<string>();
            }

            var path = new List<string> {to};
            while (current != from)
            {
                path.Add(current);
                current = _prev[current];
            }
            path.Add(from);

            path.Reverse();
            return path;
        }

        private void DfsSeacrh(IVertex start)
        {
            _visited.Add(start.Name);
            foreach (var edge in start.GetEdges())
            {
                if (!_visited.Contains(edge.Vertex2.Name))
                {
                    _prev.Add(edge.Vertex2.Name, start.Name);
                    DfsSeacrh(edge.Vertex2);
                }
            }
        }
    }
}
