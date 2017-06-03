<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="SubTipoMovimientoInventario.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style7">ID
                    <td class="auto-style6">
                        <asp:TextBox ID="TBIdSubTipoFiltro" runat="server" Width="150"></asp:TextBox>
                    </td>    
                     <td class="auto-style6">
                    </td>                
                </tr>
                  <tr>
                      <td class="auto-style8"></td>
                    <td class="auto-style7">Descripción</td>
                      <td class="auto-style6">
                          <asp:TextBox ID="TBDescripcionFiltro" runat="server" Width="150"></asp:TextBox>
                    </td>    
                     <td class="auto-style6">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style7">Tipo</td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DDTipoFiltro" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>    
                     <td class="auto-style6">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style7">Estado</td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DDEstadoFiltro" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>    
                     <td class="auto-style6">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="BTNConsultar" runat="server" Text="Consultar" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr style="text-align: center;">                  
                    <td colspan="3">
                        <asp:GridView ID="GVSubTipoMovimientoInventario" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" BorderColor="#385c81" CaptionAlign="Top" CssClass="GridComun" HorizontalAlign="Left" PagerStyle-CssClass="pgr" Width="100%">
                        </asp:GridView>
                    </td>
                </tr>               
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td style="padding-right: 10px;"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdSubTipo" runat="server" Enabled="False" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Descripcion
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>                     
                    </td>                    
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Tipo
                    </td>
                    <td class="SegundaColumna">
                         <asp:DropDownList ID="DDTipo" runat="server" Width="155px"></asp:DropDownList>                       
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Estado
                    </td>
                        <td>
                            <asp:DropDownList ID="DDEstado" runat="server" Width="155px"></asp:DropDownList>
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
    </asp:MultiView>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style6 {
            height: 22px;
        }
        .auto-style7 {
            width: 202px;
            height: 22px;
        }
        .auto-style8 {
            width: 33px;
        }
        .auto-style9 {
            width: 33px;
            height: 22px;
        }
    </style>
</asp:Content>




