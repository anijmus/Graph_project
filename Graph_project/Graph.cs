using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_project
{
    public class Graph
    {
        private readonly List<Vertex> vertices;
        public List<Vertex> Vertices { get => vertices; }
        private readonly List<Edge> edges;
        public List<Edge> Edges { get => edges; }

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public void AddVertex(Vertex v1)
        {
            vertices.Add(v1);
        }
        public void AddEdge(Vertex v1, Vertex v2)
        {
            edges.Add(new Edge(v1, v2));
        }

        public bool IsVertex(Point location, double radius)
        {
            foreach (Vertex v in vertices)
            {

                if (Distance(v.Location, location) < radius)
                {
                    return true;
                }
            }
            return false;
        }
       

        public Vertex GetVertex(Point location, int radius)
        {
            foreach (Vertex v in vertices)
            {
                if (Distance(v.Location, location) < radius)
                {
                    return v;
                }
            }
            return null;
        }
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public void Clear()
        {
            Vertices.Clear();
            Edges.Clear();
            Vertex.ResetCounter();
        }


        public class Vertex
        {
            private readonly Point location;
            private readonly String description;

            private static int count = 1;

            public Point Location { get => location; }
            public string Description { get => description; }

            public Vertex(Point point)
            {
                this.location = point;
                this.description =count.ToString();
                count++;
            }
            public static void ResetCounter()
            {
                count = 1;
            }
        }


        public class Edge
        {
            private readonly Graph.Vertex from;
            private readonly Graph.Vertex to;
            public Vertex From { get => from; }
            public Vertex To { get => to; }
            public Edge(Graph.Vertex from, Graph.Vertex to)
            {
                this.from = from;
                this.to = to;
            }
        }
    }
}
