namespace Graph_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxVisualization = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAStar = new System.Windows.Forms.Button();
            this.buttonBFS = new System.Windows.Forms.Button();
            this.buttonDFS = new System.Windows.Forms.Button();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.radioButtonEdge = new System.Windows.Forms.RadioButton();
            this.radioButtonVertex = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxVisualization
            // 
            this.pictureBoxVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVisualization.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxVisualization.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxVisualization.Name = "pictureBoxVisualization";
            this.pictureBoxVisualization.Size = new System.Drawing.Size(906, 774);
            this.pictureBoxVisualization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVisualization.TabIndex = 0;
            this.pictureBoxVisualization.TabStop = false;
            this.pictureBoxVisualization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisualization_MouseDown);
            this.pictureBoxVisualization.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisualization_MouseMove);
            this.pictureBoxVisualization.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisualization_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonClear);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAStar);
            this.splitContainer1.Panel1.Controls.Add(this.buttonBFS);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDFS);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxVisualization);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 774);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonAStar
            // 
            this.buttonAStar.Location = new System.Drawing.Point(2, 467);
            this.buttonAStar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAStar.Name = "buttonAStar";
            this.buttonAStar.Size = new System.Drawing.Size(118, 50);
            this.buttonAStar.TabIndex = 3;
            this.buttonAStar.Text = "A Star";
            this.buttonAStar.UseVisualStyleBackColor = true;
            this.buttonAStar.Click += new System.EventHandler(this.buttonAStar_Click);
            // 
            // buttonBFS
            // 
            this.buttonBFS.Location = new System.Drawing.Point(2, 413);
            this.buttonBFS.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBFS.Name = "buttonBFS";
            this.buttonBFS.Size = new System.Drawing.Size(118, 50);
            this.buttonBFS.TabIndex = 2;
            this.buttonBFS.Text = "BFS";
            this.buttonBFS.UseVisualStyleBackColor = true;
            this.buttonBFS.Click += new System.EventHandler(this.buttonBFS_Click);
            // 
            // buttonDFS
            // 
            this.buttonDFS.Location = new System.Drawing.Point(2, 358);
            this.buttonDFS.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDFS.Name = "buttonDFS";
            this.buttonDFS.Size = new System.Drawing.Size(118, 50);
            this.buttonDFS.TabIndex = 1;
            this.buttonDFS.Text = "DFS";
            this.buttonDFS.UseVisualStyleBackColor = true;
            this.buttonDFS.Click += new System.EventHandler(this.buttonDFS_Click);
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.radioButtonEdge);
            this.groupBoxAdd.Controls.Add(this.radioButtonVertex);
            this.groupBoxAdd.Location = new System.Drawing.Point(4, 110);
            this.groupBoxAdd.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAdd.Size = new System.Drawing.Size(118, 61);
            this.groupBoxAdd.TabIndex = 0;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Add";
            // 
            // radioButtonEdge
            // 
            this.radioButtonEdge.AutoSize = true;
            this.radioButtonEdge.Location = new System.Drawing.Point(3, 40);
            this.radioButtonEdge.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonEdge.Name = "radioButtonEdge";
            this.radioButtonEdge.Size = new System.Drawing.Size(50, 17);
            this.radioButtonEdge.TabIndex = 1;
            this.radioButtonEdge.TabStop = true;
            this.radioButtonEdge.Text = "Edge";
            this.radioButtonEdge.UseVisualStyleBackColor = true;
            // 
            // radioButtonVertex
            // 
            this.radioButtonVertex.AutoSize = true;
            this.radioButtonVertex.Location = new System.Drawing.Point(3, 18);
            this.radioButtonVertex.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonVertex.Name = "radioButtonVertex";
            this.radioButtonVertex.Size = new System.Drawing.Size(55, 17);
            this.radioButtonVertex.TabIndex = 0;
            this.radioButtonVertex.TabStop = true;
            this.radioButtonVertex.Text = "Vertex";
            this.radioButtonVertex.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(2, 192);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(118, 36);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 774);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisualization)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxVisualization;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonAStar;
        private System.Windows.Forms.Button buttonBFS;
        private System.Windows.Forms.Button buttonDFS;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.RadioButton radioButtonEdge;
        private System.Windows.Forms.RadioButton radioButtonVertex;
        private System.Windows.Forms.Button buttonClear;
    }
}

