namespace AnaSound
{
  partial class FInfo
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslAus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslGleich = new System.Windows.Forms.ToolStripStatusLabel();
            this.pUnten = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lLen = new System.Windows.Forms.Label();
            this.lTyp = new System.Windows.Forms.Label();
            this.lPfad = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lAufl = new System.Windows.Forms.Label();
            this.lGesamt = new System.Windows.Forms.Label();
            this.lDauer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lGleich = new System.Windows.Forms.Label();
            this.lMax = new System.Windows.Forms.Label();
            this.lMin = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.pUnten.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAus,
            this.tslGleich});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(542, 30);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslAus
            // 
            this.tslAus.Name = "tslAus";
            this.tslAus.Size = new System.Drawing.Size(128, 25);
            this.tslAus.Text = "Aussteuerung";
            // 
            // tslGleich
            // 
            this.tslGleich.Name = "tslGleich";
            this.tslGleich.Size = new System.Drawing.Size(112, 25);
            this.tslGleich.Text = "Gleichanteil";
            // 
            // pUnten
            // 
            this.pUnten.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pUnten.Controls.Add(this.bClose);
            this.pUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pUnten.Location = new System.Drawing.Point(0, 490);
            this.pUnten.Margin = new System.Windows.Forms.Padding(4);
            this.pUnten.Name = "pUnten";
            this.pUnten.Size = new System.Drawing.Size(542, 42);
            this.pUnten.TabIndex = 1;
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.AutoSize = true;
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(427, 4);
            this.bClose.Margin = new System.Windows.Forms.Padding(4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(99, 30);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "schließe";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lLen);
            this.groupBox1.Controls.Add(this.lTyp);
            this.groupBox1.Controls.Add(this.lPfad);
            this.groupBox1.Controls.Add(this.lName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(542, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // lLen
            // 
            this.lLen.AutoSize = true;
            this.lLen.Location = new System.Drawing.Point(8, 82);
            this.lLen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLen.Name = "lLen";
            this.lLen.Size = new System.Drawing.Size(39, 20);
            this.lLen.TabIndex = 3;
            this.lLen.Text = "len";
            // 
            // lTyp
            // 
            this.lTyp.AutoSize = true;
            this.lTyp.Location = new System.Drawing.Point(8, 62);
            this.lTyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTyp.Name = "lTyp";
            this.lTyp.Size = new System.Drawing.Size(39, 20);
            this.lTyp.TabIndex = 2;
            this.lTyp.Text = "Typ";
            // 
            // lPfad
            // 
            this.lPfad.AutoSize = true;
            this.lPfad.Location = new System.Drawing.Point(8, 42);
            this.lPfad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPfad.Name = "lPfad";
            this.lPfad.Size = new System.Drawing.Size(49, 20);
            this.lPfad.TabIndex = 1;
            this.lPfad.Text = "Pfad";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(8, 22);
            this.lName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(49, 20);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.lAufl);
            this.groupBox2.Controls.Add(this.lGesamt);
            this.groupBox2.Controls.Add(this.lDauer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 112);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(542, 106);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Signal";
            // 
            // lAufl
            // 
            this.lAufl.AutoSize = true;
            this.lAufl.Location = new System.Drawing.Point(8, 62);
            this.lAufl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAufl.Name = "lAufl";
            this.lAufl.Size = new System.Drawing.Size(49, 20);
            this.lAufl.TabIndex = 2;
            this.lAufl.Text = "Aufl";
            // 
            // lGesamt
            // 
            this.lGesamt.AutoSize = true;
            this.lGesamt.Location = new System.Drawing.Point(8, 42);
            this.lGesamt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGesamt.Name = "lGesamt";
            this.lGesamt.Size = new System.Drawing.Size(689, 20);
            this.lGesamt.TabIndex = 1;
            this.lGesamt.Text = "Gesamtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lDauer
            // 
            this.lDauer.AutoSize = true;
            this.lDauer.Location = new System.Drawing.Point(8, 22);
            this.lDauer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDauer.Name = "lDauer";
            this.lDauer.Size = new System.Drawing.Size(59, 20);
            this.lDauer.TabIndex = 0;
            this.lDauer.Text = "Dauer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lGleich);
            this.groupBox3.Controls.Add(this.lMax);
            this.groupBox3.Controls.Add(this.lMin);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 218);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(542, 88);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inhalt";
            // 
            // lGleich
            // 
            this.lGleich.AutoSize = true;
            this.lGleich.Location = new System.Drawing.Point(8, 59);
            this.lGleich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGleich.Name = "lGleich";
            this.lGleich.Size = new System.Drawing.Size(49, 20);
            this.lGleich.TabIndex = 5;
            this.lGleich.Text = "glei";
            // 
            // lMax
            // 
            this.lMax.AutoSize = true;
            this.lMax.Location = new System.Drawing.Point(8, 19);
            this.lMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMax.Name = "lMax";
            this.lMax.Size = new System.Drawing.Size(29, 20);
            this.lMax.TabIndex = 4;
            this.lMax.Text = "ax";
            // 
            // lMin
            // 
            this.lMin.AutoSize = true;
            this.lMin.Location = new System.Drawing.Point(8, 39);
            this.lMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMin.Name = "lMin";
            this.lMin.Size = new System.Drawing.Size(39, 20);
            this.lMin.TabIndex = 3;
            this.lMin.Text = "min";
            // 
            // FInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(542, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pUnten);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Noto Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FInfo";
            this.Text = "Info";
            this.Shown += new System.EventHandler(this.FInfo_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pUnten.ResumeLayout(false);
            this.pUnten.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Panel pUnten;
    private System.Windows.Forms.Button bClose;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lName;
    private System.Windows.Forms.Label lPfad;
    private System.Windows.Forms.Label lTyp;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label lGesamt;
    private System.Windows.Forms.Label lDauer;
    private System.Windows.Forms.Label lLen;
    private System.Windows.Forms.Label lAufl;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label lMax;
    private System.Windows.Forms.Label lMin;
    private System.Windows.Forms.Label lGleich;
    private System.Windows.Forms.ToolStripStatusLabel tslAus;
    private System.Windows.Forms.ToolStripStatusLabel tslGleich;
  }
}