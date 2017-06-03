<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarProducto.ascx.vb" Inherits="WucConsultarProducto" %>

<script>
    var arregli = [<%= b %>];
    $(Window).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);

        //iniciar autocompletado
        InitAutoCompl();
    });

    function InitializeRequest(sender, args) {
    }

    function EndRequest(sender, args) {
        // reiniciar autocompletado cuando la pagina haya cambiado
        InitAutoCompl();
    }

    function InitAutoCompl() {
        $('.typeahead').typeahead({
            name: 'suggestion-typeahead',
            limit: 10,
            local: arregli
        });
    }
</script>

<asp:MultiView ID="MUWucConsultaProducto" runat="server">
    <asp:View ID="VWPrincipal" runat="server">
        <div class="row" style="padding-left: 15px; padding-right: 15px;">
                    <asp:LinkButton Visible="false" ID="BTNAceptarBusqueda" runat="server" CssClass="btn" Style="position: absolute; margin-left: -74px; margin-top: -40px;"><span style="font-size: 28px;" class="fa fa-check"></span></asp:LinkButton>
                    <asp:LinkButton Visible="false" ID="BTNCancelarBusqueda" runat="server" CssClass="btn" Style="position: absolute; margin-left: -34px; margin-top: -40px;"><span style="font-size: 28px;" class="fa fa-times"></span></asp:LinkButton>
            <div>
                <table>
                    <tr>
                        <td>
                            &nbsp;Producto&nbsp;&nbsp;
                        </td>                                                         
                        <td>
                            <input type="text" class="typeahead" runat="server" placeholder="Producto..." ID="TBBNombreProducto" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-xs-12" style="overflow: auto; margin-top: 5px;">
                <asp:GridView ID="GVConsultarProducto" Style="margin: 0 auto; padding: 8px; font-size: 14px;" runat="server" AutoGenerateColumns="false"
                    AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" OnRowDataBound="GVBusquedaProducto_RowDataBound"
                    BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center" Visible="false">
                            <HeaderTemplate>Seleccionar</HeaderTemplate>
                            <ItemTemplate>
                                 <asp:LinkButton ID="BTNSeleccionar" runat="server" CssClass="btn" OnClick="BTNSeleccionar_Click1" Text="Seleccionar" style="padding: 0"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" Visible="true" />
                        <asp:BoundField DataField="Producto" HeaderText="Producto" Visible="true" />
                        <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Right" Visible="false">
                            <HeaderTemplate>Cantidad</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Eval("Cantidad") %>' ID="TXCantidad" OnTextChanged="TXCantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Right" Visible="false">
                            <HeaderTemplate>Precio</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Eval("Precio") %>' ID="TXPrecio" OnTextChanged="TXPrecio_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="GVBCenter" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Acción</HeaderTemplate>
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="BTNAgregar" runat="server" Style="color: black;" OnClick="BTNAgregar_Click">
                                    <asp:Image runat="server" ID="IMAccion" Width="24" /></asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:View>
</asp:MultiView>
