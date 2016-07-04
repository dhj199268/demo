namespace 环保分析系统.UI.ChildWindow
{
    partial class DrawLine
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTwo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTwo
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTwo.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTwo.Legends.Add(legend2);
            this.chartTwo.Location = new System.Drawing.Point(-1, 0);
            this.chartTwo.Name = "chartTwo";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "真实";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "预测";
            this.chartTwo.Series.Add(series3);
            this.chartTwo.Series.Add(series4);
            this.chartTwo.Size = new System.Drawing.Size(719, 516);
            this.chartTwo.SuppressExceptions = true;
            this.chartTwo.TabIndex = 0;
            this.chartTwo.Text = "折线图";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(643, 493);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存图片";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // DrawLine
            // 
            this.ClientSize = new System.Drawing.Size(721, 518);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chartTwo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DrawLine";
            this.Load += new System.EventHandler(this.DrawLine_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chartTwo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.DataVisualization.Charting.Chart chartTwo;
        //private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTwo;
        private System.Windows.Forms.Button btnSave;
    }
}