<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="RegistroProducto.aspx.vb" Inherits="_Default" %>
<%--<%@ Register Src="~/Wuc/WucConsultarProveedor.ascx" TagName="wucConsultarProveedor" TagPrefix="WUCProv" %>--%>
<%@ Register Src="~/Wuc/WucBusquedaProveedor.ascx" TagName="WucBusquedaProveedor" TagPrefix="WUCProv" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td colspan="5" class="MenuHead">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTConsultare" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td class="CeroColumna"></td>
                    <td colspan="4"><strong>Datos Generales</strong></td>
                    <%--<td colspan="2"><strong>Proveedor</strong></td>--%>
                </tr>
                <tr>
                    <td />
                    <td colspan="4">
                        <%--<WUCP:wucConsultarProducto ID="wucConsultarProducto1" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>ID</td>
                    <td>
                        <asp:TextBox ID="TBIdProducto" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Codigo Corto</td>
                    <td>
                        <asp:TextBox ID="TBIdProductoCorto" runat="server" Enabled="True" Width="150px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Descripción</td>
                    <td>
                        <asp:TextBox ID="TBDesProducto" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDesProducto" runat="server" ControlToValidate="TBDesProducto"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDesProducto" runat="server" TargetControlID="RFVDesProducto"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>Tipo</td>
                    <td>
                        <asp:DropDownList ID="DDTipo" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Unidad</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDUnidad" runat="server" Width="155px"></asp:DropDownList></td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Clasificación</td>
                    <td>
                        <asp:DropDownList ID="DDClasificacion" runat="server" Width="155px" AutoPostBack="True"></asp:DropDownList></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Subclasificacion</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDSubclasificacion" runat="server" AutoPostBack="True" Width="155px"></asp:DropDownList></td>
                    <%--DataTextField="Descripcion" DataValueField="Ganancia"--%>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td class="PrimeraColumna">Permitir venta con precio cero</td>
                                <td class="SegundaColumna">
                                    <asp:CheckBox ID="CBVenPreCero" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td style="width: 200px;">Permitir venta con cero existencia</td>
                                <td>
                                    <asp:CheckBox ID="CBVenExiCero" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td class="PrimeraColumna">Afectar Inventario</td>
                                <td class="SegundaColumna">
                                    <asp:CheckBox ID="CBAfeInv" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td></td>
                    <td><strong>Precio</strong></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Precio Ultima Entrada</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBPrecioUltimaEntrada" runat="server" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPrecioUltimaEntrada" runat="server" ControlToValidate="TBPrecioUltimaEntrada"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEPrecioUltimaEntrada" runat="server" TargetControlID="RFVPrecioUltimaEntrada"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVPrecioUltimaEntrada" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBPrecioUltimaEntrada"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEEPrecioUltimaEntrada" runat="server" TargetControlID="REVPrecioUltimaEntrada"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Ganancia</td>
                    <td>
                        <asp:TextBox ID="TBGanancia" runat="server" AutoPostBack="True" Style="margin-bottom: 0px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVGanancia" runat="server" ControlToValidate="TBGanancia"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEGanancia" runat="server" TargetControlID="RFVGanancia"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVGanancia" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBGanancia"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERGananciao" runat="server" TargetControlID="REVGanancia"></asp:ValidatorCalloutExtender>
                        <asp:CheckBox ID="CBGanancia" runat="server" AutoPostBack="True" />
                        <asp:Label ID="Label1" runat="server" Text="%"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Precio Base</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBPrecioBase" runat="server" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPrecioBase" runat="server" ControlToValidate="TBPrecioBase"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="GuardarPlazo"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEPrecioBase" runat="server" TargetControlID="RFVPrecioBase"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="3752px" Width="100%">
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>
                                        Codigo de Barras
                                    </Header>
                                    <Content>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PACodigoBarra" runat="server" BackColor="#FDFDFD" Visible="False" Width="100%">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="SegundaColumna">
                                                                    <asp:TextBox ID="TBCodigoBarra" runat="server" Visible="False" Width="50%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVCodigoBarra" runat="server" ControlToValidate="TBCodigoBarra"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                                                                        Display="None" ValidationGroup="GuardarBarras"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCECodigoBarra" runat="server" TargetControlID="RFVCodigoBarra"></asp:ValidatorCalloutExtender>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Button ID="BTNAceptarCodigoBarra" runat="server" Text="Aceptar" ValidationGroup="GuardarBarras" />
                                                                    <asp:Button ID="BTNEliminarCodigoBarra" runat="server" Enabled="False" Text="Eliminar" />
                                                                    <asp:Button ID="BTNCancelarCodigoBarra" runat="server" Text="Cancelar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView ID="GVCodigoBarra" runat="server" CssClass="GridComun" GridLines="None" Style="margin: 0 auto;" Width="100%">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <PagerStyle CssClass="pgr" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNuevoCodigoBarra" runat="server" Text="+ Nuevo Codigo de Barras" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>
                                        Maximos y Minimos
                                    </Header>
                                    <Content>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="PAMaxMin" runat="server" BackColor="#FDFDFD" Visible="false" Width="100%">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Almacen</td>
                                                                <td class="SegundaColumna">
                                                                    <asp:DropDownList ID="DDAlmacen" runat="server" Width="155px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Maximo</td>
                                                                <td>
                                                                    <asp:TextBox ID="TBMax" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVMax" runat="server" ControlToValidate="TBMax"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                                                                        Display="None" ValidationGroup="GuardarMaxMin"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEMax" runat="server" TargetControlID="RFVMax"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVMax" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="GuardarMaxMin" ControlToValidate="TBMax"></asp:RegularExpressionValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEEMax" runat="server" TargetControlID="REVMax"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Minimo</td>
                                                                <td class="SegundaColumna">
                                                                    <asp:TextBox ID="TBMin" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVMin" runat="server" ControlToValidate="TBMin"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                                                                        Display="None" ValidationGroup="GuardarMaxMin"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEMin" runat="server" TargetControlID="RFVMin"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVMin" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="GuardarMaxMin" ControlToValidate="TBMin"></asp:RegularExpressionValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEEMin" runat="server" TargetControlID="REVMin"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Button ID="BTNAceptarMaxMin" runat="server" Text="Aceptar" ValidationGroup="GuardarMaxMin" />
                                                                    <asp:Button ID="BTNEliminarMaxMin" runat="server" Text="Eliminar" />
                                                                    <asp:Button ID="BTNCancelarMaxMin" runat="server" Text="Cancelar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="2">
                                                    <asp:GridView ID="GVMaxMin" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNMaxMin" runat="server" Text="+ Nuevo Maximo y Minimo" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>
                                        Plazo
                                    </Header>
                                    <Content>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PAPrecio" runat="server" BackColor="#FDFDFD" Visible="False" Width="100%">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Plazo</td>
                                                                <td class="SegundaColumna">
                                                                    <asp:DropDownList ID="DDPlazo" runat="server" AutoPostBack="True" DataTextField="Descripcion" DataValueField="IdTipoPlazo" Width="155px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TBIdPlazo" runat="server" Visible="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Precio</td>
                                                                <td>
                                                                    <asp:TextBox ID="TBPrecio" runat="server" Enabled="False"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Estado
                                                                </td>
                                                                <td class="SegundaColumna">
                                                                    <asp:DropDownList ID="DDEstadoPlazo" runat="server" Width="155px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Button ID="BTNAceptarPrecio" runat="server" Text="Aceptar" ValidationGroup="GuardarPlazo" />
                                                                    <asp:Button ID="BTNEliminarPrecio" runat="server" Text="Eliminar" />
                                                                    <asp:Button ID="BTNCancelar" runat="server" Text="Cancelar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView ID="GVPrecio" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNPrecio" runat="server" Text="+ Nuevo Precio" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                
                                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Proveedores</Header>
                                    <Content>
                                        
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td class="Primer_Columna" >Proveedor</td>
                                                <td  class="Primer_Columna">
                                                     <WUCProv:WucBusquedaProveedor ID="wucConProv" runat="server" />&nbsp&nbsp&nbsp
                                                </td>
                                                <td class="Seggunda_Columna">&nbsp&nbsp&nbsp Precio
                                                                    <asp:TextBox ID="TBProveedorPrecio" runat="server" Width="150px" />
                                                    <asp:FilteredTextBoxExtender ID="FTBEProveedorPrecio" runat="server" FilterType="Numbers" TargetControlID="TBProveedorPrecio" />                                                    
                                                    &nbsp&nbsp&nbsp
                                                                   <asp:Button ID="BTNAceptarProveedor" runat="server" Text="Aceptar" />
                                                </td>
                                                <td />
                                                <td colspan="2">&nbsp;
                                                                    <asp:Button ID="BTNActualizarProveedor" runat="server" Enabled="false" Visible="false" Text="Actualizar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarProveedor" runat="server" Enabled="false" Visible="false" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarProveedor" runat="server" Text="Cancelar" Visible="false" />
                                                    <asp:TextBox ID="TBIdProveedor" Visible="False" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr >
                                                <td colspan="3" style="text-align: center;">
                                                 <%--   <asp:GridView Width="100%" ID="GVProveedor1" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>--%>
                                                    <asp:GridView ID="GVProveedor" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false" CssClass="GridComun" GridLines="None" Width="100%">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Eliminar</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="BTNEliminar" runat="server" ForeColor="Blue" Text="Eliminar" ShowSelectButton="True" OnClick="BTNEliminarProducto_Click1" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdProveedor" HeaderText="IdProveedor" Visible="true" />
                                                <asp:BoundField DataField="Equivalencia" HeaderText="Equivalencia" Visible="true" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true" />
                                                <%--<asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />--%>
                                                
                                                <%--<asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" Visible="true" />--%>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Precio</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TBGVPrecio" runat="server" AutoPostBack="true" OnTextChanged="GVIPrecio_TextChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <label>Sin Proveedor</label>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Button ID="BTNProveedor" Visible="false" runat="server" Text="+ Nuevo Proveedor" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>



                            </Panes>
                        </ajaxToolkit:Accordion>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table style="width: 100%">
                <tr>
                    <td colspan="3">
                        <asp:ImageButton ID="IBTConsultarNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTConsultarRegistroProducto" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTCancelarConsultar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10%">Id</td>
                    <td>
                        <asp:TextBox ID="TBIdProductoConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEProductoConsultar" runat="server" FilterType="Numbers" TargetControlID="TBIdProductoConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Codigo Corto</td>
                    <td>
                        <asp:TextBox ID="TBCodigoCortoConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Descripcion</td>
                    <td>
                        <asp:TextBox ID="TBProductoDescripcionConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Clasificacion</td>
                    <td>
                        <asp:DropDownList ID="DDClasificacionConsulta" runat="server" Height="22px" Width="155px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Subclasificacion</td>
                    <td>
                        <asp:DropDownList ID="DDSubclasificacionConsulta" runat="server" Height="22px" Width="155px">
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
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView ID="GridView1" Width="100%" Style="margin: 0 auto;" runat="server" PageSize="20" AlternatingRowStyle-CssClass="alt" CssClass="grid sortable {disableSortCols: [3]}" PagerStyle-CssClass="pgr" SelectedIndex="1" AllowPaging="false">
                            <%--<AlternatingRowStyle CssClass="alt" />
                            <FooterStyle BackColor="Black" />
                            <PagerSettings FirstPageText="Primero" LastPageText="Ultimo" Mode="NextPreviousFirstLast" NextPageText="Siguente" PreviousPageText="Ultimo" />
                            <PagerStyle CssClass="GridComun" />--%>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <%--</ContentTemplate>--%>
    <%-- </asp:UpdatePanel>
    <asp:UpdateProgress ID="UPRRegistro" runat="server" AssociatedUpdatePanelID="upProducto">
        <ProgressTemplate>
            <div id="Background"></div>
            <div id="Progress">
                <h6>
                    <p style="text-align: center">
                        <center><h2>Procesando Datos, Espere por favor... </h2></center>
                    </p>
                </h6>
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>
