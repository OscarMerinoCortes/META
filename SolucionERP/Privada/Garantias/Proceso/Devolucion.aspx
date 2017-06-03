<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Devolucion.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" /><script>
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
                 .auto-style7 {
                     width: 1px;
                     height: 24px;
                 }
                 .auto-style8 {
                     height: 24px;
                 }
                 .auto-style10 {
                     width: 102px;
                     height: 24px;
                 }
                 .auto-style15 {
                     width: 154px;
                 }
                 .auto-style17 {
                     height: 24px;
                     width: 154px;
                 }
                 .auto-style19 {
                     height: 24px;
                     width: 190px;
                 }
                 .auto-style20 {
                     width: 190px;
                 }
        </style>
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTAplicar" runat="server" ImageUrl="~/Imagenes/IMAplicar.png" />
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
                    <td class="auto-style15">
                        ID</td>
                    <td class="auto-style20" >
                        <asp:TextBox ID="TBIdDevolucion" runat="server" Enabled="False" Width="150px" />
                    </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7" style="padding-right: 10px;"></td>
                    <td class="auto-style17">Tipo de devolución</td>
                    <td class="auto-style19">
                        <asp:DropDownList ID="DDTipoDevolucion" runat="server" Width="155" AutoPostBack="true" >
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style10"></td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style1" style="padding-right: 10px;">&nbsp;</td>
                    <td class="auto-style15">Folio</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TBFolio" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BTNConsultar" runat="server" Text="Consultar" Width="100" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                      <td class="auto-style1" style="padding-right: 10px;">&nbsp;</td>
                      <td class="auto-style15">Devolución</td>
                      <td class="auto-style20">
                          <asp:DropDownList ID="DDDevolucion" runat="server" Width="155px">
                          </asp:DropDownList>
                      </td>
                      <td class="auto-style3">Observación</td>
                      <td>
                          <asp:TextBox ID="TBObservacion" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
                      </td>
                </tr>
                  <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15" >
                        Monto</td>
                    <td class="auto-style20" >
                        <asp:TextBox ID="TBMonto" runat="server" Width="150px"></asp:TextBox>
                      </td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr> 
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15">Cantidad</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TBConcepto" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RadioButton ID="RBTNCargo" runat="server" Text="Cargo" AutoPostBack="true" />
                        <br />
                        <asp:RadioButton ID="RBTNAbono" runat="server" Text="Abono" AutoPostBack="true"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15">Almacén</td>
                    <td class="auto-style20">
                        <asp:DropDownList ID="DDAlmacen" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15">&nbsp;Estado</td>
                    <td class="auto-style20">
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="4">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width: 100%;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>                                        
                    <td colspan="5" style="text-align: center">
                        <asp:GridView ID="GVDevolucion" runat="server" 
                            AllowPaging="false" 
                            AlternatingRowStyle-CssClass="alt" 
                            BorderColor="#385c81" 
                            CaptionAlign="Top" 
                            CssClass ="GridComun" 
                            HorizontalAlign="center" 
                            PagerStyle-CssClass="pgr" 
                            Width="100%">
                            <EmptyDataTemplate>
                                <label>Sin Registro</label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>      
                </tr>                                                          
                <tr>                    
                    <td colspan="5" style="text-align: center">
                        <asp:GridView ID="GVDevolucionDetalle" Width="100%" runat="server" text-align="center"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="center" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBGVDevolucionItem" runat="server" AutoPostBack="true" Checked="false" Visible="true" OnCheckedChanged="CBGVDevolucionItem_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="false" />
                                <asp:BoundField DataField="IdProductoCorto" HeaderText="Id Producto" SortExpression="IdProductoCorto" Visible="true" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" Visible="true" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" Visible="true" />
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />                                       
                                 <asp:TemplateField HeaderText="Observación">
                                     <ItemTemplate>
                                         <asp:TextBox ID="TBGVObservacion" runat="server" AutoPostBack="true" Enabled="true"  Visible="true" TextMode="MultiLine" Width="300" Height="30" Text='<%# DataBinder.Eval(Container.DataItem, "Observacion")%>'>
                                         </asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <label>Sin productos</label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>                    
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15" >&nbsp;</td>
                    <td class="auto-style20" >
                        &nbsp;</td>
                    <td class="auto-style3" >
                        &nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style20">
                        &nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style15" >&nbsp;</td>
                    <td class="auto-style20" >
                        &nbsp;</td>
                    <td class="auto-style3" >&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>                               
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    </asp:Content>


