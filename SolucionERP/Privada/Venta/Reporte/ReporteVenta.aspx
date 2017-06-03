<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteVenta.aspx.vb" Inherits="_Default" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../../CSS/font-awesome.min.css" rel="StyleSheet" />
    <link href="../../../CSS/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-1.10.2.js"></script>
    <script src="../../../Scripts/bootstrap/bootstrap.min.js"></script>
    <script src="../../../Scripts/MicrosoftAjax.js"></script>
    <script src="../../../Scripts/Imprimir.js"></script>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container-fluid">
                <div id="divBotonesPrincipales" class="row">
                    <table style="width: 100%; padding-left: 5px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" class="MenuHead">
                                <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" />
                                <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divBotonesConsultas" class="row">
                    <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNHoy_Click" />
                        <asp:Button runat="server" Text="Esta Semana" CssClass="btn btn-primary" OnClick="BTNSemana_Click" />
                        <asp:Button runat="server" Text="Este Mes" CssClass="btn btn-primary" OnClick="BTNMes_Click" />
                        <asp:Button runat="server" Text="Este Año" CssClass="btn btn-primary" OnClick="BTNAno_Click" />
                        <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" OnClick="BTNAvanzado_Click" />
                    </div>
                </div>
                <div class="row" runat="server" id="divAvanzado" style="padding-right: 20px;">
                    <div class="col-xs-3 col-sm-3 col-md-2 col-lg-2" style="padding-right: 0;">
                        <div class="input-group">
                            <label class="input-group-addon" style="padding: 0px;">Folio</label>
                            <asp:TextBox runat="server" ID="TBLVFolio" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-3 col-sm-3 col-md-2 col-lg-2" style="padding-right: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding: 0px;">Vendedor</span>
                            <asp:TextBox runat="server" ID="TBVendedor" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Sucursal</span>
                            <asp:DropDownList runat="server" ID="DDSucursal" CssClass="form-control" Style="direction: rtl;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Venta</span>
                            <asp:DropDownList runat="server" ID="DDVenta" CssClass="form-control" Style="direction: rtl;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estado</span>
                            <asp:DropDownList runat="server" ID="DDVentaEstado" CssClass="form-control" Style="direction: rtl;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px;"><span class="visible-xs">Inicio</span><span class="hidden-xs">Fecha Inicio</span></span>
                            <asp:TextBox runat="server" ID="TBFechaInicio" CssClass="form-control" Style="text-align: right; padding-right: 5px;"></asp:TextBox>
                            <asp:CalendarExtender Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px;"><span class="visible-xs">Fin</span><span class="hidden-xs">Fecha Fin</span></span>
                            <asp:TextBox runat="server" ID="TBFechaFin" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
                            <asp:CalendarExtender Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                        </div>
                    </div>
                    <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary"  OnClick="BTNAvanzadoConsultar_Click" />
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                    <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; height: 290px; padding: 0; font-size: medium; text-align: center; padding-left: 1px; padding-right: 1px;">
                        <asp:GridView ID="GVReporteVenta" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false"
                            AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" OnRowDataBound="GVBusquedaVenta_RowDataBound"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" HeaderStyle-CssClass="GVBCenter" />
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" SortExpression="Vendedor" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Venta" HeaderText="Venta" SortExpression="Venta" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" SortExpression="Subtotal" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right"/>
                            </Columns>
                                <EmptyDataTemplate>
                                    <label>Sin coincidencia</label>
                                </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <div class="col-xs-12" style="text-align: right; background-color: #001f40; color: white; height: 30px; padding-top: 0px;">
                        <asp:Label runat="server" Font-Size="12" ID="LBCantidadBusqueda"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <%-- Con el siguiente codigo ajusta el tamaño del div que contiene el grdiview de la consulta --%>
   <script>
       Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
       function endReq(sender, args) {
           comprobarTamano();
       }
       $(window).resize(function () {
           comprobarTamano();
       });
       $(document).ready(function () {
           comprobarTamano();
       });
       function comprobarTamano() {
           var alto = $(window).height();
           var altoContenidoFiltro = 0;
           var altoBotonesPrincipales = 0;
           var altoBotonesConsultas = 0;
           if (document.getElementById('MainContent_divAvanzado'))
               altoContenidoFiltro = $("#MainContent_divAvanzado").height();
           if (document.getElementById('divBotonesPrincipales'))
               altoBotonesPrincipales = $("#divBotonesPrincipales").height();
           if (document.getElementById('divBotonesConsultas'))
               altoBotonesConsultas = $("#divBotonesConsultas").height();
           var suma = 109.4 + altoContenidoFiltro + altoBotonesPrincipales + altoBotonesConsultas;
           document.getElementById('divconsulta').style.height = (alto - suma).toString() + "px";
       }
   </script>
</asp:Content>

