namespace sound_switch
{
    partial class HomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnToggleListen = new System.Windows.Forms.Button();
            this.btnBindings = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnGit = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelBindings = new System.Windows.Forms.Panel();
            this.dgvBind = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveBind = new System.Windows.Forms.Button();
            this.btnNewBind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackBind = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.tbSeconds = new System.Windows.Forms.TextBox();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.lblRecordingSeconds = new System.Windows.Forms.Label();
            this.btnSetValues = new System.Windows.Forms.Button();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCurrentDevice = new System.Windows.Forms.Label();
            this.lvSource = new System.Windows.Forms.ListView();
            this.device = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBackSet = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelBindings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBind)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "OP-SoundSwitch";
            // 
            // btnToggleListen
            // 
            this.btnToggleListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleListen.Location = new System.Drawing.Point(58, 86);
            this.btnToggleListen.Name = "btnToggleListen";
            this.btnToggleListen.Size = new System.Drawing.Size(169, 145);
            this.btnToggleListen.TabIndex = 1;
            this.btnToggleListen.Text = "Start Listening";
            this.btnToggleListen.UseVisualStyleBackColor = true;
            this.btnToggleListen.Click += new System.EventHandler(this.btnToggleListen_Click);
            // 
            // btnBindings
            // 
            this.btnBindings.Location = new System.Drawing.Point(380, 64);
            this.btnBindings.Name = "btnBindings";
            this.btnBindings.Size = new System.Drawing.Size(155, 40);
            this.btnBindings.TabIndex = 2;
            this.btnBindings.Text = "Bindings";
            this.btnBindings.UseVisualStyleBackColor = true;
            this.btnBindings.Click += new System.EventHandler(this.btnBindings_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(380, 142);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(155, 40);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnGit
            // 
            this.btnGit.Location = new System.Drawing.Point(380, 222);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(155, 40);
            this.btnGit.TabIndex = 4;
            this.btnGit.Text = "Github";
            this.btnGit.UseVisualStyleBackColor = true;
            this.btnGit.Click += new System.EventHandler(this.btnGit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.button2);
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnGit);
            this.panelMain.Controls.Add(this.btnToggleListen);
            this.panelMain.Controls.Add(this.btnSettings);
            this.panelMain.Controls.Add(this.btnBindings);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(640, 320);
            this.panelMain.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(197, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test KeySending";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test Current Unprocessed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelBindings
            // 
            this.panelBindings.Controls.Add(this.dgvBind);
            this.panelBindings.Controls.Add(this.btnRemoveBind);
            this.panelBindings.Controls.Add(this.btnNewBind);
            this.panelBindings.Controls.Add(this.label3);
            this.panelBindings.Controls.Add(this.label2);
            this.panelBindings.Controls.Add(this.btnBackBind);
            this.panelBindings.Location = new System.Drawing.Point(0, 0);
            this.panelBindings.Name = "panelBindings";
            this.panelBindings.Size = new System.Drawing.Size(640, 320);
            this.panelBindings.TabIndex = 6;
            this.panelBindings.Visible = false;
            // 
            // dgvBind
            // 
            this.dgvBind.AllowUserToDeleteRows = false;
            this.dgvBind.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.bindCode,
            this.path});
            this.dgvBind.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBind.Location = new System.Drawing.Point(207, 59);
            this.dgvBind.Name = "dgvBind";
            this.dgvBind.RowHeadersVisible = false;
            this.dgvBind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBind.Size = new System.Drawing.Size(400, 239);
            this.dgvBind.TabIndex = 8;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // bindCode
            // 
            this.bindCode.HeaderText = "Bind Code";
            this.bindCode.Name = "bindCode";
            // 
            // path
            // 
            this.path.HeaderText = "Path";
            this.path.Name = "path";
            // 
            // btnRemoveBind
            // 
            this.btnRemoveBind.Location = new System.Drawing.Point(21, 105);
            this.btnRemoveBind.Name = "btnRemoveBind";
            this.btnRemoveBind.Size = new System.Drawing.Size(155, 40);
            this.btnRemoveBind.TabIndex = 7;
            this.btnRemoveBind.Text = "Remove Bind";
            this.btnRemoveBind.UseVisualStyleBackColor = true;
            this.btnRemoveBind.Click += new System.EventHandler(this.btnRemoveBind_Click);
            // 
            // btnNewBind
            // 
            this.btnNewBind.Location = new System.Drawing.Point(21, 59);
            this.btnNewBind.Name = "btnNewBind";
            this.btnNewBind.Size = new System.Drawing.Size(155, 40);
            this.btnNewBind.TabIndex = 6;
            this.btnNewBind.Text = "New Bind";
            this.btnNewBind.UseVisualStyleBackColor = true;
            this.btnNewBind.Click += new System.EventHandler(this.btnNewBind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(233, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bindings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "OP-SoundSwitch";
            // 
            // btnBackBind
            // 
            this.btnBackBind.Location = new System.Drawing.Point(21, 258);
            this.btnBackBind.Name = "btnBackBind";
            this.btnBackBind.Size = new System.Drawing.Size(155, 40);
            this.btnBackBind.TabIndex = 2;
            this.btnBackBind.Text = "Back";
            this.btnBackBind.UseVisualStyleBackColor = true;
            this.btnBackBind.Click += new System.EventHandler(this.btnBackBind_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.tbSeconds);
            this.panelSettings.Controls.Add(this.tbThreshold);
            this.panelSettings.Controls.Add(this.tbDeviceName);
            this.panelSettings.Controls.Add(this.lblRecordingSeconds);
            this.panelSettings.Controls.Add(this.btnSetValues);
            this.panelSettings.Controls.Add(this.lblThreshold);
            this.panelSettings.Controls.Add(this.btnRefresh);
            this.panelSettings.Controls.Add(this.lblCurrentDevice);
            this.panelSettings.Controls.Add(this.lvSource);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.btnBackSet);
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(640, 320);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // tbSeconds
            // 
            this.tbSeconds.Location = new System.Drawing.Point(425, 153);
            this.tbSeconds.Name = "tbSeconds";
            this.tbSeconds.Size = new System.Drawing.Size(50, 20);
            this.tbSeconds.TabIndex = 15;
            this.tbSeconds.Leave += new System.EventHandler(this.tbSeconds_Leave);
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(425, 104);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(50, 20);
            this.tbThreshold.TabIndex = 14;
            this.tbThreshold.Leave += new System.EventHandler(this.tbThreshold_Leave);
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.Enabled = false;
            this.tbDeviceName.Location = new System.Drawing.Point(425, 51);
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(199, 20);
            this.tbDeviceName.TabIndex = 13;
            // 
            // lblRecordingSeconds
            // 
            this.lblRecordingSeconds.AutoSize = true;
            this.lblRecordingSeconds.Location = new System.Drawing.Point(317, 156);
            this.lblRecordingSeconds.Name = "lblRecordingSeconds";
            this.lblRecordingSeconds.Size = new System.Drawing.Size(102, 13);
            this.lblRecordingSeconds.TabIndex = 12;
            this.lblRecordingSeconds.Text = "Recording seconds:";
            // 
            // btnSetValues
            // 
            this.btnSetValues.Location = new System.Drawing.Point(469, 258);
            this.btnSetValues.Name = "btnSetValues";
            this.btnSetValues.Size = new System.Drawing.Size(155, 40);
            this.btnSetValues.TabIndex = 11;
            this.btnSetValues.Text = "Set Values";
            this.btnSetValues.UseVisualStyleBackColor = true;
            this.btnSetValues.Click += new System.EventHandler(this.btnSetValues_Click);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(317, 107);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(57, 13);
            this.lblThreshold.TabIndex = 10;
            this.lblThreshold.Text = "Threshold:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(308, 258);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 40);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh Sources";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCurrentDevice
            // 
            this.lblCurrentDevice.AutoSize = true;
            this.lblCurrentDevice.Location = new System.Drawing.Point(317, 54);
            this.lblCurrentDevice.Name = "lblCurrentDevice";
            this.lblCurrentDevice.Size = new System.Drawing.Size(81, 13);
            this.lblCurrentDevice.TabIndex = 8;
            this.lblCurrentDevice.Text = "Current Device:";
            // 
            // lvSource
            // 
            this.lvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.device,
            this.channels});
            this.lvSource.Location = new System.Drawing.Point(21, 45);
            this.lvSource.MultiSelect = false;
            this.lvSource.Name = "lvSource";
            this.lvSource.Scrollable = false;
            this.lvSource.Size = new System.Drawing.Size(243, 207);
            this.lvSource.TabIndex = 7;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.Details;
            this.lvSource.ItemActivate += new System.EventHandler(this.lvSource_ItemActivate);
            // 
            // device
            // 
            this.device.Text = "Device";
            this.device.Width = 175;
            // 
            // channels
            // 
            this.channels.Text = "Channels";
            this.channels.Width = 182;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(226, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Settings";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "OP-SoundSwitch";
            // 
            // btnBackSet
            // 
            this.btnBackSet.Location = new System.Drawing.Point(21, 258);
            this.btnBackSet.Name = "btnBackSet";
            this.btnBackSet.Size = new System.Drawing.Size(155, 40);
            this.btnBackSet.TabIndex = 2;
            this.btnBackSet.Text = "Back";
            this.btnBackSet.UseVisualStyleBackColor = true;
            this.btnBackSet.Click += new System.EventHandler(this.btnBackSet_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 321);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBindings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelBindings.ResumeLayout(false);
            this.panelBindings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBind)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggleListen;
        private System.Windows.Forms.Button btnBindings;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelBindings;
        private System.Windows.Forms.Button btnRemoveBind;
        private System.Windows.Forms.Button btnNewBind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackBind;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBackSet;
        private System.Windows.Forms.DataGridView dgvBind;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bindCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbSeconds;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Label lblRecordingSeconds;
        private System.Windows.Forms.Button btnSetValues;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCurrentDevice;
        private System.Windows.Forms.ListView lvSource;
        private System.Windows.Forms.ColumnHeader device;
        private System.Windows.Forms.ColumnHeader channels;
    }
}