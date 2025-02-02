namespace AnaSound
{
  partial class FASMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FASMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schreibeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inhaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ifnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeichneSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeichneLeistungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeichneAKFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequenzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFFT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPSD = new System.Windows.Forms.ToolStripMenuItem();
            this.specgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdEingabe = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslDatei = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslChan = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSr = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslBit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslEncoding = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDauer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFehler = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslWarnung = new System.Windows.Forms.ToolStripStatusLabel();
            this.wv1 = new NAudio.Gui.WaveViewer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.inhaltToolStripMenuItem,
            this.zeitToolStripMenuItem,
            this.frequenzToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.schreibeToolStripMenuItem,
            this.schließeToolStripMenuItem,
            this.endeToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(68, 29);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.öffnenToolStripMenuItem.Text = "öffne";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // schreibeToolStripMenuItem
            // 
            this.schreibeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schreibeToolStripMenuItem.Image")));
            this.schreibeToolStripMenuItem.Name = "schreibeToolStripMenuItem";
            this.schreibeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.schreibeToolStripMenuItem.Text = "schreibe";
            this.schreibeToolStripMenuItem.Click += new System.EventHandler(this.schreibeToolStripMenuItem_Click);
            // 
            // schließeToolStripMenuItem
            // 
            this.schließeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schließeToolStripMenuItem.Image")));
            this.schließeToolStripMenuItem.Name = "schließeToolStripMenuItem";
            this.schließeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.schließeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.schließeToolStripMenuItem.Text = "schließe";
            this.schließeToolStripMenuItem.Click += new System.EventHandler(this.schließeToolStripMenuItem_Click);
            // 
            // endeToolStripMenuItem
            // 
            this.endeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("endeToolStripMenuItem.Image")));
            this.endeToolStripMenuItem.Name = "endeToolStripMenuItem";
            this.endeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.endeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.endeToolStripMenuItem.Text = "Ende";
            this.endeToolStripMenuItem.Click += new System.EventHandler(this.endeToolStripMenuItem_Click);
            // 
            // inhaltToolStripMenuItem
            // 
            this.inhaltToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ifnoToolStripMenuItem});
            this.inhaltToolStripMenuItem.Name = "inhaltToolStripMenuItem";
            this.inhaltToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.inhaltToolStripMenuItem.Text = "Inhalt";
            // 
            // ifnoToolStripMenuItem
            // 
            this.ifnoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ifnoToolStripMenuItem.Image")));
            this.ifnoToolStripMenuItem.Name = "ifnoToolStripMenuItem";
            this.ifnoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.ifnoToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.ifnoToolStripMenuItem.Text = "Info";
            this.ifnoToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // zeitToolStripMenuItem
            // 
            this.zeitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zeichneSignalToolStripMenuItem,
            this.zeichneLeistungToolStripMenuItem,
            this.zeichneAKFToolStripMenuItem});
            this.zeitToolStripMenuItem.Name = "zeitToolStripMenuItem";
            this.zeitToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.zeitToolStripMenuItem.Text = "Zeit";
            // 
            // zeichneSignalToolStripMenuItem
            // 
            this.zeichneSignalToolStripMenuItem.Name = "zeichneSignalToolStripMenuItem";
            this.zeichneSignalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.zeichneSignalToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.zeichneSignalToolStripMenuItem.Text = "zeichne Signal";
            this.zeichneSignalToolStripMenuItem.Click += new System.EventHandler(this.zeichneToolStripMenuItem_Click);
            // 
            // zeichneLeistungToolStripMenuItem
            // 
            this.zeichneLeistungToolStripMenuItem.Name = "zeichneLeistungToolStripMenuItem";
            this.zeichneLeistungToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.zeichneLeistungToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.zeichneLeistungToolStripMenuItem.Text = "zeichne Leistung";
            this.zeichneLeistungToolStripMenuItem.Click += new System.EventHandler(this.zeichneLeistungToolStripMenuItem_Click);
            // 
            // zeichneAKFToolStripMenuItem
            // 
            this.zeichneAKFToolStripMenuItem.Name = "zeichneAKFToolStripMenuItem";
            this.zeichneAKFToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.zeichneAKFToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.zeichneAKFToolStripMenuItem.Text = "zeichne AKF";
            this.zeichneAKFToolStripMenuItem.Click += new System.EventHandler(this.zeichneAKFToolStripMenuItem_Click);
            // 
            // frequenzToolStripMenuItem
            // 
            this.frequenzToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFFT,
            this.tsmPSD,
            this.specgramToolStripMenuItem});
            this.frequenzToolStripMenuItem.Name = "frequenzToolStripMenuItem";
            this.frequenzToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.frequenzToolStripMenuItem.Text = "Frequenz";
            // 
            // tsmFFT
            // 
            this.tsmFFT.Name = "tsmFFT";
            this.tsmFFT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmFFT.Size = new System.Drawing.Size(243, 30);
            this.tsmFFT.Text = "FFT";
            this.tsmFFT.Click += new System.EventHandler(this.tsmFFT_Click);
            // 
            // tsmPSD
            // 
            this.tsmPSD.Name = "tsmPSD";
            this.tsmPSD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmPSD.Size = new System.Drawing.Size(243, 30);
            this.tsmPSD.Text = "PSD";
            this.tsmPSD.Click += new System.EventHandler(this.tsmPSD_Click);
            // 
            // specgramToolStripMenuItem
            // 
            this.specgramToolStripMenuItem.Name = "specgramToolStripMenuItem";
            this.specgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.specgramToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.specgramToolStripMenuItem.Text = "Spec\'gram";
            this.specgramToolStripMenuItem.Click += new System.EventHandler(this.specgramToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apapToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(66, 29);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // apapToolStripMenuItem
            // 
            this.apapToolStripMenuItem.Name = "apapToolStripMenuItem";
            this.apapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.apapToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.apapToolStripMenuItem.Text = "Adap";
            this.apapToolStripMenuItem.Click += new System.EventHandler(this.apapToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.playToolStripMenuItem.Text = "play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.spieleAbToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.stopToolStripMenuItem.Text = "stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ofdEingabe
            // 
            this.ofdEingabe.DefaultExt = "wav";
            this.ofdEingabe.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslDatei,
            this.tslChan,
            this.tslSr,
            this.tslBit,
            this.tslEncoding,
            this.tslDauer,
            this.tslFehler,
            this.tslWarnung});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 30);
            this.statusStrip1.TabIndex = 1;
            // 
            // tslDatei
            // 
            this.tslDatei.Name = "tslDatei";
            this.tslDatei.Size = new System.Drawing.Size(65, 25);
            this.tslDatei.Text = "Datei?";
            // 
            // tslChan
            // 
            this.tslChan.Name = "tslChan";
            this.tslChan.Size = new System.Drawing.Size(50, 25);
            this.tslChan.Text = "0 Ch";
            // 
            // tslSr
            // 
            this.tslSr.Name = "tslSr";
            this.tslSr.Size = new System.Drawing.Size(58, 25);
            this.tslSr.Text = "0 kHz";
            // 
            // tslBit
            // 
            this.tslBit.Name = "tslBit";
            this.tslBit.Size = new System.Drawing.Size(49, 25);
            this.tslBit.Text = "0 Bit";
            // 
            // tslEncoding
            // 
            this.tslEncoding.Name = "tslEncoding";
            this.tslEncoding.Size = new System.Drawing.Size(0, 25);
            // 
            // tslDauer
            // 
            this.tslDauer.Name = "tslDauer";
            this.tslDauer.Size = new System.Drawing.Size(35, 25);
            this.tslDauer.Text = "0 s";
            // 
            // tslFehler
            // 
            this.tslFehler.BackColor = System.Drawing.Color.Red;
            this.tslFehler.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslFehler.ForeColor = System.Drawing.Color.Yellow;
            this.tslFehler.Name = "tslFehler";
            this.tslFehler.Size = new System.Drawing.Size(20, 25);
            this.tslFehler.Text = "_";
            // 
            // tslWarnung
            // 
            this.tslWarnung.BackColor = System.Drawing.Color.Yellow;
            this.tslWarnung.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslWarnung.Name = "tslWarnung";
            this.tslWarnung.Size = new System.Drawing.Size(20, 25);
            this.tslWarnung.Text = "_";
            // 
            // wv1
            // 
            this.wv1.BackColor = System.Drawing.Color.White;
            this.wv1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wv1.Location = new System.Drawing.Point(0, 246);
            this.wv1.Name = "wv1";
            this.wv1.SamplesPerPixel = 128;
            this.wv1.Size = new System.Drawing.Size(970, 174);
            this.wv1.StartPosition = ((long)(0));
            this.wv1.TabIndex = 2;
            this.wv1.WaveStream = null;
            // 
            // FASMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 450);
            this.Controls.Add(this.wv1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FASMain";
            this.Text = "Form1";
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
    private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem endeToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog ofdEingabe;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tslDatei;
    private System.Windows.Forms.ToolStripMenuItem inhaltToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ifnoToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel tslChan;
    private System.Windows.Forms.ToolStripStatusLabel tslSr;
    private System.Windows.Forms.ToolStripStatusLabel tslDauer;
    private System.Windows.Forms.ToolStripStatusLabel tslBit;
    private System.Windows.Forms.ToolStripMenuItem zeitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem zeichneSignalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem frequenzToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem zeichneLeistungToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem schreibeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem apapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem schließeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem zeichneAKFToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel tslFehler;
    private System.Windows.Forms.ToolStripStatusLabel tslWarnung;
    private System.Windows.Forms.ToolStripStatusLabel tslEncoding;
    private System.Windows.Forms.ToolStripMenuItem tsmFFT;
    private System.Windows.Forms.ToolStripMenuItem tsmPSD;
    private NAudio.Gui.WaveViewer wv1;
    private System.Windows.Forms.ToolStripMenuItem specgramToolStripMenuItem;
  }
}

