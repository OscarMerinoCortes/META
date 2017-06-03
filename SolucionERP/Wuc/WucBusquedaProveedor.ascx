<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucBusquedaProveedor.ascx.vb" Inherits="Wuc_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script src="/Scripts/typeahead.min.js"></script>

<script>
    var TypeProveedor = [<%= StringArregloProveedor %>];
    $(Window).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);

        //iniciar autocompletado
        IniciarProveedores();
    });

    function InitializeRequest(sender, args) {
    }

    function EndRequest(sender, args) {
        // reiniciar autocompletado cuando la pagina haya cambiado
        IniciarProveedores();
    }

    function IniciarProveedores() {
        $('.typeahead').typeahead({
            name: 'Proveedores',
            limit: 10,
            local: TypeProveedor
        });
    }
</script>

<style type="text/css">
    .tt-query {
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
    }

    .tt-hint {
        color: #999;
    }

    .tt-dropdown-menu {
        width: 450px;
        margin-top: 4px;
        padding: 4px 0;
        background-color: #fff;
        border: 1px solid #ccc;
        border: 1px solid rgba(0, 0, 0, 0.2);
        -webkit-border-radius: 4px;
        -moz-border-radius: 4px;
        border-radius: 4px;
        -webkit-box-shadow: 0 5px 10px rgba(0,0,0,.2);
        -moz-box-shadow: 0 5px 10px rgba(0,0,0,.2);
        box-shadow: 0 5px 10px rgba(0,0,0,.2);
    }

    .tt-suggestion {
        padding: 3px 20px;
        line-height: 24px;
    }

        .tt-suggestion.tt-is-under-cursor {
            color: #fff;
            background-color: #0097cf;
        }

        .tt-suggestion p {
            margin: 0;
        }

    .typeahead {
        width: 100%;
    }

    .twitter-typeahead {
        width: 100%;
    }
</style>

<asp:MultiView ID="MUWucConsultaProveedor" runat="server">
    <asp:View ID="VWProveedor" runat="server">
        <input type="text" class="typeahead form-control" runat="server" placeholder="Proveedor..." id="TBBNombreProveedor" />
    </asp:View>
</asp:MultiView>

