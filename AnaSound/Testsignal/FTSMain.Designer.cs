namespace Testsignal
{
  partial class FTSMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTSMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDatei = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbParam4 = new System.Windows.Forms.TextBox();
            this.tbParam3 = new System.Windows.Forms.TextBox();
            this.tbParam2 = new System.Windows.Forms.TextBox();
            this.lParam = new System.Windows.Forms.Label();
            this.tbParam = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbTyp = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbKonstant = new System.Windows.Forms.RadioButton();
            this.rbRausch = new System.Windows.Forms.RadioButton();
            this.rbSchweb = new System.Windows.Forms.RadioButton();
            this.rbSin = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbDauer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbChan = new System.Windows.Forms.Label();
            this.rbStereo = new System.Windows.Forms.RadioButton();
            this.rbMono = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSR = new System.Windows.Forms.Label();
            this.rb48 = new System.Windows.Forms.RadioButton();
            this.rb44 = new System.Windows.Forms.RadioButton();
            this.rb22 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.rb8 = new System.Windows.Forms.RadioButton();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.bErzeuge = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rbT5 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDatei);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datei";
            // 
            // tbDatei
            // 
            this.tbDatei.Location = new System.Drawing.Point(59, 12);
            this.tbDatei.Name = "tbDatei";
            this.tbDatei.Size = new System.Drawing.Size(562, 22);
            this.tbDatei.TabIndex = 1;
            this.tbDatei.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 234);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Signal";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbParam4);
            this.groupBox7.Controls.Add(this.tbParam3);
            this.groupBox7.Controls.Add(this.tbParam2);
            this.groupBox7.Controls.Add(this.lParam);
            this.groupBox7.Controls.Add(this.tbParam);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(468, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(191, 213);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Parameter";
            // 
            // tbParam4
            // 
            this.tbParam4.Location = new System.Drawing.Point(6, 109);
            this.tbParam4.Name = "tbParam4";
            this.tbParam4.Size = new System.Drawing.Size(173, 22);
            this.tbParam4.TabIndex = 4;
            this.tbParam4.Enter += new System.EventHandler(this.tbParam_Enter);
            this.tbParam4.Leave += new System.EventHandler(this.textBoxLeave);
            // 
            // tbParam3
            // 
            this.tbParam3.Location = new System.Drawing.Point(6, 86);
            this.tbParam3.Name = "tbParam3";
            this.tbParam3.Size = new System.Drawing.Size(173, 22);
            this.tbParam3.TabIndex = 3;
            this.tbParam3.Enter += new System.EventHandler(this.tbParam_Enter);
            this.tbParam3.Leave += new System.EventHandler(this.textBoxLeave);
            // 
            // tbParam2
            // 
            this.tbParam2.Location = new System.Drawing.Point(6, 61);
            this.tbParam2.Name = "tbParam2";
            this.tbParam2.Size = new System.Drawing.Size(173, 22);
            this.tbParam2.TabIndex = 2;
            this.tbParam2.Enter += new System.EventHandler(this.tbParam_Enter);
            this.tbParam2.Leave += new System.EventHandler(this.textBoxLeave);
            // 
            // lParam
            // 
            this.lParam.AutoSize = true;
            this.lParam.Location = new System.Drawing.Point(6, 19);
            this.lParam.Name = "lParam";
            this.lParam.Size = new System.Drawing.Size(78, 17);
            this.lParam.TabIndex = 1;
            this.lParam.Text = "Parameter:";
            // 
            // tbParam
            // 
            this.tbParam.Location = new System.Drawing.Point(6, 38);
            this.tbParam.Name = "tbParam";
            this.tbParam.Size = new System.Drawing.Size(173, 22);
            this.tbParam.TabIndex = 0;
            this.tbParam.Enter += new System.EventHandler(this.tbParam_Enter);
            this.tbParam.Leave += new System.EventHandler(this.textBoxLeave);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbT5);
            this.groupBox6.Controls.Add(this.radioButton1);
            this.groupBox6.Controls.Add(this.tbTyp);
            this.groupBox6.Controls.Add(this.radioButton3);
            this.groupBox6.Controls.Add(this.rbKonstant);
            this.groupBox6.Controls.Add(this.rbRausch);
            this.groupBox6.Controls.Add(this.rbSchweb);
            this.groupBox6.Controls.Add(this.rbSin);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(350, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(118, 213);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Typ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 110);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 21);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Wobbel";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // tbTyp
            // 
            this.tbTyp.AutoSize = true;
            this.tbTyp.BackColor = System.Drawing.Color.White;
            this.tbTyp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTyp.ForeColor = System.Drawing.Color.Black;
            this.tbTyp.Location = new System.Drawing.Point(6, 180);
            this.tbTyp.Name = "tbTyp";
            this.tbTyp.Size = new System.Drawing.Size(19, 19);
            this.tbTyp.TabIndex = 7;
            this.tbTyp.Text = "0";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 132);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 21);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Knall";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // rbKonstant
            // 
            this.rbKonstant.AutoSize = true;
            this.rbKonstant.Location = new System.Drawing.Point(6, 86);
            this.rbKonstant.Name = "rbKonstant";
            this.rbKonstant.Size = new System.Drawing.Size(83, 21);
            this.rbKonstant.TabIndex = 3;
            this.rbKonstant.TabStop = true;
            this.rbKonstant.Text = "konstant";
            this.rbKonstant.UseVisualStyleBackColor = true;
            this.rbKonstant.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // rbRausch
            // 
            this.rbRausch.AutoSize = true;
            this.rbRausch.Location = new System.Drawing.Point(6, 63);
            this.rbRausch.Name = "rbRausch";
            this.rbRausch.Size = new System.Drawing.Size(93, 21);
            this.rbRausch.TabIndex = 2;
            this.rbRausch.TabStop = true;
            this.rbRausch.Text = "Rauschen";
            this.rbRausch.UseVisualStyleBackColor = true;
            this.rbRausch.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // rbSchweb
            // 
            this.rbSchweb.AutoSize = true;
            this.rbSchweb.Location = new System.Drawing.Point(6, 40);
            this.rbSchweb.Name = "rbSchweb";
            this.rbSchweb.Size = new System.Drawing.Size(102, 21);
            this.rbSchweb.TabIndex = 1;
            this.rbSchweb.TabStop = true;
            this.rbSchweb.Text = "Schwebung";
            this.rbSchweb.UseVisualStyleBackColor = true;
            this.rbSchweb.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // rbSin
            // 
            this.rbSin.AutoSize = true;
            this.rbSin.Location = new System.Drawing.Point(6, 17);
            this.rbSin.Name = "rbSin";
            this.rbSin.Size = new System.Drawing.Size(64, 21);
            this.rbSin.TabIndex = 0;
            this.rbSin.TabStop = true;
            this.rbSin.Text = "Sinus";
            this.rbSin.UseVisualStyleBackColor = true;
            this.rbSin.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbDauer);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(230, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 213);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dauer";
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(6, 19);
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.Size = new System.Drawing.Size(105, 22);
            this.tbDauer.TabIndex = 1;
            this.tbDauer.Enter += new System.EventHandler(this.tbParam_Enter);
            this.tbDauer.Leave += new System.EventHandler(this.textBoxLeave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbChan);
            this.groupBox4.Controls.Add(this.rbStereo);
            this.groupBox4.Controls.Add(this.rbMono);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(120, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 213);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kanäle";
            // 
            // tbChan
            // 
            this.tbChan.AutoSize = true;
            this.tbChan.BackColor = System.Drawing.Color.White;
            this.tbChan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChan.ForeColor = System.Drawing.Color.Black;
            this.tbChan.Location = new System.Drawing.Point(6, 180);
            this.tbChan.Name = "tbChan";
            this.tbChan.Size = new System.Drawing.Size(19, 19);
            this.tbChan.TabIndex = 6;
            this.tbChan.Text = "0";
            // 
            // rbStereo
            // 
            this.rbStereo.AutoSize = true;
            this.rbStereo.Location = new System.Drawing.Point(6, 40);
            this.rbStereo.Name = "rbStereo";
            this.rbStereo.Size = new System.Drawing.Size(71, 21);
            this.rbStereo.TabIndex = 1;
            this.rbStereo.TabStop = true;
            this.rbStereo.Text = "Stereo";
            this.rbStereo.UseVisualStyleBackColor = true;
            this.rbStereo.CheckedChanged += new System.EventHandler(this.rbMono_CheckedChanged);
            // 
            // rbMono
            // 
            this.rbMono.AutoSize = true;
            this.rbMono.Location = new System.Drawing.Point(6, 17);
            this.rbMono.Name = "rbMono";
            this.rbMono.Size = new System.Drawing.Size(64, 21);
            this.rbMono.TabIndex = 0;
            this.rbMono.TabStop = true;
            this.rbMono.Text = "Mono";
            this.rbMono.UseVisualStyleBackColor = true;
            this.rbMono.CheckedChanged += new System.EventHandler(this.rbMono_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSR);
            this.groupBox3.Controls.Add(this.rb48);
            this.groupBox3.Controls.Add(this.rb44);
            this.groupBox3.Controls.Add(this.rb22);
            this.groupBox3.Controls.Add(this.rb11);
            this.groupBox3.Controls.Add(this.rb8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 213);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Samplerate";
            // 
            // tbSR
            // 
            this.tbSR.AutoSize = true;
            this.tbSR.BackColor = System.Drawing.Color.White;
            this.tbSR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSR.ForeColor = System.Drawing.Color.Black;
            this.tbSR.Location = new System.Drawing.Point(6, 180);
            this.tbSR.Name = "tbSR";
            this.tbSR.Size = new System.Drawing.Size(19, 19);
            this.tbSR.TabIndex = 5;
            this.tbSR.Text = "0";
            // 
            // rb48
            // 
            this.rb48.AutoSize = true;
            this.rb48.Location = new System.Drawing.Point(6, 109);
            this.rb48.Name = "rb48";
            this.rb48.Size = new System.Drawing.Size(73, 21);
            this.rb48.TabIndex = 4;
            this.rb48.TabStop = true;
            this.rb48.Text = "48.000";
            this.rb48.UseVisualStyleBackColor = true;
            this.rb48.Click += new System.EventHandler(this.rb8_Click);
            // 
            // rb44
            // 
            this.rb44.AutoSize = true;
            this.rb44.Location = new System.Drawing.Point(6, 86);
            this.rb44.Name = "rb44";
            this.rb44.Size = new System.Drawing.Size(73, 21);
            this.rb44.TabIndex = 3;
            this.rb44.TabStop = true;
            this.rb44.Text = "44.100";
            this.rb44.UseVisualStyleBackColor = true;
            this.rb44.Click += new System.EventHandler(this.rb8_Click);
            // 
            // rb22
            // 
            this.rb22.AutoSize = true;
            this.rb22.Location = new System.Drawing.Point(6, 63);
            this.rb22.Name = "rb22";
            this.rb22.Size = new System.Drawing.Size(73, 21);
            this.rb22.TabIndex = 2;
            this.rb22.TabStop = true;
            this.rb22.Text = "22.050";
            this.rb22.UseVisualStyleBackColor = true;
            this.rb22.Click += new System.EventHandler(this.rb8_Click);
            // 
            // rb11
            // 
            this.rb11.AutoSize = true;
            this.rb11.Location = new System.Drawing.Point(6, 40);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(73, 21);
            this.rb11.TabIndex = 1;
            this.rb11.TabStop = true;
            this.rb11.Text = "11.025";
            this.rb11.UseVisualStyleBackColor = true;
            this.rb11.Click += new System.EventHandler(this.rb8_Click);
            // 
            // rb8
            // 
            this.rb8.AutoSize = true;
            this.rb8.Location = new System.Drawing.Point(6, 17);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(65, 21);
            this.rb8.TabIndex = 0;
            this.rb8.TabStop = true;
            this.rb8.Text = "8.000";
            this.rb8.UseVisualStyleBackColor = true;
            this.rb8.Click += new System.EventHandler(this.rb8_Click);
            // 
            // sfd1
            // 
            this.sfd1.DefaultExt = "wav";
            this.sfd1.Title = "Ausgabedatei";
            // 
            // bErzeuge
            // 
            this.bErzeuge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bErzeuge.Location = new System.Drawing.Point(382, 303);
            this.bErzeuge.Name = "bErzeuge";
            this.bErzeuge.Size = new System.Drawing.Size(124, 27);
            this.bErzeuge.TabIndex = 2;
            this.bErzeuge.Text = "erzeuge Signal";
            this.bErzeuge.UseVisualStyleBackColor = true;
            this.bErzeuge.Click += new System.EventHandler(this.bErzeuge_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(512, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "beende Programm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbT5
            // 
            this.rbT5.AutoSize = true;
            this.rbT5.Location = new System.Drawing.Point(6, 156);
            this.rbT5.Name = "rbT5";
            this.rbT5.Size = new System.Drawing.Size(94, 21);
            this.rbT5.TabIndex = 9;
            this.rbT5.TabStop = true;
            this.rbT5.Text = "5-Ton-Ruf";
            this.rbT5.UseVisualStyleBackColor = true;
            this.rbT5.CheckedChanged += new System.EventHandler(this.rbT5_CheckedChanged);
            this.rbT5.Click += new System.EventHandler(this.rbSin_Click);
            // 
            // FTSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bErzeuge);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FTSMain";
            this.Text = "Testsignal-Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FTSMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox tbDatei;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.SaveFileDialog sfd1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton rb48;
    private System.Windows.Forms.RadioButton rb44;
    private System.Windows.Forms.RadioButton rb22;
    private System.Windows.Forms.RadioButton rb11;
    private System.Windows.Forms.RadioButton rb8;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.RadioButton radioButton3;
    private System.Windows.Forms.RadioButton rbKonstant;
    private System.Windows.Forms.RadioButton rbRausch;
    private System.Windows.Forms.RadioButton rbSchweb;
    private System.Windows.Forms.RadioButton rbSin;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.RadioButton rbStereo;
    private System.Windows.Forms.RadioButton rbMono;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.Label lParam;
    private System.Windows.Forms.TextBox tbParam;
    private System.Windows.Forms.Label tbSR;
    private System.Windows.Forms.Label tbChan;
    private System.Windows.Forms.Label tbTyp;
    private System.Windows.Forms.Button bErzeuge;
    private System.Windows.Forms.TextBox tbParam2;
    private System.Windows.Forms.TextBox tbParam3;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox tbParam4;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.TextBox tbDauer;
    private System.Windows.Forms.RadioButton rbT5;
  }
}

