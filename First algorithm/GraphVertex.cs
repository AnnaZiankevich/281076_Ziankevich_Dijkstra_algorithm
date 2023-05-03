using System.Collections.Generic;

namespace dijkstra_algorithm
{
    class GraphVertex
    {
        public string Name { get; }

        public List<GraphEdge> Edges { get; }

        public GraphVertex(string vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge _newEdge)
        {
            Edges.Add(_newEdge);
        }

        public void AddEdge(GraphVertex _vertex, int _edgeWeight)
        {
            AddEdge(new GraphEdge(_vertex, _edgeWeight));
        }

        public override string ToString() => Name;
    }
}
