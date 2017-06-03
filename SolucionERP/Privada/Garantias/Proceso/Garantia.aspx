<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Garantia.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" /><script>
        function IsValid(args) {
            if (args.value.length == 0) {
                return false;
            }
            else {
                return true;
            }
        }
    </script><script type="text/javascript">
        function SelectSingleRadiobutton(rdbtnid) {
            var rdBtn = document.getElementById(rdbtnid);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }
    </script><style>
        .BotonError{
            border-style: none;
            border: solid 2px #ff0000;
            background: #82A7CD;
            color: black;
            font-size: 15px;
            border-radius: 5px;
            position: relative;
            box-sizing: border-box;
            transition: all 500ms ease;
            top: 0px;
            left: 0px;
        }
        .BotonCorrecto{
            border-style: none;
            border: solid 2px #385c81;
            background: #82A7CD;
            color: black;
            font-size: 15px;
            border-radius: 5px;
            position: relative;
            box-sizing: border-box;
            transition: all 500ms ease;
            top: 0px;
            left: 0px;
        }
        .auto-style1 {
            width: 1px;
        }
        .auto-style3 {
            width: 102px;
        }
        .auto-style6 {
            width: 1578px;
        }
        </style><table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVConsulta" Width="100%" runat="server"
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
                    <td style="padding-right: 10px;" class="auto-style1">&nbsp;</td>
                    <td>
                        ID</td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBIdGarantia" runat="server" Enabled="False" Width="150px" />
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td style="padding-right: 10px;" class="auto-style1"></td>                    
                    <td colspan="4">
                        <WUCP:wucConsultarPersona ID="wucConsultarPersona" style="width: 100%;" runat="server" />
                    </td>                                      
                </tr>
                  <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >
                        <asp:Button ID="BTNConsultar" runat="server" Text="Consultar" Width="100" />
                    </td>
                    <td class="auto-style6" >
                        &nbsp;</td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr> 
                <tr>
                    <td class="auto-style1">&nbsp;</td>                    
                    <td colspan="4">
                        <asp:GridView ID="GVVenta" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" BorderColor="#385c81" CaptionAlign="Top" CssClass="GridComun" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Width="100%">
                        </asp:GridView>
                    </td>      
                </tr>                                                          
                <tr>                    
                    <td colspan="4">
                        <asp:GridView ID="GVDetalleVenta" Width="100%" runat="server" text-align="center"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="center">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:RadioButton ID="RDBTNVentaDetalleItem" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdVenta" HeaderText="Id Venta" SortExpression="IdProducto" Visible="false" />
                                <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" Visible="true" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" Visible="true" />
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />
                                <asp:BoundField DataField="IdAlmacen" HeaderText="Id Almacen" SortExpression="IdAlmacen" Visible="false" />
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" Visible="false" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>                    
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Folio</td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBFolio" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style3" >
                        &nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Sucursal </td>
                    <td class="auto-style6" >
                        <asp:DropDownList ID="DDSucursalGarantia" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3" >
                        &nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Teléfono/Celular</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TBTelefono" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style3" >
                        &nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Falla </td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBFalla" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Observación&nbsp; </td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBObservacion" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>               
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Accesorios</td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBAccesorios" runat="server" Width="300" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Fecha Estimada</td>
                    <td class="auto-style6" >
                        <asp:TextBox ID="TBFechaEstimada" runat="server" Width="150"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaEstimada" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td >Estado</td>
                    <td class="auto-style6" >
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="4">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width: 100%;" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    </asp:Content>


