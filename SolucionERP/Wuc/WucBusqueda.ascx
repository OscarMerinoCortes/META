<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucBusqueda.ascx.vb" Inherits="Wuc_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<script>
    var TypeProductos = [<%= StringArregloProductos %>];
    $(Window).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
        //iniciar autocompletado
        IniciarProductos();
    });

    function InitializeRequest(sender, args) {
    }

    function EndRequest(sender, args) {
        // reiniciar autocompletado cuando la pagina haya cambiado
        IniciarProductos();
    }

    function IniciarProductos() {
        $('.typeahead2').typeahead({
            name: 'Productos',
            limit: 10,
            local: TypeProductos
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
        width: 100%;
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

    .typeahead2 {
        width: 100%;
    }
    .twitter-typeahead{width:100%}
</style>
<asp:MultiView ID="MUWucConsulta" runat="server">
    <asp:View ID="VWProductos" runat="server">
        <input type="text" class="typeahead2 form-control" runat="server" placeholder="Producto..." id="TBBNombreProducto" />
    </asp:View>
</asp:MultiView>