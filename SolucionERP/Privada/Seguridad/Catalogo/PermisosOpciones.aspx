<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="PermisosOpciones.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td></td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVUsuario" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%; border-collapse: collapse;">

                <tr>
                    <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdUsuario" runat="server" Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="TBIdUsuarioPermiso" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Username
                    </td>
                    <td>
                        <asp:TextBox ID="TBUsername" runat="server" Enabled="False"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Abreviacion
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBAbreviacion" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Nombre 
                    </td>
                    <td>
                        <asp:TextBox ID="TBNombre" Enabled="False" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td class="CeroColumna"></td>
                    <td colspan="2" class="PrimeraColumna"><strong>Acciones</strong></td>
                </tr>
                <tr>
                    <td />
                    <td class="">Guardar</td>
                    <td class="">
                        <asp:CheckBox ID="CBGuardar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="CeroColumna">Actualizar</td>
                    <td class="">
                        <asp:CheckBox ID="CBActualizar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Consultar</td>
                    <td class="">
                        <asp:CheckBox ID="CBConsultar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>                
                <tr>
                    <td />
                    <td class="">Cancelar</td>
                    <td class="">
                        <asp:CheckBox ID="CBCancelar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Exportar</td>
                    <td class="">
                        <asp:CheckBox ID="CBExportar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Imprimir</td>
                    <td class="">
                        <asp:CheckBox ID="CBImprimir" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Aplicar</td>
                    <td class="">
                        <asp:CheckBox ID="CBAplicar" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                 <tr>
                    <td class="CeroColumna"></td>
                    <td colspan="2"><strong>Opciones</strong></td>
                </tr>
                 <tr>
                    <td />
                    <td class="">Cataloos</td>
                    <td class="">
                        <asp:CheckBox ID="CBCataloos" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Proceso</td>
                    <td class="">
                        <asp:CheckBox ID="CBProceso" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td class="">Reportes</td>
                    <td class="">
                        <asp:CheckBox ID="CBReportes" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td />
                    <td colspan="2">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" Visible="false" runat="server" style="width: 100%;" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<%--  --%>