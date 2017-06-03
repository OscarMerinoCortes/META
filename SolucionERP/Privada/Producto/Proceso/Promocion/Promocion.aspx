<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Promocion.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../JS/jquery.metadata.js" type="text/javascript"></script>
    <script src="../../../../JS/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../../../../JS/Paginacion.js" type="text/javascript"></script>
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
                                <asp:TextBox ID="TBIdPromocion" runat="server" Enabled="False" Width="150px"></asp:TextBox>
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
                                    ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;"></td>
                            <td class="PrimeraColumna">Gracia</td>
                            <td class="SegundaColumna">
                                <asp:TextBox ID="TBGracia" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVGracia" runat="server" ControlToValidate="TBGracia"
                                    ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEGracia" runat="server" TargetControlID="RFVGracia"></asp:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator Display="none" ID="REVGracia" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBGracia"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="VCEERGracia" runat="server" TargetControlID="REVGracia"></asp:ValidatorCalloutExtender>
                                <asp:DropDownList ID="DDGracia" runat="server">
                                </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;" class="auto-style1"></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Extra"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TBExtra" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVExtra" runat="server" ControlToValidate="TBExtra"
                                    ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEExtra" runat="server" TargetControlID="RFVExtra"></asp:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator Display="none" ID="REVExtra" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBExtra"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="VCEERExtra" runat="server" TargetControlID="REVExtra"></asp:ValidatorCalloutExtender>
                                <asp:DropDownList ID="DDExtra" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;" class="auto-style1"></td>
                            <td class="PrimeraColumna">
                                <asp:Label ID="Label3" runat="server" Text="Descuento"></asp:Label>
                            </td>
                            <td class="SegundaColumna">
                                <asp:TextBox ID="TBDescuento" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVDescuento" runat="server" ControlToValidate="TBDescuento"
                                    ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEDescuento" runat="server" TargetControlID="RFVDescuento"></asp:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator Display="none" ID="REVDescuento" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBDescuento"></asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="VCEERDescuento" runat="server" TargetControlID="REVDescuento"></asp:ValidatorCalloutExtender>
                                <asp:DropDownList ID="DDDescuento" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;" class="auto-style1"></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Observacion"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TBObservacion" runat="server" Width="217px" TextMode="MultiLine" Height="103px"></asp:TextBox>
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
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td />
                            <td colspan="2">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td>
                                <%--     <asp:MultiView ID="MultiView2" runat="server">
        <asp:View ID="View1" runat="server">
             </asp:View>
    </asp:MultiView>--%>

                            </td>

                        </tr>

                    </table>



                    <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="1567px" Width="100%">
                        <Panes>
                            <ajaxToolkit:AccordionPane ID="AccordionPane0" runat="server" ContentCssClass="" HeaderCssClass="" Visible="true">
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
                                                                <asp:Button ID="BTNAceptarSucursal" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <%--<asp:Button ID="BTNActualizarMedio" runat="server" Text="Actualizar" ValidationGroup="Guardar" />--%>&nbsp;
                                                                    <asp:Button ID="BTNEliminarSucursal" runat="server" Text="Eliminar" />&nbsp;
                                                                    <%--<asp:Button ID="BTNCancelarMedio" runat="server" Text="Cancelar" />&nbsp;--%>
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
                                                <asp:Button ID="BTNuevaSucursal" runat="server" Text="Agregar Sucursal" />
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="" Visible="true">
                                <Header>Productos</Header>
                                <Content>
                                    <table>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td>Clasificacion</td>
                                            <td>
                                                <asp:DropDownList ID="DDClasificacion" runat="server" AutoPostBack="true" Height="22px" Width="155px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td class="PrimeraColumna">Subclasificacion</td>
                                            <td class="SegundaColumna">
                                                <asp:DropDownList ID="DDSubclasificacion" runat="server" Height="22px" Width="155px">
                                                </asp:DropDownList>

                                                <asp:Button ID="BTNConsultarProducto" runat="server" Height="26px" Text="Consultar" />
                                            </td>

                                        </tr>

                                        <tr>
                                            <td style="padding-right: 10px;"></td>
                                            <td style="width: 154px"><%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
                        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
                        <script type="text/javascript" src="<%= ResolveUrl("~/JS/gridviewScroll.min.js")%>"></script>
                       
                                    width: 1661,
                                    height: 200
                                });
                            }
                       <%-- </script>--%>&nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px;">&nbsp;</td>
                                            <td style="width: 154px">&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">

                                                <%--<a>CssClass="GridComun"</a>--%>
                                                <%-- PAGINACION-------<asp:GridView CssClass="grid sortable {disableSortCols: [3]}" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="GVProducto" Width="100%" runat="server" AllowPaging="false"
                                                    CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">--%>
                                                <div runat="server" id="divGVProducto" visible="false">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView CssClass="cruises scrollable GridComun table table-responsive" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="GVProducto" Width="100%" runat="server" AllowPaging="false"
                                                                CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <%-- <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <%--<asp:BoundField DataField="IdSubClasificacion" HeaderText="IdSubClasificacion" SortExpression="IdSubClasificacion" Visible="false" />
                                                        <asp:BoundField DataField="IdClasificacion" HeaderText="IdClasificacion" SortExpression="IdClasificacion" Visible="false" />--%>
                                                                    <%--<asp:BoundField DataField="TipoDescuento" HeaderText="Tipo de Descuento" SortExpression="TipoDescuento" Visible="true" />--%>
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio" SortExpression="Precio" Visible="true" />
                                                                    <%-- <asp:BoundField DataField="PrecioDescuento" HeaderText="Precio con Descuento" SortExpression="PrecioDescuento" Visible="true" />
                                                          <asp:BoundField DataField="Gracia" HeaderText="Gracia" SortExpression="Gracia" Visible="true" />--%>
                                                                    <%--<asp:BoundField DataField="TipoGracia" HeaderText="Dia/Mes de gracia" SortExpression="Extra" Visible="true" />--%>
                                                                    <%--<asp:BoundField DataField="IdEstado" HeaderText="Id Estado" SortExpression="IdEstado" Visible="false" />--%>
                                                                    <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" Visible="true" />
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                                                                </Columns>
                                                                <%--<HeaderStyle CssClass="GridviewScrollHeader" />
                                                            <RowStyle CssClass="GridviewScrollItem" />
                                                            <PagerStyle CssClass="GridviewScrollPager" />--%>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="3">
                                                <asp:Button ID="BTNAgregar" runat="server" Height="26px" Text="Agregar" />
                                            </td>
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
                                                <div runat="server" id="divGVProductoDetalle">
                                                    <div class="scrollableContainer">
                                                        <div class="scrollingArea">
                                                            <asp:GridView ID="GVProductoDetalle" Width="100%" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" CaptionAlign="Top" CssClass="GridComun cruisess scrollable" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                                                                <%--AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr"--%>
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVPromocionDetalleHeader_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CBGVPromocionDetalleItem" runat="server" Checked="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="IdPromocionDetalle" HeaderText="IdPromocionDetalle" SortExpression="IdPromocionDetalle" Visible="false" />
                                                                    <%--<asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="IdProducto" Visible="true" />--%>
                                                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />
                                                                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio Producto" SortExpression="PrecioProducto" Visible="true" />
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>Precio con Descuento</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TBGVPrecioDescuento" runat="server" AutoPostBack="true" OnTextChanged="GVIPrecio_TextChanged" />

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
                                                <asp:Button ID="BTNQuitar" runat="server" Text="Quitar" Height="26px" Width="104px" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BTNRedondeo" runat="server" Height="26px" Text="Redondeo" Width="115px" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BTNCalcular" runat="server" Height="26px" Text="Calcular" Width="105px" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
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
                                <asp:GridView ID="GVDescuento" Width="100%" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun sortable {disableSortCols: [3]}" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
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
                    $("table.c").each(function () {
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


