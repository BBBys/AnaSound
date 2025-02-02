namespace AnaSound
{
  partial class FASSpec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FASSpec));
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb10 = new System.Windows.Forms.ToolStripButton();
            this.tsb1 = new System.Windows.Forms.ToolStripButton();
            this.tsb01 = new System.Windows.Forms.ToolStripButton();
            this.tsb001 = new System.Windows.Forms.ToolStripButton();
            this.tsb0001 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslFFT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslWin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFq = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslGemittelt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLap = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.White;
            this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView1.Location = new System.Drawing.Point(0, 0);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(919, 450);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
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
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButton6,
            this.toolStripButton2,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton10});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb10
            // 
            this.tsb10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb10.Image = ((System.Drawing.Image)(resources.GetObject("tsb10.Image")));
            this.tsb10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb10.Name = "tsb10";
            this.tsb10.Size = new System.Drawing.Size(46, 29);
            this.tsb10.Tag = "256";
            this.tsb10.Text = "256";
            this.tsb10.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // tsb1
            // 
            this.tsb1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb1.Image = ((System.Drawing.Image)(resources.GetObject("tsb1.Image")));
            this.tsb1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1.Name = "tsb1";
            this.tsb1.Size = new System.Drawing.Size(56, 29);
            this.tsb1.Text = "1024";
            this.tsb1.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // tsb01
            // 
            this.tsb01.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb01.Image = ((System.Drawing.Image)(resources.GetObject("tsb01.Image")));
            this.tsb01.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb01.Name = "tsb01";
            this.tsb01.Size = new System.Drawing.Size(56, 29);
            this.tsb01.Text = "4096";
            this.tsb01.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // tsb001
            // 
            this.tsb001.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb001.Image = ((System.Drawing.Image)(resources.GetObject("tsb001.Image")));
            this.tsb001.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb001.Name = "tsb001";
            this.tsb001.Size = new System.Drawing.Size(98, 29);
            this.tsb001.Text = "Hamming";
            this.tsb001.ToolTipText = "stärkere Unterdrückung der Nebenkeulen\r\nReduktion der Frequenzauflösung";
            this.tsb001.Click += new System.EventHandler(this.tsb10_Click);
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
            this.tsb0001.Size = new System.Drawing.Size(162, 29);
            this.tsb0001.Text = "Blackman-Nuttall";
            this.tsb0001.ToolTipText = "besste Unterdrückung der Nebenkeulen";
            this.tsb0001.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 29);
            this.toolStripButton1.Text = "cos²";
            this.toolStripButton1.ToolTipText = "größten Nebenkeulen maximal unterdrückt";
            this.toolStripButton1.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(62, 29);
            this.toolStripButton4.Text = "5 kHz";
            this.toolStripButton4.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(56, 29);
            this.toolStripButton3.Text = "Max.";
            this.toolStripButton3.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(35, 29);
            this.toolStripButton5.Text = "1x";
            this.toolStripButton5.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(35, 29);
            this.toolStripButton7.Text = "3x";
            this.toolStripButton7.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(35, 29);
            this.toolStripButton6.Text = "9x";
            this.toolStripButton6.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 29);
            this.toolStripButton2.Text = "zeichne";
            this.toolStripButton2.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslFFT,
            this.tslWin,
            this.tslFq,
            this.tslGemittelt,
            this.tslLap});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(919, 30);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslFFT
            // 
            this.tslFFT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslFFT.Name = "tslFFT";
            this.tslFFT.Size = new System.Drawing.Size(20, 25);
            this.tslFFT.Text = "_";
            // 
            // tslWin
            // 
            this.tslWin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslWin.Name = "tslWin";
            this.tslWin.Size = new System.Drawing.Size(20, 25);
            this.tslWin.Text = "_";
            // 
            // tslFq
            // 
            this.tslFq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslFq.Name = "tslFq";
            this.tslFq.Size = new System.Drawing.Size(20, 25);
            this.tslFq.Text = "_";
            // 
            // tslGemittelt
            // 
            this.tslGemittelt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslGemittelt.Name = "tslGemittelt";
            this.tslGemittelt.Size = new System.Drawing.Size(20, 25);
            this.tslGemittelt.Text = "_";
            // 
            // tslLap
            // 
            this.tslLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslLap.Name = "tslLap";
            this.tslLap.Size = new System.Drawing.Size(20, 25);
            this.tslLap.Text = "_";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(43, 29);
            this.toolStripButton8.Text = "1/6";
            this.toolStripButton8.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(43, 29);
            this.toolStripButton9.Text = "1/3";
            this.toolStripButton9.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(24, 29);
            this.toolStripButton10.Text = "-";
            this.toolStripButton10.Click += new System.EventHandler(this.tsb10_Click);
            // 
            // FASSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.plotView1);
            this.Name = "FASSpec";
            this.Text = "FASSpec";
            this.Shown += new System.EventHandler(this.FASSpec_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private OxyPlot.WindowsForms.PlotView plotView1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsb10;
    private System.Windows.Forms.ToolStripButton tsb1;
    private System.Windows.Forms.ToolStripButton tsb01;
    private System.Windows.Forms.ToolStripButton tsb001;
    private System.Windows.Forms.ToolStripButton tsb0001;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
    private System.Windows.Forms.ToolStripButton toolStripButton4;
    private System.Windows.Forms.ToolStripButton toolStripButton3;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tslFFT;
    private System.Windows.Forms.ToolStripStatusLabel tslFq;
    private System.Windows.Forms.ToolStripStatusLabel tslWin;
    private System.Windows.Forms.ToolStripStatusLabel tslGemittelt;
    private System.Windows.Forms.ToolStripStatusLabel tslLap;
    private System.Windows.Forms.ToolStripButton toolStripButton5;
    private System.Windows.Forms.ToolStripButton toolStripButton6;
    private System.Windows.Forms.ToolStripButton toolStripButton7;
    private System.Windows.Forms.ToolStripButton toolStripButton8;
    private System.Windows.Forms.ToolStripButton toolStripButton9;
    private System.Windows.Forms.ToolStripButton toolStripButton10;
  }
}