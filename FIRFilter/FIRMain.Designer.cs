namespace FIRFilter
{
  partial class FIRMain
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.leseAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.leseFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.schließeAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ofdEingabe = new System.Windows.Forms.OpenFileDialog();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.statusStrip1.Location = new System.Drawing.Point(0, 428);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // dateiToolStripMenuItem
      // 
      this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leseAudioToolStripMenuItem,
            this.leseFilterToolStripMenuItem,
            this.beendenToolStripMenuItem,
            this.schließeAudioToolStripMenuItem});
      this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
      this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
      this.dateiToolStripMenuItem.Text = "Datei";
      // 
      // beendenToolStripMenuItem
      // 
      this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
      this.beendenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.beendenToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
      this.beendenToolStripMenuItem.Text = "beende";
      this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
      // 
      // leseAudioToolStripMenuItem
      // 
      this.leseAudioToolStripMenuItem.Name = "leseAudioToolStripMenuItem";
      this.leseAudioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.leseAudioToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
      this.leseAudioToolStripMenuItem.Text = "öffne Audio";
      this.leseAudioToolStripMenuItem.Click += new System.EventHandler(this.leseAudioToolStripMenuItem_Click);
      // 
      // leseFilterToolStripMenuItem
      // 
      this.leseFilterToolStripMenuItem.Name = "leseFilterToolStripMenuItem";
      this.leseFilterToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
      this.leseFilterToolStripMenuItem.Text = "lese Filter";
      // 
      // schließeAudioToolStripMenuItem
      // 
      this.schließeAudioToolStripMenuItem.Name = "schließeAudioToolStripMenuItem";
      this.schließeAudioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.schließeAudioToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
      this.schließeAudioToolStripMenuItem.Text = "schließe Audio";
      // 
      // ofdEingabe
      // 
      this.ofdEingabe.DefaultExt = "wav";
      this.ofdEingabe.FileName = "openFileDialog1";
      // 
      // FIRMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FIRMain";
      this.Text = "FIR-Filter";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem leseAudioToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem leseFilterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripMenuItem schließeAudioToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog ofdEingabe;
  }
}

