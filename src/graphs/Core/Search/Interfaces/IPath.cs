using System.Collections.Generic;

namespace Core.Search.Interfaces
{
    public interface IPath
    {
        IEnumerable<string> GetPath(string to);
        string GetPathString(string to);
    }
}
