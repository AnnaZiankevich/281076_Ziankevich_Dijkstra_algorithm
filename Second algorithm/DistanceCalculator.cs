using System;
using System.Collections.Generic;
using System.Linq;

namespace dijkstra_algorithm
{
    class DistanceCalculator
    {
        Dictionary<Node, int> Distances;
        Dictionary<Node, Node> Routes;
        Graph2 Graph;
        List<Node> AllNodes;

        public DistanceCalculator(Graph2 _g)
        {
            Graph = _g;
            AllNodes = _g.GetNodes();
            Distances = SetDistances();
            Routes = SetRoutes();
        }

        public void Calculate(Node _startNode, Node _finishNode)
        {
            Distances[_startNode] = 0;

            while (AllNodes.ToList().Count != 0)
            {
                Node LeastExpensiveNode = getLeastExpensiveNode();
                ExamineConnections(LeastExpensiveNode);
                AllNodes.Remove(LeastExpensiveNode);
            }
            Print(_startNode, _finishNode);
        }

        private void Print(Node _startNode, Node _finishNode)
        {
            Console.WriteLine(string.Format("Shortest path from " +
                                         $"{_startNode.getName()} to {_finishNode.getName()} is: "));
            PrintLeg(_finishNode);
            Console.ReadKey();
        }

        private void PrintLeg(Node _d)
        {
            if (Routes[_d] == null)
                return;
            Console.WriteLine(string.Format($"{Routes[_d].getName()} --> {_d.getName()} "));
            PrintLeg(Routes[_d]);
        }

        private void ExamineConnections(Node _n)
        {
            foreach (var neighbor in _n.getNeighbors())
            {
                if (Distances[_n] + neighbor.Value < Distances[neighbor.Key])
                {
                    Distances[neighbor.Key] = neighbor.Value + Distances[_n];
                    Routes[neighbor.Key] = _n;
                }
            }
        }

        private Node getLeastExpensiveNode()
        {
            Node LeastExpensive = AllNodes.FirstOrDefault();

            foreach (var min in AllNodes)
            {
                if (Distances[min] < Distances[LeastExpensive])
                    LeastExpensive = min;
            }

            return LeastExpensive;
        }

        private Dictionary<Node, int> SetDistances()
        {
            Dictionary<Node, int> Distances = new Dictionary<Node, int>();

            foreach (Node n in Graph.GetNodes())
            {
                Distances.Add(n, int.MaxValue);
            }
            return Distances;
        }

        private Dictionary<Node, Node> SetRoutes()
        {
            Dictionary<Node, Node> Routes = new Dictionary<Node, Node>();

            foreach (Node n in Graph.GetNodes())
            {
                Routes.Add(n, null);
            }
            return Routes;
        }
    }
}
