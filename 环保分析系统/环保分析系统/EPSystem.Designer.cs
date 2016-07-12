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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewOne = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAimFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAimFile = new System.Windows.Forms.ToolStripMenuItem();
            this.数据分析ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matlabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pM25预测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sO2预测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异常分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.等级预测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogOne = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.labTime);
            this.panel1.Controls.Add(this.label1);
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(391, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 21);
            this.txtName.TabIndex = 15;
            this.txtName.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "当前显示的工作表名：";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(110, 32);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 13;
            this.btnRight.Text = "下张表";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(12, 32);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.Text = "上张表";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
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
            this.dataGridViewOne.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewOne_RowPostPaint);
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
            this.数据分析ToolStripMenuItem1,
            this.pM25预测ToolStripMenuItem,
            this.sO2预测ToolStripMenuItem,
            this.异常分析ToolStripMenuItem,
            this.等级预测ToolStripMenuItem});
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
            this.SaveAimFile});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openAimFile
            // 
            this.openAimFile.Name = "openAimFile";
            this.openAimFile.Size = new System.Drawing.Size(100, 22);
            this.openAimFile.Text = "打开";
            this.openAimFile.Click += new System.EventHandler(this.openAimFile_Click);
            // 
            // SaveAimFile
            // 
            this.SaveAimFile.Name = "SaveAimFile";
            this.SaveAimFile.Size = new System.Drawing.Size(100, 22);
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
            // pM25预测ToolStripMenuItem
            // 
            this.pM25预测ToolStripMenuItem.Name = "pM25预测ToolStripMenuItem";
            this.pM25预测ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.pM25预测ToolStripMenuItem.Text = "PM2.5预测";
            this.pM25预测ToolStripMenuItem.Click += new System.EventHandler(this.pM25预测ToolStripMenuItem_Click);
            // 
            // sO2预测ToolStripMenuItem
            // 
            this.sO2预测ToolStripMenuItem.Name = "sO2预测ToolStripMenuItem";
            this.sO2预测ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.sO2预测ToolStripMenuItem.Text = "SO2预测";
            this.sO2预测ToolStripMenuItem.Click += new System.EventHandler(this.sO2预测ToolStripMenuItem_Click);
            // 
            // 异常分析ToolStripMenuItem
            // 
            this.异常分析ToolStripMenuItem.Name = "异常分析ToolStripMenuItem";
            this.异常分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.异常分析ToolStripMenuItem.Text = "异常分析";
            this.异常分析ToolStripMenuItem.Click += new System.EventHandler(this.异常分析ToolStripMenuItem_Click);
            // 
            // 等级预测ToolStripMenuItem
            // 
            this.等级预测ToolStripMenuItem.Name = "等级预测ToolStripMenuItem";
            this.等级预测ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.等级预测ToolStripMenuItem.Text = "等级预测";
            this.等级预测ToolStripMenuItem.Click += new System.EventHandler(this.等级预测ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 478);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
        private System.Windows.Forms.SaveFileDialog saveFileDialogOne;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private 环保分析系统.Entity.SaveShowDataMethod model;
        private System.Windows.Forms.ToolStripMenuItem pM25预测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sO2预测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 异常分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 等级预测ToolStripMenuItem;
        private System.Windows.Forms.Button button1;

    }
}