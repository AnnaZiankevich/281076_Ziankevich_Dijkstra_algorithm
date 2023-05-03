using System.Collections.Generic;

namespace dijkstra_algorithm
{
    class Node
    {
        public string Name;
        private Dictionary<Node, int> Neighbors;

        public Node(string _nodeName)
        {
            Name = _nodeName;
            Neighbors = new Dictionary<Node, int>();
        }

        public void AddNeighbour(Node _n, int _cost)
        {
            Neighbors.Add(_n, _cost);
        }

        public string getName()
        {
            return Name;
        }

        public Dictionary<Node, int> getNeighbors()
        {
            return Neighbors;
        }
    }
}
