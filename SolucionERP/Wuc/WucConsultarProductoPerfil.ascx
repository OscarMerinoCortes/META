<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarProductoPerfil.ascx.vb" Inherits="WucConsultarProductoPerfil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:HiddenField ID="HFMPEConsultarProductoDetalle" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarProductoDetalle" runat="server" TargetControlID="HFMPEConsultarProductoDetalle" PopupControlID="PanelConsultarProductoPerfil" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="PanelConsultarProductoPerfil" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px" Height="600px" Width="1100px">
 <table style="width: 100%; border-collapse: collapse;">
        <tr>
            <td colspan="2" style="background-color: #285583; background-image: none; background-repeat: no-repeat; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: normal; height: 25px; text-align: left; vertical-align: middle; width: 1250px;">&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="LBTitulo"/>
            </td>
            <td style="background-color: #285583;">
                <asp:ImageButton ID="BTNCerrarBusqueda" runat="server" OnClick="BTNCerrarBusqueda_Click" ImageUrl="~/Imagenes/IMCerrar.png" Width="24" />
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="1752px" Width="100%">
                <Panes>
                    <asp:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                        <Header>Compras</Header>
                        <Content>
                            <table style="width: 100%;">
                                <tr style="text-align: center;">
                                    <td colspan="5">
                                        <asp:Chart ID="CHCompra" runat="server" Height="240px" ViewStateContent="All"
                                            Width="1100px">
                                            <Titles>
                                                <asp:Title Font="Trebuchet MS, 10pt, style=Bold"  Name="Title1" ForeColor="26, 59, 105">
                                                </asp:Title>
                                            </Titles>
                                            <Legends>
                                                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Enabled="true"
                                                    Name="Default">
                                                </asp:Legend>
                                            </Legends>
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
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                        <Header>Ventas</Header>
                        <Content>
                            <table style="width: 100%;">
                                <tr style="text-align: center;">
                                    <td>                                       
                                         <asp:Chart ID="CHVenta" runat="server" Height="240px" ViewStateContent="All"
                                            Width="1100px">
                                            <Titles>
                                                <asp:Title Font="Trebuchet MS, 10pt, style=Bold"  Name="Title1" ForeColor="26, 59, 105">
                                                </asp:Title>
                                            </Titles>
                                            <Legends>
                                                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="true" Enabled="true"
                                                    Name="Default">
                                                </asp:Legend>
                                            </Legends>
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
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                        <Header>Existencias</Header>
                        <Content>
                            <table style="width: 100%;">
                                <tr style="text-align: center;">
                                    <td>
                                        <asp:Chart ID="CHExistencia" runat="server" Height="240px" ViewStateContent="All"
                                            Width="1100px">
                                            <Titles>
                                                <asp:Title Font="Trebuchet MS, 10pt, style=Bold"  Name="Title1" ForeColor="26, 59, 105">
                                                </asp:Title>
                                            </Titles>
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
                                                    <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="Almacenes" IntervalAutoMode="VariableCount">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="" HeaderCssClass="">
                        <Header>Proveedores</Header>
                        <Content>
                            <table style="width: 100%;">
                                <tr style="text-align: center;">
                                    <td>
                                        <asp:GridView ID="GVProveedor" runat="server" CssClass="GridComun" GridLines="None" Style="margin: 0 auto;" Width="100%">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <PagerStyle CssClass="pgr" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
        </asp:View>
    </asp:MultiView>
</asp:Panel>
