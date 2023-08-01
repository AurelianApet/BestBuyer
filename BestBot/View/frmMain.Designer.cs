namespace BestBot
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tblProductInfo = new System.Windows.Forms.DataGridView();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfile = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAutoCheckout = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBackdoor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBackdoorInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStripProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.timerKeep = new System.Windows.Forms.Timer(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.cloneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnProxy = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblProductInfo)).BeginInit();
            this.contextMenuStripProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblProductInfo
            // 
            this.tblProductInfo.AllowUserToResizeColumns = false;
            this.tblProductInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.tblProductInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblProductInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProductInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblProductInfo.ColumnHeadersHeight = 25;
            this.tblProductInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUrl,
            this.colSize,
            this.colProfile,
            this.colAutoCheckout,
            this.colBackdoor,
            this.colBackdoorInfo});
            this.tblProductInfo.ContextMenuStrip = this.contextMenuStripProduct;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblProductInfo.DefaultCellStyle = dataGridViewCellStyle9;
            this.tblProductInfo.EnableHeadersVisualStyles = false;
            this.tblProductInfo.GridColor = System.Drawing.SystemColors.Control;
            this.tblProductInfo.Location = new System.Drawing.Point(90, 35);
            this.tblProductInfo.MinimumSize = new System.Drawing.Size(487, 206);
            this.tblProductInfo.MultiSelect = false;
            this.tblProductInfo.Name = "tblProductInfo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProductInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.tblProductInfo.RowHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tblProductInfo.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.tblProductInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tblProductInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblProductInfo.ShowCellErrors = false;
            this.tblProductInfo.ShowEditingIcon = false;
            this.tblProductInfo.ShowRowErrors = false;
            this.tblProductInfo.Size = new System.Drawing.Size(792, 271);
            this.tblProductInfo.TabIndex = 0;
            this.tblProductInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProductInfo_CellContentClick);
            this.tblProductInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProductInfo_CellValueChanged);
            this.tblProductInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tblProductInfo_DataError);
            // 
            // colUrl
            // 
            this.colUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.colUrl.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUrl.HeaderText = "Url";
            this.colUrl.MinimumWidth = 100;
            this.colUrl.Name = "colUrl";
            this.colUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSize
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.colSize.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSize.Width = 50;
            // 
            // colProfile
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.colProfile.DefaultCellStyle = dataGridViewCellStyle5;
            this.colProfile.HeaderText = "Profile";
            this.colProfile.Name = "colProfile";
            this.colProfile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAutoCheckout
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.NullValue = false;
            this.colAutoCheckout.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAutoCheckout.HeaderText = "Auto Checkout?";
            this.colAutoCheckout.Name = "colAutoCheckout";
            // 
            // colBackdoor
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.NullValue = false;
            this.colBackdoor.DefaultCellStyle = dataGridViewCellStyle7;
            this.colBackdoor.HeaderText = "Backdoor?";
            this.colBackdoor.Name = "colBackdoor";
            // 
            // colBackdoorInfo
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.colBackdoorInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.colBackdoorInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colBackdoorInfo.HeaderText = "Backdoor Info";
            this.colBackdoorInfo.MinimumWidth = 50;
            this.colBackdoorInfo.Name = "colBackdoorInfo";
            this.colBackdoorInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBackdoorInfo.Text = "Enter";
            this.colBackdoorInfo.UseColumnTextForButtonValue = true;
            // 
            // contextMenuStripProduct
            // 
            this.contextMenuStripProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem});
            this.contextMenuStripProduct.Name = "contextMenuStrip";
            this.contextMenuStripProduct.Size = new System.Drawing.Size(106, 26);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // rtLog
            // 
            this.rtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtLog.BackColor = System.Drawing.Color.White;
            this.rtLog.Location = new System.Drawing.Point(0, 306);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(882, 175);
            this.rtLog.TabIndex = 1;
            this.rtLog.Text = "";
            // 
            // timerKeep
            // 
            this.timerKeep.Interval = 600000;
            this.timerKeep.Tick += new System.EventHandler(this.timerKeep_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(36, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 16);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "BestBot";
            // 
            // cloneToolStripMenuItem1
            // 
            this.cloneToolStripMenuItem1.Name = "cloneToolStripMenuItem1";
            this.cloneToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::BestBot.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(857, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::BestBot.Properties.Resources.Minimize1;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(834, 7);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(22, 22);
            this.btnMin.TabIndex = 9;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnIcon
            // 
            this.btnIcon.BackColor = System.Drawing.Color.Transparent;
            this.btnIcon.BackgroundImage = global::BestBot.Properties.Resources.SAFRA;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.FlatAppearance.BorderSize = 0;
            this.btnIcon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIcon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIcon.Location = new System.Drawing.Point(6, 6);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(24, 24);
            this.btnIcon.TabIndex = 6;
            this.btnIcon.UseVisualStyleBackColor = false;
            // 
            // picTitle
            // 
            this.picTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitle.BackgroundImage = global::BestBot.Properties.Resources.Log_Title;
            this.picTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTitle.Location = new System.Drawing.Point(-2, -1);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(885, 36);
            this.picTitle.TabIndex = 5;
            this.picTitle.TabStop = false;
            this.picTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTitle_MouseDown);
            this.picTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTitle_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.BackgroundImage = global::BestBot.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 264);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 31);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Yellow;
            this.btnStop.BackgroundImage = global::BestBot.Properties.Resources.Stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(12, 221);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 31);
            this.btnStop.TabIndex = 4;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.BackgroundImage = global::BestBot.Properties.Resources.Start;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(12, 178);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 31);
            this.btnStart.TabIndex = 3;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnProxy
            // 
            this.btnProxy.BackColor = System.Drawing.Color.Aqua;
            this.btnProxy.BackgroundImage = global::BestBot.Properties.Resources.proxy;
            this.btnProxy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProxy.FlatAppearance.BorderSize = 0;
            this.btnProxy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProxy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProxy.Location = new System.Drawing.Point(12, 47);
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.Size = new System.Drawing.Size(65, 31);
            this.btnProxy.TabIndex = 0;
            this.btnProxy.UseVisualStyleBackColor = false;
            this.btnProxy.Click += new System.EventHandler(this.btnLoadAccount_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Aqua;
            this.btnProfile.BackgroundImage = global::BestBot.Properties.Resources.profile;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Location = new System.Drawing.Point(12, 91);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(65, 31);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Aqua;
            this.btnSetting.BackgroundImage = global::BestBot.Properties.Resources.setting;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(12, 135);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(65, 31);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(882, 478);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnProxy);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.rtLog);
            this.Controls.Add(this.tblProductInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(525, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblProductInfo)).EndInit();
            this.contextMenuStripProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblProductInfo;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Timer timerKeep;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProduct;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem1;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnProxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProfile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAutoCheckout;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBackdoor;
        private System.Windows.Forms.DataGridViewButtonColumn colBackdoorInfo;
    }
}

