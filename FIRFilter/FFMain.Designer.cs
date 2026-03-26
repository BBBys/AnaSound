namespace FIRFilter
{
  partial class FFMain
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
      this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.öffneSigalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.öffneFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.schließeSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.schließeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslDatei = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslChan = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslSr = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslBit = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslEncoding = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslDauer = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFehler = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslWarnung = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFDatei = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFChan = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFSr = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFBit = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFEncoding = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFDauer = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFFehler = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslFWarnung = new System.Windows.Forms.ToolStripStatusLabel();
      this.ofdEingabe = new System.Windows.Forms.OpenFileDialog();
      this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.filterPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.filterStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(884, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // dateiToolStripMenuItem
      // 
      this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffneSigalToolStripMenuItem,
            this.öffneFilterToolStripMenuItem,
            this.toolStripSeparator2,
            this.schließeSignalToolStripMenuItem,
            this.schließeFilterToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
      this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
      this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
      this.dateiToolStripMenuItem.Text = "Datei";
      // 
      // öffneSigalToolStripMenuItem
      // 
      this.öffneSigalToolStripMenuItem.Name = "öffneSigalToolStripMenuItem";
      this.öffneSigalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.öffneSigalToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
      this.öffneSigalToolStripMenuItem.Text = "öffne Signal";
      this.öffneSigalToolStripMenuItem.Click += new System.EventHandler(this.öffneSigalToolStripMenuItem_Click);
      // 
      // öffneFilterToolStripMenuItem
      // 
      this.öffneFilterToolStripMenuItem.Name = "öffneFilterToolStripMenuItem";
      this.öffneFilterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
      this.öffneFilterToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
      this.öffneFilterToolStripMenuItem.Text = "öffne Filter";
      this.öffneFilterToolStripMenuItem.Click += new System.EventHandler(this.öffneFilterToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(337, 6);
      // 
      // schließeSignalToolStripMenuItem
      // 
      this.schließeSignalToolStripMenuItem.Name = "schließeSignalToolStripMenuItem";
      this.schließeSignalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.schließeSignalToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
      this.schließeSignalToolStripMenuItem.Text = "schließe Signal";
      this.schließeSignalToolStripMenuItem.Click += new System.EventHandler(this.schließeSignalToolStripMenuItem_Click);
      // 
      // schließeFilterToolStripMenuItem
      // 
      this.schließeFilterToolStripMenuItem.Name = "schließeFilterToolStripMenuItem";
      this.schließeFilterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
      this.schließeFilterToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
      this.schließeFilterToolStripMenuItem.Text = "schließe Filter";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(337, 6);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.toolStripMenuItem2.Size = new System.Drawing.Size(340, 26);
      this.toolStripMenuItem2.Text = "beende";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tslDatei,
            this.tslChan,
            this.tslSr,
            this.tslBit,
            this.tslEncoding,
            this.tslDauer,
            this.tslFehler,
            this.tslWarnung,
            this.toolStripStatusLabel2,
            this.tslFDatei,
            this.tslFChan,
            this.tslFSr,
            this.tslFBit,
            this.tslFEncoding,
            this.tslFDauer,
            this.tslFFehler,
            this.tslFWarnung});
      this.statusStrip1.Location = new System.Drawing.Point(0, 419);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(884, 31);
      this.statusStrip1.TabIndex = 2;
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 25);
      this.toolStripStatusLabel1.Text = "Audio:";
      // 
      // tslDatei
      // 
      this.tslDatei.Name = "tslDatei";
      this.tslDatei.Size = new System.Drawing.Size(52, 25);
      this.tslDatei.Text = "Datei?";
      // 
      // tslChan
      // 
      this.tslChan.Name = "tslChan";
      this.tslChan.Size = new System.Drawing.Size(38, 25);
      this.tslChan.Text = "0 Ch";
      // 
      // tslSr
      // 
      this.tslSr.Name = "tslSr";
      this.tslSr.Size = new System.Drawing.Size(46, 25);
      this.tslSr.Text = "0 kHz";
      // 
      // tslBit
      // 
      this.tslBit.Name = "tslBit";
      this.tslBit.Size = new System.Drawing.Size(39, 25);
      this.tslBit.Text = "0 Bit";
      // 
      // tslEncoding
      // 
      this.tslEncoding.Name = "tslEncoding";
      this.tslEncoding.Size = new System.Drawing.Size(78, 25);
      this.tslEncoding.Text = "Encoding?";
      // 
      // tslDauer
      // 
      this.tslDauer.Name = "tslDauer";
      this.tslDauer.Size = new System.Drawing.Size(27, 25);
      this.tslDauer.Text = "0 s";
      // 
      // tslFehler
      // 
      this.tslFehler.BackColor = System.Drawing.Color.Red;
      this.tslFehler.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tslFehler.ForeColor = System.Drawing.Color.Yellow;
      this.tslFehler.Name = "tslFehler";
      this.tslFehler.Size = new System.Drawing.Size(19, 25);
      this.tslFehler.Text = "_";
      // 
      // tslWarnung
      // 
      this.tslWarnung.BackColor = System.Drawing.Color.Yellow;
      this.tslWarnung.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tslWarnung.Name = "tslWarnung";
      this.tslWarnung.Size = new System.Drawing.Size(19, 25);
      this.tslWarnung.Text = "_";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 25);
      this.toolStripStatusLabel2.Text = "Filter:";
      // 
      // tslFDatei
      // 
      this.tslFDatei.Name = "tslFDatei";
      this.tslFDatei.Size = new System.Drawing.Size(52, 25);
      this.tslFDatei.Text = "Datei?";
      // 
      // tslFChan
      // 
      this.tslFChan.Name = "tslFChan";
      this.tslFChan.Size = new System.Drawing.Size(38, 25);
      this.tslFChan.Text = "0 Ch";
      // 
      // tslFSr
      // 
      this.tslFSr.Name = "tslFSr";
      this.tslFSr.Size = new System.Drawing.Size(46, 25);
      this.tslFSr.Text = "0 kHz";
      // 
      // tslFBit
      // 
      this.tslFBit.Name = "tslFBit";
      this.tslFBit.Size = new System.Drawing.Size(39, 25);
      this.tslFBit.Text = "0 Bit";
      // 
      // tslFEncoding
      // 
      this.tslFEncoding.Name = "tslFEncoding";
      this.tslFEncoding.Size = new System.Drawing.Size(78, 25);
      this.tslFEncoding.Text = "Encoding?";
      // 
      // tslFDauer
      // 
      this.tslFDauer.Name = "tslFDauer";
      this.tslFDauer.Size = new System.Drawing.Size(27, 25);
      this.tslFDauer.Text = "0 s";
      // 
      // tslFFehler
      // 
      this.tslFFehler.BackColor = System.Drawing.Color.Red;
      this.tslFFehler.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tslFFehler.ForeColor = System.Drawing.Color.Yellow;
      this.tslFFehler.Name = "tslFFehler";
      this.tslFFehler.Size = new System.Drawing.Size(19, 25);
      this.tslFFehler.Text = "_";
      // 
      // tslFWarnung
      // 
      this.tslFWarnung.BackColor = System.Drawing.Color.Yellow;
      this.tslFWarnung.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tslFWarnung.Name = "tslFWarnung";
      this.tslFWarnung.Size = new System.Drawing.Size(19, 25);
      this.tslFWarnung.Text = "_";
      // 
      // ofdEingabe
      // 
      this.ofdEingabe.DefaultExt = "wav";
      // 
      // audioToolStripMenuItem
      // 
      this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator3,
            this.filterPlayToolStripMenuItem,
            this.filterStopToolStripMenuItem});
      this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
      this.audioToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
      this.audioToolStripMenuItem.Text = "Audio";
      // 
      // playToolStripMenuItem
      // 
      this.playToolStripMenuItem.Name = "playToolStripMenuItem";
      this.playToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.playToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
      this.playToolStripMenuItem.Text = "play";
      // 
      // stopToolStripMenuItem
      // 
      this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
      this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.stopToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
      this.stopToolStripMenuItem.Text = "stop";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(312, 6);
      // 
      // filterPlayToolStripMenuItem
      // 
      this.filterPlayToolStripMenuItem.Name = "filterPlayToolStripMenuItem";
      this.filterPlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
      this.filterPlayToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
      this.filterPlayToolStripMenuItem.Text = "Filter play";
      // 
      // filterStopToolStripMenuItem
      // 
      this.filterStopToolStripMenuItem.Name = "filterStopToolStripMenuItem";
      this.filterStopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.filterStopToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
      this.filterStopToolStripMenuItem.Text = "Filter stop";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // FFMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(884, 450);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FFMain";
      this.Text = "FFMain";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem öffneSigalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem öffneFilterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem schließeSignalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem schließeFilterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tslDatei;
    private System.Windows.Forms.ToolStripStatusLabel tslChan;
    private System.Windows.Forms.ToolStripStatusLabel tslSr;
    private System.Windows.Forms.ToolStripStatusLabel tslBit;
    private System.Windows.Forms.ToolStripStatusLabel tslEncoding;
    private System.Windows.Forms.ToolStripStatusLabel tslDauer;
    private System.Windows.Forms.ToolStripStatusLabel tslFehler;
    private System.Windows.Forms.ToolStripStatusLabel tslWarnung;
    private System.Windows.Forms.OpenFileDialog ofdEingabe;
    private System.Windows.Forms.ToolStripStatusLabel tslFDatei;
    private System.Windows.Forms.ToolStripStatusLabel tslFChan;
    private System.Windows.Forms.ToolStripStatusLabel tslFSr;
    private System.Windows.Forms.ToolStripStatusLabel tslFBit;
    private System.Windows.Forms.ToolStripStatusLabel tslFDauer;
    private System.Windows.Forms.ToolStripStatusLabel tslFFehler;
    private System.Windows.Forms.ToolStripStatusLabel tslFWarnung;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.ToolStripStatusLabel tslFEncoding;
    private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem filterPlayToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem filterStopToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
  }
}

