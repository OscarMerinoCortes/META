<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Autorizar.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" Visible="False" />
                <asp:ImageButton ID="IBTConsultar0" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>       
        </table>
    <asp:MultiView ID="MultiView1" runat="server">                 
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%; height: 177px;">
                <tr >
                    <td class="auto-style3">&nbsp; ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                  
                        <asp:TextBox ID="TBId" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp; Nombre&nbsp;
                    
                        <asp:TextBox ID="TBNombre" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp; Estado&nbsp;&nbsp;&nbsp;&nbsp;
                    
                        <asp:DropDownList ID="DDEstado2" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="BTNConsultar" runat="server" Text="Consultar" Visible="False" />
                    </td>
                </tr>
                <tr style="text-align: center;">
                    <td class="auto-style2">
                        <asp:GridView ID="GVAutorizar" Width="100%" runat="server"
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
                        <asp:TextBox ID="TBIdCredito" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td  colspan="2">
                        <WUCP:wucConsultarPersona ID="wucConsultarPersona1" runat="server"  style="width: 100%;"/>
                    </td>
                </tr>
                <tr>
                <td></td>
                    <td class="PrimeraColumna">Fecha Apertura
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBFechaApertura" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEFechaApertura" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaApertura" />
                    </td>                
                </tr>
                <tr>
                <td></td >
                    <td >Fecha Vencimiento
                    </td>
                    <td >
                        <asp:TextBox ID="TBFechaVencimiento" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEFechaVencimiento" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaVencimiento" />
                    </td>                
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Monto 
                    </td>
                        <td class="SegundaColumna">
                            <asp:TextBox ID="TBMonto" runat="server"></asp:TextBox>
                        </td>                    
                </tr>
                <tr>
                    <td></td>
                    <td>Estado
                    </td>
                    <td >
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="128px">
                        </asp:DropDownList>
                    </td>
                </tr>                                  
                <tr>
                    <td />
                    <td colspan="2">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" style="width: 100%;" />
                    </td>
                </tr>
            </table>
        </asp:View>
         <asp:View ID="VNuevo" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVEvaluado" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            width: 1695px;
        }
        .auto-style3 {
            height: 22px;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</asp:Content>

