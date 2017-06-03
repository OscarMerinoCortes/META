<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteCliente.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css"/>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
              
                <tr>
                    <td colspan="4" class="MenuHead">
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />  
                        <asp:ImageButton ID="IBTReporte" runat="server" ImageUrl="~/Imagenes/IMReporte.png" />
                        <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" Visible="False" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">&nbsp;</td>
                </tr>

                <tr>
                    <td colspan="2"><strong>&nbsp;&nbsp;&nbsp;</strong></td>
                    <td style="width: 156px"></td>
                    <td style="width: 273px"></td>
                </tr>
                <tr>
                    <td style="font-size: medium;" class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estado</td>
                    <td style="width: 241px">
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="128px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
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
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Genero</td>
                    <td style="width: 241px; height: 24px;">
                        <asp:DropDownList ID="DDGenero" runat="server" Height="22px" Width="128px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 156px; height: 24px;"></td>
                    <td style="width: 273px; height: 24px;"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tipo Persona</td>
                    <td style="width: 241px">
                        <asp:DropDownList ID="DDTipoPersona" runat="server" Height="22px" Width="128px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 156px"></td>
                    <td style="width: 273px"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td style="width: 241px"></td>
                    <td style="width: 156px"></td>
                    <td style="width: 273px"></td>
                </tr>
                <tr style="text-align:center;">
                    <td colspan="4"><span>
                        <asp:GridView ID="GVReporteCliente" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" style="margin: 0 auto;">
                        </asp:GridView>
                        </span></td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
            </table>
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
    </style>
</asp:Content>

