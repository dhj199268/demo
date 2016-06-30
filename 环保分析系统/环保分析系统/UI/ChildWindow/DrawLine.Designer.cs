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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTwo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTwo
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTwo.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTwo.Legends.Add(legend3);
            this.chartTwo.Location = new System.Drawing.Point(-1, 0);
            this.chartTwo.Name = "chartTwo";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series2";
            this.chartTwo.Series.Add(series5);
            this.chartTwo.Series.Add(series6);
            this.chartTwo.Size = new System.Drawing.Size(428, 307);
            this.chartTwo.SuppressExceptions = true;
            this.chartTwo.TabIndex = 0;
            this.chartTwo.Text = "折线图";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(352, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存图片";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // DrawLine
            // 
            this.ClientSize = new System.Drawing.Size(429, 337);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chartTwo);
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