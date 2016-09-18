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
            this.label6 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(61, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xcorr-Win";
            // 
            // btnToggleListen
            // 
            this.btnToggleListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleListen.Location = new System.Drawing.Point(48, 106);
            this.btnToggleListen.Name = "btnToggleListen";
            this.btnToggleListen.Size = new System.Drawing.Size(155, 132);
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
            // 
            // panelMain
            // 
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
            this.label3.Location = new System.Drawing.Point(152, 12);
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
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xcorr-Win";
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
            this.panelSettings.Controls.Add(this.label6);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.btnBackSet);
            this.panelSettings.Location = new System.Drawing.Point(1, 1);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(640, 320);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 39);
            this.label6.TabIndex = 6;
            this.label6.Text = "NYI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(152, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Xcorr-Win";
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
            this.Controls.Add(this.panelBindings);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSettings);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBind;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bindCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
    }
}