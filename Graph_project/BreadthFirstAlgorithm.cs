using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphProject;

namespace Graph_project
{
    public class BreadthFirstAlgorithm : GraphAlgorithm
    {
        public BreadthFirstAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal = null)
        {
            HashSet<Graph.Vertex> visited = new HashSet<Graph.Vertex>();
            Queue<Graph.Vertex> queue = new Queue<Graph.Vertex>();
            List<Graph.Vertex> result = new List<Graph.Vertex>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Graph.Vertex current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    result.Add(current);

                    foreach (Graph.Vertex neighbor in GetNeighbors(current))
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
}
