<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageVenta.Master" AutoEventWireup="false" CodeFile="Venta.aspx.vb" Inherits="_Default" Culture="es-MX" UICulture="es-MX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Wuc/Venta/WucConsultarProductoVenta.ascx" TagName="wucBuscarProducto" TagPrefix="WUCBProducto" %>
<%@ Register Src="~/Wuc/Venta/WucConsultarPersonaVenta.ascx" TagName="wucBuscarPersona" TagPrefix="WUCBPersona" %>
<%@ Register Src="~/Wuc/Venta/WucConsultarVenta.ascx" TagName="wucBuscarVenta" TagPrefix="WUCBVenta" %>
<%@ Register Src="~/Wuc/Venta/WucVentaAviso.ascx" TagName="wucMAviso" TagPrefix="WucAviso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div style="margin-left: 0; margin-right: 0; position:absolute; width: 100%;background-color: #337ab7;height: 43px;">< /div>--%>
    <script src="../../../Scripts/jquery-1.10.2.js"></script>
    <script src="../../../Scripts/bootstrap/bootstrap.min.js"></script>
    <asp:MultiView runat="server" ID="MVVenta">
        <asp:View ID="ContenidoPrinicpal" runat="server">
            <div class="container-fluid" style="background-color: white;">
                <div id="divFolios" class="row" style="padding-top: 4px; padding-bottom: 4px;">
                    <div class="col-xs-12 col-sm-6"> 
                        <div class="input-group">
                            <asp:TextBox runat="server" CssClass="form-control" placeholder="F1 Buscar Producto" ID="TBXCodigo" />
                            <div class="input-group-btn">
                                <asp:ImageButton runat="server" ID="IBTNBuscarProducto" CssClass="btn btn-default" ImageUrl="~/Imagenes/Venta/search.png" Style="height: 34px;" OnClick="BTNBuscarProducto_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                        <div class="col-xs-6" style="padding: 0;">
                            <asp:TextBox runat="server" CssClass="form-control" ID="TBFolio2" placeholder="Folio Fisico"></asp:TextBox>
                            <asp:Label runat="server" CssClass="form-control" ID="LBFolio2" Visible="false" style="padding-right: 0; padding-left: 0;"></asp:Label>
                        </div>
                        <div class="col-xs-6" style="padding: 0;"><asp:Label runat="server" ID="TBLVFolio" CssClass="form-control" Style="text-align: right; padding-left: 0; padding-right: 0;"></asp:Label></div>
                    </div>
                </div>
                <%--Parte de la tabla de venta--%>
                <div class="row">
                    <div class="col-sm-12 panel panel-default" style="padding-left: 0px; padding-right: 0px; border: 0; margin-bottom: 0;">
                        <%--Tabla--%>
                        <div runat="server" id="tablaVentaDetalle" class="panel-body col-xs-12" style="overflow: auto; height: 290px; padding: 0; font-size: medium; text-align: center;">
                            <asp:GridView ID="GVVentaDetalle" Style="margin: 0 auto; padding: 8px; font-size: 16px;" runat="server" AutoGenerateColumns="false"
                                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" OnRowDataBound="GVVentaDetalle_OnRowDataBound"
                                BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="Codigo" Visible="true" HeaderStyle-CssClass="GVVDetalleCodigo"  />
                                    <%--<asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" Visible="true" ItemStyle-HorizontalAlign="Left" />--%>
                                    <asp:TemplateField HeaderStyle-CssClass="GVVDetalleProducto"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"><HeaderTemplate>Productos</HeaderTemplate><ItemTemplate><asp:Label runat="server" Text='<%# Eval("Producto") %>'></asp:Label><asp:Label runat="server" Text='<%# Eval("Promocion") %>' CssClass="col-xs-12" style="font-size: 16px; margin-top: -12px;"  Visible='<%# Eval("PromocionBoolean") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    <%--<asp:BoundField DataField="Cantidad" HeaderText="F2 Cantidad" SortExpression="Cantidad" Visible="true" ItemStyle-CssClass="editar" />--%>
                                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter"><HeaderTemplate>Almacen&nbsp;&nbsp;</HeaderTemplate><ItemTemplate><asp:Label runat="server" Text='<%# Eval("Almacen")%>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-CssClass="editar"><HeaderTemplate><span id="spngvcantidad"></span></HeaderTemplate><ItemTemplate><asp:Label runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    <%--<asp:BoundField DataField="TotalCredito" HeaderText="Total" SortExpression="TotalCredito" Visible="true" DataFormatString="{0:C2}"  />--%>
                                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter GVVDetalleTotal" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>Total</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="LBTotal" Text='<%# Eval("TotalCredito", "{0:c}") %>' Style="padding-right: 15px;"></asp:Label>
                                            <asp:Label runat="server" ID="LBDescuento" class="col-xs-12" Style="font-size: 16px; margin-top: -12px; padding-right: 15px;" Visible='<%# Eval("PromocionBoolean") %>'>
                                            <asp:Image runat="server" ID="IMDescuento"  style="height: 14px; margin-top: -4px;" ImageUrl='~/Imagenes/Venta/descuento.png'/> <%# Eval("DescuentoCredito", "{0:c}") %>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter"><HeaderTemplate></HeaderTemplate><ItemTemplate><asp:LinkButton ID="BTNQuitarProducto" runat="server" OnClick="BTNQuitarProducto_OnClick"><span class="fa fa-trash fa-2x"></span></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <label>Sin productos</label>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id="divbtnproductos" class="col-xs-12" style="text-align: center; background-color: #104577; color: white; height: 40px; border-bottom: #337ab7 solid 2px;">
                            <a id="LBTNProductos" runat="server" onclick="FuncionOcultarGVDetalle()" class="btn btn-default" style="padding-right: 22%; padding-left: 22%; height: 35px; width: 100%; padding-top: 3px; font-size: 16px; margin-top: 1px;"><span style="font-size: 22px;" class="fa fa-shopping-cart"></span>&nbsp;<asp:Label runat="server" ID="LBVentaDetalleProductosxs" CssClass="badge pull-right" style="margin-top: 2px; margin-right: 2px; font-size: 15px;"></asp:Label><span>PRODUCTOS</span></a>                                          
                        </div>
                        
                        <div id="divlbproductos" class="col-xs-12" style="text-align: right; background-color: #104577; color: white; height: 30px; border-bottom: #337ab7 solid 2px;">
                            <asp:Label runat="server" Font-Size="12" ID="LBVentaDetalleProductos">Productos:</asp:Label>
                        </div>
                    </div>
                </div>
                <%--Parte de cliente y todoal--%>
                <div id="tabs" class="row" style="background-color: #337ab7; margin-top: 0;">
                    <div class="col-md-8 col-lg-4" style="padding-left: 0px; padding-right: 0px;">
                        <div class="panel with-nav-tabs panel-primary" style="border: 0 solid transparent; border-radius: 0; margin-bottom: 0;">
                            <div id="tabspaneles" class="panel-heading" style="border-top-left-radius: 0; border-top-right-radius: 0; padding-top: 0;">
                                <ul class="nav nav-tabs">
                                    <li id="litabcontado" runat="server"><a href="#tabcontado" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px; padding-left: 7px; padding-right: 7px;"><span id="spnnavcontado"></span></a></li>
                                    <li id="litabcredito" runat="server"><a href="#tabcredito" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px; padding-left: 7px; padding-right: 7px;"><span id="spnnavcredito"></span></a></li>
                                    <li id="litabcargo" runat="server"><a href="#tabcargo" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px; padding-left: 7px; padding-right: 7px;">
                                        <asp:Label runat="server" ID="LBCargos" CssClass="badge pull-right"></asp:Label><span id="spnnavcargo"></span>&nbsp;</a></li>
                                    <li id="litabpromocion" runat="server"><a href="#tabpromociones" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px; padding-left: 7px; padding-right: 7px;">
                                        <asp:Label runat="server" ID="LBPromociones" CssClass="badge pull-right"></asp:Label><span id="spnnavpromocion"></span>&nbsp;</a></li>
                                    <li id="litabcliente" class="hidden-lg"><a href="#tabclientexs" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px;"><span id="spnnavcliente"></span></a></li>
                                    <li id="litabavalxs" runat="server" class="hidden-lg"><a href="#tabavalxs" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px;"><span id="spnnavaval"></span></a></li>
                                    <li id="litabtotalxs" runat="server" class=" visible-xs visible-sm hidden-md hidden-lg"><a href="#tabtotalxs" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px;"><asp:label ID="LBTabTotal" runat="server"></asp:label></a></li>
                                </ul>
                            </div>
                            <div id="panelesprincipales" class="panel-body" style="padding: 0px; height: 215px;">
                                <div class="tab-content">
                                    <div class="tab-pane fade" id="tabcargo">
                                        <div class="col-xs-12" style="overflow: auto; height: 155px; padding-left: 1px; padding-right: 0px;">
                                            <asp:GridView ID="GVCargos" runat="server" CssClass="table table-responsive GridComun" AlternatingRowStyle-CssClass="alt" Style="margin: 0px; border: 0px;" ShowHeader="false" AutoGenerateColumns="False">
                                                <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="CBCargos" name="CBCargos" OnCheckedChanged="CBCargos_OnCheckedChanged" AutoPostBack="True" Checked='<%#Eval("Activo")%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" Visible="true" />
                                                    <asp:BoundField DataField="TipoCargoVenta" HeaderText="Cargo" SortExpression="TipoCargoVenta" Visible="true" />
                                                     <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Right"><ItemTemplate><asp:Label runat="server" Text='<%# Eval("Total", "{0:c}") %>' Style="padding-right: 15px;"></asp:Label></ItemTemplate></asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabpromociones">
                                        <div class="col-xs-12" style="overflow: auto; height: 155px; padding-left: 0px; padding-right: 0px;">
                                            <asp:GridView ID="GVPromociones" runat="server" CssClass="table table-responsive GridComun" AlternatingRowStyle-CssClass="alt" Style="margin: 0px; border: 0px;" ShowHeader="false" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="BTNDescuentoAgregar" runat="server" ForeColor="Blue" ShowSelectButton="True" Text="Agregar" OnClick="BTNDescuentoAgregar_Click" /></ItemTemplate></asp:TemplateField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Promoción" SortExpression="Descripcion" Visible="true" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabcontado">
                                        <div class="col-sm-6" style="padding-left: 4px;">
                                            <div class="input-group" style="text-align: right;">
                                                <span class="input-group-addon" >Plazo</span>
                                                <asp:DropDownList runat="server"  CssClass="form-control" ID="CBPLPlazoContado" DataTextField="Descripcion" DataValueField="IdTipoPlazo" AutoPostBack="true" OnTextChanged="CBPLPlazoContado_TextChanged" />
                                                <asp:Label runat="server" CssClass="form-control" ID="LBPLPlazoContado" Visible="false" style="padding-right: 0; "></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-6" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group" style="text-align: right; ">
                                                <span id="spnfecinicon" class="input-group-addon" style="padding-right: 0; ">Fecha Inicio</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCFInicioCon" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-6" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group" style="text-align: right; ">
                                                <span id="spnfecfincon"  class="input-group-addon" style="padding-right: 0; ">Fecha Fin</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCFFinCorto" style=" "></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="divPeriodoContado">
                                            <div class="input-group" style="text-align: right; padding-left: 16px; ">
                                                <asp:DropDownList runat="server" CssClass="form-control"  ID="DDPeriodo1" DataTextField="Descripcion" DataValueField="IdPeriodo" AutoPostBack="true" OnTextChanged="DDPeriodo1_OnTextChanged" />
                                                <asp:Label runat="server" CssClass="form-control" ID="LBPeriodo1" Visible="false" style="padding-left: 0; text-align: left; "></asp:Label>
                                                <asp:Label runat="server" CssClass="input-group-addon" ID="TBLPCCONoPeriodo" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="divAbonoContado">
                                            <div class="input-group" style="text-align: right; ">
                                                <span class="input-group-addon" >Abono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCCOImporte" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="divTotalContado">
                                            <div class="input-group" style="text-align: right;  ">
                                                <span class="input-group-addon" >Total</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCCOTotal" ></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabcredito">
                                        <div class="col-sm-6" style="padding-left: 4px;">
                                            <div class="input-group" style="text-align: right;">
                                                <span class="input-group-addon" >Plazo</span>
                                                <asp:DropDownList runat="server"  CssClass="form-control" ID="CBPLPlazoCredito" DataTextField="Descripcion" DataValueField="IdTipoPlazo" AutoPostBack="true" OnTextChanged="CBPLPlazoContado_TextChanged" />
                                                <asp:Label runat="server" CssClass="form-control" ID="LBPLPlazoCredito" Visible="false" style="padding-right: 0; "></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-6" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group" style="text-align: right; ">
                                                <span id="spnfecinicre" class="input-group-addon" style="padding-right: 0; ">Fecha Inicio</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCFInicioCre" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-6" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group" style="text-align: right; ">
                                                <span id="spnfecfincre"  class="input-group-addon" style="padding-right: 0; ">Fecha Fin</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCFFin" style=" "></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="div1">
                                            <div class="input-group" style="text-align: right; padding-left: 16px; ">
                                                <asp:DropDownList runat="server" CssClass="form-control"  ID="DDPeriodo2" DataTextField="Descripcion" DataValueField="IdPeriodo" AutoPostBack="true" OnTextChanged="DDPeriodo2_OnTextChanged" />
                                                <asp:Label runat="server" CssClass="form-control" ID="LBPeriodo2" Visible="false" style="padding-left: 0; text-align: left; "></asp:Label>
                                                <asp:Label runat="server" CssClass="input-group-addon" ID="TBLPCCRNoPeriodo" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="div2">
                                            <div class="input-group" style="text-align: right; ">
                                                <span class="input-group-addon" >Abono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCCRImporte" ></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" style="padding-left: 4px; padding-right: 4px;" runat="server" id="div3">
                                            <div class="input-group" style="text-align: right;  ">
                                                <span class="input-group-addon" >Total</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLPCCRTotal" ></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabclientexs">
                                        <div class="col-xs-12" style="padding-left: 4px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Cliente</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCNombrexs"></asp:Label>
                                                <div class="input-group-btn">
                                                    <asp:LinkButton ID="IBTNRegistrarPersonaxs" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><asp:label id="spnbtnnuevoclientexs" runat="server" class="fa fa-plus"></asp:label><asp:label text=" Nuevo" runat="server" id="LNBTNNuevoClientexs"/></asp:LinkButton>
                                                    <asp:LinkButton ID="IBTNBuscarPersonaxs" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><span class="fa fa-search"></span><span id="spnbuscarcliente"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Saldo disponible</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCSaldoxs"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Entrega</span>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="TBLCDomicilioxs"></asp:TextBox>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLCDomicilioxs" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Teléfono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCTelefonoxs"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="tab-pane fade" id="tabavalxs">
                                        <div class="col-xs-12" style="padding-left: 4px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Aval</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLANombrexs"></asp:Label>
                                                <div class="input-group-btn">
                                                    <asp:LinkButton ID="IBTNARegistrarPersonaxs" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><asp:label id="LNBTNNuevoAvalxs" runat="server" class="fa fa-plus"></asp:label><asp:label text=" Nuevo" runat="server" id="spnbtnnuevoavalxs"/></asp:LinkButton>
                                                    <asp:LinkButton ID="IBTNABuscarPersonaxs" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><span class="fa fa-search"></span><span id="spnbuscaraval"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Saldo disponible</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLASaldoxs"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Domicilio</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLADomicilioxs"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Teléfono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLATelefonoxs"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabtotalxs">
                                         <div class="col-xs-12" style="padding-bottom: 0; padding-top: 0;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Subtotal&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLTSubtotalxs"></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-xs-12" style="padding-bottom: 0; padding-top: 0;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Descuento</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLTDescuentoxs"></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-xs-12" style="padding-bottom: 0; padding-top: 0;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Cargo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLTImpuestoxs"></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-6" style="padding-bottom: 0; padding-top: 0;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Enganche&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="TBXPCEAnticipoxs" AutoPostBack="true" OnTextChanged="TBXPCEAnticipo_OnTextChanged"></asp:TextBox>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBXPCEAnticipoxs" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-6" style="padding-bottom: 0; padding-top: 0; background: #337ab7;">
                                            <div class="input-group">
                                                <span class="input-group-addon" style="font-size: 22pt; color: white;">Total</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLTotalxs" style="font-size: 22pt; margin-top: -10px; color: white;"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 visible-lg" style="padding-left: 0px; padding-right: 0px;">
                        <div class="panel with-nav-tabs panel-primary" style="border: 0 solid transparent; border-radius: 0; margin-bottom: 0;">
                            <div class="panel-heading" style="border-top-left-radius: 0; border-top-right-radius: 0; padding-top: 0;">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#tabcliente" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px;">Cliente</a></li>
                                    <li id="litabaval"  runat="server"><a href="#tabaval" data-toggle="tab" style="font: normal bold; font-size: 11pt; padding-top: 0; height: 30px;">Aval</a></li>
                                </ul>
                            </div>
                            <div class="panel-body" style="padding: 0px; height: 155px;">
                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="tabcliente">
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Cliente</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCNombre"></asp:Label>
                                                <div class="input-group-btn">
                                                    <asp:LinkButton ID="IBTNRegistrarPersona" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><asp:label id="spnbtnnuevocliente" runat="server" class="fa fa-plus"></asp:label><asp:label text=" Nuevo" runat="server" id="LNBTNNuevoCliente"/></asp:LinkButton>
                                                    <asp:LinkButton ID="IBTNBuscarPersona" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><span class="fa fa-search"></span>&nbsp;F8</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Saldo disponible</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCSaldo"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon" style="padding-right: 4px;">Entrega</span>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="TBLCDomicilio"></asp:TextBox>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLCDomicilio" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Teléfono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="TBLCTelefono"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabaval">
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Aval</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLANombre"></asp:Label>
                                                <div class="input-group-btn">
                                                    <asp:LinkButton ID="IBTNARegistrarPersona" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><asp:label id="spnbtnnuevoaval" runat="server" class="fa fa-plus"></asp:label><asp:label text=" Nuevo" runat="server" id="LNBTNNuevoAval"/></asp:LinkButton>
                                                    <asp:LinkButton ID="IBTNABuscarPersona" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black; padding-left: 10px; padding-right: 10px;"><span class="fa fa-search"></span>&nbsp;F8</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Saldo disponible</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLASaldo"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon" style="padding-right: 4px;">Domicilio</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLADomicilio"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-xs-12" style="padding-left: 4px; padding-right: 4px; padding-top: 0px;">
                                            <div class="input-group">
                                                <span class="input-group-addon">Teléfono</span>
                                                <asp:Label runat="server" CssClass="form-control" ID="LBLATelefono"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="hidden-xs hidden-sm col-md-4 col-lg-3" style="padding-left: 0px; padding-right: 0px; border: 6px solid #337ab7;">
                        <div class="panel panel-collapse" style="margin: 0; border-radius: 0px; border: 0;">
                            <div class="panel-body" style="padding: 0;">
                                <div class="col-xs-12" style="margin-top: 0px;">
                                    <div class="col-xs-6" style="text-align: left;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">Subtotal</h5>
                                    </div>
                                    <div class="col-xs-6" style="text-align: right;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">
                                            <asp:Label runat="server" ID="TBLTSubtotal" /></h5>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="col-xs-6" style="text-align: left;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">
                                            <asp:Label runat="server">Descuento</asp:Label></h5>
                                    </div>
                                    <div class="col-xs-6" style="text-align: right;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">
                                            <asp:Label runat="server" ID="TBLTDescuento" /></h5>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="input-group" style="text-align: right;">
                                        <h5 class="input-group-addon" style="font-family: inherit; font-weight: 400; line-height: 1.1; color: #444444; font-size: 20px; margin-top: 3px; margin-bottom: 3px;">Enganche</h5>
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="TBXPCEAnticipo" Style="text-align: right; font-family: inherit; font-weight: 400; line-height: 1.1; color: #444444; font-size: 20px; padding-right: 15px;"
                                                AutoPostBack="true" OnTextChanged="TBXPCEAnticipo_OnTextChanged"></asp:TextBox>
                                            <asp:Label runat="server" ID="LBXPCEAnticipo" Visible="false" style="padding-right: 13px;"/>
                                        </h5>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="col-xs-6" style="text-align: left;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">Cargo</h5>
                                    </div>
                                    <div class="col-xs-6" style="text-align: right;">
                                        <h5 style="margin-top: 3px; margin-bottom: 3px;">
                                            <asp:Label runat="server" ID="TBLTImpuesto" /></h5>
                                    </div>
                                </div>
                                <div class="col-xs-12" style="background-color: #337ab7; color: white; margin-top: 3px;">
                                    <div class="col-xs-3" style="text-align: left; font-size: large; padding: 0;">
                                        <h4 style="color: white;">Total</h4>
                                    </div>
                                    <div class="col-xs-9" style="text-align: right; font-size: large; padding: 0;">
                                        <h4 style="color: white;">
                                            <asp:Label runat="server" ID="TBLTTotal" /></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--estado de la venta--%>
                <footer style="margin-left: -15px; margin-right: -15px;">
                    <div id="divBotonesPrincipales" class="col-xs-12" style="padding: 5px; text-align: left;">
                        <div class="btn-group btn-group-justified">
                            <asp:LinkButton ID="BTNVNuevo" runat="server" CssClass="btn btn-default" Text="Nuevo" Width="16%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-file-o"></span>&nbsp;<span id="spnnuevo"></span></asp:LinkButton>
                            <asp:LinkButton ID="BTNVBuscar" runat="server" CssClass="btn btn-default" Text="Buscar" Width="16%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-search"></span>&nbsp;<span id="spnbuscar"></span></asp:LinkButton>
                            <asp:LinkButton ID="BTNVPendiente" runat="server" CssClass="btn btn-default" Text="Pendiente" Width="16%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-clock-o"></span>&nbsp;<span id="spnpendiente"></span></asp:LinkButton>
                            <asp:LinkButton ID="BTNVReimprimir"  runat="server" CssClass="btn btn-default" Text="Imprimir" Width="16%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-print"></span>&nbsp;<span id="spnimprimir"></span></asp:LinkButton>
                            <asp:LinkButton ID="BTNVFinalizar" runat="server" CssClass="btn btn-default" Text="Finalizar" Width="18%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-check"></span>&nbsp;<span id="spnfinalizar"></span></asp:LinkButton>
                            <asp:LinkButton ID="BTNVCancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" Width="18%" Height="40" Style="padding: 15px; padding-top: 5px; box-shadow: 0px 0px 5px #001f40; color: black; min-width: 130px;"><span style="font-size: 26px;" class="fa fa-times"></span>&nbsp;<span id="spncancelar"></span></asp:LinkButton>
                        </div>
                    </div>
                    <div id="divInfoHora" class="col-xs-12" style="color: black; padding-bottom: 5px; padding-left: 0px; padding-right: 0px; background-color: #001f40; color: white;">
