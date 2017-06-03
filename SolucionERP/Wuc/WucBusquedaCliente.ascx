<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucBusquedaCliente.ascx.vb" Inherits="Wuc_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script>
    var TypeCliente = [<%= StringArregloCliente %>];
    $(Window).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);

        //iniciar autocompletado
        IniciarClientes();
    });

    function InitializeRequest(sender, args) {
    }

    function EndRequest(sender, args) {
        // reiniciar autocompletado cuando la pagina haya cambiado
        IniciarClientes();
    }

    function IniciarClientes() {
        $('.typeahead').typeahead({
            name: 'Clientes',
            limit: 10,
            local: TypeCliente
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
        width: 550px;
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
        width: 350px;
    }
</style>
<asp:MultiView ID="MUWucConsultaCliente" runat="server">
    <asp:View ID="VWCliente" runat="server">
        <input type="text" class="typeahead" runat="server" placeholder="Cliente..." id="TBBNombreCliente" />
    </asp:View>
</asp:MultiView>
