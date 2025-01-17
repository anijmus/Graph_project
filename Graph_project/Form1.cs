using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Graph_project.Graph;

namespace Graph_project
{
    public partial class Form1 : Form
    {
        private readonly Graphics graphics;
        private const int radius = 15;
        private readonly Pen PenVertex;
        private readonly Pen PenVertexSelected;
        private readonly Pen PenEdge;
        private readonly SolidBrush BrushVertexDescription;

        private readonly Graph myGraph;

        private Graph.Vertex vertexFrom;
        private Graph.Vertex vertexTo;

        public Form1()
        {
            InitializeComponent();

            myGraph = new Graph();

            vertexFrom = null;
            vertexTo = null;

            pictureBoxVisualization.Image = new Bitmap(pictureBoxVisualization.Width,
                                                      pictureBoxVisualization.Height);

            graphics = Graphics.FromImage(pictureBoxVisualization.Image);
            PenVertex = new Pen(Color.Black, 3);
            PenVertexSelected = new Pen(Color.Red, 5);
            PenEdge = new Pen(Color.Blue, 3)
            {
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor
            };

            BrushVertexDescription = new SolidBrush(Color.Black);

            DrawGraph();
        }

        private void DrawGraph()
        {
            graphics.Clear(Color.White);

            foreach (Graph.Vertex v in myGraph.Vertices)
            {
                graphics.DrawEllipse(PenVertex, v.Location.X - radius, v.Location.Y - radius, 2 * radius, 2 * radius);
                graphics.DrawString(v.Description, new Font("Arial", radius, FontStyle.Bold), BrushVertexDescription,
                    v.Location.X - radius / 2, v.Location.Y - radius / 2);
            }

            foreach (Graph.Edge e in myGraph.Edges)
            {
                DrawArrow(e.From.Location, e.To.Location);
            }

            if (vertexFrom != null)
            {
                graphics.DrawEllipse(PenVertexSelected, vertexFrom.Location.X - radius, vertexFrom.Location.Y - radius, 2 * radius, 2 * radius);
            }

            pictureBoxVisualization.Refresh();
        }

        private void DrawArrow(Point from, Point to)
        {
            float dx = to.X - from.X;
            float dy = to.Y - from.Y;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);

            dx /= length;
            dy /= length;

            float arrowSize = 12; // Zwiększono rozmiar strzałki

            PointF arrowPoint1 = new PointF(
                to.X - arrowSize * (dx - dy),
                to.Y - arrowSize * (dy + dx));

            PointF arrowPoint2 = new PointF(
                to.X - arrowSize * (dx + dy),
                to.Y - arrowSize * (dy - dx));

            graphics.DrawLine(PenEdge, from, to);
            graphics.FillPolygon(new SolidBrush(PenEdge.Color), new PointF[] { to, arrowPoint1, arrowPoint2 });
        }

        private Point? currentMousePosition = null;

        private void pictureBoxVisualization_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButtonVertex.Checked)
            {
                if (!myGraph.IsVertex(e.Location, radius * 2))
                {
                    myGraph.AddVertex(new Vertex(e.Location));
                    DrawGraph();
                }
                else
                {
                    MessageBox.Show("Nie można wstawić wierzchołka tak blisko innego!");
                }
            }
            else if (radioButtonEdge.Checked)
            {
                vertexFrom = myGraph.GetVertex(e.Location, radius * 2); // Zwiększona tolerancja
                if (vertexFrom != null)
                {
                    currentMousePosition = e.Location;
                }
            }
        }

        private void pictureBoxVisualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (radioButtonEdge.Checked && vertexFrom != null)
            {
                currentMousePosition = e.Location;
                DrawGraphWithEdgePreview();
            }
        }

        private void pictureBoxVisualization_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButtonEdge.Checked && vertexFrom != null)
            {
                vertexTo = myGraph.GetVertex(e.Location, radius * 2); // Zwiększona tolerancja

                if (vertexTo != null && vertexFrom != vertexTo)
                {
                    myGraph.AddEdge(vertexFrom, vertexTo);
                }

                DrawGraph();
                vertexFrom = null;
                vertexTo = null;
            }
        }

        private void DrawGraphWithEdgePreview()
        {
            DrawGraph();

            if (vertexFrom != null && currentMousePosition != null)
            {
                Point adjustedFrom = new Point(
                    vertexFrom.Location.X,
                    vertexFrom.Location.Y);

                using (Graphics g = pictureBoxVisualization.CreateGraphics())
                {
                    Pen tempPen = new Pen(Color.Gray, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                    g.DrawLine(tempPen, adjustedFrom, currentMousePosition.Value);
                }
            }
        }
    }
}
