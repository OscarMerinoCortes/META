<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="AutorizarOrdenCompra.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucBusquedaProveedor.ascx" TagName="wucConsultarProveedor" TagPrefix="WUCProv1" %>
<%@ Register Src="~/Wuc/WucConsultarProducto.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Src="~/Wuc/wucConsultarProductoPerfil.ascx" TagName="wucConsultarProductoPerfil" TagPrefix="WUCPF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover1);
        function Hover1() {
            $(".tooltip").hover(function () {
                var tooltip = $("> div", this).show();
                var pos = tooltip.offset();
                tooltip.hide();
                var right = pos.left + tooltip.width();
                var pageWidth = $(document).width();
                if (pos.left < 0) {
                    tooltip.css("marginLeft", "+=" + (-pos.left) + "px");
                }
                else if (right > pageWidth) {
                    tooltip.css("marginLeft", "-=" + (right - pageWidth));
                }
                var IdProducto = tooltip[0].id.replace("divTablasTooltip", "");
                $.ajax({
                    //primero es atravez de ajax hacer una llamada al metodo GetChart
                    type: "POST", //por post
                    url: "Compra.aspx/TablasTooltip", //este es el webmethod que esta en el .vb del aspx
                    data: "{idproducto: '" + IdProducto + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
                    contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
                    dataType: "json", // se especifica el tipo de dato devuelto
                    success: function (r) { //si la operacion es exitosa
                        var divTabla = "divTablasTooltip" + IdProducto;
                        document.getElementById(divTabla).innerHTML = r.d;
                    },
                    failure: function (response) {
                        alert('Error al cargar las tablas');
                    }
                });

                tooltip.fadeIn();
            }, function () {
                $("> div", this).fadeOut(function () { $(this).css("marginLeft", ""); });
            });
        };
    </script>
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="5" class="MenuHead">
                                <asp:ImageButton ID="IBTNuevo" Visible="false" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMAutorizar.png" />
                                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="IBTCancelar" Visible="false" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" />
                                <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Orden</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBIdOrdenCompra" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoPrioridad" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Proveedor</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <WUCProv1:wucConsultarProveedor ID="wucConProv" runat="server" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Observacion</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBObservacion" runat="server" Enabled="True" Height="30px" TextMode="MultiLine" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Almacen</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDDestino" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoOrdenEstado" runat="server" Enabled="False" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div id="divOrden" class="panel-body col-xs-12">
                        <asp:GridView ID="GVOrdenDetalle" Style="margin: 0 auto;" runat="server"
                            CssClass="GridComun" GridLines="None" Width="100%">
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                            <Columns>

                                <%--<asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />--%>
                                <asp:TemplateField ItemStyle-CssClass="tooltip">
                                    <HeaderTemplate>Codigo</HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("IdProductoCorto")%>
                                        <div id="divTablasTooltip<%# Eval("IdProductoCorto")%>" class="tooltipContent"></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Producto
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" Visible="true" />
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />
                                <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Almacen" Visible="true" />
                                <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado Solicitud" SortExpression="TipoSolicitudEstado" Visible="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTNConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="BTNRegresar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" CssClass="Ocultar" />
                            </td>
                        </tr>
                    </table>
                    <div id="divBotonesConsultas" class="row">
                        <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                            <asp:Button runat="server" Text="Baja" CssClass="btn btn-primary" ID="BTNBaja" />
                            <asp:Button runat="server" Text="Media" CssClass="btn btn-primary" ID="BTNMedia" />
                            <asp:Button runat="server" Text="Alta" CssClass="btn btn-primary" ID="BTNAlta" />
                            <asp:Button runat="server" Text="Todo" CssClass="btn btn-primary" ID="BTNTodo" />
                            <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" ID="BTNAvanzado" />
                        </div>
                    </div>
                    <div id="divAvanzado" runat="server">
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Orden</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBOrdenFiltro" runat="server" AutoPostBack="True" CssClass="form-control" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Proveedor</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDProveedorFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Del:</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFechaInicioFiltro" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" CssClass="form-control" />
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioFiltro" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Al:</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFechaFinFiltro" runat="server" Font-Bold="True" CssClass="form-control" AutoPostBack="True" />
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinFiltro" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDPrioridadFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDEstadoFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                         <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Consultar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" ID="BTNConsultarAvanzado" />
                        </div>
                    </div>
                    <div id="divConsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                        <asp:GridView ID="GVConsulta" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                            AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" Width="100%">
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View ID="Imprimir" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTNImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" CssClass="Ocultar" />
                                <asp:ImageButton ID="BTIRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="Ocultar" />
                            </td>
                        </tr>
                    </table>
                    <div id="TablaEncabezado">
                        <table>
                            <tr>
                                <td>IdOrdenCompra:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LIdOrdenCompra" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Estado:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LEstado" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Prioridad:&nbsp;&nbsp;&nbsp;&nbsp;

                                </td>
                                <td>
                                    <asp:Label ID="LPrioridad" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                        <td>Id Proveedor:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td>
                            <asp:Label ID="LIdProveedor" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>--%>
                            <tr>
                                <td>Nombre Proveedor:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LNombreProveedor" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Fecha:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="TablaImprimir">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr style="text-align: center;">
                                <td colspan="3">
                                    <asp:GridView ID="GVOrdenProducto" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                                        Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
        .tooltip {
            position: relative;
        }

            .tooltip > div {
                display: none;
                position: absolute;
                left: 50%;
                margin-left: 30px;
                width: 1000%;
                top: -100px;
            }

        .tooltipContent {
            position: absolute;
            background-color: #eee;
            border: 1px solid #555;
            border-radius: 5px;
            padding: 5px;
            z-index: 99999;
        }
        .divTooltipTablas {
            font-size:12px;
            z-index:999999;
            color:#000000;
            text-align:left;
        }
        .divTooltipTablas table{
            font-size:12px;
            color:#000000;
        }
    </style>
</asp:Content>
