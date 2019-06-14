using Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList.Interfaces;

namespace Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList
{
    public static class AdjacencyListFactory
    {
        public static IAdjacencyList CreateDirected() => new AdjacencyList(true);

        public static IAdjacencyList CreateDirectedFromStructure(string structure) => new AdjacencyList(structure, true);

        public static IAdjacencyList CreateUndirected() => new AdjacencyList(false);

        public static IAdjacencyList CreateUndirectedFromStructure(string structure) => new AdjacencyList(structure, false);
    }
}
