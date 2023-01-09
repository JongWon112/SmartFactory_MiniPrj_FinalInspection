namespace Form_List
{
    partial class ISP_History
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.ISP_SDate = new System.Windows.Forms.DateTimePicker();
            this.ISP_EDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboFReason = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvISPMain = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvISPSub = new System.Windows.Forms.DataGridView();
            this.groupBox11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPSub)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ISP_EDate);
            this.groupBox11.Controls.Add(this.ISP_SDate);
            this.groupBox11.Controls.Add(this.txtItemName);
            this.groupBox11.Controls.Add(this.cboItemCode);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.label3);
            this.groupBox11.Controls.Add(this.label2);
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Size = new System.Drawing.Size(1213, 80);
            this.groupBox11.Text = "품목조회";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.groupBox3);
            this.groupBox22.Controls.Add(this.groupBox2);
            this.groupBox22.Controls.Add(this.groupBox1);
            this.groupBox22.Location = new System.Drawing.Point(0, 80);
            this.groupBox22.Size = new System.Drawing.Size(1213, 586);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "품목코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "품목명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "검사기간";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "~";
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(65, 38);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(121, 20);
            this.cboItemCode.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(256, 37);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 21);
            this.txtItemName.TabIndex = 2;
            // 
            // ISP_SDate
            // 
            this.ISP_SDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ISP_SDate.Location = new System.Drawing.Point(469, 35);
            this.ISP_SDate.Name = "ISP_SDate";
            this.ISP_SDate.Size = new System.Drawing.Size(100, 21);
            this.ISP_SDate.TabIndex = 3;
            this.ISP_SDate.Value = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            // 
            // ISP_EDate
            // 
            this.ISP_EDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ISP_EDate.Location = new System.Drawing.Point(605, 37);
            this.ISP_EDate.Name = "ISP_EDate";
            this.ISP_EDate.Size = new System.Drawing.Size(100, 21);
            this.ISP_EDate.TabIndex = 3;
            this.ISP_EDate.Value = new System.DateTime(2022, 12, 23, 19, 24, 6, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboFReason);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1207, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "귀책사유 입력";
            // 
            // cboFReason
            // 
            this.cboFReason.FormattingEnabled = true;
            this.cboFReason.Location = new System.Drawing.Point(78, 29);
            this.cboFReason.Name = "cboFReason";
            this.cboFReason.Size = new System.Drawing.Size(121, 20);
            this.cboFReason.TabIndex = 1;
            this.cboFReason.SelectedIndexChanged += new System.EventHandler(this.cboFReason_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "귀책사유";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvISPMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 486);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvISPMain
            // 
            this.dgvISPMain.AllowUserToAddRows = false;
            this.dgvISPMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvISPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvISPMain.Location = new System.Drawing.Point(3, 17);
            this.dgvISPMain.Name = "dgvISPMain";
            this.dgvISPMain.RowTemplate.Height = 23;
            this.dgvISPMain.Size = new System.Drawing.Size(594, 466);
            this.dgvISPMain.TabIndex = 0;
            this.dgvISPMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvISPMain_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvISPSub);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(610, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 486);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dgvISPSub
            // 
            this.dgvISPSub.AllowUserToAddRows = false;
            this.dgvISPSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvISPSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvISPSub.Location = new System.Drawing.Point(3, 17);
            this.dgvISPSub.Name = "dgvISPSub";
            this.dgvISPSub.RowTemplate.Height = 23;
            this.dgvISPSub.Size = new System.Drawing.Size(594, 466);
            this.dgvISPSub.TabIndex = 0;
            // 
            // ISP_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 666);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ISP_History";
            this.Text = "출하검사 이력 조회";
            this.Load += new System.EventHandler(this.ISP_History_Load);
            this.Resize += new System.EventHandler(this.ISP_History_Resize);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ISP_SDate;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.DateTimePicker ISP_EDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboFReason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvISPSub;
        private System.Windows.Forms.DataGridView dgvISPMain;
    }
}