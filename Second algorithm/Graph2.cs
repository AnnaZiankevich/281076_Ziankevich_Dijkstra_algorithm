using System.Collections.Generic;
using System.Linq;

namespace dijkstra_algorithm
{
    class Graph2
    {
        private List<Node> Nodes;

        public Graph2()
        {
            Nodes = new List<Node>();
        }

        public void Add(Node _n)
        {
            Nodes.Add(_n);
        }

        public List<Node> GetNodes()
        {
            return Nodes.ToList();
        }

        public Node FindNode(string _nodeName)
        {
            foreach (var node in Nodes)
            {
                if (node.Name.Equals(_nodeName))
                {
                    return node;
                }
            }
            return null;
        }
    }
}
