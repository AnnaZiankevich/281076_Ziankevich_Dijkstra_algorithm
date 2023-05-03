using System.Collections.Generic;

namespace dijkstra_algorithm
{
    class Graph
    {
        public List<GraphVertex> Vertexes { get; }

        public Graph()
        {
            Vertexes = new List<GraphVertex>();
        }

        public void AddVertex(string _vertexName)
        {
            Vertexes.Add(new GraphVertex(_vertexName));
        }

        public GraphVertex FindVertexName(string _vertexName)
        {
            foreach (var vertex in Vertexes)
            {
                if (vertex.Name.Equals(_vertexName))
                {
                    return vertex;
                }
            }
            return null;
        }

        public void AddEdge(string _firstName, string _secondName, int _weight)
        {
            var v1 = FindVertexName(_firstName);
            var v2 = FindVertexName(_secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, _weight);
                v2.AddEdge(v1, _weight);
            }
        }
    }
}
