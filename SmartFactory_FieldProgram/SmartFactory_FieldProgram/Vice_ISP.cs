using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assamble;

namespace SmartFactory_FieldProgram
{
    public partial class Vice_ISP : Form
    {
        public Vice_ISP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            #region < 품목코드 콤보박스 세팅 >
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

            cboItemCode.DataSource= dtTemp;
            cboItemCode.ValueMember = "CODE_ID";    // 로직 상 처리될 코드가있는 컬럼.
            cboItemCode.DisplayMember = "CODE_NAME";  // 사용자 에게 보여줄 컬럼.

            #endregion

            #region < 그리드 기본 세팅 >
            // 품목리스트 그리드 세팅
            GridUtil _Gridutril1 = new GridUtil();
            _Gridutril1.InitColumnGrid(dgvItemList, "ITEMCODE", "품목코드", typeof(string), 80, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvItemList, "ITEMNAME", "품목명", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvItemList, "ITEMTYPE", "품목유형", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
     

            // 검사항목 그리드 세팅
            GridUtil _Gridutril2 = new GridUtil();
            _Gridutril2.InitColumnGrid(dgvISPList, "ISPCODE", "검사코드", typeof(string), 80, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "ISPTYPE", "검사항목명", typeof(string), 80, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "ISPPOINT", "판정기준", typeof(string), 80, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "LSL", "규격하한", typeof(string), 80, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "USL", "규격상한", typeof(string), 80, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "SPEC", "표준규격", typeof(string), 80, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril2.InitColumnGrid(dgvISPList, "iVALUE", "판정", typeof(string), 80, DataGridViewContentAlignment.MiddleCenter, true);

            #endregion

            #region < dgvISPList 검사항목 정보 세팅 >

            helper.SetSelectSP("SP_ISPList_S1");

            dtTemp = new DataTable();
            helper.SelectSP_Run(dtTemp);

            //기본값 입력
            foreach(DataRow dr in dtTemp.Rows)
            {
                if (dr["SPEC"].ToString() == "") dr["iVALUE"] = "OK"; //OK 를 기본값으로 설정
                else dr["iVALUE"] = dr["SPEC"];
            }

            dgvISPList.DataSource = dtTemp;

            #endregion
        }

        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region < 품목을선택 했을 때 이미지 불러오기 세팅 >

            if (dgvItemList.Rows.Count == 0) return;
            string sItemCode = dgvItemList.CurrentRow.Cells["ITEMCODE"].Value.ToString();


            pbItemImage.Image = null;

            DBHelper helper = new DBHelper();
            try
            {
                
                
                string sSelectSql = $"SELECT ITEMIMAGE FROM TB_ITEMMASTER WHERE ITEMCODE = '{sItemCode}'";
                helper.adapter = new SqlDataAdapter(sSelectSql, helper.sCon);
                DataTable dtTemp = new DataTable();

                helper.adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0) return;

                // 품목 별 이미지 BYTE 코드가 있는지 체크
                if (Convert.ToString(dtTemp.Rows[0]["ITEMIMAGE"]) == "") return;


                // byte[] 배열 형식으로 받아올 변수 생성
                Byte[] bImage = null;

                // byte 배열 형식으로 byte코드 형 변환
                bImage = (byte[])dtTemp.Rows[0]["ITEMIMAGE"];

                //byte[] 배열인 bImage를 Bitmap(픽셀 이미지로 변경해주는 클래스)로 변환.
                pbItemImage.Image = new Bitmap(new MemoryStream(bImage));


            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 로드에 실패하였습니다." + ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            #endregion
        }

