namespace SmartFactory_FieldProgram
{
    partial class Vice_ISP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnISPAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvISPList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChkerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtISPCnt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbItemImage);
            this.groupBox1.Controls.Add(this.dgvItemList);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.cboItemCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(871, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "품목조회";
            // 
            // pbItemImage
            // 
            this.pbItemImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbItemImage.Location = new System.Drawing.Point(302, 17);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(217, 206);
            this.pbItemImage.TabIndex = 12;
            this.pbItemImage.TabStop = false;
            // 
            // dgvItemList
            // 
            this.dgvItemList.AllowUserToAddRows = false;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvItemList.Location = new System.Drawing.Point(519, 17);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowTemplate.Height = 23;
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(349, 206);
            this.dgvItemList.TabIndex = 11;
            this.dgvItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemList_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(23, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(166, 39);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "검사품목조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(80, 64);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(155, 21);
            this.txtItemName.TabIndex = 9;
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(65, 20);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(231, 20);
            this.cboItemCode.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "품목명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "품목코드";
            // 
            // btnISPAdd
            // 
            this.btnISPAdd.Location = new System.Drawing.Point(622, 384);
            this.btnISPAdd.Name = "btnISPAdd";
            this.btnISPAdd.Size = new System.Drawing.Size(166, 39);
            this.btnISPAdd.TabIndex = 10;
            this.btnISPAdd.Text = "등록";
            this.btnISPAdd.UseVisualStyleBackColor = true;
            this.btnISPAdd.Click += new System.EventHandler(this.btnISPAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvISPList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 263);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검사";
            // 
            // dgvISPList
            // 
            this.dgvISPList.AllowUserToAddRows = false;
            this.dgvISPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvISPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvISPList.Location = new System.Drawing.Point(3, 17);
            this.dgvISPList.Name = "dgvISPList";
            this.dgvISPList.RowTemplate.Height = 23;
            this.dgvISPList.Size = new System.Drawing.Size(608, 243);
            this.dgvISPList.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "작업자명";
            // 
            // txtChkerName
            // 
            this.txtChkerName.Location = new System.Drawing.Point(676, 266);
            this.txtChkerName.Name = "txtChkerName";
            this.txtChkerName.Size = new System.Drawing.Size(99, 21);
            this.txtChkerName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(620, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "수량";
            // 
            // txtISPCnt
            // 
            this.txtISPCnt.Location = new System.Drawing.Point(676, 313);
            this.txtISPCnt.Name = "txtISPCnt";
            this.txtISPCnt.Size = new System.Drawing.Size(99, 21);
            this.txtISPCnt.TabIndex = 9;
            // 
            // Vice_ISP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnISPAdd);
            this.Controls.Add(this.txtISPCnt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChkerName);
            this.Controls.Add(this.label3);
            this.Name = "Vice_ISP";
            this.Text = "출하검사 현장프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvISPList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvISPList;
        private System.Windows.Forms.PictureBox pbItemImage;
        private System.Windows.Forms.Button btnISPAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChkerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtISPCnt;
    }
}

