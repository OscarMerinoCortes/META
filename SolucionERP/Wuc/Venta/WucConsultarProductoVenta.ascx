<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarProductoVenta.ascx.vb" Inherits="WucConsultarProductoVenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="row">
    <div class="col-xs-12" id="divBotonesConsultas">
        <div class="col-xs-12 col-sm-10" style="margin-top: 5px;">
            <div class="input-group">
                <span class="input-group-addon sr-only">Buscar Producto:</span>
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Buscar Producto" ID="TBXCodigo" />
                <div class="input-group-btn">
                    <asp:ImageButton runat="server" CssClass="btn btn-default" ImageUrl="~/Imagenes/Venta/search.png" Style="height: 34px;" OnClick="BTNBuscar_Click" />
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-2" style="text-align: right; margin-top: 5px;">
            <div class="btn-group btn-group-justified">
                <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-danger col-xs-4" ID="BTNVCancelar" Width="100%" OnClick="BTNVCancelar_Click" />
            </div>
        </div>
    </div>
    <div class="col-xs-12" style="margin-top: 5px; padding-left: 0px; padding-right: 0px;">
        <div id="tablaGVBProducto" class="panel-body col-xs-12" style="overflow:auto; height: 290px; padding: 0; font-size: medium; text-align: center;">
            <asp:GridView ID="GVBusquedaProducto" Style="margin: 0 auto; padding: 8px; font-size: 15px;" runat="server" AutoGenerateColumns="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" OnRowDataBound="GVBusquedaProducto_RowDataBound"
                BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None" >
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="120">
                        <HeaderTemplate>
                            <div class="col-xs-12">Almacen</div>
                            <div class="col-xs-12" style="padding: 0;"><div class="col-xs-6" style="padding: 0;">Actual</div><div class="col-xs-6" style="padding: 0;">Otros</div></div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-xs-12" style="padding: 0;"><div class="col-xs-6" style="padding: 0;"><asp:LinkButton CssClass="fa fa-check" ID="BTNSeleccionar" runat="server" OnClick="BTNSeleccionar_Click1" style="font-size: 25px;"/></div><div class="col-xs-6" style="padding: 0;"><asp:LinkButton CssClass="fa fa-list-ol" ID="BTNVerExistencia" runat="server" style="font-size: 25px;" OnClick="BTNVerExistencia_OnClick" /></div></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="120"/>
                    <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>               
                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="120">
                        <HeaderTemplate>
                            <div class="col-xs-12">Existencia</div>
                            <div class="col-xs-12" style="padding: 0;"><div class="col-xs-6" style="padding: 0;">Actual</div><div class="col-xs-6" style="padding: 0;">Total</div></div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-xs-12" style="padding: 0;"><div class="col-xs-6" style="padding: 0;"><%# Eval("Cantidad")%></div><div class="col-xs-6" style="padding: 0;"><%# Eval("CantidadTotal")%></div></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Contado" HeaderText="Contado" SortExpression="Contado" DataFormatString="{0:C2}" HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="90"/>
                    <asp:BoundField DataField="Abono" HeaderText="Abono" SortExpression="Abono" DataFormatString="{0:C2}" HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="90"/>
                    <asp:BoundField DataField="Credito" HeaderText="Credito" SortExpression="Credito" DataFormatString="{0:C2}" HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="90"/>
                    <asp:BoundField DataField="Plazo" HeaderText="Plazo" SortExpression="Plazo" HeaderStyle-Width="90"/>
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" DataFormatString="{0:C2}" HeaderStyle-CssClass="GVBCenter" HeaderStyle-Width="90"/>
                </Columns>
                <EmptyDataTemplate>
                    <Label>Sin coincidencia o existencia en ninguna sucursal</Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:GridView ID="GVBusquedaProductoSucursal" Style="margin: 0 auto; padding: 8px; font-size: 15px;" runat="server" AutoGenerateColumns="false" Visible="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" OnRowDataBound="GVBusquedaProducto_RowDataBound"
                 BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            Seleccionar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="BTNSeleccionar" runat="server"
                                ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionar2_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
<%--                    <asp:BoundField DataField="Id Corto" HeaderText="Codigo" SortExpression="Id Corto" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>--%>
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
                <EmptyDataTemplate>
                    <label>Sin existencias en ninguna sucursal</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div class="col-xs-12" style="text-align: right; background-color: #001f40; color: white; height: 30px;">
            <asp:Label runat="server" Font-Size="12" ID="LBCantidadBusqueda">Productos: 0</asp:Label>
        </div>
    </div>
</div>

