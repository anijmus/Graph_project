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
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.radioButtonVertex = new System.Windows.Forms.RadioButton();
            this.radioButtonEdge = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.pictureBoxVisualization.Name = "pictureBoxVisualization";
            this.pictureBoxVisualization.Size = new System.Drawing.Size(1251, 953);
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
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxVisualization);
            this.splitContainer1.Size = new System.Drawing.Size(1382, 953);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.radioButtonEdge);
            this.groupBoxAdd.Controls.Add(this.radioButtonVertex);
            this.groupBoxAdd.Location = new System.Drawing.Point(6, 136);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(157, 75);
            this.groupBoxAdd.TabIndex = 0;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Add";
            // 
            // radioButtonVertex
            // 
            this.radioButtonVertex.AutoSize = true;
            this.radioButtonVertex.Location = new System.Drawing.Point(4, 22);
            this.radioButtonVertex.Name = "radioButtonVertex";
            this.radioButtonVertex.Size = new System.Drawing.Size(66, 20);
            this.radioButtonVertex.TabIndex = 0;
            this.radioButtonVertex.TabStop = true;
            this.radioButtonVertex.Text = "Vertex";
            this.radioButtonVertex.UseVisualStyleBackColor = true;
            // 
            // radioButtonEdge
            // 
            this.radioButtonEdge.AutoSize = true;
            this.radioButtonEdge.Location = new System.Drawing.Point(4, 49);
            this.radioButtonEdge.Name = "radioButtonEdge";
            this.radioButtonEdge.Size = new System.Drawing.Size(61, 20);
            this.radioButtonEdge.TabIndex = 1;
            this.radioButtonEdge.TabStop = true;
            this.radioButtonEdge.Text = "Edge";
            this.radioButtonEdge.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 61);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 61);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 953);
            this.Controls.Add(this.splitContainer1);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.RadioButton radioButtonEdge;
        private System.Windows.Forms.RadioButton radioButtonVertex;
    }
}

