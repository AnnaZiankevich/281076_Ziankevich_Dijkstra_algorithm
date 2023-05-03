using System;

namespace dijkstra_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph();

            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddVertex("F");
            g.AddVertex("G");

            g.AddEdge("A", "B", 22);
            g.AddEdge("A", "C", 33);
            g.AddEdge("A", "D", 61);
            g.AddEdge("B", "C", 47);
            g.AddEdge("B", "E", 93);
            g.AddEdge("C", "D", 11);
            g.AddEdge("C", "E", 79);
            g.AddEdge("C", "F", 63);
            g.AddEdge("D", "F", 41);
            g.AddEdge("E", "F", 17);
            g.AddEdge("E", "G", 58);
            g.AddEdge("F", "G", 84);

            Console.Write("Enter start point (A-G): ");
            string startPoint = Console.ReadLine();
            Console.Write("Enter end point (A-G): ");
            string endPoint = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("First Dijkstra algorithm");
            Console.WriteLine("-------------------------------------------------------------");

            var dijkstra1 = new DijkstraAlgorithm1(g);
            Console.Write($"Shortest path from {startPoint} to {endPoint} is ");
            var path = dijkstra1.FindShortestPath(startPoint, endPoint);
            Console.WriteLine(path);

            Console.WriteLine();
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Second Dijkstra algorithm");
            Console.WriteLine("-------------------------------------------------------------");

            var g2 = new Graph2();

            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            Node G = new Node("G");

            g2.Add(A);
            g2.Add(B);
            g2.Add(C);
            g2.Add(D);
            g2.Add(E);
            g2.Add(F);
            g2.Add(G);

            A.AddNeighbour(B, 22);
            A.AddNeighbour(C, 33);
            A.AddNeighbour(D, 61);
            B.AddNeighbour(A, 22);
            B.AddNeighbour(C, 47);
            B.AddNeighbour(E, 93);
            C.AddNeighbour(A, 33);
            C.AddNeighbour(B, 47);
            C.AddNeighbour(D, 11);
            C.AddNeighbour(E, 79);
            C.AddNeighbour(F, 63);
            D.AddNeighbour(A, 61);
            D.AddNeighbour(C, 11);
            D.AddNeighbour(F, 41);
            E.AddNeighbour(B, 93);
            E.AddNeighbour(C, 79);
            E.AddNeighbour(F, 17);
            E.AddNeighbour(G, 58);
            F.AddNeighbour(C, 63);
            F.AddNeighbour(E, 17);
            F.AddNeighbour(D, 41);
            F.AddNeighbour(G, 84);
            G.AddNeighbour(E, 58);
            G.AddNeighbour(F, 84);
            
            DistanceCalculator calc = new DistanceCalculator(g2);
            calc.Calculate(g2.FindNode(startPoint), g2.FindNode(endPoint));
        }
    }

}
