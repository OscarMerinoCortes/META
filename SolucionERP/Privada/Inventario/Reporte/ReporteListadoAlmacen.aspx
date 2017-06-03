<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteListadoAlmacen.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarProductoDetalle.ascx" TagName="wucConsultarProductoDetalle" TagPrefix="WUCCPD" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="Ocultar">
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td colspan="4" class="MenuHead">
                            <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                            <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()" Height="30px" />
                            <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                        </td>
                    </tr>

                    <tr runat="server" visible="false" >
                        <td />
                        <td>
                            ID</td>
                        <td class="auto-style35">
                            <asp:TextBox ID="TBId" runat="server" Width="150"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr runat="server" visible="false" >
                        <td />
                        <td >
                            Producto</td>
                        <td class="auto-style35" >
                            <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>
                        </td>
                        <td ></td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td />
                        <td >
                            Sucursal</td>
                        <td class="auto-style35" >
                            <asp:DropDownList ID="DDSucursal" runat="server" AutoPostBack="True" Width="155">
                            </asp:DropDownList>
                        </td>
                        <td ></td>
                    </tr>
                    <%--<tr>
                    <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Inicio Registro</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaInicioRegistro" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioRegistro" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                    <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Fin Registro</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaFinRegistro" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinRegistro" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                    <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Inicio Actualizacion</td>
                    <td style="width: 241px"><asp:TextBox ID="TBFechaInicioActualizacion" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioActualizacion" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                    <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Fin Actualizacion</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaFinActualizacion" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinActualizacion" />
                    </td>
                    <td style="width: 156px"></td>
                    <td style="width: 273px"></td>
                </tr>--%>
                    <tr>
                        <td />
                        <td >
                            Almacén</td>
                        <td class="auto-style35" >
                            <asp:DropDownList ID="DDAlmacen" runat="server" Width="155">
                            </asp:DropDownList>
                        </td>
                        <td ></td>
                    </tr>
                    <tr>
                        <td />
                        <td >
                            Clasificación</td>
                        <td class="auto-style35" >
                            <asp:DropDownList ID="DDClasificacion" runat="server" AutoPostBack="True" Width="155">
                            </asp:DropDownList>
                        </td>
                        <td ></td>
                    </tr>
                    <tr>
                        <td />
                        <td >
                            Subclasificación</td>
                        <td class="auto-style35" >
                            <asp:DropDownList ID="DDSubClasificacion" runat="server" Width="155">
                            </asp:DropDownList>
                        </td>
                        <td ></td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td />
                        <td >
                            Estado</td>
                        <td class="auto-style35" >
                            <asp:DropDownList ID="DDEstado" runat="server" Width="155">
                            </asp:DropDownList>
                        </td>
                        <td ></td>
                    </tr>
                    <tr>
                        <td />
                        <td ></td>
                        <td class="auto-style35" ></td>
                        <td ></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:GridView ID="GVReporteExistencia" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="100%">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>            
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        
        .auto-style34 {
            width: 1587px;
        }
        .auto-style35 {
            width: 1664px;
        }
    </style>
</asp:Content>