<%--                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2" style="padding-left: 10px; padding-right: 10px; text-align: center;">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="DDVCambiar" AutoPostBack="true" OnTextChanged="DDVCambiar_TextChanged" Style="color: white; background-color: #001f40" />
                        </div>--%>
                        <div class="col-xs-12 alinearTop">
                            <div class="col-xs-5" style="padding-left: 0; padding-right: 0;">
                                <span>Estado de la Venta:</span>
                                <span><asp:Label runat="server" ID="TBLEstadoVenta"></asp:Label></span>
                            </div>
                            <div class="col-xs-7" style="text-align: right; padding: 0px;">
                                <span id="TBLFechaVenta"></span>
                                <span>&nbsp;<a href="#" onclick=" Alternar(document.getElementById('form1')); return false; "><img id="imgFullscreen" src="/Imagenes/Venta/fullscreen_enter.png" alt="fullscreen" style="height: 20px;" /></a></span>
                                <div class="hidden"><asp:Button runat="server" ID="BTNActualizaCantidad" OnClick="BTNActualizaCantidad_Click" /></div>
                                <div class="hidden"><asp:Button runat="server" ID="BTNActualizarAnticipo" OnClick="BTNActualizarAnticipo_OnClick" /></div>
                                <div class="hidden"><asp:Button runat="server" ID="BTNCambiarVenta" OnClick="BTNCambiarVenta_Click" /></div>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
            <asp:HiddenField ID="TabName" runat="server" />
            <div class="hidden"><asp:Button runat="server" ID="BTNActualizaCargos" OnClick="BTNActualizaCargos_OnClick"/></div>
        </asp:View>
        <asp:View ID="ContenidoBuscarProducto" runat="server">
            <div class="container-fluid" style="background-color: white;">
                <WUCBProducto:wucBuscarProducto ID="wucConPrd" runat="server" />
            </div>
        </asp:View>
        <asp:View ID="ContenidoBuscarPersona" runat="server">
            <div class="container-fluid" style="background-color: white;">
                <WUCBPersona:wucBuscarPersona ID="WucBuscarPersona1" runat="server" />
            </div>
        </asp:View>
        <asp:View ID="ContenidoBuscarVenta" runat="server">
            <div class="container-fluid" style="background-color: white;">
                <WUCBVenta:wucBuscarVenta ID="WucBuscarVenta" runat="server" />
            </div>
        </asp:View>
        <asp:View ID="ContenidoAviso" runat="server">
            <div class="container-fluid" style="background-color: white;">
                <WucAviso:wucMAviso ID="WucAviso1" runat="server" />
            </div>
        </asp:View>
    </asp:MultiView>
    <script src="../../../Scripts/venta/jquery.price_format.2.0.min.js"></script>
    <script src="../../../Scripts/venta/mindmup-editabletable.js"></script>
    <script src="../../../Scripts/venta/numeric-input-example.js"></script>
    <script src="../../../Scripts/venta/prettify.js"></script>
    <script src="../../../Scripts/venta/ScriptsVenta.js"></script>
    <script src="../../../Scripts/venta/jquery.hotkeys.js"></script>
    <script src="../../../Scripts/venta/Funciones.js"></script>
    <script src="../../../Scripts/venta/fullScreen.js"></script>
    <script src="../../../Scripts/bootstrap/bootstrap-switch.min.js"></script>
    <%--<script src="../../../Scripts/venta/jquery.scrolling-tabs.min.js"></script>--%>
    <script src="../../../Scripts/Imprimir.js"></script>
</asp:Content>



