namespace 环保分析系统.UI.ChildWindow
{
    partial class RandomForestForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.treenumText = new System.Windows.Forms.TextBox();
            this.treenumBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.treedepth = new System.Windows.Forms.Label();
            this.treedepthBar = new System.Windows.Forms.TrackBar();
            this.depthTextBox = new System.Windows.Forms.TextBox();
            this.isPrun = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treenumBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treedepthBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.isPrun);
            this.splitContainer.Panel2.Controls.Add(this.treedepth);
            this.splitContainer.Panel2.Controls.Add(this.treedepthBar);
            this.splitContainer.Panel2.Controls.Add(this.depthTextBox);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.treenumBar);
            this.splitContainer.Panel2.Controls.Add(this.treenumText);
            this.splitContainer.Size = new System.Drawing.Size(426, 523);
            // 
            // treenumText
            // 
            this.treenumText.BackColor = System.Drawing.SystemColors.Window;
            this.treenumText.Enabled = false;
            this.treenumText.Location = new System.Drawing.Point(166, 38);
            this.treenumText.Name = "treenumText";
            this.treenumText.ReadOnly = true;
            this.treenumText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treenumText.Size = new System.Drawing.Size(29, 21);
            this.treenumText.TabIndex = 1;
            this.treenumText.Text = "500";
            // 
            // treenumBar
            // 
            this.treenumBar.Enabled = false;
            this.treenumBar.Location = new System.Drawing.Point(61, 32);
            this.treenumBar.Maximum = 1000;
            this.treenumBar.Minimum = 500;
            this.treenumBar.Name = "treenumBar";
            this.treenumBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treenumBar.Size = new System.Drawing.Size(104, 45);
            this.treenumBar.SmallChange = 5;
            this.treenumBar.TabIndex = 2;
            this.treenumBar.TickFrequency = 10;
            this.treenumBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.treenumBar.Value = 500;
            this.treenumBar.Scroll += new System.EventHandler(this.treenumBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "树木数量";
            // 
            // treedepth
            // 
            this.treedepth.AutoSize = true;
            this.treedepth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treedepth.Location = new System.Drawing.Point(14, 82);
            this.treedepth.Name = "treedepth";
            this.treedepth.Size = new System.Drawing.Size(41, 12);
            this.treedepth.TabIndex = 6;
            this.treedepth.Text = "树深度";
            // 
            // treedepthBar
            // 
            this.treedepthBar.Enabled = false;
            this.treedepthBar.Location = new System.Drawing.Point(61, 76);
            this.treedepthBar.Maximum = 100;
            this.treedepthBar.Minimum = 15;
            this.treedepthBar.Name = "treedepthBar";
            this.treedepthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treedepthBar.Size = new System.Drawing.Size(104, 45);
            this.treedepthBar.TabIndex = 5;
            this.treedepthBar.TickFrequency = 5;
            this.treedepthBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.treedepthBar.Value = 15;
            this.treedepthBar.Scroll += new System.EventHandler(this.depthtrackBar_Scroll);
            // 
            // depthTextBox
            // 
            this.depthTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.depthTextBox.Enabled = false;
            this.depthTextBox.Location = new System.Drawing.Point(166, 82);
            this.depthTextBox.Name = "depthTextBox";
            this.depthTextBox.ReadOnly = true;
            this.depthTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.depthTextBox.Size = new System.Drawing.Size(29, 21);
            this.depthTextBox.TabIndex = 4;
            this.depthTextBox.Text = "15";
            // 
            // isPrun
            // 
            this.isPrun.AutoSize = true;
            this.isPrun.Enabled = false;
            this.isPrun.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.isPrun.Location = new System.Drawing.Point(261, 61);
            this.isPrun.Name = "isPrun";
            this.isPrun.Size = new System.Drawing.Size(72, 16);
            this.isPrun.TabIndex = 7;
            this.isPrun.Text = "是否剪枝";
            this.isPrun.UseVisualStyleBackColor = true;
            // 
            // RandomForestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(426, 523);
            this.Name = "RandomForestForm";
            this.Text = "随机深林参数选择";
            this.Load += new System.EventHandler(this.RandomForestForm_Load);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treenumBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treedepthBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar treenumBar;
        private System.Windows.Forms.TextBox treenumText;
        private System.Windows.Forms.Label treedepth;
        private System.Windows.Forms.TrackBar treedepthBar;
        private System.Windows.Forms.TextBox depthTextBox;
        private System.Windows.Forms.CheckBox isPrun;
    }
}
