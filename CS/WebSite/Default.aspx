<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register assembly="DevExpress.XtraCharts.v13.1.Web, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" >
            <Fields>
                <dx:PivotGridField ID="fieldName" AreaIndex="0" Area="RowArea" 
                    FieldName="Name" 
                    UnboundFieldName="fieldOrderDate" >
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldProductAmount" Area="DataArea" AreaIndex="0" 
                    FieldName="ProductAmount">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldOrderDate1" Area="FilterArea" AreaIndex="0" 
                    FieldName="OrderDate"  ValueFormat-FormatType="Numeric" ValueFormat-FormatString="dd MMMM"  >
                </dx:PivotGridField>
            </Fields>
            <OptionsView ShowColumnGrandTotals="False" ShowRowGrandTotals="False" />
        </dx:ASPxPivotGrid>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
            DataFile="~/App_Data/nwind.mdb" 
            SelectCommand="SELECT [ProductName], [CompanyName], [OrderDate], [ProductAmount] FROM [CustomerReports]">
        </asp:AccessDataSource>
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" 
            DataSourceID="ASPxPivotGrid1" Height="400px" Width="600px"             >
<SeriesTemplate   >
<ViewSerializable>
<cc1:SideBySideBarSeriesView HiddenSerializableString="to be serialized"></cc1:SideBySideBarSeriesView>
</ViewSerializable>

<LabelSerializable>
<cc1:SideBySideBarSeriesLabel HiddenSerializableString="to be serialized" LineVisible="True">
<FillStyle >
<OptionsSerializable>
<cc1:SolidFillOptions HiddenSerializableString="to be serialized"></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
</cc1:SideBySideBarSeriesLabel>
</LabelSerializable>

<PointOptionsSerializable>
<cc1:PointOptions HiddenSerializableString="to be serialized"></cc1:PointOptions>
</PointOptionsSerializable>

<LegendPointOptionsSerializable>
<cc1:PointOptions HiddenSerializableString="to be serialized"></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

<FillStyle >
<OptionsSerializable>
<cc1:SolidFillOptions HiddenSerializableString="to be serialized"></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
        </dxchartsui:WebChartControl>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server">
        </asp:AccessDataSource>
    
    </div>
    </form>
</body>
</html>
