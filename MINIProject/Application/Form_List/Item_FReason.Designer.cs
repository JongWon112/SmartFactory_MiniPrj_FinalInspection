using System.Drawing;
using System.Windows.Forms;
namespace Form_List
{
    partial class Item_FReason
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.ISP_EDate = new System.Windows.Forms.DateTimePicker();
            this.ISP_SDate = new System.Windows.Forms.DateTimePicker();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFReason = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvChartData = new System.Windows.Forms.DataGridView();
            this.groupBox11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChartData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ISP_EDate);
            this.groupBox11.Controls.Add(this.ISP_SDate);
            this.groupBox11.Controls.Add(this.cboFReason);
            this.groupBox11.Controls.Add(this.cboItemCode);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.label3);
            this.groupBox11.Controls.Add(this.label2);
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Size = new System.Drawing.Size(1070, 100);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.dgvChartData);
            this.groupBox22.Controls.Add(this.chart2);
            this.groupBox22.Controls.Add(this.chart1);
            this.groupBox22.Size = new System.Drawing.Size(1070, 534);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 140);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ISP_EDate
            // 
            this.ISP_EDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ISP_EDate.Location = new System.Drawing.Point(464, 42);
            this.ISP_EDate.Name = "ISP_EDate";
            this.ISP_EDate.Size = new System.Drawing.Size(100, 21);
            this.ISP_EDate.TabIndex = 10;
            this.ISP_EDate.Value = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            // 
            // ISP_SDate
            // 
            this.ISP_SDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ISP_SDate.Location = new System.Drawing.Point(328, 40);
            this.ISP_SDate.Name = "ISP_SDate";
            this.ISP_SDate.Size = new System.Drawing.Size(100, 21);
            this.ISP_SDate.TabIndex = 11;
            this.ISP_SDate.Value = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(71, 42);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(180, 20);
            this.cboItemCode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "검사기간";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "귀책사유";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "품목코드";
            // 
            // cboFReason
            // 
            this.cboFReason.FormattingEnabled = true;
            this.cboFReason.Location = new System.Drawing.Point(651, 43);
            this.cboFReason.Name = "cboFReason";
            this.cboFReason.Size = new System.Drawing.Size(121, 20);
            this.cboFReason.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea10.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea10);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend10.Name = "Legend1";
            this.chart1.Legends.Add(legend10);
            this.chart1.Location = new System.Drawing.Point(3, 17);
            this.chart1.Name = "chart1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series10.IsValueShownAsLabel = true;
            series10.Legend = "Legend1";
            series10.LegendToolTip = "#SERIESNAME#INDEX";
            series10.Name = "Series1";
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(300, 514);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea9.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea9);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Top;
            legend9.Name = "Legend1";
            this.chart2.Legends.Add(legend9);
            this.chart2.Location = new System.Drawing.Point(303, 17);
            this.chart2.Name = "chart2";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chart2.Series.Add(series9);
            this.chart2.Size = new System.Drawing.Size(764, 400);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // dgvChartData
            // 
            this.dgvChartData.AllowUserToAddRows = false;
            this.dgvChartData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChartData.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvChartData.Location = new System.Drawing.Point(567, 417);
            this.dgvChartData.Name = "dgvChartData";
            this.dgvChartData.RowTemplate.Height = 23;
            this.dgvChartData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChartData.Size = new System.Drawing.Size(500, 114);
            this.dgvChartData.TabIndex = 2;
            this.dgvChartData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChartData_CellClick);
            // 
            // Item_FReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 634);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Item_FReason";
            this.Text = "일자별 불량현황";
            this.Load += new System.EventHandler(this.Item_FReason_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.groupBox11, 0);
            this.Controls.SetChildIndex(this.groupBox22, 0);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChartData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker ISP_EDate;
        private System.Windows.Forms.DateTimePicker ISP_SDate;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFReason;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridView dgvChartData;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}