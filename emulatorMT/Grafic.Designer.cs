namespace emulatorMT
{
    partial class Graphic
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
            this.components = new System.ComponentModel.Container();
            this.chartWorkMT = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // chartWorkMT
            // 
            this.chartWorkMT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWorkMT.IsEnableHPan = false;
            this.chartWorkMT.Location = new System.Drawing.Point(0, 0);
            this.chartWorkMT.Name = "chartWorkMT";
            this.chartWorkMT.ScrollGrace = 0D;
            this.chartWorkMT.ScrollMaxX = 0D;
            this.chartWorkMT.ScrollMaxY = 0D;
            this.chartWorkMT.ScrollMaxY2 = 0D;
            this.chartWorkMT.ScrollMinX = 0D;
            this.chartWorkMT.ScrollMinY = 0D;
            this.chartWorkMT.ScrollMinY2 = 0D;
            this.chartWorkMT.Size = new System.Drawing.Size(741, 355);
            this.chartWorkMT.TabIndex = 0;
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 355);
            this.Controls.Add(this.chartWorkMT);
            this.Name = "Graphic";
            this.Text = "Grafic";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl chartWorkMT;

    }
}