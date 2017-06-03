<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteExistenciaAlmacen.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarProductoDetalle.ascx" TagName="wucConsultarProductoDetalle" TagPrefix="WUCCPD" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print"/>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="Ocultar">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" class="MenuHead">
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png"/>
                       <%-- <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl= Visible="False" />--%>
                        <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()"/>
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style33">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style36">
                        ID</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBId" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 273px">&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style37">
                        Descripcion</td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 273px">&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style41">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style38">Sucursal</td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="DDSucursal" runat="server" AutoPostBack="True" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13"></td>
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
                    <td class="auto-style40" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td >
                        Almacén</td>
                    <td >
                        <asp:DropDownList ID="DDAlmacen" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td ></td>
                </tr>
                <tr>
                    <td class="auto-style40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style37">
                        Clasificación</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DDClasificacion" runat="server" AutoPostBack="True" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 273px"></td>
                </tr>
                <tr>
                    <td class="auto-style40" >&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td >
                        SubClasificación</td>
                    <td >
                        <asp:DropDownList ID="DDSubClasificacion" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td >&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style37">
                        Estado</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 273px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style41"></td>
                    <td class="auto-style38"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style13"></td>
                </tr>
                </table>
            </div>
            <%--<table>
                <tr style="text-align: center;">--%>
                        <asp:GridView ID="GVReporteExistencia" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto; text-align:center;" 
                            Width="100%" >
                        </asp:GridView> 
              <%--  </tr>--%>
          <%--  </table>--%>
            <WUCCPD:wucConsultarProductoDetalle ID="wucConProDet" runat="server" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style2 {
            height: 24px;
            width: 189px;
        }

        .auto-style4 {
            width: 507px;
        }

        .auto-style9 {
            height: 24px;
            width: 608px;
        }

        .auto-style10 {
            width: 189px;
            height: 29px;
        }

        .auto-style12 {
            width: 507px;
            height: 22px;
        }

        .auto-style13 {
            width: 273px;
            height: 22px;
        }
        .auto-style33 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            width: 40px;
        }
        .auto-style34 {
            width: 50px;
        }
        .auto-style35 {
            height: 22px;
            width: 50px;
        }
        .auto-style36 {
            width: 171px;
            background-color: rgba(195, 195, 195, 0.38);
        }
        .auto-style37 {
            width: 171px;
        }
        .auto-style38 {
            width: 171px;
            height: 22px;
        }
        .auto-style40 {
            width: 40px;
        }
        .auto-style41 {
            height: 22px;
            width: 40px;
        }
    </style>
</asp:Content>

