using System.Collections.Generic;
using System.Linq;
using Core.AdjacencyList.Interfaces;
using Core.Search.Interfaces;

namespace Core.Search
{
    public sealed class DijkstraAlgorithm : ISearch
    {
        private readonly HashSet<string> _visited = new HashSet<string>();
        private readonly Dictionary<string, int> _costs = new Dictionary<string, int>();
        private readonly IAdjacencyList _graph;
        private Path _path;

        public DijkstraAlgorithm(IAdjacencyList graph)
        {
            _graph = graph;
        }

        public IPath BuildPath(string from)
        {
            _path = new Path(from);
            var start = _graph.GetVertex(from);

            _costs.Add(start.Name, 0);
            var current = start;
            while (current != null)
            {
                var edges = current.GetEdges().OrderBy(x => x.Weight).ToArray();
                foreach (var edge in edges)
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
                }

                _visited.Add(current.Name);

                current = edges.Where(e => !_visited.Contains(e.Vertex2.Name))
                    .OrderBy(e => _costs.TryGetValue(e.Vertex2.Name, out var cost) ? cost : int.MaxValue)
                    .FirstOrDefault()?.Vertex2;
            }

            return _path;
        }
    }
}
