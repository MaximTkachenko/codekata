using System;
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
        private readonly Dictionary<string, string> _prev = new Dictionary<string, string>();
        private readonly IAdjacencyMatrix _graph;

        public Search(IAdjacencyMatrix graph)
        {
            _graph = graph;
        }

        public IEnumerable<string> Find(string from, string to)
        {
            if (from == to)
            {
                return Enumerable.Empty<string>();
            }

            var start = _graph.GetVertex(from);
            DijkstrasSeacrh(start);

            //move to separate class, like path or smth like this
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
                        _prev[edge.Vertex2.Name] = current.Name;
                    }

                    queue.Enqueue(edge.Vertex2);
                }

                _visited.Add(current.Name);
            }
        }
    }
}
