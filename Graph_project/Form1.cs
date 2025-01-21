using GraphProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            PenVertexSelected = new Pen(Color.DeepPink, 5);
            AdjustableArrowCap myArrow = new AdjustableArrowCap(6, 3);
            PenEdge = new Pen(Color.Gold, 3);
            PenEdge.CustomEndCap = myArrow;

            BrushVertexDescription = new SolidBrush(Color.Black);

            animationTimer = new Timer();
            animationTimer.Interval = 500;
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
                    v.Location.X - 5 * radius/2 , v.Location.Y - 2 * radius);
            }

            foreach (Graph.Edge e in myGraph.Edges)
            {
                graphics.DrawLine(PenEdge, e.From.Location.X, e.From.Location.Y, e.To.Location.X, e.To.Location.Y);
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


        private Point? currentMousePosition = null; //nullable


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
                    MessageBox.Show("You can't insert a vertex so close to another!");
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
            else if (e.Button == MouseButtons.Right) 
            {
                Vertex selectedVertex = myGraph.GetVertex(e.Location, radius);
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

                using (Graphics g = pictureBoxVisualization.CreateGraphics())
                {
                    Pen tempPen = new Pen(Color.Gray, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                    g.DrawLine(tempPen, vertexFrom.Location.X, vertexFrom.Location.Y, currentMousePosition.Value.X, currentMousePosition.Value.Y);
                }
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

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (algorithmPath != null && currentStep < algorithmPath.Count)
            {
                Vertex currentVertex = algorithmPath[currentStep];
                graphics.FillEllipse(new SolidBrush(Color.BlueViolet), currentVertex.Location.X - radius, currentVertex.Location.Y - radius, 2 * radius, 2 * radius);
                pictureBoxVisualization.Refresh();
                currentStep++;
            }
            else
            {
                animationTimer.Stop();
                algorithmPath = null;
                MessageBox.Show( "Algorithm visualization completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonAStar_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null || vertexTo == null)
            {
                MessageBox.Show("Please select both a start and an end vertex (right-click and Add Vertex mode).", "Vertex Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AStarAlgorithm aStar = new AStarAlgorithm(myGraph);
            algorithmPath = aStar.Execute(vertexFrom, vertexTo);
            StartAnimation();
        }

        private void buttonBFS_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null)
            {
                MessageBox.Show("Please select a starting vertex (Add Vertex mode and right-click).", "Vertex Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BreadthFirstAlgorithm bfs = new BreadthFirstAlgorithm(myGraph);
            algorithmPath = bfs.Execute(vertexFrom);
            StartAnimation();
        }

        private void buttonDFS_Click(object sender, EventArgs e)
        {
            if (vertexFrom == null)
            {
                MessageBox.Show("Please select a starting vertex (Add Vertex mode and right-click).", "Vertex Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepthFirstAlgorithm dfs = new DepthFirstAlgorithm(myGraph);
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

            graphics.Clear(Color.White);
            pictureBoxVisualization.Refresh();
        }
    }
}
