using GraphProject;
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
        private const int radius = 20;
        private readonly Pen PenVertex;
        private readonly Pen PenVertexSelected;
        private readonly Pen PenEdge;
        private readonly SolidBrush BrushVertexDescription;

        private readonly Graph myGraph;

        private Graph.Vertex vertexFrom;
        private Graph.Vertex vertexTo;

        private List<Graph.Vertex> algorithmPath;
        private int currentStep;
        private Timer animationTimer;

        public Form1()
        {
            InitializeComponent();

            myGraph = new Graph();

            vertexFrom = null;
            vertexTo = null;

            pictureBoxVisualization.Image = new Bitmap(pictureBoxVisualization.Width,
                                                      pictureBoxVisualization.Height);

            graphics = Graphics.FromImage(pictureBoxVisualization.Image);
            PenVertex = new Pen(Color.Black, 4);
            PenVertexSelected = new Pen(Color.Red, 5);
            PenEdge = new Pen(Color.Gold, 3)
            {
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor
            };

            BrushVertexDescription = new SolidBrush(Color.Black);

            animationTimer = new Timer();
            animationTimer.Interval = 500; // Интервал обновления анимации
            animationTimer.Tick += AnimationTimer_Tick;

            DrawGraph();
        }

        private void DrawGraph()
        {
            graphics.Clear(Color.White);

            foreach (Graph.Vertex v in myGraph.Vertices)
            {
                graphics.DrawEllipse(PenVertex, v.Location.X - radius, v.Location.Y - radius, 2 * radius, 2 * radius);
                graphics.DrawString(v.Description, new Font("Arial", radius, FontStyle.Bold), BrushVertexDescription,
                    v.Location.X - 2*radius , v.Location.Y - 2 * radius);
            }

            foreach (Graph.Edge e in myGraph.Edges)
            {
                DrawArrow(e.From.Location, e.To.Location);
            }

            if (vertexFrom != null)
            {
                graphics.DrawEllipse(PenVertexSelected, vertexFrom.Location.X - radius, vertexFrom.Location.Y - radius, 2 * radius, 2 * radius);
            }
            if (vertexTo != null)
            {
                graphics.DrawEllipse(PenVertexSelected, vertexTo.Location.X - radius, vertexTo.Location.Y - radius, 2 * radius, 2 * radius);
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

            float arrowSize = 12; 

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
            if (e.Button == MouseButtons.Left && radioButtonVertex.Checked)
            {
                if (!myGraph.IsVertex(e.Location, radius * 4))
                {
                    myGraph.AddVertex(new Vertex(e.Location));
                    DrawGraph();
                }
                else
                {
                    MessageBox.Show("Nie można wstawić wierzchołka tak blisko innego!");
                }
            }
            else if (e.Button == MouseButtons.Left && radioButtonEdge.Checked)
            {
                vertexFrom = myGraph.GetVertex(e.Location, radius); 
                if (vertexFrom != null)
                {
                    currentMousePosition = e.Location;
                }
            }
            else if (e.Button == MouseButtons.Right) // Выбор начальной/конечной вершины
            {
                var selectedVertex = myGraph.GetVertex(e.Location, radius);
                if (selectedVertex != null)
                {
                    if (vertexFrom == null)
                    {
                        vertexFrom = selectedVertex;
                    }
                    else if (vertexTo == null)
                    {
                        vertexTo = selectedVertex;
                    }
                    else
                    {
                        vertexFrom = selectedVertex;
                        vertexTo = null;
                    }
                }
                DrawGraph();
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
                vertexTo = myGraph.GetVertex(e.Location, radius);

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
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (algorithmPath != null && currentStep < algorithmPath.Count)
            {
                var currentVertex = algorithmPath[currentStep];
                graphics.FillEllipse(new SolidBrush(Color.BlueViolet), currentVertex.Location.X - radius, currentVertex.Location.Y - radius, 2 * radius, 2 * radius);
                pictureBoxVisualization.Refresh();
                currentStep++;
            }
            else
            {
                animationTimer.Stop();
                algorithmPath = null; // Сброс пути после завершения
                MessageBox.Show("Algorithm visualization completed.");
            }
        }

        private void StartAnimation()
        {
            if (algorithmPath == null || algorithmPath.Count == 0)
            {
                MessageBox.Show("No path found or invalid graph structure.");
                return;
            }

            currentStep = 0;
            animationTimer.Start();
        }

        private void buttonAStar_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null || vertexTo == null)
            {
                MessageBox.Show("Please select both a start and an end vertex (right-click).");
                return;
            }

            var aStar = new AStarAlgorithm(myGraph);
            algorithmPath = aStar.Execute(vertexFrom, vertexTo);
            StartAnimation();
        }

        private void buttonBFS_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null)
            {
                MessageBox.Show("Please select a starting vertex (right-click).");
                return;
            }

            var bfs = new BreadthFirstAlgorithm(myGraph);
            algorithmPath = bfs.Execute(vertexFrom);
            StartAnimation();
        }

        private void buttonDFS_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null)
            {
                MessageBox.Show("Please select a starting vertex (right-click).");
                return;
            }

            var dfs = new DepthFirstAlgorithm(myGraph);
            algorithmPath = dfs.Execute(vertexFrom);
            StartAnimation();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            myGraph.Clear();
            vertexFrom = null;
            vertexTo = null;
            algorithmPath = null;
            currentStep = 0;

            // Очищаем экран
            graphics.Clear(Color.White);
            pictureBoxVisualization.Refresh();
        }
    }
}
