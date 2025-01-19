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
            if (start == null)
                throw new ArgumentNullException(nameof(start), "Start vertex cannot be null.");
            if (goal == null)
                throw new ArgumentNullException(nameof(goal), "Goal vertex cannot be null.");

            // Zbiór otwarty przechowujący wierzchołki do przetworzenia
            List<Graph.Vertex> openSet = new List<Graph.Vertex> { start };

            Dictionary<Graph.Vertex, Graph.Vertex> cameFrom = new Dictionary<Graph.Vertex, Graph.Vertex>();

            // G-Score: koszt dotarcia do każdego wierzchołka, początkowo nieskończoność
            var gScore = Graph.Vertices.ToDictionary(v => v, v => double.PositiveInfinity);
            // F-Score: szacowany całkowity koszt od startu do celu
            var fScore = Graph.Vertices.ToDictionary(v => v, v => double.PositiveInfinity);

            gScore[start] = 0;
            fScore[start] = HeuristicCost(start, goal);

            while (openSet.Count > 0)
            {
                Graph.Vertex current = openSet.OrderBy(v => fScore[v]).First();

                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);

                foreach (Graph.Vertex neighbor in GetNeighbors(current))
                {
                    double tentativeGScore = gScore[current] + Distance(current, neighbor);

                    if (tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicCost(neighbor, goal);

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return null; // Path not found
        }

        private List<Graph.Vertex> ReconstructPath(Dictionary<Graph.Vertex, Graph.Vertex> cameFrom, Graph.Vertex current)
        {
            List<Graph.Vertex> totalPath = new List<Graph.Vertex> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Insert(0, current);
            }
            return totalPath;
        }
        //Szacuje koszt heurystyczny między dwoma wierzchołkami, czyli odleglosc
        protected virtual double HeuristicCost(Graph.Vertex from, Graph.Vertex to)
        {
            return Distance(from, to);
        }

        private static double Distance(Graph.Vertex v1, Graph.Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v1.Location.X - v2.Location.X, 2) + Math.Pow(v1.Location.Y - v2.Location.Y, 2));
        }
    }
}
