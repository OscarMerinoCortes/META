<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucGraficaCXP.ascx.vb" Inherits="WucGraficaCXP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="../CSS/StyleSheet.css" rel="stylesheet" />
<table>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td class="style1">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart1" runat="server" Height="240px" DataSourceID="SqlDataSource1"
                ViewStateContent="All" Width="285px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Numero de Cuentas por pagar"
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
                SelectCommand="ERP_LisNumCXP"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart2" runat="server" Height="240px" DataSourceID="SqlDataSource2"
                ViewStateContent="All" Width="285px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Estimados por mes" Name="Title1"
                        ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="false"
                        Name="Default">
                    </asp:Legend>
                </Legends>
                <Series>
                  <%--  <asp:Series Name="Series1" XValueMember="Mes" YValueMembers="Principal" ChartType="StackedArea">
                    </asp:Series>--%>
                    <asp:Series Name="Series2" XValueMember="Mes" YValueMembers="Monto" 
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_LisEstMesCXP"></asp:SqlDataSource>
        </td>
        <td class="style1">
            &nbsp;&nbsp;&nbsp;</td>
        <td align=center>
            <asp:Chart ID="Chart6" runat="server" Height="240px" DataSourceID="SqlDataSource6"
                Width="385px" ViewStateContent="All">
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" IsValueShownAsLabel="True" 
                        Legend="Default" Name="Series1" XValueMember="Estado" 
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
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Numero de cuentas por pagar" Name="Title1"
                        ForeColor="26, 59, 105" Alignment="TopCenter">
                    </asp:Title>
                </Titles>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_LisNumCXPEst"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart4" runat="server" Height="240px" DataSourceID="SqlDataSource4"
                Width="285px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Monto de Cuentas por pagar"
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
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_LisMonCXP"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <asp:Chart ID="Chart5" runat="server" Height="240px" DataSourceID="SqlDataSource5"
                Width="285px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Pagados por mes" Name="Title1"
                        ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="false"
                        Name="Default">
                    </asp:Legend>
                </Legends>
                <Series>
                  <%--  <asp:Series Name="Series1" XValueMember="Mes" YValueMembers="Principal" ChartType="StackedArea">
                    </asp:Series>--%>
                    <asp:Series Name="Series2" XValueMember="Mes" YValueMembers="Monto" 
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
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_LisCXPConCob"></asp:SqlDataSource>
        </td>
        <td class="style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td align=center>
            <asp:Chart ID="Chart7" runat="server" Height="240px" DataSourceID="SqlDataSource7"
                Width="285px">
                <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Saldo de Creditos" Name="Title1"
                        ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="false"
                        Name="Default" Alignment="Far">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad" ChartType="Pie">
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
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:MMunozConnectionString %>"
                SelectCommand="ERP_LisSalCXPEst"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
       <td> &nbsp;</td>
        <td colspan="5" align="left"  >
<%--         <asp:Chart ID="Chart3" runat="server" Height="240px" ViewStateContent="All" 
                Width="1100px">
                                                <Titles>
                                                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Interes Generado" Name="Title1" ForeColor="26, 59, 105">
                                                    </asp:Title>
                                                </Titles>
                                                <legends>
                                                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Enabled="true"
                                                    Name="Default">
                                                    </asp:Legend>
                                                </legends>
                                                <Series>
                                                    <asp:Series Name="Serie1" XValueMember="Dia" YValueMembers="Interes" IsXValueIndexed="true" IsVisibleInLegend="true" LegendText="Interes"   
                                                        ChartType="StackedArea">
                                                    </asp:Series>
                                                      <asp:Series Name="Serie2" XValueMember="Dia" YValueMembers="Mora" IsXValueIndexed="true" IsVisibleInLegend="true" LegendText="Mora"  
                                                        ChartType="StackedArea">
                                                    </asp:Series>
                                                      <asp:Series Name="Serie3" XValueMember="Dia" YValueMembers="Suspenso" IsXValueIndexed="true" IsVisibleInLegend="true" LegendText="Suspenso" 
                                                        ChartType="StackedArea">
                                                    </asp:Series>

                                                </Series>
                                                <chartareas>
                                                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                                        BackColor="White" ShadowColor="DarkRed" BackGradientStyle="TopBottom" AlignmentOrientation="Vertical"
                                                        AlignmentStyle="All">
                                                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="True"
                                                            WallWidth="0" IsClustered="False" />
                                                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Cantidad [Miles]">
                                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                                        </AxisY>
                                                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Dias" IntervalAutoMode="VariableCount" >
                                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                                        </AxisX>
                                                    </asp:ChartArea>
                                                </chartareas>
                                            </asp:Chart>--%>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td class="style1">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
