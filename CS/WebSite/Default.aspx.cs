using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using DevExpress.XtraCharts;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxPivotGrid1.DataSource = GetDataTable();

        if (!IsPostBack)
        {
            WebChartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Pie   );
            WebChartControl1.SeriesDataMember = "Series";
            WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
            WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            WebChartControl1.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            WebChartControl1.SeriesTemplate.PointOptions.Pattern = "{A} - {V}";
            WebChartControl1.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(WebChartControl1_CustomDrawSeriesPoint);

        }
        
    }

    void WebChartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
    {
        ((PieDrawOptions)e.SeriesDrawOptions).FillStyle.FillMode = FillMode.Solid;
        ((PieDrawOptions)e.LegendDrawOptions).FillStyle.FillMode = FillMode.Solid;
        ((PieDrawOptions)e.SeriesDrawOptions).Color = Color.FromName(e.SeriesPoint.Argument);
        ((PieDrawOptions)e.LegendDrawOptions).Color = Color.FromName(e.SeriesPoint.Argument);
    }

    private DataTable GetDataTable()
    {
        DataTable data = new DataTable();
        data.Columns.Add("Name", typeof(string));
        data.Columns.Add("OrderDate", typeof(DateTime ));
        data.Columns.Add("ProductAmount", typeof(int));

        data.Rows.Add(new object[] { "Red", DateTime.Today, 10 });
        data.Rows.Add(new object[] { "Green", DateTime.Today.AddMonths(2), 5 });
        data.Rows.Add(new object[] { "Blue", DateTime.Today.AddMonths(3), 7 });
        data.Rows.Add(new object[] { "Yellow", DateTime.Today.AddMonths(4), 3 });

        return data;

    }
    
}
