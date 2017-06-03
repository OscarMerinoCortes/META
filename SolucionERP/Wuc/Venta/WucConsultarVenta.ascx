<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarVenta.ascx.vb" Inherits="WucConsultarVenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="">
    <div id="divBotonesConsultas" class="row">
        <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNHoy_Click" />
            <asp:Button runat="server" Text="Esta Semana" CssClass="hidden-xs btn btn-primary" OnClick="BTNSemana_Click" />
            <asp:Button runat="server" Text="Semana" CssClass="visible-xs btn btn-primary" OnClick="BTNSemana_Click" />
            <asp:Button runat="server" Text="Este Mes" CssClass="hidden-xs btn btn-primary" OnClick="BTNMes_Click" />
            <asp:Button runat="server" Text="Mes" CssClass="visible-xs btn btn-primary" OnClick="BTNMes_Click" />
            <asp:Button runat="server" Text="Este Año" CssClass="hidden-xs btn btn-primary" OnClick="BTNAno_Click" />
            <asp:Button runat="server" Text="Año" CssClass="visible-xs btn btn-primary" OnClick="BTNAno_Click" />
            <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" OnClick="BTNAvanzado_Click" />
            <asp:Button runat="server" Text="Cancelar" CssClass="visible-xs btn btn-danger" OnClick="BTNVCancelar_Click"/>
        </div>
        <div class="hidden-xs" style="min-width: 150px; float: right; padding-right: 10px; padding-top: 2px;">
            <asp:Button runat="server" Text="Cancelar" Width="100%" CssClass="btn btn-danger" OnClick="BTNVCancelar_Click"/>
        </div>
    </div>
    <div class="row" runat="server" id="divAvanzado" style="padding-right: 20px;">
        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding-right: 0;">
            <div class="input-group">
                <label class="input-group-addon" style="padding: 0px;">Folio</label>
                <asp:TextBox runat="server" ID="TBLVFolio" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
            </div>
        </div>
        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding-right: 0;">
            <div class="input-group">
                <span class="input-group-addon" style="padding: 0px;">Vendedor</span>
                <asp:TextBox runat="server" ID="TBVendedor" CssClass="form-control" Style="text-align: right;"></asp:TextBox>
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
            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 5px; padding-left: 0px; padding-right: 0px;">
        <div id="tablaGVBVenta" class="panel-body col-xs-12" style="overflow:auto; height: 290px; padding: 0; font-size: medium; text-align: center;">
            <asp:GridView ID="GVBusquedaVenta" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" OnRowDataBound="GVBusquedaVenta_RowDataBound"
                BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None" >
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter">
                        <HeaderTemplate>
                            Seleccionar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="BTNSeleccionar" runat="server"
                                ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionar_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Venta" HeaderText="Venta" SortExpression="Venta" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" Visible="true" HeaderStyle-CssClass="GVBCenter"/>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" DataFormatString="{0:C2}" HeaderStyle-CssClass="GVBCenter"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-xs-12" style="text-align: right; background-color: #001f40; color: white; height: 30px; padding-top: 0px;">
            <asp:Label runat="server" Font-Size="12" ID="LBCantidadBusqueda"></asp:Label>
        </div>
    </div>
</div>
