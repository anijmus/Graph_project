using Graph_project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphProject
{
    public abstract class GraphAlgorithm
    {
        protected Graph Graph { get; }

        protected GraphAlgorithm(Graph graph)
        {
            Graph = graph;
        }

        public abstract List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal = null);

        protected List<Graph.Vertex> GetNeighbors(Graph.Vertex vertex)
        {
            return Graph.Edges
                .Where(edge => edge.From == vertex)
                .Select(edge => edge.To)
                .ToList();
        }
    }

    public class DepthFirstAlgorithm : GraphAlgorithm
    {
        public DepthFirstAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal = null)
        {
            var visited = new HashSet<Graph.Vertex>();
            List<Graph.Vertex> result = new List<Graph.Vertex>();
            var stack = new Stack<Graph.Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);

                    foreach (var neighbor in GetNeighbors(current))
                    {
                        if (!visited.Contains(neighbor))
                        {
                            stack.Push(neighbor);
                        }
                    }
                }
            }
            return result;
        }
    }

    public class BreadthFirstAlgorithm : GraphAlgorithm
    {
        public BreadthFirstAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal = null)
        {
            var visited = new HashSet<Graph.Vertex>();
            var result = new List<Graph.Vertex>();
            var queue = new Queue<Graph.Vertex>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);

                    foreach (var neighbor in GetNeighbors(current))
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            return result;
        }
    }

    public class AStarAlgorithm : GraphAlgorithm
    {
        public AStarAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start), "Start vertex cannot be null.");
            if (goal == null)
                throw new ArgumentNullException(nameof(goal), "Goal vertex cannot be null.");

            var openSet = new List<Graph.Vertex> { start };
            var cameFrom = new Dictionary<Graph.Vertex, Graph.Vertex>();
            var gScore = Graph.Vertices.ToDictionary(v => v, v => double.PositiveInfinity);
            var fScore = Graph.Vertices.ToDictionary(v => v, v => double.PositiveInfinity);

            gScore[start] = 0;
            fScore[start] = HeuristicCostEstimate(start, goal);

            while (openSet.Count > 0)
            {
                var current = openSet.OrderBy(v => fScore[v]).First();

                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    double tentativeGScore = gScore[current] + Distance(current, neighbor);

                    if (tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, goal);

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
            var totalPath = new List<Graph.Vertex> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Insert(0, current);
            }
            return totalPath;
        }

        protected virtual double HeuristicCostEstimate(Graph.Vertex from, Graph.Vertex to)
        {
            return Distance(from, to);
        }

        private static double Distance(Graph.Vertex v1, Graph.Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v1.Location.X - v2.Location.X, 2) + Math.Pow(v1.Location.Y - v2.Location.Y, 2));
        }
    }
}
