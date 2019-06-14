using System.Collections.Generic;
using System.Linq;
using Mtk.AlgorithmsAndDataStructures.Algorithms.Graphs.Search.Interfaces;
using Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList.Interfaces;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms.Graphs.Search
{
    public sealed class BreadthFirstSearch : ISearch
    {
        private readonly IAdjacencyList _graph;
        private readonly HashSet<string> _visited = new HashSet<string>();
        private Path _path;

        public BreadthFirstSearch(IAdjacencyList graph)
        {
            _graph = graph;
        }

        public IPath BuildPath(string from)
        {
            _path = new Path(from);
            var start = _graph.GetVertex(from);

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

            return _path;
        }
    }
}
