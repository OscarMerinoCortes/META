<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarPersonaVenta.ascx.vb" Inherits="WucConsultarPersonaVenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="row">
    <div class="col-xs-12" id="divBotonesConsultas">
        <div class="col-xs-12 col-sm-10" style="margin-top: 5px;">
            <div class="input-group">
                <span class="input-group-addon sr-only">Buscar Persona:</span>
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Buscar Persona" ID="TBXCodigo" />
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
        <div id="tablaGVBPersona" class="panel-body col-xs-12" style="overflow: auto; height: 290px; padding: 0; font-size: medium; text-align: center;">
            <asp:GridView ID="GVBusquedaPersona" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive " OnRowDataBound="GVBusquedaPersona_RowDataBound"
                BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionar_Click1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="left" />
                    <asp:BoundField DataField="Equivalencia" HeaderText="Equivalencia" SortExpression="Equivalencia" Visible="true"  HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="true" HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center" />
                </Columns>
                <EmptyDataTemplate>
                    <label>Sin coincidencia de personas</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div class="col-xs-12" style="text-align: right; background-color: #001f40; color: white; height: 30px;">
            <asp:Label runat="server" Font-Size="12" ID="LBCantidadBusqueda">Personas: 0</asp:Label>
        </div>
    </div>
</div>

