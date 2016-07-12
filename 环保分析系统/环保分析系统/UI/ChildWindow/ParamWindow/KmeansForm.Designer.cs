namespace 环保分析系统.UI.ChildWindow
{
    partial class KmeansForm
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
            this.itertrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.itertextBox = new System.Windows.Forms.TextBox();
            this.classtrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.classtextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itertrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classtrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.classtrackBar);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.classtextBox);
            this.splitContainer.Panel2.Controls.Add(this.itertrackBar);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.itertextBox);
            this.splitContainer.Size = new System.Drawing.Size(390, 499);
            // 
            // itertrackBar
            // 
            this.itertrackBar.Enabled = false;
            this.itertrackBar.Location = new System.Drawing.Point(97, 38);
            this.itertrackBar.Maximum = 20;
            this.itertrackBar.Minimum = 3;
            this.itertrackBar.Name = "itertrackBar";
            this.itertrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.itertrackBar.Size = new System.Drawing.Size(78, 45);
            this.itertrackBar.TabIndex = 6;
            this.itertrackBar.TickFrequency = 10;
            this.itertrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.itertrackBar.Value = 3;
            this.itertrackBar.Scroll += new System.EventHandler(this.itertrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "阈值";
            // 
            // itertextBox
            // 
            this.itertextBox.Enabled = false;
            this.itertextBox.Location = new System.Drawing.Point(181, 38);
            this.itertextBox.Name = "itertextBox";
            this.itertextBox.Size = new System.Drawing.Size(48, 21);
            this.itertextBox.TabIndex = 4;
            this.itertextBox.Text = "3";
            // 
            // classtrackBar
            // 
            this.classtrackBar.Enabled = false;
            this.classtrackBar.Location = new System.Drawing.Point(97, 68);
            this.classtrackBar.Maximum = 8;
            this.classtrackBar.Minimum = 2;
            this.classtrackBar.Name = "classtrackBar";
            this.classtrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.classtrackBar.Size = new System.Drawing.Size(78, 45);
            this.classtrackBar.TabIndex = 9;
            this.classtrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.classtrackBar.Value = 2;
            this.classtrackBar.Scroll += new System.EventHandler(this.classtrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "分类数";
            // 
            // classtextBox
            // 
            this.classtextBox.Enabled = false;
            this.classtextBox.Location = new System.Drawing.Point(181, 68);
            this.classtextBox.Name = "classtextBox";
            this.classtextBox.Size = new System.Drawing.Size(48, 21);
            this.classtextBox.TabIndex = 7;
            this.classtextBox.Text = "2";
            // 
            // KmeansForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(390, 499);
            this.Name = "KmeansForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itertrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classtrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar itertrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itertextBox;
        private System.Windows.Forms.TrackBar classtrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox classtextBox;
    }
}
