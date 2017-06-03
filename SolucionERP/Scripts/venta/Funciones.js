var meses = new Array("ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC");
var diasSemana = new Array("Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado");
    function show5() {
        if (!document.layers && !document.all && !document.getElementById)
            return;

        var Digital = new Date();
        var hours = Digital.getHours();
        var minutes = Digital.getMinutes();
        var seconds = Digital.getSeconds();
        var dia = diasSemana[Digital.getDay()];
        var dia2 = Digital.getDate();
        var mes = meses[Digital.getMonth()];
        var año = Digital.getFullYear();
        var dn = "PM";
        if (hours < 12)
            dn = "AM";
        if (hours > 12)
            hours = hours - 12;
        if (hours == 0)
            hours = 12;
        if (minutes <= 9)
            minutes = "0" + minutes;
        if (seconds <= 9)
            seconds = "0" + seconds;
        if (document.getElementById('TBLFechaVenta'))
            document.getElementById('TBLFechaVenta').innerHTML = dia + ", " + dia2 + "-" + mes + "-" + año + " " + hours + ":" + minutes + ":" + seconds + " " + dn;
        setTimeout("show5()", 1000);
    }
window.onload = show5;

function Alternar(elemento) {
    try {

        if (CurrentlyInFullScreen()) //Si estamos en pantalla completa
        {
            //Vemos qu� elemento est� en pantalla completa (deber�a ser el mismo que se le pasa)
            var eltoFS = getCurrentElementInFullScreen();
            //alert(eltoFS == elemento); //indicamos si es as� o no
            //salimos de pantalla completa
            document.getElementById('imgFullscreen').src = "../../../Imagenes/Venta/fullscreen_enter.png";
            FuncionF1();
            ExitFullScreenMode();
        } else //Si no est� a pantalla completa
        {
            document.getElementById('imgFullscreen').src = "../../../Imagenes/Venta/fullscreen_exit.png";
            FuncionF1();
            console.log(SetFullScreen(elemento));
        }
    } catch (ex) {
        //alert(ex.message);
    }
}

function QuitarFocoTodo() {
    if (document.getElementById("MainContent_TBXCodigo")) {
        document.getElementById("MainContent_TBXCodigo").blur();
    }

    
}

$(document).bind('keydown', '', function (evt) {
    //alert(evt.keyCode);
    var key = evt.keyCode;
    if ((key > 111 && key < 124) || key == 17) {
        QuitarFocoTodo();
        switch (key) {
            case 112:
                FuncionF1();
                break;
            case 113:
                FuncionF2();
                break;
            case 114:
                FuncionF3();
                break;
            case 115:
                FuncionF4();
                break;
            case 116:
                FuncionF5();
                break;
            case 117:
                FuncionF6();
                break;
            case 118:
                FuncionF7();
                break;
            case 119:
                FuncionF8();
                break;
            case 121:
                FuncionF10();
                break;
            case 122:
                FuncionF11();
                break;
            default:
        }
        return false;
    }
    return true;
});

$(document).bind('keypress', 'ctrl+s', function (evt) {
    //guardaTexto();
    alert("FUNCION CTROL+S");
    return false;
});

$(document).bind('keydown', 'ctrl+b', function (evt) {
    //guardaTexto();
    FuncionCtrlB();
    return false;
});

function ComprobarPantalla() {
    try {

        if (CurrentlyInFullScreen()) //Si estamos en pantalla completa
        {
            //Vemos qu� elemento est� en pantalla completa (deber�a ser el mismo que se le pasa)
            var eltoFS = getCurrentElementInFullScreen();
            //alert(eltoFS == elemento); //indicamos si es as� o no
            //salimos de pantalla completa
            document.getElementById('imgFullscreen').src = "../../../Imagenes/Venta/fullscreen_exit.png";
            FuncionF1();
        } else //Si no est� a pantalla completa
        {
            document.getElementById('imgFullscreen').src = "../../../Imagenes/Venta/fullscreen_enter.png";
            FuncionF1();
        }
    } catch (ex) {
        alert(ex.message);
    }
}

function FuncionF1() {
    if (document.getElementById("MainContent_TBXCodigo")) {
        document.getElementById("MainContent_TBXCodigo").focus();
    }
}

function FuncionF2() {
    if (document.getElementById("MainContent_GVVentaDetalle")) {
        $('#MainContent_GVVentaDetalle').find('td:eq(2)').focus();
    }
}

function FuncionF3() {
    
}

function FuncionF4() {
}

function FuncionF5() {
    if (document.getElementById('MainContent_litabcontado')) {
        if (document.getElementById("MainContent_CBPLPlazoContado")) {
            ActivaContado();
            var dropdown = document.getElementById('MainContent_CBPLPlazoContado');
            var event = document.createEvent('MouseEvents');
            event.initMouseEvent('mousedown', true, true, window);
            dropdown.dispatchEvent(event);
        }
    }
}

function FuncionF6() {
    if (document.getElementById('MainContent_litabcredito')) {
        ActivaCredito();
        if (document.getElementById("MainContent_CBPLPlazoCredito")) {
            var dropdown = document.getElementById('MainContent_CBPLPlazoCredito');
            var event = document.createEvent('MouseEvents');
            event.initMouseEvent('mousedown', true, true, window);
            dropdown.dispatchEvent(event);
        }
    }
}

function FuncionF7() {
    if (document.getElementById('litabpromocion')) {
        ActivaPromocion();
        //if (document.getElementById("MainContent_CBPLPlazoCredito")) {
        //    var dropdown = document.getElementById('MainContent_CBPLPlazoCredito');
        //    var event = document.createEvent('MouseEvents');
        //    event.initMouseEvent('mousedown', true, true, window);
        //    dropdown.dispatchEvent(event);
        //}
    }
}

function FuncionF8() {
    var ancho = $(window).width();
    //if (ancho <= 1200) {
    if (document.getElementById('tabcliente')) {
        if (document.getElementById('tabcliente').classList.contains('active')) {
            if (document.getElementById("MainContent_IBTNBuscarPersona")) {
                document.getElementById("MainContent_IBTNBuscarPersona").click();
            }
        } //else {
        //    ActivaCliente();
        //}
        //}
        //else {
        //    if (document.getElementById("MainContent_IBTNBuscarPersona")) {
        //        document.getElementById("MainContent_IBTNBuscarPersona").click();
        //    }
        //}
    }

    if (document.getElementById('tabaval')) {
        if (document.getElementById('tabaval').classList.contains('active')) {
            if (document.getElementById("MainContent_IBTNABuscarPersona")) {
                document.getElementById("MainContent_IBTNABuscarPersona").click();
            }
        }
    }
}

function FuncionF10() {
    if (document.getElementById("MainContent_BTNVNuevo")) {
        document.getElementById("MainContent_BTNVNuevo").click();
    }
}

function FuncionF11() {

}

function FuncionCtrlB() {
    if (document.getElementById("MainContent_BTNVBuscar")) {
        document.getElementById("MainContent_BTNVBuscar").click();
    }
}

function CambiarVenta() {
    if (document.getElementById("MainContent_BTNCambiarVenta")) {
        document.getElementById("MainContent_BTNCambiarVenta").click();
    }
}