<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Obsequio.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../JS/jquery.metadata.js" type="text/javascript"></script>
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3" class="MenuHead">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTCopiar" runat="server" ImageUrl="~/Imagenes/IMCopiar.png" />
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td></td>
                </tr>
            </table>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="VRegistro" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td class="PrimeraColumna">
                                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                            </td>
                            <td class="SegundaColumna">
                                <asp:TextBox ID="TBIdPromocion" runat="server" Enabled="False" Width="150px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BTNRedondeo0" runat="server" Height="26px" Text="Redondeo" ValidationGroup="Guardar" Width="105px" Style="float: right" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BTNCalcular2" runat="server" Text="Calcular" ValidationGroup="Guardar" Height="26px" Style="float: right" Width="105px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TBDescripcion" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                                    ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;" class="auto-style1"></td>
                            <td class="PrimeraColumna">
                                <asp:Label ID="Label7" runat="server" Text="Observacion"></asp:Label>
                            </td>
                            <td class="SegundaColumna">
                                <asp:TextBox ID="TBObservacion" runat="server" Width="217px" TextMode="MultiLine" Height="103px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1" style="padding-right: 10px;"></td>
                            <td class="auto-style1">
                                <asp:Label Text="Monto" runat="server" ID="LMonto"></asp:Label></td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TBMonto" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVMonto" runat="server" ControlToValidate="TBMonto"
                                    ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEMonto" runat="server" TargetControlID="RFVMonto"></asp:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator Display="none" ID="REVMonto" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBMonto"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="VCEERMonto" runat="server" TargetControlID="REVMonto"></asp:ValidatorCalloutExtender>
                                &nbsp;&nbsp;
                        <asp:DropDownList ID="DDOpcion" runat="server" AutoPostBack="True" Style="margin-bottom: 0px">
                        </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td class="PrimeraColumna">
                                <asp:Label ID="Label5" runat="server" Text="Fecha de Inicio"></asp:Label>
                            </td>
                            <td class="SegundaColumna">
                                <asp:TextBox ID="TBFechaInicio" runat="server" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TBFechaFin" runat="server" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td class="PrimeraColumna">Estado</td>
                            <td class="SegundaColumna">
                                <asp:DropDownList ID="DDEstado" runat="server" AutoPostBack="true" Height="22px" Width="155px">
                                </asp:DropDownList>
                            </td>

                        </tr>

                        <tr>
                            <td />
                            <td colspan="2">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="LSucursal" runat="server" Visible="False">Sucursal</asp:Label>
                                &nbsp;&nbsp;&nbsp;
                        <asp:DropDownCheckBoxes ID="DDCBSucursal" runat="server" AddJQueryReference="True" style="top: 0px; left: -75px; height: 24px; width: 226px;" UseButtons="False" UseSelectAllNode="True" Visible="False">
                            <Style DropDownBoxBoxHeight="100" DropDownBoxBoxWidth="200" SelectBoxWidth="300" />
                            <Texts SelectBoxCaption="Seleccionar Sucursal" />
                        </asp:DropDownCheckBoxes>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="1813px" Width="100%">
                        <Panes>
                            <%--<ajaxToolkit:AccordionPane ID="AccordionPane0" runat="server" ContentCssClass="" HeaderCssClass="" Visible="true">
                                <Header>Sucursal</Header>
                                <Content>
                                    <table style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel ID="PASucursal" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                    <table style="width: 100%; border-collapse: collapse;">
                                                        <tr>
                                                            <td class="PrimeraColumna">Sucursal</td>
                                                            <td class="PrimeraColumna">
                                                                <asp:DropDownList ID="DDSucursal" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                            <td class="PrimeraColumna"></td>
                                                            <td class="SegundaColumna"></td>
                                                        </tr>

                                                        <tr>
                                                            <td class="SegundaColumna" colspan="4">
                                                                <asp:Button ID="BTNAceptarSucursal" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;&nbsp;
                                                                    <asp:Button ID="BTNEliminarSucursal" runat="server" Text="Eliminar" />&nbsp;

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp; </td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="2">
                                                <asp:GridView ID="GVSucursal" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                    CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Button ID="BTNuevaSucursal" runat="server" Text="+ Elige Sucursal" />
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>--%>
                            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="" Visible="true">
                                <Header>Productos</Header>
                                <Content>
                                    <table>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td>Clasificacion</td>
                                            <td>
                                                <asp:DropDownList ID="DDClasificacion" runat="server" AutoPostBack="true" Height="22px" Width="155px"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td class="PrimeraColumna">Subclasificacion</td>
                                            <td class="SegundaColumna">
                                                <asp:DropDownList ID="DDSubclasificacion" runat="server" Height="22px" Width="155px"></asp:DropDownList>
                                                <asp:Button ID="BTNConsultarProducto" runat="server" Height="26px" Text="Consultar" />
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td style="width: 154px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;">&nbsp;</td>
                                            <td style="width: 154px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div runat="server" id="divGVProducto" visible="false">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView ID="GVProducto" Width="100%" CssClass="cruises scrollable GridComun" runat="server" AllowPaging="false"
                                                                AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <%--<asp:BoundField DataField="IdSubClasificacion" HeaderText="IdSubClasificacion" SortExpression="IdSubClasificacion" Visible="false" />
                                <asp:BoundField DataField="IdClasificacion" HeaderText="IdClasificacion" SortExpression="IdClasificacion" Visible="false" />--%><%--<asp:BoundField DataField="TipoDescuento" HeaderText="Tipo de Descuento" SortExpression="TipoDescuento" Visible="true" />--%>
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio" SortExpression="Precio" Visible="true" />
                                                                    <%-- <asp:BoundField DataField="PrecioDescuento" HeaderText="Precio con Descuento" SortExpression="PrecioDescuento" Visible="true" />
                                <asp:BoundField DataField="Gracia" HeaderText="Gracia" SortExpression="Gracia" Visible="true" />--%><%--<asp:BoundField DataField="TipoGracia" HeaderText="Dia/Mes de gracia" SortExpression="Extra" Visible="true" />--%><%--<asp:BoundField DataField="IdEstado" HeaderText="Id Estado" SortExpression="IdEstado" Visible="false" />--%>
                                                                    <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" Visible="true" />
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                                                                </Columns>
                                                                <%--AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr"--%>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <asp:Button ID="BTNAgregar" runat="server" Height="26px" Text="Agregar" /></td>
                                            <td></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <div runat="server" id="divGVProductoDetalle">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView ID="GVProductoDetalle" CssClass="GridComun cruisess scrollable" Width="100%" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionDetalleHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="IdPromocionObsequioDetalle" HeaderText="IdPromocionDetalle" SortExpression="IdPromocionDetalle" Visible="false" />
                                                                   <%-- <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio Producto" SortExpression="PrecioProducto" Visible="true" />
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>Cantidad en Existencia</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TBGVCantidadExistencia" runat="server" AutoPostBack="true" OnTextChanged="GVICantidadExistencia" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <asp:Button ID="BTNQuitar" runat="server" Text="Quitar" Height="26px" Width="104px" /></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="" Enabled="true">
                                <Header>Obsequios</Header>
                                <Content>
                                    <table>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td>Clasificacion</td>
                                            <td>
                                                <asp:DropDownList ID="DDClasificacionObsequio" runat="server" AutoPostBack="true" Height="22px" Width="155px"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td class="PrimeraColumna">Subclasificacion</td>
                                            <td class="SegundaColumna">
                                                <asp:DropDownList ID="DDSubclasificacionObsequio" runat="server" Height="22px" Width="155px"></asp:DropDownList>
                                                <asp:Button ID="BTNConsultarObsequio" runat="server" Height="26px" Text="Consultar" /></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;">&nbsp;</td>
                                            <td style="width: 154px">&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <div runat="server" id="divGVProducto2" visible="false">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView ID="GVProductoObsequiar" CssClass="cruisess scrollable GridComun" Width="100%" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionObsequioHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionObsequioHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionObsequioItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio" SortExpression="Precio" Visible="true" />
                                                                    <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" Visible="true" />
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                                                                </Columns>
                                                                <%--AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr"--%>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <asp:Button ID="BTNAgregarObsequio" runat="server" Height="26px" Text="Agregar" /></td>
                                            <td></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3"></td>
                                            <td></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">&nbsp;</td>
                                            <td></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <div runat="server" id="divGVProductoDetalleObsequio">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView ID="GVProductoDetalleObsequio" Width="100%" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" CssClass="cruisess scrollable GridComun" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleObsequioHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionDetalleObsequioHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleObsequioItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="IdPromocionObsequioProducto" HeaderText="IdPromocionDetalle" SortExpression="IdPromocionDetalle" Visible="false" />
                                                                    <%--<asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio Producto" SortExpression="PrecioProducto" Visible="true" />
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>Cantidad de Obsequios</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TBGVCantidadObsequio" runat="server" AutoPostBack="true" OnTextChanged="GVICantidadObsequio" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <asp:Button ID="BTNQuitarObsequio" runat="server" Text="Quitar" Height="26px" Width="104px" />&#160;&#160;&#160;&#160;
                                        <asp:Button ID="BtnCalcular" runat="server" Text="Calcular" Height="26px" Width="104px" ValidationGroup="Guardar" />&#160;&#160;&#160;&#160;
                                        <asp:Button ID="BTNRedondeo" runat="server" Text="Redondeo" Height="26px" Width="104px" ValidationGroup="Guardar" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="" Enabled="true">
                                <Header>Resultados</Header>
                                <Content>
                                    <table style="width: 100%;">
                                        <tr style="text-align: center;">
                                            <td style="width: 100%;">
                                                <asp:GridView ID="GVProductoObsequio" Width="100%" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center"></asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                        </Panes>
                    </ajaxToolkit:Accordion>
                    <table>
                    </table>
                    <table>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="VConsulta" runat="server">
                    <table style="width: 100%;">
                        <tr style="text-align: center;">
                            <td style="width: 100%;">
                                <asp:GridView ID="GVDescuento" Width="100%" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UPRPromocion" runat="server" AssociatedUpdatePanelID="UPPromocion">
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
    </asp:UpdateProgress>

    <style>
        * {
            padding: 0;
            margin: 0;
        }

        table.cruises {
            width: 100%;
        }

            table.cruises th {
                padding: 4px 4px;
                border: solid 0px #424242;
                text-align: center;
                color: #fff;
                background: #104577;
                font-size: 1em;
            }

            table.cruises td {
                padding: 2px;
                border: solid 0px #424242;
                color: #717171;
            }

        div.scrollableContainer {
            position: relative;
            width: 100%;
            padding-top: 2em;
        }

        div.scrollingArea {
            height: 240px;
            overflow: auto;
            width: 100%;
        }

        table.scrollable thead tr {
            left: 0;
            top: 0;
            position: absolute;
            width: 100%;
        }
    </style>
    <script>
        $(document).ready(function () {
            THEAD();
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
        function endReq(sender, args) {
            THEAD();
        }

        function THEAD() {
            try {
                $(document).ready(function () {
                    // Setup Metadata plugin
                    $.metadata.setType("class");
                    // table.Nombre del gridview 
                    // $("table.scrollable").each(function () {
                    $("table.s").each(function () {
                        var jTbl = $(this);

                        if (jTbl.find("tbody>tr>th").length > 0) {
                            jTbl.find("tbody").before("<thead><tr></tr></thead>");
                            jTbl.find("thead:first tr").append(jTbl.find("th"));
                            jTbl.find("tbody tr:first").remove();

                        }
                    });
                });
            }
            catch (err) {
                alert(err.message)
            }
        }
    </script>
</asp:Content>

