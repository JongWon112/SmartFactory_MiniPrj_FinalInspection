using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assamble;

namespace Form_List
{
    public partial class ISP_History : BaseChildForm
    {
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlTransaction sTran;
        public ISP_History()
        {
            InitializeComponent();
        }

       

        private void ISP_History_Load(object sender, EventArgs e)
        {
            //Form Load 시 아이템코드, 귀책사유 세팅


            #region < 귀책사유 항목 세팅>

            cboFReason.Items.Add("사람");
            cboFReason.Items.Add("공정");
            cboFReason.Items.Add("원자재");

            #endregion


            #region <아이템 코드 세팅>
            DBHelper helper = new DBHelper();
            DataTable dtTemp = new DataTable();
            string sql = string.Empty;
            sql += " select ''                              AS CODE_ID  ";
            sql += "       ,'ALL'                           AS CODE_NAME";
            sql += " UNION ALL                                          ";
            sql += " select ITEMCODE                        AS CODE_ID  ";
            sql += "       ,'[' + ITEMCODE + ']' + ITEMNAME AS CODE_NAME";
            sql += " from TB_ItemMaster                                 ";
            sql += " WHERE ITEMTYPE = 'FERT'                            ";

            helper.SelectSql(sql, dtTemp);

            cboItemCode.DataSource = dtTemp;
            cboItemCode.ValueMember = "CODE_ID";    // 로직 상 처리될 코드가있는 컬럼.
            cboItemCode.DisplayMember = "CODE_NAME";  // 사용자 에게 보여줄 컬럼.
            #endregion


            #region <dgvMain 그리드 세팅>
            GridUtil _Gridutril1 = new GridUtil();
            _Gridutril1.InitColumnGrid(dgvISPMain, "ISPDATE", "검사일자", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "SEQ", "순번", typeof(int), 70, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "ITEMCODE", "품목코드", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "ITEMNAME", "품목명", typeof(string), 200, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "AMOUNT", "수량", typeof(int), 80, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "TRESULT", "종합판정결과", typeof(string), 80, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "CHKER", "검사자", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvISPMain, "FREASON", "귀책사유", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);

            #endregion

            #region < dgvSub 그리드 세팅 >
             GridUtil _Gridutril2 = new GridUtil();
            _Gridutril2.InitColumnGrid(dgvISPSub, "ISPCODE", "검사코드", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "ISPTYPE", "검사항목", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "ISPPOINT", "판정기준", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "LSL", "규격하한", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "USL", "규격상한", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "SPEC", "표준규격", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "IVALUE", "실제 기입값", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPSub, "IRESULT", "개별판정", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);

            #endregion
        }

       
        //조회
        public override void DoInquire()
        {
            #region < 출하검사 메인 테이블 조회 > 

            string itemCode = cboItemCode.SelectedValue.ToString();
            string itemName = txtItemName.Text;
            string startDate = ISP_SDate.Text;
            string endDate = ISP_EDate.Text;
            bool fReasonFlag = chkFReasonFlag.Checked;

            //검사결과 헤더 조회

            //DB 객체 생성
            DBHelper helper = new DBHelper();
            //저장프로시져 세팅

            helper.SetSelectSP("SP_ItemISPResult_S1");
            //파라미터 세팅
            helper.SetSelectSP_Param("@ITEMCODE", itemCode);
            helper.SetSelectSP_Param("@ITEMNAME", itemName);
            helper.SetSelectSP_Param("@STARTDATE", startDate);
            helper.SetSelectSP_Param("@ENDDATE", endDate);
            helper.SetSelectSP_Param("@fReasonFlag", fReasonFlag.ToString().ToUpper());
            //sp 실행
            DataTable dtTemp = new DataTable();
            helper.SelectSP_Run(dtTemp);

            //그리드에 바인딩
            dgvISPMain.DataSource = dtTemp;
            #endregion
        }


        #region < 그리드 비율 조정 >
        private void ISP_History_Resize(object sender, EventArgs e)
        {
            groupBox2.Width = Convert.ToInt32(this.Width / 2);
            groupBox3.Width = Convert.ToInt32(this.Width / 2);

        }
        #endregion

       
        private void dgvISPMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region < 출하검사 서브 테이블 조회 >
            string seq = dgvISPMain.CurrentRow.Cells["SEQ"].Value.ToString();

            //DB 객체 생성
            DBHelper helper = new DBHelper();
            //저장프로시져 세팅
            helper.SetSelectSP("SP_ItemISPResultDetail_S1");
            //파라미터 세팅
            helper.SetSelectSP_Param("@SEQ", seq);
            //sp 실행
            DataTable dtTemp_Sub = new DataTable();
            helper.SelectSP_Run(dtTemp_Sub);

            //그리드에 바인딩
            dgvISPSub.DataSource = dtTemp_Sub;
            #endregion
        }



        public override void DoSave()
        {
            #region < 귀책사유 저장  >
            DataTable dtTemp = ((DataTable)dgvISPMain.DataSource).GetChanges();

            if (dtTemp.Rows.Count == 0) return;

            DBHelper helper = new DBHelper();
            helper.SetChangeSP("SP_ItemISPResult_U1");
            string seq = string.Empty;
            string fReason = string.Empty;
            try
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:
                            seq = dr["SEQ"].ToString();
                            fReason = dr["FREASON"].ToString();
                            helper.setSPNameNew ("SP_ItemISPResult_U1");
                            helper.SetChangeSP_Param("@SEQ", seq);
                            helper.SetChangeSP_Param("@FREASON", fReason);

                            helper.ChangeSP_Run();
                            break;
                    }
                }

                helper.sTran.Commit();
                MessageBox.Show("저장하였습니다.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("저장에 실패하였습니다." + ex.ToString());
                helper.sTran.Rollback();
            }
            finally
            {
                helper.Close();
            }
            #endregion

        }

        private void cboFReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvISPMain.Rows.Count == 0) return;

            if (dgvISPMain.CurrentRow == null) return;


            if (dgvISPMain.CurrentRow.Cells["TRESULT"].Value.ToString() == "NG")
            {

                
                dgvISPMain.CurrentRow.Cells["FREASON"].Value = cboFReason.Text;
            }

           
        }
    }
}
