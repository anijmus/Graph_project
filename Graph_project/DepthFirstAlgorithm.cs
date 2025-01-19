using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphProject;

namespace Graph_project
{
    public class DepthFirstAlgorithm : GraphAlgorithm
    {
        public DepthFirstAlgorithm(Graph graph) : base(graph) { }

        public override List<Graph.Vertex> Execute(Graph.Vertex start, Graph.Vertex goal = null)
        {
            HashSet<Graph.Vertex> visited = new HashSet<Graph.Vertex>();
            List<Graph.Vertex> result = new List<Graph.Vertex>();
            Stack<Graph.Vertex> stack = new Stack<Graph.Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                Graph.Vertex current = stack.Pop();
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
}
