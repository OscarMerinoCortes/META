<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteCXC.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />    
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
   <%-- <script type="text/javascript">
        function imprSelec(muestra)
        { var ficha = document.getElementById(muestra); var ventimp = window.open(' ', 'popimpr'); ventimp.document.write(ficha.innerHTML); ventimp.document.close(); ventimp.print(); ventimp.close(); }
    </script>--%>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="Ocultar">
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td colspan="3" class="MenuHead">
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTReporte" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                        <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" Visible="False" />
                        <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                        <%--<a href="javascript:imprSelec('TablaReporte')">Imprimir Tabla</a>--%>

                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
             <%--   <tr>
                    <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">*</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBCompra" runat="server" Width="150px" AutoPostBack="True" Visible="false" />                        
                    </td>
                </tr>--%>
                <tr>
                    <td />
                    <td colspan="3">
                       <WUCP:WucConsultarPersona ID="wucConPer" runat="server" />
                    </td>
                </tr>
              <%--   <tr>
                    <td style="width: 20px;" />
                    <td style="width: 150px;">*</td>
                    <td>
                        <asp:DropDownList ID="DDDestino" runat="server" Width="155" AutoPostBack="True" />
                    </td>
                </tr>--%>
                 <%-- <tr>
                    <td />
                    <td class="PrimeraColumna">*</td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDClasificacion" runat="server" Width="155" AutoPostBack="True" />
                    </td>
                </tr>--%>
            <%--    <tr>
                    <td />
                    <td>*</td>
                    <td>
                        <asp:DropDownList ID="DDSubclasificacion" runat="server" Width="155" AutoPostBack="True" />
                    </td>
                </tr>--%>
            <%--    <tr>
                    <td />
                    <td class="PrimeraColumna">Sucursal</td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDSucursal" runat="server" Width="155" AutoPostBack="True" />
                    </td>
                </tr>--%>
                <tr>
                    <td />
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155" AutoPostBack="True" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="PrimeraColumna">Del:</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBFechaInicio" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" Width="150" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                            Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td>Al:</td>
                    <td>
                        <asp:TextBox ID="TBFechaFin" runat="server" Font-Bold="True" Width="150" AutoPostBack="True" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                            Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
            </table>
                </div>
            <div id="TablaReporte">
                <table style="width: 100%;">
                    <tr style="text-align: center;">
                        <td colspan="4"><span>

                            <asp:GridView Width=" 100%" ID="GVCompra" runat="server" OnSorting="SortRecords" AllowSorting="true" CellPadding="4" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                            </asp:GridView>
                        </span></td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>















































































