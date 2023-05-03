
namespace dijkstra_algorithm
{
    class GraphEdge
    {
        public GraphVertex ConnectedVertex { get; }

        public int EdgeWeight { get; }

        public GraphEdge(GraphVertex _connectedVertex, int _weight)
        {
            ConnectedVertex = _connectedVertex;
            EdgeWeight = _weight;
        }
    }
}
