using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;

namespace BreadthFirstSearch
{
    public sealed class Search : ISearch
    {
        private readonly IAdjacencyMatrix _graph;
        private readonly HashSet<string> _visited = new HashSet<string>();
        private Path _path;

        public Search(IAdjacencyMatrix graph)
        {
            _graph = graph;
        }

        public Path BuildPath(string from)
        {
            _path = new Path(from);
            var start = _graph.GetVertex(from);
            BfsSeacrh(start);

            return _path;
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
                        _path.Set(edge.Vertex2.Name, current.Name);
                    }
                }
            }
        }
    }
}
