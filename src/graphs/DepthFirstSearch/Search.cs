using System.Collections.Generic;
using Core;
using Core.Interfaces;

namespace DepthFirstSearch
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
            DfsSeacrh(start);

            return _path;
        }

        private void DfsSeacrh(IVertex start)
        {
            _visited.Add(start.Name);
            foreach (var edge in start.GetEdges())
            {
                if (!_visited.Contains(edge.Vertex2.Name))
                {
                    _path.Set(edge.Vertex2.Name, start.Name);
                    DfsSeacrh(edge.Vertex2);
                }
            }
        }
    }
}
