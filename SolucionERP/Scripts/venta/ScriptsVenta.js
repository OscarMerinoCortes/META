Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
function endReq(sender, args) {
    comprobarTamano();
}

$(window).resize(function() {
    comprobarTamano();
});
$(document).ready(function () {
    comprobarTamano();
});

function comprobarTamano() {
    try {
        //aqui el codigo que se ejecutara cuando se redimencione la ventana
        var ancho = $(window).width();
        var alto = $(window).height();
        var altoPrincipalMaster = 0;
        var altoContenidoFiltro = 0;
        var altoBotonesConsultas = 0;
        if (document.getElementById('tablaGVBProducto')) {
            if (document.getElementById('divPrincipalMaster'))
                altoPrincipalMaster = $("#divPrincipalMaster").height();
            if (document.getElementById('divBotonesConsultas'))
                altoBotonesConsultas = $("#divBotonesConsultas").height();
            var suma = 35 + altoContenidoFiltro + altoBotonesConsultas + altoPrincipalMaster;
            document.getElementById('tablaGVBProducto').style.height = (alto - suma).toString() + "px";
        }
        if (document.getElementById('tablaGVBPersona')) {
            if (document.getElementById('divPrincipalMaster'))
                altoPrincipalMaster = $("#divPrincipalMaster").height();
            if (document.getElementById('divBotonesConsultas'))
                altoBotonesConsultas = $("#divBotonesConsultas").height();
            var suma = 35 + altoContenidoFiltro + altoBotonesConsultas + altoPrincipalMaster;
            document.getElementById('tablaGVBPersona').style.height = (alto - suma).toString() + "px";
        }
        if (document.getElementById('tablaGVBVenta')) {
            if (document.getElementById('divPrincipalMaster'))
                altoPrincipalMaster = $("#divPrincipalMaster").height();
            if (document.getElementById('MainContent_WucBuscarVenta_divAvanzado'))
                altoContenidoFiltro = $("#MainContent_WucBuscarVenta_divAvanzado").height();
            if (document.getElementById('divBotonesConsultas'))
                altoBotonesConsultas = $("#divBotonesConsultas").height();
            var suma = 35 + altoContenidoFiltro + altoBotonesConsultas + altoPrincipalMaster;
            document.getElementById('tablaGVBVenta').style.height = (alto - suma).toString() + "px";
        }
        if (document.getElementById('MainContent_tablaVentaDetalle')) {
            if (ancho >= 768) {
                document.getElementById('panelesprincipales').style.height = "155px";
                try {
                    document.getElementById('divlbproductos').classList.remove('hidden');
                } catch (ex) {
                }
                try {
                    document.getElementById('divbtnproductos').classList.add('hidden');
                } catch (ex) {
                }
                FuncionMostrarGVDetalle();
                if (ancho == 768)
                    OcultrarFunciones();
                else
                    MostrarFunciones();

                var divPrincipalMaster = 0;
                var divFolios = 0; //+8
                var divlbproductos = 0; //+2
                var tabs = 0;
                var divBotonesPrincipales = 0; //+10
                var divInfoHora = 0; //+5
                if (document.getElementById('divPrincipalMaster'))
                    divPrincipalMaster = $("#divPrincipalMaster").height();
                if (document.getElementById('divFolios'))
                    divFolios = $("#divFolios").height();
                if (document.getElementById('divlbproductos'))
                    divlbproductos = $("#divlbproductos").height();
                if (document.getElementById('tabs'))
                    tabs = $("#tabs").height();
                if (document.getElementById('divBotonesPrincipales'))
                    divBotonesPrincipales = $("#divBotonesPrincipales").height();
                if (document.getElementById('divInfoHora'))
                    divInfoHora = $("#divInfoHora").height();
                var sumaPrincipal = 25 + divPrincipalMaster + divFolios + divlbproductos + tabs + divBotonesPrincipales + divInfoHora;
                document.getElementById('MainContent_tablaVentaDetalle').style.height = (alto - sumaPrincipal).toString() + "px";
                //mostramos la palabra fecha ya que ya no es necesario ahorrar espacio
                if (document.getElementById('spnfecinicon')) {
                    document.getElementById('spnfecinicon').innerHTML = "Fecha Inicio";
                    document.getElementById('spnfecinicre').innerHTML = "Fecha Inicio";
                }
                if (document.getElementById('spnfecfincon')) {
                    document.getElementById('spnfecfincon').innerHTML = "Fecha Fin";
                    document.getElementById('spnfecfincre').innerHTML = "Fecha Fin";
                }
            } else {
                try {
                    document.getElementById('divlbproductos').classList.add('hidden');
                } catch (ex) {
                }
                try {
                    document.getElementById('divbtnproductos').classList.remove('hidden');
                } catch (ex) {
                }
                FuncionOcultarGVDetalle();
                document.getElementById('panelesprincipales').style.height = "185px";
                document.getElementById('MainContent_tablaVentaDetalle').style.height = "300px";
                OcultrarFunciones();

                //ocultamos la palabra fecha para ahorrar espacio en tamaños chicos
                if (document.getElementById('spnfecinicon')) {
                    document.getElementById('spnfecinicon').innerHTML = "Inicio";
                    document.getElementById('spnfecinicre').innerHTML = "Inicio";
                }
                if (document.getElementById('spnfecfincon')) {
                    document.getElementById('spnfecfincon').innerHTML = "Fin";
                    document.getElementById('spnfecfincre').innerHTML = "Fin";
                }
            }
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tabcontado";
            $('#tabspaneles a[href="#' + tabName + '"]').tab('show');
            $("#tabspaneles a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        }
        if (document.getElementById('encabezadoTablaBusquedaProducto')) {
            if (ancho < 578) {
                document.getElementById('encabezadoTablaBusquedaProducto').classList.remove('col-xs-12');
            }
            document.getElementById('encabezadoTablaBusquedaProducto').style.width = document.getElementById('tablaGVBProducto').style.width + "px";
        }
        if (document.getElementById('MainContent_GVVentaDetalle')) {
            $('#MainContent_GVVentaDetalle').editableTableWidget().numericInputExample().find('td:first').focus();
            $('#textAreaEditor').editableTableWidget({ editor: $('<textarea>') });
            window.prettyPrint && prettyPrint();
            $('#MainContent_TBXPCEAnticipo').priceFormat({
                prefix: '$',
                centsSeparator: '.',
                thousandsSeparator: ',',
                centsLimit: 2
            });
            $("#MainContent_TBXPCEAnticipo").focus(function () {
                $(this).select();
            });
            var i = 0;
            $('#MainContent_GVCargos tr').each(function () {
                var check = "MainContent_GVCargos_CBCargos_" + i;
                $("#" + check).bootstrapSwitch();
                $("#" + check).on('switchChange.bootstrapSwitch', function (event, data) {
                    document.getElementById("MainContent_BTNActualizaCargos").click();
                });
                i++;
            });
        }
    } catch (ex) {
        alert(ex.message);
    }
}
function FuncionMostrarGVDetalle() {
    try {
        if (document.getElementById('MainContent_tablaVentaDetalle').classList.contains('hidden')) {
            document.getElementById('MainContent_tablaVentaDetalle').classList.remove('hidden');
        } 
        if (document.getElementById('panelesprincipales').classList.contains('hidden')) {
            document.getElementById('panelesprincipales').classList.remove('hidden');
        }
    } catch (ex) {tablaGVBVenta
    }
}

function FuncionOcultarGVDetalle() {
    try {
        if (document.getElementById('MainContent_tablaVentaDetalle').classList.contains('hidden')) {
            document.getElementById('MainContent_tablaVentaDetalle').classList.remove('hidden');
            document.getElementById('panelesprincipales').classList.add('hidden');
        } else {
            document.getElementById('MainContent_tablaVentaDetalle').classList.add('hidden');
            document.getElementById('panelesprincipales').classList.remove('hidden');
            
        }
} catch (ex) {
    }
}

function MostrarFunciones() {
    if (document.getElementById('spnnuevo'))
        document.getElementById('spnnuevo').innerHTML = "Nuevo";
    if (document.getElementById('spnbuscar'))
        document.getElementById('spnbuscar').innerHTML = "Buscar";
    if (document.getElementById('spnpendiente'))
        document.getElementById('spnpendiente').innerHTML = "Pendiente";
    if (document.getElementById('spnimprimir'))
        document.getElementById('spnimprimir').innerHTML = "Imprimir";
    if (document.getElementById('spnfinalizar'))
        document.getElementById('spnfinalizar').innerHTML = "Finalizar";
    if (document.getElementById('spncancelar'))
        document.getElementById('spncancelar').innerHTML = "Cancelar";
    if (document.getElementById('spnbuscarcliente'))
        document.getElementById('spnbuscarcliente').innerHTML = "";
    if (document.getElementById('spnnavcontado')) {
        try {
            if (document.getElementById('DDVCambiar').value != 3) {
                document.getElementById('spnnavcontado').innerHTML = "Contado";
            } else
                document.getElementById('spnnavcontado').innerHTML = "Plazo";
        } catch (ex) {
            document.getElementById('spnnavcontado').innerHTML = "Plazo";
        }
    }
    if (document.getElementById('spnnavcredito'))
        document.getElementById('spnnavcredito').innerHTML = "Credito";
    if (document.getElementById('spnnavpromocion'))
        document.getElementById('spnnavpromocion').innerHTML = "Promociones";
    if (document.getElementById('spnnavcliente'))
        document.getElementById('spnnavcliente').innerHTML = "Cliente";
    if (document.getElementById('spnnavaval'))
        document.getElementById('spnnavaval').innerHTML = "Aval";
    if (document.getElementById('spngvcantidad'))
        document.getElementById('spngvcantidad').innerHTML = "Cantidad";
    if (document.getElementById('spnnavcargo'))
        document.getElementById('spnnavcargo').innerHTML = "Cargos";

}
function OcultrarFunciones() {
    if (document.getElementById('spnnuevo'))
        document.getElementById('spnnuevo').innerHTML = "Nuevo";
    if (document.getElementById('spnbuscar'))
        document.getElementById('spnbuscar').innerHTML = "Buscar";
    if (document.getElementById('spnpendiente'))
        document.getElementById('spnpendiente').innerHTML = "Pendiente";
    if (document.getElementById('spnimprimir'))
        document.getElementById('spnimprimir').innerHTML = "Imprimir";
    if (document.getElementById('spnfinalizar'))
        document.getElementById('spnfinalizar').innerHTML = "Finalizar";
    if (document.getElementById('spncancelar'))
        document.getElementById('spncancelar').innerHTML = "Cancelar";
    if (document.getElementById('spnbuscarcliente'))
        document.getElementById('spnbuscarcliente').innerHTML = "";
    if (document.getElementById('spnnavcontado')) {
        try {
            if (document.getElementById('DDVCambiar').value != 3) {
                document.getElementById('spnnavcontado').innerHTML = "Contado";
            } else
                document.getElementById('spnnavcontado').innerHTML = "Plazo";
        } catch (ex) {
            document.getElementById('spnnavcontado').innerHTML = "Plazo";
        }
    }
    if (document.getElementById('spnnavcredito'))
        document.getElementById('spnnavcredito').innerHTML = "Credito";
    if (document.getElementById('spnnavpromocion'))
        document.getElementById('spnnavpromocion').innerHTML = "Promociones";
    if (document.getElementById('spnnavcliente'))
        document.getElementById('spnnavcliente').innerHTML = "Cliente";
    if (document.getElementById('spnnavaval'))
        document.getElementById('spnnavaval').innerHTML = "Aval";
    if (document.getElementById('spngvcantidad'))
        document.getElementById('spngvcantidad').innerHTML = "Cantidad";
    if (document.getElementById('spnnavcargo'))
        document.getElementById('spnnavcargo').innerHTML = "Cargos";
}

function VentaApartado() {
    if (document.getElementById('spnnavcontado'))
        document.getElementById('spnnavcontado').innerHTML = "Plazo";
}

function VentaCredito() {
    if (document.getElementById('spnnavcontado'))
        document.getElementById('spnnavcontado').innerHTML = "Contado";
}

function ActivaContado() {
    try {
        if (!document.getElementById('MainContent_litabcontado').classList.contains('active')) {
            document.getElementById('tabcontado').classList.add('in');
            document.getElementById('tabcontado').classList.add('active');
            document.getElementById('MainContent_litabcontado').classList.add('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabcredito').classList.contains('active')) {
            document.getElementById('tabcredito').classList.remove('in');
            document.getElementById('tabcredito').classList.remove('active');
            document.getElementById('MainContent_litabcredito').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabextra').classList.contains('active')) {
            document.getElementById('tabperiodoyextra').classList.remove('in');
            document.getElementById('tabperiodoyextra').classList.remove('active');
            document.getElementById('MainContent_litabextra').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabpromocion').classList.contains('active')) {
            document.getElementById('tabpromociones').classList.remove('in');
            document.getElementById('tabpromociones').classList.remove('active');
            document.getElementById('litabpromocion').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabcliente').classList.contains('active')) {
            document.getElementById('tabclientexs').classList.remove('in');
            document.getElementById('tabclientexs').classList.remove('active');
            document.getElementById('litabcliente').classList.remove('active');
        }
    }
    catch (ex) { }
}
function ActivaCredito() {
    try {
        if (document.getElementById('MainContent_litabcontado').classList.contains('active')) {
            document.getElementById('tabcontado').classList.remove('in');
            document.getElementById('tabcontado').classList.remove('active');
            document.getElementById('MainContent_litabcontado').classList.remove('active');
        }
    } catch (ex) { }
    try {
        if (!document.getElementById('MainContent_litabcredito').classList.contains('active')) {
            document.getElementById('tabcredito').classList.add('in');
            document.getElementById('tabcredito').classList.add('active');
            document.getElementById('MainContent_litabcredito').classList.add('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabextra').classList.contains('active')) {
            document.getElementById('tabperiodoyextra').classList.remove('in');
            document.getElementById('tabperiodoyextra').classList.remove('active');
            document.getElementById('MainContent_litabextra').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabpromocion').classList.contains('active')) {
            document.getElementById('tabpromociones').classList.remove('in');
            document.getElementById('tabpromociones').classList.remove('active');
            document.getElementById('litabpromocion').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabcliente').classList.contains('active')) {
            document.getElementById('tabclientexs').classList.remove('in');
            document.getElementById('tabclientexs').classList.remove('active');
            document.getElementById('litabcliente').classList.remove('active');
        }
    }
    catch (ex) { }
}
function ActivaCondicion() {
    try {
        if (document.getElementById('MainContent_litabcontado').classList.contains('active')) {
            document.getElementById('tabcontado').classList.remove('in');
            document.getElementById('tabcontado').classList.remove('active');
            document.getElementById('MainContent_litabcontado').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabcredito').classList.contains('active')) {
            document.getElementById('tabcredito').classList.remove('in');
            document.getElementById('tabcredito').classList.remove('active');
            document.getElementById('MainContent_litabcredito').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (!document.getElementById('MainContent_litabextra').classList.contains('active')) {
            document.getElementById('tabperiodoyextra').classList.add('in');
            document.getElementById('tabperiodoyextra').classList.add('active');
            document.getElementById('MainContent_litabextra').classList.add('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabpromocion').classList.contains('active')) {
            document.getElementById('tabpromociones').classList.remove('in');
            document.getElementById('tabpromociones').classList.remove('active');
            document.getElementById('litabpromocion').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabcliente').classList.contains('active')) {
            document.getElementById('tabclientexs').classList.remove('in');
            document.getElementById('tabclientexs').classList.remove('active');
            document.getElementById('litabcliente').classList.remove('active');
        }
    }
    catch (ex) { }
}
function ActivaPromocion() {
    try {
        if (document.getElementById('MainContent_litabcontado').classList.contains('active')) {
            document.getElementById('tabcontado').classList.remove('in');
            document.getElementById('tabcontado').classList.remove('active');
            document.getElementById('MainContent_litabcontado').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabcredito').classList.contains('active')) {
            document.getElementById('tabcredito').classList.remove('in');
            document.getElementById('tabcredito').classList.remove('active');
            document.getElementById('MainContent_litabcredito').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabextra').classList.contains('active')) {
            document.getElementById('tabperiodoyextra').classList.remove('in');
            document.getElementById('tabperiodoyextra').classList.remove('active');
            document.getElementById('MainContent_litabextra').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (!document.getElementById('litabpromocion').classList.contains('active')) {
            document.getElementById('tabpromociones').classList.add('in');
            document.getElementById('tabpromociones').classList.add('active');
            document.getElementById('litabpromocion').classList.add('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabcliente').classList.contains('active')) {
            document.getElementById('tabclientexs').classList.remove('in');
            document.getElementById('tabclientexs').classList.remove('active');
            document.getElementById('litabcliente').classList.remove('active');
        }
    }
    catch (ex) { }
}

function ActivaCliente() {
    try {
        if (document.getElementById('MainContent_litabcontado').classList.contains('active')) {
            document.getElementById('tabcontado').classList.remove('in');
            document.getElementById('tabcontado').classList.remove('active');
            document.getElementById('MainContent_litabcontado').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabcredito').classList.contains('active')) {
            document.getElementById('tabcredito').classList.remove('in');
            document.getElementById('tabcredito').classList.remove('active');
            document.getElementById('MainContent_litabcredito').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('MainContent_litabextra').classList.contains('active')) {
            document.getElementById('tabperiodoyextra').classList.remove('in');
            document.getElementById('tabperiodoyextra').classList.remove('active');
            document.getElementById('MainContent_litabextra').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (document.getElementById('litabpromocion').classList.contains('active')) {
            document.getElementById('tabpromociones').classList.remove('in');
            document.getElementById('tabpromociones').classList.remove('active');
            document.getElementById('litabpromocion').classList.remove('active');
        }
    }
    catch (ex) { }
    try {
        if (!document.getElementById('litabcliente').classList.contains('active')) {
            document.getElementById('tabclientexs').classList.add('in');
            document.getElementById('tabclientexs').classList.add('active');
            document.getElementById('litabcliente').classList.add('active');
        }
    }
    catch (ex) { }
}

