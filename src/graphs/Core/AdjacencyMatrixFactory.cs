using Core.Interfaces;

namespace Core
{
    public static class AdjacencyMatrixFactory
    {
        public static IAdjacencyMatrix Create() => new AdjacencyMatrix();

        public static IAdjacencyMatrix CreateFromStructure(string structure) => new AdjacencyMatrix(structure);
    }
}
