<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Proveedor.aspx.vb" Inherits="Catalogos._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <LINK REL=StyleSheet HREF="../CSS/StyleSheet.css" TYPE="text/css">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%;">
                <tr>
                    <%--<td colspan="3">
                        <asp:Button ID="BTNNuevo" runat="server" Text="Nuevo" />
                        <asp:Button ID="BTNGuardar" runat="server" Text="Guardar" />
                    </td>--%>
                    <td colspan="4" class="MenuHead">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />                     
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Datos Generales</strong></td>
                    <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp; <strong>Datos Contacto&nbsp;</strong></td>
                </tr>
                <tr>
                    <td style="width: 154px">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBIdSubclasificacion" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Contacto</td>
                    <td>
                        <asp:TextBox ID="TBIdSubclasificacion4" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">RFC</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBDesSubclasificacion" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Telefono</td>
                    <td>
                        <asp:TextBox ID="TBIdSubclasificacion5" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Nombre</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBGanancia" runat="server" Width="268px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Fax</td>
                    <td>
                        <asp:TextBox ID="TBIdSubclasificacion6" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px"> Dirección</td>
                    <td class="auto-style1"> 
                        <asp:TextBox ID="TBGanancia0" runat="server" Width="266px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Correo</td>
                    <td>
                        <asp:TextBox ID="TBIdSubclasificacion7" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">CodigoPostal</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBGanancia1" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr style="text-align:center;">
                    <td colspan="4" >
                        <asp:GridView ID="GVSubclasificacion" style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Center">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td colspan="2"></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 341px;
        }
        .auto-style2 {
            width: 189px;
        }
    </style>
</asp:Content>

