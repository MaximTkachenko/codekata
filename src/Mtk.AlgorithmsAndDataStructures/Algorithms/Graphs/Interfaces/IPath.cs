using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.Algorithms.Graphs.Search.Interfaces
{
    public interface IPath
    {
        IEnumerable<string> GetPath(string to);
        string GetPathString(string to);
    }
}
