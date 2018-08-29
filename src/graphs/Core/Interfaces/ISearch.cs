using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISearch
    {
        IEnumerable<string> Find(string from, string to);
    }
}
