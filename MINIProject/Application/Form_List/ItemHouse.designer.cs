using System.Drawing;
using System.Windows.Forms;
namespace Form_List
{
    partial class ItemHouse
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEday = new System.Windows.Forms.DateTimePicker();
            this.dtpSday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Controls.Add(this.txtItemName);
            this.groupBox11.Controls.Add(this.cboItemCode);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.dtpEday);
            this.groupBox11.Controls.Add(this.dtpSday);
            this.groupBox11.Controls.Add(this.label3);
            this.groupBox11.Controls.Add(this.label2);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.dgvGrid);
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(107, 32);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(170, 20);
            this.cboItemCode.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(675, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "~";
            // 
            // dtpEday
            // 
            this.dtpEday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEday.Location = new System.Drawing.Point(692, 29);
            this.dtpEday.Name = "dtpEday";
            this.dtpEday.Size = new System.Drawing.Size(86, 21);
            this.dtpEday.TabIndex = 9;
            this.dtpEday.Value = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            // 
            // dtpSday
            // 
            this.dtpSday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSday.Location = new System.Drawing.Point(583, 28);
            this.dtpSday.Name = "dtpSday";
            this.dtpSday.Size = new System.Drawing.Size(86, 21);
            this.dtpSday.TabIndex = 8;
            this.dtpSday.Value = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "날짜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "품목명";
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(3, 17);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowTemplate.Height = 23;
            this.dgvGrid.Size = new System.Drawing.Size(794, 330);
            this.dgvGrid.TabIndex = 4;
            // 
            // txtItemName
            // 
            this.txtItemName.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtItemName.Location = new System.Drawing.Point(386, 32);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(87, 21);
            this.txtItemName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "품목코드";
            // 
            // ItemHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ItemHouse";
            this.Text = "제품창고 현황";
            this.Load += new System.EventHandler(this.ItemHouse__Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEday;
        private System.Windows.Forms.DateTimePicker dtpSday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
    }
}
