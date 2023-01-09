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
using System.Windows.Forms.DataVisualization.Charting;
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

            cboFReason.Items.Add("ALL");
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

            GridUtil _Gridutril1 = new GridUtil();
            _Gridutril1.InitColumnGrid(dgvChartData, "DATE", "날짜", typeof(string), 120, DataGridViewContentAlignment.MiddleLeft, false);
            _Gridutril1.InitColumnGrid(dgvChartData, "FREASON", "귀책사유", typeof(int), 100, DataGridViewContentAlignment.MiddleRight, false);
            _Gridutril1.InitColumnGrid(dgvChartData, "CNT", "수량", typeof(string), 100, DataGridViewContentAlignment.MiddleLeft, false);
        }

        public override void DoInquire()
        {

            //일자별 총 검사 품목 수 대비 불량 수량 을 보여주는 파이차트
            string itemCode = cboItemCode.SelectedValue.ToString();
            string sDate = ISP_SDate.Text;
            string eDate = ISP_EDate.Text;
            string fReason = cboFReason.Text;
            if (fReason == "ALL") fReason = "";

            DBHelper helper = new DBHelper();
            helper.SetSelectSP("SP_ItemISPResult_PiChartData");
            helper.SetSelectSP_Param("@ITEMCODE", itemCode);
            helper.SetSelectSP_Param("@SDATE", sDate);
            helper.SetSelectSP_Param("@EDATE", eDate);

            DataTable dtTemp = new DataTable();
            helper.SelectSP_Run(dtTemp);


            #region < 조회기간동안 OK/NG 비율을 파이 차트로 표현  >

            if (dtTemp.Rows.Count == 0)
            {
                chart1.Series.Clear();
                return;
            }

            int cntOK = 0;
            int cntNG = 0;

            //해당기간동안 OK, NG 수량 합
            foreach(DataRow dr in dtTemp.Rows)
            {
                if(dr["TRESULT"].ToString() == "OK")
                {
                    cntOK += Convert.ToInt32(dr["ITEMCNT"].ToString());
                }
                else
                {
                    cntNG += Convert.ToInt32(dr["ITEMCNT"].ToString());
                }
            }

            //chart1에 파이차트 세팅
            chart1.Series.Clear();
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;

            chart1.Series.Add(series);

            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

            //파이차트를 ok/ng 비율로 표시
            chart1.Series[0].Label = "#PERCENT{P1}";
            string[] Legend = { "OK", "NG" };

            //ok/ng 수량이 0일 경우 처리
            if(cntOK == 0)
            {
                chart1.Series[0].Points.Add(cntNG);
                chart1.Series[0].Points[0].LegendText = Legend[1];
            }
            else if(cntNG == 0)
            {
                chart1.Series[0].Points.Add(cntOK);
                chart1.Series[0].Points[0].LegendText = Legend[0];
            }
            else
            {

                chart1.Series[0].Points.Add(cntOK);
                chart1.Series[0].Points[0].LegendText = Legend[0];
                chart1.Series[0].Points.Add(cntNG);
                chart1.Series[0].Points[1].LegendText = Legend[1];
            }
        

            //일자별 귀책사유를 보여주는 차트(막대차트)
            helper.SetSelectSP("SP_ItemISPResult_ColumnhartData");
            helper.SetSelectSP_Param("@ITEMCODE", itemCode);
            helper.SetSelectSP_Param("@SDATE", sDate);
            helper.SetSelectSP_Param("@EDATE", eDate);
            helper.SetSelectSP_Param("@FREASON", fReason);

            DataTable dtTemp2 = new DataTable();
            helper.SelectSP_Run(dtTemp2);

            dgvChartData.DataSource = dtTemp2;

            chart2.Series.Clear();

            #endregion


            if (dtTemp2.Rows.Count == 0)
            {
                return;
            }

           

            if (Convert.ToString(cboFReason.SelectedValue) == "") //ALL 선택시
            {
                #region < 다중 막대 차트 >
                chart2.DataBindCrossTable(dtTemp2.AsEnumerable(), "FREASON", "DATE", "CNT", "");
                for (int i = 0; i < chart2.Series.Count; i++)
                {
                    chart2.Series[i].IsVisibleInLegend = true; //  범례 표시
                    chart2.Series[i].LegendText = chart2.Series[i].ToString().Split('-')[1].ToString(); // 범례
                    chart2.Series[i].SetCustomProperty("PixelPointWidth", "100"); //막대의 폭
                    chart2.Series[i].SetCustomProperty("PointWidth", "0");
                   //
                   //chart2.Series[i].Label = chart2.Series[i].ToString().Split('-')[1].ToString();
                    
                    chart2.Series[i].IsValueShownAsLabel = true;  // 차트에 값 표시

                }
                #endregion
            }
            else // 개별 선택시
            {
                chart2.DataBindTable(dtTemp2.DefaultView, "DATE");
                chart2.Series[0].Name = Convert.ToString(dtTemp2.Rows[0]["FREASON"]);
                //chart2.Series[1].Name = Convert.ToString(dtTemp2.Rows[1]["FREASON"]);
                //chart2.Series[2].Name = Convert.ToString(dtTemp2.Rows[2]["FREASON"]);
            }



        }

        private void dgvChartData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////선택한 행과 일치한느 CHART 데이터를 표시?
            //for(int i = 0; i < chart2.Series.Count; i++)
            //{
            //    string date = dgvChartData.CurrentRow.Cells["DATE"].ToString();
            //    string fReason = dgvChartData.CurrentRow.Cells["FREASON"].ToString();
            //    MessageBox.Show(chart2.Series[i].Points[0].YValues.ToString());
            //    //MessageBox.Show(chart2.Series[i].YValueMembers.ToString()); // 날짜
            //}
            ////if (chart2.Series[i].Name.ToString() == fReason && chart2.Series[i].XV)
          
            //    //MessageBox.Show(chart2.Series[i].Name.ToString()); //공정
            //    //MessageBox.Show(chart2.Series[i].Label.ToString());
            //    //MessageBox.Show(chart2.Series[i].XAxisType.ToString());
            //    //MessageBox.Show(chart2.Series[i].XValueMember.ToString());
        }



        //private void DrawPieChart(Chart chart1, string title, int cntOK, int cntNG)
        //{

        //    chart1.Series.Clear();
        //    chart1.Legends.Clear();

        //    //Add a new Legend(if needed) and do some formating
        //    chart1.Legends.Add("MyLegend");
        //    chart1.Legends[0].LegendStyle = LegendStyle.Table;
        //    chart1.Legends[0].Docking = Docking.Bottom;
        //    chart1.Legends[0].Alignment = StringAlignment.Center;
        //    chart1.Legends[0].Title = title;
        //    chart1.Legends[0].BorderColor = Color.Black;

        //    //Add a new chart-series
        //    string seriesname = "MySeriesName";
        //    chart1.Series.Add(seriesname);
        //    //set the chart-type to "Pie"
        //    chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

        //    //Add some datapoints so the series. in this case you can pass the values to this method
        //    chart1.Series[seriesname].Points.AddXY(cntOK.ToString(), cntOK);
        //    chart1.Series[seriesname].Points.AddXY(cntNG.ToString(), cntNG);
        //    chart1.Series[seriesname].LegendText = "aaa";
        //    MessageBox.Show(chart1.Series[seriesname].Points[0].ToString());

        //    //chart1.Series[seriesname].Points.AddXY("MyPointName2", value3);
        //    //chart1.Series[seriesname].Points.AddXY("MyPointName3", value4);
        //    //chart1.Series[seriesname].Points.AddXY("MyPointName4", value5);
        //}
    }
}
