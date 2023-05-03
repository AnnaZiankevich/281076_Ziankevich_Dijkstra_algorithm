using System.Collections.Generic;

namespace dijkstra_algorithm
{
    class DijkstraAlgorithm1
    {
        Graph graph;

        List<GraphVertexInfo> infos;

        public DijkstraAlgorithm1(Graph graph)
        {
            this.graph = graph;
        }

        void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var vertex in graph.Vertexes)
            {
                infos.Add(new GraphVertexInfo(vertex));
            }
        }

        GraphVertexInfo GetVertexInfo(GraphVertex _vertex)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(_vertex))
                {
                    return i;
                }
            }

            return null;
        }

        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }

        public string FindShortestPath(string _startName, string _finishName)
        {
            return FindShortestPath(graph.FindVertexName(_startName), 
                                                graph.FindVertexName(_finishName));
        }

        public string FindShortestPath(GraphVertex _startVertex, GraphVertex _finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(_startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(_startVertex, _finishVertex);
        }

        void SetSumToNextVertex(GraphVertexInfo _info)
        {
            _info.IsUnvisited = false;
            foreach (var e in _info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = _info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = _info.Vertex;
                }
            }
        }

        string GetPath(GraphVertex _startVertex, GraphVertex _endVertex)
        {
            var path = _endVertex.ToString();
            while (_startVertex != _endVertex)
            {
                _endVertex = GetVertexInfo(_endVertex).PreviousVertex;
                path = _endVertex.ToString() + path;
            }

            return path;
        }
    }
}
