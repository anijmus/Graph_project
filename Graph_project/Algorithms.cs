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
}
