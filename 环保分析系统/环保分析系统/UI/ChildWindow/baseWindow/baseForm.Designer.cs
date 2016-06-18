namespace 环保分析系统.UI.ChildWindow.baseWindow
{
    partial class baseForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.timelabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trainrownum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.devarlabel = new System.Windows.Forms.Label();
            this.indevarlabel = new System.Windows.Forms.Label();
            this.varlabel = new System.Windows.Forms.Label();
            this.MothdcomboBox = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.begin = new System.Windows.Forms.Button();
            this.advence = new System.Windows.Forms.Button();
            this.devarList = new System.Windows.Forms.ListBox();
            this.indevarList = new System.Windows.Forms.ListBox();
            this.varList = new System.Windows.Forms.ListBox();
            this.isAdvence = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.predictrownum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.splitContainer.Panel1.Controls.Add(this.button2);
            this.splitContainer.Panel1.Controls.Add(this.button1);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.predictrownum);
            this.splitContainer.Panel1.Controls.Add(this.timelabel);
            this.splitContainer.Panel1.Controls.Add(this.timeTextBox);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.trainrownum);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.button6);
            this.splitContainer.Panel1.Controls.Add(this.button5);
            this.splitContainer.Panel1.Controls.Add(this.devarlabel);
            this.splitContainer.Panel1.Controls.Add(this.indevarlabel);
            this.splitContainer.Panel1.Controls.Add(this.varlabel);
            this.splitContainer.Panel1.Controls.Add(this.MothdcomboBox);
            this.splitContainer.Panel1.Controls.Add(this.cancel);
            this.splitContainer.Panel1.Controls.Add(this.reset);
            this.splitContainer.Panel1.Controls.Add(this.begin);
            this.splitContainer.Panel1.Controls.Add(this.advence);
            this.splitContainer.Panel1.Controls.Add(this.devarList);
            this.splitContainer.Panel1.Controls.Add(this.indevarList);
            this.splitContainer.Panel1.Controls.Add(this.varList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.isAdvence);
            this.splitContainer.Panel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer.Size = new System.Drawing.Size(406, 596);
            this.splitContainer.SplitterDistance = 386;
            this.splitContainer.TabIndex = 0;
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timelabel.Location = new System.Drawing.Point(216, 308);
            this.timelabel.Name = "timelabel";
            this.timelabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timelabel.Size = new System.Drawing.Size(65, 12);
            this.timelabel.TabIndex = 17;
            this.timelabel.Text = "时序长度：";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(279, 303);
            this.timeTextBox.MaxLength = 3;
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(48, 21);
            this.timeTextBox.TabIndex = 16;
            this.timeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 278);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "训练行号：";
            // 
            // trainrownum
            // 
            this.trainrownum.Location = new System.Drawing.Point(71, 273);
            this.trainrownum.Name = "trainrownum";
            this.trainrownum.Size = new System.Drawing.Size(76, 21);
            this.trainrownum.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(216, 273);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "方案：";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(150, 215);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 22);
            this.button6.TabIndex = 12;
            this.button6.Text = "<<";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(150, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 22);
            this.button5.TabIndex = 11;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // devarlabel
            // 
            this.devarlabel.AutoSize = true;
            this.devarlabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devarlabel.Location = new System.Drawing.Point(214, 145);
            this.devarlabel.Name = "devarlabel";
            this.devarlabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.devarlabel.Size = new System.Drawing.Size(41, 12);
            this.devarlabel.TabIndex = 10;
            this.devarlabel.Text = "因变量";
            // 
            // indevarlabel
            // 
            this.indevarlabel.AutoSize = true;
            this.indevarlabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.indevarlabel.Location = new System.Drawing.Point(214, 13);
            this.indevarlabel.Name = "indevarlabel";
            this.indevarlabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.indevarlabel.Size = new System.Drawing.Size(41, 12);
            this.indevarlabel.TabIndex = 9;
            this.indevarlabel.Text = "自变量";
            // 
            // varlabel
            // 
            this.varlabel.AutoSize = true;
            this.varlabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varlabel.Location = new System.Drawing.Point(13, 13);
            this.varlabel.Name = "varlabel";
            this.varlabel.Size = new System.Drawing.Size(29, 12);
            this.varlabel.TabIndex = 8;
            this.varlabel.Text = "变量";
            // 
            // MothdcomboBox
            // 
            this.MothdcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MothdcomboBox.FormattingEnabled = true;
            this.MothdcomboBox.Items.AddRange(new object[] {
            "快   速",
            "标   准",
            "精   确"});
            this.MothdcomboBox.Location = new System.Drawing.Point(261, 270);
            this.MothdcomboBox.Name = "MothdcomboBox";
            this.MothdcomboBox.Size = new System.Drawing.Size(100, 20);
            this.MothdcomboBox.TabIndex = 7;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(306, 342);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "退  出";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(215, 342);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 5;
            this.reset.Text = "重   置";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // begin
            // 
            this.begin.Location = new System.Drawing.Point(120, 342);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(75, 23);
            this.begin.TabIndex = 4;
            this.begin.Text = "开  始";
            this.begin.UseVisualStyleBackColor = true;
            // 
            // advence
            // 
            this.advence.Location = new System.Drawing.Point(12, 342);
            this.advence.Name = "advence";
            this.advence.Size = new System.Drawing.Size(75, 23);
            this.advence.TabIndex = 3;
            this.advence.Text = "高  级  >>";
            this.advence.UseVisualStyleBackColor = true;
            this.advence.Click += new System.EventHandler(this.button1_Click);
            // 
            // devarList
            // 
            this.devarList.FormattingEnabled = true;
            this.devarList.ItemHeight = 12;
            this.devarList.Location = new System.Drawing.Point(217, 161);
            this.devarList.Name = "devarList";
            this.devarList.Size = new System.Drawing.Size(151, 88);
            this.devarList.TabIndex = 2;
            // 
            // indevarList
            // 
            this.indevarList.FormattingEnabled = true;
            this.indevarList.ItemHeight = 12;
            this.indevarList.Location = new System.Drawing.Point(217, 29);
            this.indevarList.Name = "indevarList";
            this.indevarList.Size = new System.Drawing.Size(151, 88);
            this.indevarList.TabIndex = 1;
            // 
            // varList
            // 
            this.varList.FormattingEnabled = true;
            this.varList.ItemHeight = 12;
            this.varList.Location = new System.Drawing.Point(12, 29);
            this.varList.Name = "varList";
            this.varList.Size = new System.Drawing.Size(123, 220);
            this.varList.TabIndex = 0;
            // 
            // isAdvence
            // 
            this.isAdvence.AutoSize = true;
            this.isAdvence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.isAdvence.Location = new System.Drawing.Point(9, 3);
            this.isAdvence.Name = "isAdvence";
            this.isAdvence.Size = new System.Drawing.Size(96, 16);
            this.isAdvence.TabIndex = 0;
            this.isAdvence.Text = "使用高级选项";
            this.isAdvence.UseVisualStyleBackColor = true;
            this.isAdvence.CheckedChanged += new System.EventHandler(this.isAdvence_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 310);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "预测行号：";
            // 
            // predictrownum
            // 
            this.predictrownum.Location = new System.Drawing.Point(71, 305);
            this.predictrownum.Name = "predictrownum";
            this.predictrownum.Size = new System.Drawing.Size(76, 21);
            this.predictrownum.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 22);
            this.button1.TabIndex = 20;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 22);
            this.button2.TabIndex = 21;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // baseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 596);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "baseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "baseForm";
            this.Load += new System.EventHandler(this.baseForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button advence;
        private System.Windows.Forms.ListBox devarList;
        private System.Windows.Forms.ListBox indevarList;
        private System.Windows.Forms.ListBox varList;
        private int bighight;
        private int smallhight;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.ComboBox MothdcomboBox;

        public System.Windows.Forms.ComboBox MothdChoose
        {
            get { return MothdcomboBox; }
            set { MothdcomboBox = value; }
        }
        private System.Windows.Forms.Label devarlabel;
        private System.Windows.Forms.Label indevarlabel;
        private System.Windows.Forms.Label varlabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox trainrownum;
        protected internal System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.CheckBox isAdvence;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox predictrownum;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}