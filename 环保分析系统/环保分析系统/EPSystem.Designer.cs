namespace 环保分析系统
{
    partial class mainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.Pbar = new System.Windows.Forms.ProgressBar();
            this.lblTip = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labl = new System.Windows.Forms.Label();
            this.comboBoxOne = new System.Windows.Forms.ComboBox();
            this.dataGridViewOne = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAimFile = new System.Windows.Forms.ToolStripMenuItem();
            this.dataView = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAimFile = new System.Windows.Forms.ToolStripMenuItem();
            this.数据分析ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matlabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogOne = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.Pbar);
            this.panel1.Controls.Add(this.lblTip);
            this.panel1.Controls.Add(this.labTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labl);
            this.panel1.Controls.Add(this.comboBoxOne);
            this.panel1.Controls.Add(this.dataGridViewOne);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 478);
            this.panel1.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(188, 31);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "添加工作表";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Pbar
            // 
            this.Pbar.Location = new System.Drawing.Point(751, 32);
            this.Pbar.Name = "Pbar";
            this.Pbar.Size = new System.Drawing.Size(142, 23);
            this.Pbar.TabIndex = 10;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(647, 36);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(53, 12);
            this.lblTip.TabIndex = 9;
            this.lblTip.Text = "保存进度";
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(960, 36);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(0, 12);
            this.labTime.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(919, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "时间：";
            // 
            // labl
            // 
            this.labl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labl.AutoSize = true;
            this.labl.Location = new System.Drawing.Point(337, 37);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(65, 12);
            this.labl.TabIndex = 6;
            this.labl.Text = "选择工作表";
            // 
            // comboBoxOne
            // 
            this.comboBoxOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOne.FormattingEnabled = true;
            this.comboBoxOne.Location = new System.Drawing.Point(424, 33);
            this.comboBoxOne.Name = "comboBoxOne";
            this.comboBoxOne.Size = new System.Drawing.Size(121, 20);
            this.comboBoxOne.TabIndex = 5;
            // 
            // dataGridViewOne
            // 
            this.dataGridViewOne.AllowUserToAddRows = false;
            this.dataGridViewOne.AllowUserToDeleteRows = false;
            this.dataGridViewOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOne.Location = new System.Drawing.Point(0, 61);
            this.dataGridViewOne.Name = "dataGridViewOne";
            this.dataGridViewOne.ReadOnly = true;
            this.dataGridViewOne.RowTemplate.Height = 23;
            this.dataGridViewOne.Size = new System.Drawing.Size(1091, 417);
            this.dataGridViewOne.TabIndex = 4;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(959, 517);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "数据导入";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(794, 517);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "数据导出";
            this.btnOut.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.数据分析ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAimFile,
            this.dataView,
            this.SaveAimFile});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openAimFile
            // 
            this.openAimFile.Name = "openAimFile";
            this.openAimFile.Size = new System.Drawing.Size(124, 22);
            this.openAimFile.Text = "打开";
            this.openAimFile.Click += new System.EventHandler(this.openAimFile_Click);
            // 
            // dataView
            // 
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(124, 22);
            this.dataView.Text = "数据显示";
            this.dataView.Click += new System.EventHandler(this.dataView_Click);
            // 
            // SaveAimFile
            // 
            this.SaveAimFile.Name = "SaveAimFile";
            this.SaveAimFile.Size = new System.Drawing.Size(124, 22);
            this.SaveAimFile.Text = "保存";
            this.SaveAimFile.Click += new System.EventHandler(this.SaveAimFile_Click);
            // 
            // 数据分析ToolStripMenuItem1
            // 
            this.数据分析ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算器ToolStripMenuItem,
            this.matlabToolStripMenuItem});
            this.数据分析ToolStripMenuItem1.Name = "数据分析ToolStripMenuItem1";
            this.数据分析ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.数据分析ToolStripMenuItem1.Text = "分析工具";
            // 
            // 计算器ToolStripMenuItem
            // 
            this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
            this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.计算器ToolStripMenuItem.Text = "计算器";
            this.计算器ToolStripMenuItem.DoubleClick += new System.EventHandler(this.计算器ToolStripMenuItem_DoubleClick);
            // 
            // matlabToolStripMenuItem
            // 
            this.matlabToolStripMenuItem.Name = "matlabToolStripMenuItem";
            this.matlabToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.matlabToolStripMenuItem.Text = "Matlab";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 478);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.Text = "环保信息分析系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据分析ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matlabToolStripMenuItem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAimFile;
        private System.Windows.Forms.ToolStripMenuItem SaveAimFile;
        private System.Windows.Forms.DataGridView dataGridViewOne;
        private System.Windows.Forms.ToolStripMenuItem dataView;
        private System.Windows.Forms.Label labl;
        private System.Windows.Forms.ComboBox comboBoxOne;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOne;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ProgressBar Pbar;
        private System.Windows.Forms.Button btnSelect;

    }
}