<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteCompras.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WucConsultarProveedor.ascx" TagName="wucConsultarProveedor" TagPrefix="WUCProv" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="Ocultar">
                <table style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td colspan="3" class="MenuHead">
                            <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                            <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()" />
                            <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeroColumna"></td>
                        <td class="PrimeraColumna">&nbsp;</td>
                        <td class="SegundaColumna">&nbsp;</td>
                    </tr>
                    <tr>
                        <td />
                        <td colspan="2">
                            <WUCProv:wucConsultarProveedor ID="wucConProv" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td class="PrimeraColumna">Fecha Inicio</td>
                        <td class="SegundaColumna">
                            <asp:TextBox ID="TBFechaInicio" runat="server" AutoPostBack="True" Font-Bold="True" Font-Strikeout="False" Width="150" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td>Fecha Fin </td>
                        <td>
                            <asp:TextBox ID="TBFechaFin" runat="server" AutoPostBack="True" Font-Bold="True" Width="150" />
                            <ajaxToolkit:CalendarExtender ID="TBFechaFin_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td class="PrimeraColumna">Estado</td>
                        <td class="SegundaColumna">
                            <asp:DropDownList ID="DDEstado" runat="server" AutoPostBack="True" Width="155" />
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td />
                        <td class="PrimeraColumna">&nbsp;</td>
                        <td class="SegundaColumna">&nbsp;</td>
                    </tr>
                    <tr>
                        <td />
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                </table>
            </div>
            <div id="TablaReporte">
                <%--  <table style="width: 100%; border-collapse: collapse;">--%>
                <asp:GridView Width=" 100%" ID="GVCompra" runat="server" OnSorting="SortRecords" AllowSorting="true" CellPadding="4" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto; text-align: center;">
                </asp:GridView>
                <%--</table>--%>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>















































































