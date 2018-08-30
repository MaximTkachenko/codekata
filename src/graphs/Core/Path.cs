using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public sealed class Path
    {
        private readonly Dictionary<string, string> _path = new Dictionary<string, string>();
        private readonly string _start;

        public Path(string start)
        {
            _start = string.IsNullOrEmpty(start) ? throw new ArgumentNullException(nameof(start)) : start;
        }

        public void Set(string to, string from)
        {
            _path[to] = from;
        }

        public IEnumerable<string> GetPath(string to)
        {
            if (to == _start)
            {
                return Enumerable.Empty<string>();
            }

            if (!_path.TryGetValue(to, out var current))
            {
                return Enumerable.Empty<string>();
            }

            var path = new List<string> { to };
            while (current != _start)
            {
                path.Add(current);
                current = _path[current];
            }
            path.Add(_start);

            path.Reverse();
            return path;
        }
    }
}
