namespace 环保分析系统.UI.ChildWindow
{
    partial class WaveANNForm
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
            this.itertextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itertrackBar = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.hidelayertrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.hidelayertextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itertrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidelayertrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.hidelayertrackBar);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.hidelayertextBox);
            this.splitContainer.Panel2.Controls.Add(this.trackBar2);
            this.splitContainer.Panel2.Controls.Add(this.itertrackBar);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.itertextBox);
            this.splitContainer.Size = new System.Drawing.Size(424, 542);
            // 
            // itertextBox
            // 
            this.itertextBox.Enabled = false;
            this.itertextBox.Location = new System.Drawing.Point(224, 47);
            this.itertextBox.Name = "itertextBox";
            this.itertextBox.Size = new System.Drawing.Size(48, 21);
            this.itertextBox.TabIndex = 1;
            this.itertextBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "迭代次数";
            // 
            // itertrackBar
            // 
            this.itertrackBar.Enabled = false;
            this.itertrackBar.Location = new System.Drawing.Point(140, 47);
            this.itertrackBar.Maximum = 1000;
            this.itertrackBar.Minimum = 100;
            this.itertrackBar.Name = "itertrackBar";
            this.itertrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.itertrackBar.Size = new System.Drawing.Size(78, 45);
            this.itertrackBar.TabIndex = 3;
            this.itertrackBar.TickFrequency = 10;
            this.itertrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.itertrackBar.Value = 100;
            this.itertrackBar.Scroll += new System.EventHandler(this.itertrackBar_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(163, 67);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(8, 45);
            this.trackBar2.TabIndex = 4;
            // 
            // hidelayertrackBar
            // 
            this.hidelayertrackBar.Enabled = false;
            this.hidelayertrackBar.Location = new System.Drawing.Point(140, 91);
            this.hidelayertrackBar.Maximum = 50;
            this.hidelayertrackBar.Minimum = 1;
            this.hidelayertrackBar.Name = "hidelayertrackBar";
            this.hidelayertrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hidelayertrackBar.Size = new System.Drawing.Size(78, 45);
            this.hidelayertrackBar.TabIndex = 7;
            this.hidelayertrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hidelayertrackBar.Value = 6;
            this.hidelayertrackBar.Scroll += new System.EventHandler(this.hidelayertrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "隐藏层数";
            // 
            // hidelayertextBox
            // 
            this.hidelayertextBox.Enabled = false;
            this.hidelayertextBox.Location = new System.Drawing.Point(224, 91);
            this.hidelayertextBox.Name = "hidelayertextBox";
            this.hidelayertextBox.Size = new System.Drawing.Size(48, 21);
            this.hidelayertextBox.TabIndex = 5;
            this.hidelayertextBox.Text = "6";
            // 
            // WaveANNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(424, 542);
            this.Name = "WaveANNForm";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itertrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidelayertrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox itertextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar itertrackBar;
        private System.Windows.Forms.TrackBar hidelayertrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hidelayertextBox;
    }
}
