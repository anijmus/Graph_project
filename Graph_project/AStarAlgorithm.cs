using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphProject;

namespace Graph_project
{

    public class AStarAlgorithm : GraphAlgorithm
    {
        public AStarAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal)
        {
            if (start == null || goal == null)
                throw new ArgumentNullException("Start or goal vertex cannot be null.");

            // Zbiór otwarty (wierzchołki do odwiedzenia)
            List<Graph.Vertex> openSet = new List<Graph.Vertex> { start };

            // Śledzenie ścieżki
            Dictionary<Graph.Vertex, Graph.Vertex> cameFrom = new Dictionary<Graph.Vertex, Graph.Vertex>();

            // Koszty dotarcia do wierzchołków
            Dictionary<Graph.Vertex, double> gScore = new Dictionary<Graph.Vertex, double>();
            Dictionary<Graph.Vertex, double> fScore = new Dictionary<Graph.Vertex, double>();

            foreach (var vertex in Graph.Vertices)
            {
                gScore[vertex] = double.PositiveInfinity;
                fScore[vertex] = double.PositiveInfinity;
            }

            gScore[start] = 0;
            fScore[start] = HeuristicDistance(start, goal); // Szacowany koszt dotarcia do celu

            while (openSet.Count > 0)
            {
                // Wierzchołek z najniższym fScore
                Graph.Vertex current = openSet.OrderBy(v => fScore[v]).First();

                if (current == goal) 
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);

                foreach (Graph.Vertex neighbor in GetNeighbors(current))
                {
                    
                    double tentativeGScore = gScore[current] + HeuristicDistance(current, neighbor);

                    if (tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicDistance(neighbor, goal);
                       
                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
            return null;
        }
        private List<Graph.Vertex> ReconstructPath(Dictionary<Graph.Vertex, Graph.Vertex> cameFrom, Graph.Vertex current)
        {
            List<Graph.Vertex> path = new List<Graph.Vertex> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Insert(0, current);
            }
            return path;
        }

        // Obliczanie odległości euklidesowej między dwoma wierzchołkami
        private double HeuristicDistance(Graph.Vertex v1, Graph.Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v1.Location.X - v2.Location.X, 2) + Math.Pow(v1.Location.Y - v2.Location.Y, 2));
        }
    }
}
