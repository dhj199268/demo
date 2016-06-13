namespace 环保分析系统
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnDengLu = new System.Windows.Forms.Button();
            this.lalName = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnDesc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDengLu
            // 
            this.btnDengLu.Location = new System.Drawing.Point(136, 140);
            this.btnDengLu.Name = "btnDengLu";
            this.btnDengLu.Size = new System.Drawing.Size(56, 23);
            this.btnDengLu.TabIndex = 0;
            this.btnDengLu.Text = "登  录";
            this.btnDengLu.UseVisualStyleBackColor = true;
            this.btnDengLu.Click += new System.EventHandler(this.btnDengLu_Click);
            // 
            // lalName
            // 
            this.lalName.AutoSize = true;
            this.lalName.BackColor = System.Drawing.Color.Transparent;
            this.lalName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalName.Location = new System.Drawing.Point(59, 48);
            this.lalName.Name = "lalName";
            this.lalName.Size = new System.Drawing.Size(67, 14);
            this.lalName.TabIndex = 1;
            this.lalName.Text = "用户名：";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(136, 48);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(131, 21);
            this.txtLoginName.TabIndex = 2;
            // 
            // passWord
            // 
            this.passWord.AutoSize = true;
            this.passWord.BackColor = System.Drawing.Color.Transparent;
            this.passWord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passWord.Location = new System.Drawing.Point(59, 90);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(68, 14);
            this.passWord.TabIndex = 3;
            this.passWord.Text = "密  码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            //this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnDesc
            // 
            this.btnDesc.Location = new System.Drawing.Point(211, 140);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(56, 23);
            this.btnDesc.TabIndex = 5;
            this.btnDesc.Text = "取  消";
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 194);
            this.Controls.Add(this.btnDesc);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.lalName);
            this.Controls.Add(this.btnDengLu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.Text = "环保信息分析系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDengLu;
        private System.Windows.Forms.Label lalName;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label passWord;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnDesc;
    }
}

