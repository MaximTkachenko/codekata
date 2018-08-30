namespace Core.Interfaces
{
    public interface IEdge
    {
        int Weight { get; }
        IVertex Vertex1 { get; }
        IVertex Vertex2 { get; }
    }
}
