Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraCharts

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxPivotGrid1.DataSource = GetDataTable()

		If (Not IsPostBack) Then
			WebChartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Pie)
			WebChartControl1.SeriesDataMember = "Series"
			WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments"
			WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Values" })
			WebChartControl1.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent
			WebChartControl1.SeriesTemplate.PointOptions.Pattern = "{A} - {V}"
			AddHandler WebChartControl1.CustomDrawSeriesPoint, AddressOf WebChartControl1_CustomDrawSeriesPoint

		End If

	End Sub

	Private Sub WebChartControl1_CustomDrawSeriesPoint(ByVal sender As Object, ByVal e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs)
		CType(e.SeriesDrawOptions, PieDrawOptions).FillStyle.FillMode = FillMode.Solid
		CType(e.LegendDrawOptions, PieDrawOptions).FillStyle.FillMode = FillMode.Solid
		CType(e.SeriesDrawOptions, PieDrawOptions).Color = Color.FromName(e.SeriesPoint.Argument)
		CType(e.LegendDrawOptions, PieDrawOptions).Color = Color.FromName(e.SeriesPoint.Argument)
	End Sub

	Private Function GetDataTable() As DataTable
		Dim data As New DataTable()
		data.Columns.Add("Name", GetType(String))
		data.Columns.Add("OrderDate", GetType(DateTime))
		data.Columns.Add("ProductAmount", GetType(Integer))

		data.Rows.Add(New Object() { "Red", DateTime.Today, 10 })
		data.Rows.Add(New Object() { "Green", DateTime.Today.AddMonths(2), 5 })
		data.Rows.Add(New Object() { "Blue", DateTime.Today.AddMonths(3), 7 })
		data.Rows.Add(New Object() { "Yellow", DateTime.Today.AddMonths(4), 3 })

		Return data

	End Function

End Class
