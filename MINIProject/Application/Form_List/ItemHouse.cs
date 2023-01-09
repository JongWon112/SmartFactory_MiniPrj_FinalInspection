using Assamble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Form_List
{
    public partial class ItemHouse : Assamble.BaseChildForm
    {
        public ItemHouse()
        {
            InitializeComponent();
        }

        private void ItemHouse__Load(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("ITEMCODE", typeof(string));
            dtTemp.Columns.Add("ITEMNAME", typeof(string));
            dtTemp.Columns.Add("AMOUNT", typeof(string));
            dtTemp.Columns.Add("LASTINDATE", typeof(string));
            dtTemp.Columns.Add("LASTCHKER", typeof(string));

            dgvGrid.DataSource = dtTemp;

            // 그리드 컬럼 명칭 셋팅
            dgvGrid.Columns["ITEMCODE"].HeaderText = "품목코드";
            dgvGrid.Columns["ITEMNAME"].HeaderText = "품목명";
            dgvGrid.Columns["AMOUNT"].HeaderText = "수량";
            dgvGrid.Columns["LASTINDATE"].HeaderText = "최근입고일자";
            dgvGrid.Columns["LASTCHKER"].HeaderText = "최근입고자";



            // 콤보박스 셋팅
            SqlConnection Connect = new SqlConnection(Common.sConn);
            try
            {
                // 데이터베이스에 공통기준정보(TB_Standrd) 중 품목 유형 (ITEMTYPE) 의 정보를
                // 받아 와서 콤보박스에 등록 하기.

                // 1. 데이터베이스 접속 클래스 설정.
                // Common.sConn : Assamble 에 등록 되어 있는 데이터베이스 접속 주소.
                //SqlConnection Connect = new SqlConnection(Common.sConn);
                // 데이터 베이스 오픈.
                Connect.Open();

                // 2. 품목유형 데이터 리스트 조회 SQL
                string sSqlSelect = string.Empty;
                sSqlSelect += " select ''                              AS CODE_ID  ";
                sSqlSelect += "       ,'ALL'                           AS CODE_NAME";
                sSqlSelect += " UNION ALL                                          ";
                sSqlSelect += " SELECT ITEMCODE                   AS CODE_ID     ";
                sSqlSelect += "  ,'[' + ITEMCODE + ']' + ITEMNAME AS CODE_NAME   ";
                sSqlSelect += "  FROM TB_ITEMMASTER                              ";
                sSqlSelect += "  WHERE ITEMTYPE  = 'FERT'                        ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSqlSelect, Connect);
                DataTable dtTemp1 = new DataTable();
                Adapter.Fill(dtTemp1);

                // 콤보박스에 품목유형 리스트 등록.
                cboItemCode.DataSource = dtTemp1;
                cboItemCode.ValueMember   = "CODE_ID";   // 로직 상 처리될 코드가있는 컬럼
                cboItemCode.DisplayMember = "CODE_NAME"; // 사용자 에게 보여줄 컬럼.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {

                Connect.Close();

            }
        }
        public override void DoInquire()
        {

            //조히 버튼 클릭시 품목코드 정보 조회
            string sItemCode = Convert.ToString(cboItemCode.SelectedValue);
            string sItemName = txtItemName.Text;
            string sDay      = dtpSday.Text;
            string sEay      = dtpEday.Text;


            // 데이터 베이스 오픈.
            DBHelper helper = new DBHelper();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SP_ItemHouse_S1", helper.sCon);

                // Adapter 에게 저장 프로시져 형식의 sql 을 실행할것을 등록함.
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정.
                adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME", sItemName);
                adapter.SelectCommand.Parameters.AddWithValue("@SINDATE", sDay);
                adapter.SelectCommand.Parameters.AddWithValue("@EINDATE", sEay);

                // 기본적으로 모든 프로시져에 적용될 내용.
                adapter.SelectCommand.Parameters.AddWithValue("@LANG", "KO");
                adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                dgvGrid.DataSource = dtTemp;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {

                helper.Close();

            }


        }


    }
}
