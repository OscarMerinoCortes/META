<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucGraficaVenta.ascx.vb" Inherits="WucGraficaVenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="../CSS/StyleSheet.css" rel="stylesheet" />
<table>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td class="style1"></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart1" runat="server" Height="240px" DataSourceID="SqlDataSource1"
                ViewStateContent="All" Width="350px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Cantidad de Ventas por Mes"
                        Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="false"
                        Name="Default">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" XValueMember="Mes" YValueMembers="Cantidad"
                        ChartType="StackedColumn">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="White" ShadowColor="DarkRed" BackGradientStyle="TopBottom" AlignmentOrientation="Vertical"
                        AlignmentStyle="All">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="True"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Cantidad">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Meses" IntervalAutoMode="VariableCount">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenAnoCan2"></asp:SqlDataSource>
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart2" runat="server" Height="240px" DataSourceID="SqlDataSource2"
                Width="385px" ViewStateContent="All">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="sucursal"
                        YValueMembers="cantidad">
                        <EmptyPointStyle BackImageAlignment="Right" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea AlignmentStyle="None" BackColor="White"
                        BackGradientStyle="TopBottom" BackSecondaryColor="White"
                        BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="DarkRed">
                        <AxisY LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Cantidad">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        </AxisY>
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False"
                            LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Sucursales">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Angle="90" Font="Trebuchet MS, 8.25pt, style=Bold"
                                IsEndLabelVisible="False" />
                        </AxisX>
                        <Area3DStyle Inclination="15" Rotation="10" WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend BackColor="Transparent" Enabled="False"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        TableStyle="Tall" LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Ventas de Sucursales del Mes [miles]" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenMesSuc">
            </asp:SqlDataSource>
        </td>
        <td align="center">
            <asp:Chart ID="Chart3" runat="server" Height="240px" DataSourceID="SqlDataSource3"
                Width="385px" ViewStateContent="All">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="vendedor"
                        YValueMembers="cantidad">
                        <EmptyPointStyle BackImageAlignment="Right" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea AlignmentStyle="None" BackColor="White"
                        BackGradientStyle="TopBottom" BackSecondaryColor="White"
                        BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="DarkRed">
                        <AxisY LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Cantidad">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        </AxisY>
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False"
                            LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Vendedor">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Angle="90" Font="Trebuchet MS, 8.25pt, style=Bold"
                                IsEndLabelVisible="False" />
                        </AxisX>
                        <Area3DStyle Inclination="15" Rotation="10" WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend BackColor="Transparent" Enabled="False"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        TableStyle="Tall" LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="TOP (10) Vendedores del Mes [miles]" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenMesVen">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart4" runat="server" Height="240px" DataSourceID="SqlDataSource4"
                ViewStateContent="All" Width="350px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Monto de Ventas por Mes [miles]"
                        Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="false"
                        Name="Default">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" XValueMember="Mes" YValueMembers="Cantidad"
                        ChartType="StackedColumn">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="White" ShadowColor="DarkRed" BackGradientStyle="TopBottom" AlignmentOrientation="Vertical"
                        AlignmentStyle="All">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="True"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Cantidad (Miles)">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Meses" IntervalAutoMode="VariableCount">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenAnoMon">
            </asp:SqlDataSource>
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td align="center">
            <asp:Chart ID="Chart5" runat="server" Height="240px" DataSourceID="SqlDataSource5"
                Width="385px" ViewStateContent="All">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="Clasificacion"
                        YValueMembers="Cantidad">
                        <EmptyPointStyle BackImageAlignment="Right" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea AlignmentStyle="None" BackColor="White"
                        BackGradientStyle="TopBottom" BackSecondaryColor="White"
                        BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="DarkRed">
                        <AxisY LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Cantidad">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        </AxisY>
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False"
                            LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Meses">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Angle="90" Font="Trebuchet MS, 8.25pt, style=Bold"
                                IsEndLabelVisible="False" />
                        </AxisX>
                        <Area3DStyle Inclination="15" Rotation="10" WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend BackColor="Transparent" Enabled="False"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        TableStyle="Tall" LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="TOP (10) Ventas por Clasificacion del Mes [miles]" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenMesCla">
            </asp:SqlDataSource>
        </td>
        <td colspan="5" align="left">
               <asp:Chart ID="Chart6" runat="server" Height="240px" DataSourceID="SqlDataSource6"
                Width="385px" ViewStateContent="All">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="Producto"
                        YValueMembers="Cantidad">
                        <EmptyPointStyle BackImageAlignment="Right" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea AlignmentStyle="None" BackColor="White"
                        BackGradientStyle="TopBottom" BackSecondaryColor="White"
                        BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="DarkRed">
                        <AxisY LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Cantidad">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        </AxisY>
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False"
                            LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64"
                            TextOrientation="Stacked" Title="Meses">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Angle="90" Font="Trebuchet MS, 8.25pt, style=Bold"
                                IsEndLabelVisible="False" />
                        </AxisX>
                        <Area3DStyle Inclination="15" Rotation="10" WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend BackColor="Transparent" Enabled="False"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        TableStyle="Tall" LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="TOP (10) Ventas por Clasificacion del Mes [miles]" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_ObtVenMesPro">
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
