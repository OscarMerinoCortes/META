<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="PerfilCliente.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WucConsultarPersona.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css"/>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                
                <tr>
                    <td class="MenuHead">
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                





                 <table style="width: 100%">
                <tr>
                    <td  colspan="2">
                        <WUCP:wucConsultarPersona ID="wucConPer" runat="server"  style="width: 100%;"/>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">Id</td>
                    <td>
                        <asp:TextBox ID="TBIdPersonaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Equivalencia</td>
                    <td>
                        <asp:TextBox ID="TBEquivalenciaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Nombre Cliente</td>
                    <td>
                        <asp:TextBox ID="TBNombreClienteConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                     <tr>
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="TBFechaInicioConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Fin</td>
                    <td>
                        <asp:TextBox ID="TBFechaFinConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Genero</td>
                    <td>
                        <asp:DropDownList ID="DDGeneroConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Persona</td>
                    <td>
                        <asp:DropDownList ID="DDTipoPersonaConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstadoConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView Width="100%" ID="GVPersona" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                        </asp:GridView>
                    </td>
                </tr>
            </table>


                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td>
                        <asp:ImageButton ID="IBTRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align:center;">
                    <td>
                        <asp:GridView ID="GVPerfilCliente" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" style="margin: 0 auto;">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>

