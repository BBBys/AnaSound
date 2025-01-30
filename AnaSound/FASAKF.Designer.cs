namespace AnaSound
{
  partial class FASAKF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FASAKF));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb10 = new System.Windows.Forms.ToolStripButton();
            this.tsb1 = new System.Windows.Forms.ToolStripButton();
            this.tsb01 = new System.Windows.Forms.ToolStripButton();
            this.tsb001 = new System.Windows.Forms.ToolStripButton();
            this.tsb0001 = new System.Windows.Forms.ToolStripButton();
            this.tsbZeit = new System.Windows.Forms.ToolStripButton();
            this.tsbWeg = new System.Windows.Forms.ToolStripButton();
            this.tsbFq = new System.Windows.Forms.ToolStripButton();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb10,
            this.tsb1,
            this.tsb01,
            this.tsb001,
            this.tsb0001,
            this.tsbZeit,
            this.tsbWeg,
            this.tsbFq});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb10
            // 
            this.tsb10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb10.Image = ((System.Drawing.Image)(resources.GetObject("tsb10.Image")));
            this.tsb10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb10.Name = "tsb10";
            this.tsb10.Size = new System.Drawing.Size(49, 29);
            this.tsb10.Text = "10 s";
            this.tsb10.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // tsb1
            // 
            this.tsb1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb1.Image = ((System.Drawing.Image)(resources.GetObject("tsb1.Image")));
            this.tsb1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1.Name = "tsb1";
            this.tsb1.Size = new System.Drawing.Size(39, 29);
            this.tsb1.Text = "1 s";
            this.tsb1.Click += new System.EventHandler(this.tsb1_Click);
            // 
            // tsb01
            // 
            this.tsb01.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb01.Image = ((System.Drawing.Image)(resources.GetObject("tsb01.Image")));
            this.tsb01.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb01.Name = "tsb01";
            this.tsb01.Size = new System.Drawing.Size(75, 29);
            this.tsb01.Text = "100 ms";
            this.tsb01.Click += new System.EventHandler(this.tsb01_Click);
            // 
            // tsb001
            // 
            this.tsb001.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb001.Image = ((System.Drawing.Image)(resources.GetObject("tsb001.Image")));
            this.tsb001.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb001.Name = "tsb001";
            this.tsb001.Size = new System.Drawing.Size(65, 29);
            this.tsb001.Text = "10 ms";
            this.tsb001.Click += new System.EventHandler(this.tsb001_Click);
            // 
            // tsb0001
            // 
            this.tsb0001.Checked = true;
            this.tsb0001.CheckOnClick = true;
            this.tsb0001.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.tsb0001.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb0001.Image = ((System.Drawing.Image)(resources.GetObject("tsb0001.Image")));
            this.tsb0001.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb0001.Name = "tsb0001";
            this.tsb0001.Size = new System.Drawing.Size(55, 29);
            this.tsb0001.Text = "1 ms";
            this.tsb0001.Click += new System.EventHandler(this.tsb0001_Click);
            // 
            // tsbZeit
            // 
            this.tsbZeit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbZeit.Image = ((System.Drawing.Image)(resources.GetObject("tsbZeit.Image")));
            this.tsbZeit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZeit.Name = "tsbZeit";
            this.tsbZeit.Size = new System.Drawing.Size(48, 29);
            this.tsbZeit.Tag = "z";
            this.tsbZeit.Text = "Zeit";
            this.tsbZeit.Click += new System.EventHandler(this.tsbFq_Click);
            // 
            // tsbWeg
            // 
            this.tsbWeg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbWeg.Image = ((System.Drawing.Image)(resources.GetObject("tsbWeg.Image")));
            this.tsbWeg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWeg.Name = "tsbWeg";
            this.tsbWeg.Size = new System.Drawing.Size(54, 29);
            this.tsbWeg.Tag = "w";
            this.tsbWeg.Text = "Weg";
            this.tsbWeg.Click += new System.EventHandler(this.tsbFq_Click);
            // 
            // tsbFq
            // 
            this.tsbFq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFq.Image = ((System.Drawing.Image)(resources.GetObject("tsbFq.Image")));
            this.tsbFq.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFq.Name = "tsbFq";
            this.tsbFq.Size = new System.Drawing.Size(94, 29);
            this.tsbFq.Tag = "fq";
            this.tsbFq.Text = "Frequenz";
            this.tsbFq.Click += new System.EventHandler(this.tsbFq_Click);
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.White;
            this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView1.Location = new System.Drawing.Point(0, 32);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(782, 521);
            this.plotView1.TabIndex = 1;
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // FASAKF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FASAKF";
            this.Text = "AKF";
            this.Shown += new System.EventHandler(this.FASAKF_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsb10;
    private System.Windows.Forms.ToolStripButton tsb1;
    private System.Windows.Forms.ToolStripButton tsb01;
    private System.Windows.Forms.ToolStripButton tsb001;
    private System.Windows.Forms.ToolStripButton tsb0001;
    private OxyPlot.WindowsForms.PlotView plotView1;
    private System.Windows.Forms.ToolStripButton tsbZeit;
    private System.Windows.Forms.ToolStripButton tsbWeg;
    private System.Windows.Forms.ToolStripButton tsbFq;
  }
}