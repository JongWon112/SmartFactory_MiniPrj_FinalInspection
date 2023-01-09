using Assamble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Form_List
{
    public partial class Item_FReason : BaseChildForm
    {
        public Item_FReason()
        {
            InitializeComponent();
        }

        private void Item_FReason_Load(object sender, EventArgs e)
        {

            cboFReason.Items.Add("");
            cboFReason.Items.Add("사람");
            cboFReason.Items.Add("공정");
            cboFReason.Items.Add("원자재");

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
        }

        public override void DoInquire()
        {

            //일자별 총 검사 품목 수 대비 불량 수량 을 보여주는 파이차트
            string itemCode = cboItemCode.SelectedValue.ToString();
            string sDate = ISP_SDate.Text;
            string eDate = ISP_EDate.Text;

            DBHelper helper = new DBHelper();
            helper.SetSelectSP("SP_ItemISPResult_PiChartData");
            helper.SetChangeSP_Param("@ITEMCODE", itemCode);
            helper.SetChangeSP_Param("@SDATE", sDate);
            helper.SetChangeSP_Param("@EDATE", eDate);

            DataTable dtTemp = new DataTable();
            helper.SelectSP_Run(dtTemp);


        }

        //private void ISP_History_Resize(object sender, EventArgs e)
        //{
        //    chart1.Width = Convert.ToInt32(this.Width / 2);
        //    chart2.Width = Convert.ToInt32(this.Width / 2);

        //}
    }
}
