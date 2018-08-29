namespace Core.Interfaces
{
    public interface IEdge
    {
        short Weight { get; }
        IVertex Vertex1 { get; }
        IVertex Vertex2 { get; }
        IEdge Next { get; }
    }
}
