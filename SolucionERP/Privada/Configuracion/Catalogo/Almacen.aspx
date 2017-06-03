<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Almacen.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
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
                        <asp:GridView ID="GVAlmacen" Width="100%" runat="server"
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
                    <td style="padding-right: 10px;"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdAlmacen" runat="server" Enabled="False" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Almacen" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" />
                        <asp:CheckBox ID="CBAlmacen" runat="server" text=" Almacen para devoluciones"/>
                        &nbsp;<asp:CheckBox ID="CBPredeterminado" runat="server" text=" Almacen Predeterminado" />
                        <%--<asp:RadioButton id="RBAlmacen" GroupName="ALMACEN" Text="Almacen para devoluciones"  runat="server"/>
                        <asp:RadioButton id="RBPredeterminado" GroupName="ALMACEN" Text="Almacen Predeterminado"  runat="server"/>--%>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label2" runat="server" Text="Sucursal" />
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDSucursal" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Estado" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td/>
                    <td colspan="2" >
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width:100%;" runat="server"/>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
