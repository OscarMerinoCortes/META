<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucGraficaMovimientoInventario.ascx.vb" Inherits="Wuc_WucGraficaMovimientoInventario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .auto-style2 {
        width: 100px;
        height: 314px;
    }
    .auto-style3 {
        height: 314px;
    }
    .auto-style7 {
        height: 66px;
    }
    .auto-style11 {
        width: 100px;
    }
    .auto-style12 {
        height: 66px;
        width: 100px;
    }
    .auto-style14 {
        height: 40px;
    }
    .auto-style15 {
        width: 100px;
        height: 40px;
    }
</style>
<table>
    <tr>
        <td class="auto-style15"></td>
        <td class="auto-style14"></td>
        <td class="auto-style15"></td>
        <td class="auto-style14"></td>      
        <td class="auto-style15"></td> 
        <td class="auto-style14"></td>  
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td class="auto-style3">
            <asp:Chart ID="Chart1" runat="server" Height="300px" 
                ViewStateContent="All" Width="500px" PaletteCustomColors="Black; Red; Blue; 192, 64, 0; Fuchsia">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Numero de productos por mes"
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
                    <asp:Series Name="Cantidad" XValueMember="Mes" YValueMembers="Cantidad"
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
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SysetiSFIConnectionString %>"
                SelectCommand="cre_LisGraNumCre"></asp:SqlDataSource>--%>
   <%--         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ Data Source=syseti.database.windows.net,1433;Initial Catalog=SysetiMeta;Persist Security Info=True;User ID=syseti; Password=Quanto206#;" providerName="System.Data.SqlClient %>"
                SelectCommand="ERP_GraNumProMes"></asp:SqlDataSource>--%>
        </td>  
        <td class="auto-style2"></td>
        <td class="auto-style3">
            <asp:Chart ID="Chart3" runat="server" Height="300px"
                Width="500px" ViewStateContent="All"  PaletteCustomColors="Black; Red; Blue; 192, 64, 0; Fuchsia">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="Almacen"
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
                    <asp:Legend BackColor="Transparent" Enabled="false"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Name="Default"
                        TableStyle="tall" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Inventario por almacén" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </td>
        <td class="auto-style11"></td>
        <td></td>
    </tr>
    <tr>
        <td class="auto-style12"></td>
        <td class="auto-style7"></td>
        <td class="auto-style12"></td>
        <td class="auto-style7"></td>
        <td class="auto-style12"></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style11"></td>
        <td>
            <asp:Chart ID="Chart2" runat="server" Height="300px"
                Width="500px" PaletteCustomColors="Black; Red; Blue; 192, 64, 0; Fuchsia">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Monto de productos por mes"
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
                    <asp:Series Name="Monto" XValueMember="Mes" YValueMembers="Monto" 
                        ChartType="StackedColumn">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="White" ShadowColor="DarkRed" BackGradientStyle="TopBottom" AlignmentOrientation="Vertical"
                        AlignmentStyle="All">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="True"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Cantidad [Miles]">
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
        </td>
        <td class="auto-style11"></td>
        <td>
            <asp:Chart ID="Chart4" runat="server" Height="300px"
                Width="500px" ViewStateContent="All" PaletteCustomColors="Black; Red; Blue; 192, 64, 0; Fuchsia">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="Maximo"
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
                    <asp:Legend BackColor="Transparent" Enabled="false"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Name="Default"
                        TableStyle="tall" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Productos con excedentes" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </td>
        <td class="auto-style11"></td>
        <td>
            <asp:Chart ID="Chart5" runat="server" Height="300px"
                Width="500px" ViewStateContent="All" PaletteCustomColors="Black; Red; Blue; 192, 64, 0; Fuchsia">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True"
                        Legend="Default" Name="Series1" XValueMember="Minimo"
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
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="false"
                            LabelAutoFitMaxFontSize="8"
                            LineColor="64, 64, 64, 64"
                            TextOrientation="Auto" Title="Meses">
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <LabelStyle Angle="90" Font="Trebuchet MS, 8.25pt, style=Bold"
                                IsEndLabelVisible="false" />
                        </AxisX>
                        <Area3DStyle Inclination="15" Rotation="10" WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend BackColor="Transparent" Enabled="false"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Name="Default"
                        TableStyle="tall" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Productos con faltantes" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </td>
    </tr>
</table>
