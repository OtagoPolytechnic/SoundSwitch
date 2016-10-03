namespace RecorderTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rbSoundLevel = new System.Windows.Forms.RichTextBox();
            this.lvSource = new System.Windows.Forms.ListView();
            this.Device = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbListen = new System.Windows.Forms.Button();
            this.btnWave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRecordEverything = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rbSoundLevel);
            this.splitContainer1.Panel1.Controls.Add(this.lvSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnRecordEverything);
            this.splitContainer1.Panel2.Controls.Add(this.tbListen);
            this.splitContainer1.Panel2.Controls.Add(this.btnWave);
            this.splitContainer1.Panel2.Controls.Add(this.btnExit);
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Size = new System.Drawing.Size(461, 322);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 0;
            // 
            // rbSoundLevel
            // 
            this.rbSoundLevel.Location = new System.Drawing.Point(4, 120);
            this.rbSoundLevel.Name = "rbSoundLevel";
            this.rbSoundLevel.Size = new System.Drawing.Size(280, 199);
            this.rbSoundLevel.TabIndex = 1;
            this.rbSoundLevel.Text = "";
            this.rbSoundLevel.TextChanged += new System.EventHandler(this.rbDecibel_TextChanged);
            // 
            // lvSource
            // 
            this.lvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Device,
            this.Channels});
            this.lvSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvSource.Location = new System.Drawing.Point(0, 0);
            this.lvSource.MultiSelect = false;
            this.lvSource.Name = "lvSource";
            this.lvSource.Size = new System.Drawing.Size(287, 117);
            this.lvSource.TabIndex = 0;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.Details;
            // 
            // Device
            // 
            this.Device.Text = "Device";
            this.Device.Width = 160;
            // 
            // Channels
            // 
            this.Channels.Text = "Channels";
            this.Channels.Width = 122;
            // 
            // tbListen
            // 
            this.tbListen.Location = new System.Drawing.Point(2, 178);
            this.tbListen.Name = "tbListen";
            this.tbListen.Size = new System.Drawing.Size(161, 23);
            this.tbListen.TabIndex = 5;
            this.tbListen.Text = "Listen";
            this.tbListen.UseVisualStyleBackColor = true;
            this.tbListen.Click += new System.EventHandler(this.tbListen_Click);
            // 
            // btnWave
            // 
            this.btnWave.Location = new System.Drawing.Point(2, 149);
            this.btnWave.Name = "btnWave";
            this.btnWave.Size = new System.Drawing.Size(161, 23);
            this.btnWave.TabIndex = 4;
            this.btnWave.Text = "To WAV";
            this.btnWave.UseVisualStyleBackColor = true;
            this.btnWave.Click += new System.EventHandler(this.btnWave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(2, 296);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(3, 120);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(161, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 94);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(161, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(2, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Refresh Sources";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRecordEverything
            // 
            this.btnRecordEverything.Location = new System.Drawing.Point(2, 207);
            this.btnRecordEverything.Name = "btnRecordEverything";
            this.btnRecordEverything.Size = new System.Drawing.Size(161, 23);
            this.btnRecordEverything.TabIndex = 6;
            this.btnRecordEverything.Text = "Record Everything";
            this.btnRecordEverything.UseVisualStyleBackColor = true;
            this.btnRecordEverything.Click += new System.EventHandler(this.btnRecordEverything_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 322);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Recorder";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvSource;
        private System.Windows.Forms.ColumnHeader Device;
        private System.Windows.Forms.ColumnHeader Channels;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnWave;
        private System.Windows.Forms.RichTextBox rbSoundLevel;
        private System.Windows.Forms.Button tbListen;
        private System.Windows.Forms.Button btnRecordEverything;
    }
}