        private void btnISPAdd_Click(object sender, EventArgs e)
        {
            #region < 벨리데이션 체크 >

            if (dgvItemList.CurrentRow == null) 
            { 

                MessageBox.Show("검사품목을 선택하세요");
                return;
            }
               

            if (txtChkerName.Text == "" || txtISPCnt.Text == "")
            {
                MessageBox.Show("작업자 이릅과 품목수량을 확인하세요");
                return;
            }

            if(!int.TryParse(txtISPCnt.Text, out int ispCnt) || ispCnt < 1)
            {
                MessageBox.Show("수량은 1보다 큰 정수로 입력하세요.");
                return;
            }

            #endregion


            int inputValue = 0; // 값으로 개별검사하는 항목의 입력값
            int lslValue = 0;   // 값으로 개별검사하는 항목의 최소값
            int uslValue = 0;   // 값으로 개별검사하는 항목의 최대값

            //  검사 종합결과 체크 변수
            string iTemCode = dgvItemList.CurrentRow.Cells["ITEMCODE"].Value.ToString();
            string ISPChkValue = "OK"; //종합판정 결과
            string chker = txtChkerName.Text;
            string amount = txtISPCnt.Text;

            string iResult = string.Empty; // 개별 판정 값
            string iValue = string.Empty; // 실제 기입 값
            string ispCode = string.Empty; // 검사 항목 코드

            DBHelper helper = new DBHelper(); //DB 객체 생성

          

            try
            {
                #region < 1. 출하검사 종합결과 저장 TB_ItemISPResult>
                for (int i = 0; i < dgvISPList.Rows.Count; i++)
                {
                    //값입력인지 ok/ng 입력인지 확인
                    if (dgvISPList.Rows[i].Cells["SPEC"].Value.ToString() == "") // ok / ng 입력
                    {
                        if (dgvISPList.Rows[i].Cells["IVALUE"].Value.ToString().ToUpper() == "NG")
                        {
                            ISPChkValue = "NG";
                            break;
                        }
                    }
                    else // 값 
                    {
                        inputValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["iVALUE"].Value);
                        lslValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["LSL"].Value);
                        uslValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["USL"].Value);
                        if (inputValue < lslValue || inputValue > uslValue)
                        {
                            ISPChkValue = "NG";
                            break;
                        }
                    }
                }

                //DBHelper를 이용한 프로시져 실행
                helper.SetChangeSP("SP_ItemISPResult_I1");
                helper.SetChangeSP_Param("@ITEMCODE", iTemCode);
                helper.SetChangeSP_Param("@TRESULT", ISPChkValue);
                helper.SetChangeSP_Param("@CHKER", chker);
                helper.SetChangeSP_Param("@AMOUNT", amount);

                helper.ChangeSP_Run();

                #endregion


                #region < 2. 출하검사 검사항목별 결과 저장 TB_ItemISPResult_Detail >
                //검사 품목별 각각의 판단값 입력
                for (int i = 0; i < dgvISPList.Rows.Count; i++)
                {
                    ispCode = dgvISPList.Rows[i].Cells["ISPCODE"].Value.ToString();
                    //값입력인자 ok/ng입력인지 확인
                    if (dgvISPList.Rows[i].Cells["SPEC"].Value.ToString() == "") // ok / ng 입력
                    {
                        iValue = dgvISPList.Rows[i].Cells["iVALUE"].Value.ToString().ToUpper();
                        iResult = iValue;
                    }
                    else // 값 입력
                    {
                        inputValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["iVALUE"].Value);
                        lslValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["LSL"].Value);
                        uslValue = Convert.ToInt32(dgvISPList.Rows[i].Cells["USL"].Value);
                        iValue = Convert.ToString(inputValue);

                        if (inputValue < lslValue || inputValue > uslValue)
                        {
                            iResult = "OK";
                        }
                        else iResult = "NG";

                    }

                    //SP 실행
                    //helper = new DBHelper();
                    helper.setSPNameNew("SP_ItemISPResultDetail_I1");
                    helper.SetChangeSP_Param("@ISPCODE", ispCode);
                    helper.SetChangeSP_Param("@IRESULT", iResult);
                    helper.SetChangeSP_Param("@IVALUE", iValue);
                    helper.ChangeSP_Run();

                }

                #endregion

                #region < 3. 출하검사 결과 OK인 제품 제품창고 테이블 저장 TB_ItemHouse >
                //제고창고 insert or update
                if (ISPChkValue == "OK")
                {
                    //helper = new DBHelper();
                    helper.setSPNameNew("SP_SET_ITEMHOUSE");
                    helper.SetChangeSP_Param("@ITEMCODE", iTemCode);
                    helper.SetChangeSP_Param("@AMOUNT", amount);
                    helper.SetChangeSP_Param("@LASTCHKER", chker);
                    helper.ChangeSP_Run();
                }

                #endregion

                helper.sTran.Commit();
                MessageBox.Show("등록하였습니다.");



            }
            catch(Exception ex)
            {
                helper.sTran.Rollback();
                MessageBox.Show("등록에 실패하였습니다." + ex.ToString());
            }
            finally
            {
                helper.Close();
            }
          

           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper();
            helper.SetSelectSP("SP_ITEMMASTER_S1");

            helper.SetSelectSP_Param("@ITEMCODE", cboItemCode.SelectedValue.ToString());
            helper.SetSelectSP_Param("@ITEMNAME", txtItemName.Text);

            DataTable dtTemp = new DataTable();
            helper.SelectSP_Run(dtTemp);

            dgvItemList.DataSource = dtTemp;
        }
    }
}
