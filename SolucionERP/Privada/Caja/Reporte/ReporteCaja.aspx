<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteCaja.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css"/>
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print"/>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
           <%-- <div class="Ocultar">--%>
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" class="MenuHead">
                            <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                            <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()" />
                            <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" class="auto-style7"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style9"></td>
                    </tr>

                    <tr>
                        <td class="auto-style7" colspan="2">
                            <div id="divBotonesConsultas" class="row">
                                <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                                    <asp:Button ID="BTNHoy" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary"/>
                                    <asp:Button ID="BTNSemana" runat="server" Text="Esta Semana" CssClass="btn btn-primary" />
                                    <asp:Button ID="BTNMes" runat="server" Text="Este Mes" CssClass="btn btn-primary"/>
                                    <asp:Button ID="BTNAno" runat="server" Text="Este Año" CssClass="btn btn-primary"/>
                                    <asp:Button ID="BTNAvanzado" runat="server" Text="Avanzado" CssClass="btn btn-primary"/>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr runat="server" visible="false">
                        <td style="font-size: medium;" class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id Cliente</td>
                        <td style="width: 241px">
                            <asp:TextBox ID="TBIdCliente" runat="server" Width="165"></asp:TextBox>
                        </td>
                        <td style="width: 156px">&nbsp;</td>
                        <td style="width: 273px">&nbsp;</td>
                    </tr>
                    <tr id="RWSucursal" runat="server" visible="false">
                        <td class="auto-style3" style="font-size: medium;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sucursal</td>
                        <td style="width: 241px">
                            <asp:DropDownList ID="DDSucursal" runat="server" Height="22px" Width="170px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 156px">&nbsp;</td>
                        <td style="width: 273px">&nbsp;</td>
                    </tr>
                    <tr id="RWDe" runat="server" visible="false">
                        <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; De:</td>
                        <td style="width: 241px">
                            <asp:TextBox ID="TBFechaInicio" runat="server" Width="165px" Height="20px" Font-Bold="True" Font-Strikeout="False"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                        </td>
                        <td style="width: 156px">&nbsp;</td>
                        <td style="width: 273px">&nbsp;</td>
                    </tr>
                    <tr id="RWAl" runat="server" visible="false">
                        <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Al:</td>
                        <td style="width: 241px">
                            <asp:TextBox ID="TBFechaFin" runat="server" Width="165px" Height="20px" Font-Bold="True"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                        </td>
                        <td style="width: 156px">&nbsp;</td>
                        <td style="width: 273px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                        <td style="width: 241px">
                            <asp:Button ID="BTNBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" visible="false"/>
                        </td>
                        <td style="width: 156px"></td>
                        <td style="width: 273px"></td>
                    </tr>
                </table>
            <div>
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr style="text-align: center;">
                        <td colspan="4"><span>
                            <asp:GridView ID="GVReporteCaja" runat="server" OnSorting="SortRecords" AllowSorting="true" CellPadding="4" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 5% 3% 5% 1%;" Width="100%" >
                            </asp:GridView>
                        </span></td>
                    </tr>
                </table>
                    
                
            </div>
                           
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            height: 24px;
            width: 189px;
        }
        .auto-style3 {
            width: 189px;
        }
        .auto-style4 {
            width: 241px;
            height: 24px;
        }
        .auto-style5 {
            width: 156px;
            height: 24px;
        }
        .auto-style6 {
            width: 273px;
            height: 24px;
        }
        .auto-style7 {
            height: 21px;
        }
        .auto-style8 {
            width: 156px;
            height: 21px;
        }
        .auto-style9 {
            width: 273px;
            height: 21px;
        }
        .auto-style10 {
            width: 189px;
            height: 22px;
        }
        .auto-style11 {
            width: 241px;
            height: 22px;
        }
        .auto-style12 {
            width: 156px;
            height: 22px;
        }
        .auto-style13 {
            width: 273px;
            height: 22px;
        }
        </style>
</asp:Content>

