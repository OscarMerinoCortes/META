<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucEstadisticaProducto.ascx.vb" Inherits="Wuc_EstadisticaProducto" %>

<asp:Panel Visible="false" runat="server" ID="PanelTablas" CssClass="PanelTablas">

                <asp:Label ID="Compra" runat="server">Cantidad de productos comprados</asp:Label>
            <asp:GridView ID="GVCompra" runat="server" CssClass="GridEstadistica" GridLines="None" Style="margin: 0 auto;" Width="100%" AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="alt" />
                <PagerStyle CssClass="pgr" />
                <Columns>
                    <asp:BoundField DataField="Anio" HeaderText="Año" SortExpression="Año" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Ene" HeaderText="Ene" SortExpression="PrecioUnitario" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Feb" HeaderText="Feb" SortExpression="Existencia" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Mar" HeaderText="Mar" SortExpression="Maximo" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Abr" HeaderText="Abr" SortExpression="Minimo" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="May" HeaderText="May" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Jun" HeaderText="Jun" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Jul" HeaderText="Jul" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Ago" HeaderText="Ago" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Sep" HeaderText="Sep" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Oct" HeaderText="Oct" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Nov" HeaderText="Nov" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Dic" HeaderText="Dic" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
                <EmptyDataTemplate></div><center><label>Sin Datos</label></center></EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="Venta" runat="server">Cantidad de productos vendidos</asp:Label>
            <asp:GridView ID="GVVenta" runat="server" CssClass="GridEstadistica" GridLines="None" Style="margin: 0 auto;" Width="100%" AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="alt" />
                <PagerStyle CssClass="pgr" />
                <Columns>
                    <asp:BoundField DataField="Anio" HeaderText="Año" SortExpression="Año" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Ene" HeaderText="Ene" SortExpression="PrecioUnitario" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Feb" HeaderText="Feb" SortExpression="Existencia" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Mar" HeaderText="Mar" SortExpression="Maximo" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Abr" HeaderText="Abr" SortExpression="Minimo" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="May" HeaderText="May" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Jun" HeaderText="Jun" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Jul" HeaderText="Jul" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Ago" HeaderText="Ago" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Sep" HeaderText="Sep" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Oct" HeaderText="Oct" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Nov" HeaderText="Nov" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Dic" HeaderText="Dic" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Sugerido" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
                <EmptyDataTemplate></div><center><label>Sin Datos</label></center></EmptyDataTemplate>
            </asp:GridView>
            <%--<asp:GridView ID="GVVenta" Style="margin: 0 auto; text-align: center;" runat="server" AllowPaging="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" Width="100%">
            </asp:GridView>--%>
            <asp:Label ID="Sucursal" runat="server" >Existencias de productos por Sucursal</asp:Label>
            <asp:GridView ID="GVExistencia" Style="margin: 0 auto; text-align: center;" runat="server" AllowPaging="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridEstadistica" PagerStyle-CssClass="pgr" Width="100%">
                <EmptyDataTemplate></div><label style="text-align:center">Sin Datos</label></EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="Proveedor" runat="server">Costo de productos por proveedor</asp:Label>
            <asp:GridView ID="GVProveedores" runat="server" CssClass="GridEstadistica" GridLines="None" Style="margin: 0 auto;" Width="100%" AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="alt" />
                <PagerStyle CssClass="pgr" />
                <Columns>
                    <asp:BoundField DataField="IdProveedor" HeaderText="IdProveedor" SortExpression="Año" Visible="false" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Equivalencia" HeaderText="Equivalencia" SortExpression="PrecioUnitario" Visible="true" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="Existencia" Visible="true" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="PrecioUltimaEntrada" HeaderText="Costo" SortExpression="Maximo" Visible="true" ItemStyle-HorizontalAlign="Right"/>
                    <asp:BoundField DataField="FechaUltimaCompra" HeaderText="Fecha Ultima Compra" SortExpression="Minimo" Visible="true" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
                <EmptyDataTemplate></div><center><label>Sin Datos</label></center></EmptyDataTemplate>
            </asp:GridView>
           
</asp:Panel>
<br />
<style >
    .PanelTablas {
        background:#e4e4e4;
        
    }
    .GridEstadistica {
    background-color: rgba(195, 195, 195, 0.38);
    margin: 5px 0 10px 0;
    font-size: 1em;
}
    .GridEstadistica th {
        padding: 4px 4px;
        border: solid 0px #424242;
        text-align: center;
        color: #fff;
        background: #104577;
        font-size: small;  
    }
    .GridEstadistica td {
        padding: 2px;
        border: solid 0px #424242;
        color: #000;
        font-size:small;
    }
    .GridEstadistica tr {
       background:#aaaaaa;
    }
    .GridEstadistica tr:hover {
        background: #B9D6FC;
    }

    .GridEstadistica th a {
        padding: 4px 4px;
        text-decoration: none;
        color: #fff;
        background: #104577;
        font-size: 0.9em;
    }
     .GridEstadistica .alt {
        background: #727171;
    }
    .GridEstadistica .pgr table {
            margin: 5px 0px;
        }

        .GridEstadistica .pgr td {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            color: #fff;
            line-height: 12px;
        }

        .GridEstadistica .pgr a {
            color: #666;
            text-decoration: none;
        }

            .GridEstadistica .pgr a:hover {
                color: #000;
                text-decoration: none;
            }
</style>