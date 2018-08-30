using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;

namespace DijkstraAlgorithm
{
    public sealed class Search : ISearch
    {
        private readonly HashSet<string> _visited = new HashSet<string>();
        private readonly Dictionary<string, int> _costs = new Dictionary<string, int>();
        private readonly IAdjacencyMatrix _graph;
        private Path _path;

        public Search(IAdjacencyMatrix graph)
        {
            _graph = graph;
        }

        public Path BuildPath(string from)
        {
            _path = new Path(from);
            var start = _graph.GetVertex(from);
            DijkstrasSeacrh(start);

            return _path;
        }

        private void DijkstrasSeacrh(IVertex start)
        {
            _visited.Add(start.Name);
            _costs.Add(start.Name, 0);

            var queue = new Queue<IVertex>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var edge in current.GetEdges().OrderBy(x => x.Weight))
                {
                    if (_visited.Contains(edge.Vertex2.Name))
                    {
                        continue;
                    }

                    if (!_costs.TryGetValue(edge.Vertex2.Name, out var cost) || cost > edge.Weight + _costs[current.Name])
                    {
                        _costs[edge.Vertex2.Name] = edge.Weight + _costs[current.Name];
                        _path.Set(edge.Vertex2.Name, current.Name);
                    }

                    queue.Enqueue(edge.Vertex2);
                }

                _visited.Add(current.Name);
            }
        }
    }
}
