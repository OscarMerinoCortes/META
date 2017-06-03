var chartInstance = null;
var Titulos = { titulo1: "", titulo2: "", titulo3: "", titulo4: "", titulo5: "", titulo6: "" };
var TipoGraficas = {
    tipoGrafica1: "", mensajeOver1: "", tipoGrafica2: "", mensajeOver2: "",
    tipoGrafica3: "", mensajeOver3: "", tipoGrafica4: "", mensajeOver4: "",
    tipoGrafica5: "", mensajeOver5: "", tipoGrafica6: "", mensajeOver6: ""
}

function CargarGraficas(catalogo) {
    if (chartInstance != null) {
        chartInstance.destroy();
    }
    for (var opcion = 1; opcion <= 6; opcion++) {
       ObtenerDatos(opcion, catalogo);
    }
}

function ObtenerDatos(opcion, catalogo) {
    var direccion = "";
    switch (catalogo) {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            direccion = "Compras";
            TipoGraficas.tipoGrafica1 = "bar";
            TipoGraficas.tipoGrafica2 = "bar";
            TipoGraficas.tipoGrafica3 = "pie";
            TipoGraficas.tipoGrafica4 = "pie";
            TipoGraficas.tipoGrafica5 = "pie";
            TipoGraficas.mensajeOver1 = "Cantidad";
            TipoGraficas.mensajeOver2 = "Cantidad";
            TipoGraficas.mensajeOver3 = "Cantidad";
            TipoGraficas.mensajeOver4 = "Monto";
            TipoGraficas.mensajeOver5 = "Cantidad";
            Titulos.titulo1 = 'Cantidad de Compras por Mes';
            Titulos.titulo2 = 'Monto de Compras por Mes';
            Titulos.titulo3 = 'TOP(5) Compras por Proveedor del Mes';
            Titulos.titulo4 = 'Top(5) Compras por Producto del Mes';
            Titulos.titulo5 = 'TOP(5) Compras por Clasificacion del Mes';
            break;
        case 6:
            direccion = "Ventas";
            TipoGraficas.tipoGrafica1 = "bar";
            TipoGraficas.tipoGrafica2 = "bar";
            TipoGraficas.tipoGrafica3 = "pie";
            TipoGraficas.tipoGrafica4 = "pie";
            TipoGraficas.tipoGrafica5 = "pie";
            TipoGraficas.tipoGrafica6 = "pie";
            TipoGraficas.mensajeOver1 = "Cantidad";
            TipoGraficas.mensajeOver2 = "Cantidad";
            TipoGraficas.mensajeOver3 = "Cantidad";
            TipoGraficas.mensajeOver4 = "Monto";
            TipoGraficas.mensajeOver5 = "Cantidad";
            TipoGraficas.mensajeOver6 = "Cantidad";
            Titulos.titulo1 = 'Cantidad de Ventas por Mes';
            Titulos.titulo2 = 'Monto de Ventas del Mes';
            Titulos.titulo3 = 'TOP(5) Sucursales del Mes';
            Titulos.titulo4 = 'TOP(5) Vendedores por Mes';
            Titulos.titulo5 = 'TOP(5) Ventas por Clasificacion del Mes';
            Titulos.titulo6 = 'TOP(5) Ventas por Producto del Mes';
            break;
        case 7:
            direccion = "Caja";
            TipoGraficas.tipoGrafica1 = "bar";
            TipoGraficas.tipoGrafica2 = "bar";
            TipoGraficas.tipoGrafica3 = "bar";
            TipoGraficas.tipoGrafica4 = "pie";
            TipoGraficas.tipoGrafica5 = "bar";
            TipoGraficas.tipoGrafica6 = "pie";
            TipoGraficas.mensajeOver1 = "Cantidad";
            TipoGraficas.mensajeOver2 = "Monto [miles]";
            TipoGraficas.mensajeOver3 = "Monto [miles]";
            TipoGraficas.mensajeOver4 = "Cantidad";
            TipoGraficas.mensajeOver5 = "Monto [miles]";
            TipoGraficas.mensajeOver6 = "Cantidad [miles]";
            Titulos.titulo1 = 'Numero de Cuentas por Cobrar';
            Titulos.titulo2 = 'Monto de Cuentas por cobrar';
            Titulos.titulo3 = 'Estimados por mes';
            Titulos.titulo4 = 'Numero de cuentas por cobrar';
            Titulos.titulo5 = 'Cobrados por mes';
            Titulos.titulo6 = 'Saldo de Creditos';
        default:
            break;
    }
    direccion += ".aspx/Dashboard";
    $.ajax({
        //primero es atravez de ajax hacer una llamada al metodo GetChart
        type: "POST", //por post
        url: direccion, //este es el webmethod que esta en el .vb del aspx
        data: "{opcion: '" + opcion + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
        contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
        dataType: "json", // se especifica el tipo de dato devuelto
        success: function (r) { //si la operacion es exitosa
            GraficarTabla(r, opcion); //graficamos mandando el string con forma json que obtuvimos y la opcion para saber que tabla sigue
        },
        failure: function (response) {
            alert('Error al cargar la grafica');
        }
    });
}

function GraficarTabla(r, opcion) {
    var dats = eval(r.d); //el string obtenido lo convertimos en json
    var texto = []; //meses a mostrar en la tabla
    var valor = []; //sus respectivas cantidades
    var valor2 = []; //sus respectivas cantidades
    var valor3 = []; //sus respectivas cantidades
    var canvas;
    var colores = ["#407BC5", "#D24C1D", "#E9C215", "#3CDC6E", "#D13AD1", "#091230", "#470A46", "#695709", "#2F0F38", "#772177"];
    var myBarChart;
    //for (i = 0; i < 100; i++) {
    //    colores.push(getRandomColor());
    //}
    var option = {
        //opciones del chart pueden ser animaciones o acomodo cualquier cosa
        //pagina http://www.chartjs.org/docs/#chart-configuration-creating-a-chart-with-options
        animation: {
            duration: 500,
            animateScale: true
        },
        responsive: true,
        maintainAspectRatio: false,
        title: {
            display: true,
            text: 'Sin titulo'
        },
        legend: {
            display: true,
            position: "right",
            labels: {
                fontColor: '#2E2E2E'
            }
        }
    };
    var multipleColumna = true;
    for (var i in dats) { //recorremos el json para llenar los meses y sus respectivas cantidades
        var text = "";
        if (dats[i].text.length > 10) {
            var matrizText = dats[i].text.split(" ");
            if (matrizText.length > 1) {
                for (var j in matrizText) {
                    if (matrizText[j].length > 4) text += matrizText[j].substring(0, 4) + ". ";
                    else text += matrizText[j] + " ";
                }
                text = text.substring(0, text.length - 1);
            } else text += matrizText[0];
        }
        else
            text = dats[i].text; //obtener el mes de la variable text del json
        if (NoExisteTexto(text, texto))
            texto.push(text);
        if (dats[i].tipo == 1) { valor.push(dats[i].value);} 
        else if (dats[i].tipo == 2) {valor2.push(dats[i].value);}
        else{ valor3.push(dats[i].value);}
    }
    var data = {
        //se llenan los datos necesarios para el chart
        labels: texto, //esta linea lo que hace es poner debajo de la grafica su respectivo mes
        datasets: [//los datos
            {
                label: "", //Mensaje que se muestra al pasar el mouse por encima
                backgroundColor: colores, //Esta linea usa un metodo que genera aleatoreamente colores en hexa
                //backgroundColor: "#407BC5",
                hoverBackgroundColor: "#104577", //color al pasar el mouse por encima
                hoverBorderColor: "#104577", //color al pasar el mouse por encima
                borderWidth: 2,
                data: valor //este dato es el que se concatena mostrando por ejemplo cantidad : ##
            }
        ]
    };
    switch (opcion) {
        case 1:
            canvas = document.getElementById('dvGrafica1'); //localizamos y obtenemos el canvas donde se va a dibujar
            data.datasets[0].label = TipoGraficas.mensajeOver1; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica1; //Tipo de grafica que se va a crear
            option.title.text = Titulos.titulo1; //Titulo de la grafica
            option.legend.display = false; //Esto es para los cuadritos de interaccion
            //document.getElementById('spnGrafica1').classList.remove('hidden');
            break;
        case 2:
            canvas = document.getElementById('dvGrafica2');
            data.datasets[0].label = TipoGraficas.mensajeOver2; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica2; //Tipo de grafica que se va a crear
            option.legend.display = false;
            option.title.text = Titulos.titulo2;
            //document.getElementById('spnGrafica2').classList.remove('hidden');
            break;
        case 3:
            canvas = document.getElementById('dvGrafica3');
            data.datasets[0].label = TipoGraficas.mensajeOver3; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica3; //Tipo de grafica que se va a crear
            option.title.text = Titulos.titulo3;
            //document.getElementById('spnGrafica3').classList.remove('hidden');
            break;
        case 4:
            canvas = document.getElementById('dvGrafica4');
            data.datasets[0].label = TipoGraficas.mensajeOver4; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica4; //Tipo de grafica que se va a crear
            option.title.text = Titulos.titulo4;
            //document.getElementById('spnGrafica4').classList.remove('hidden');
            break;
        case 5:
            canvas = document.getElementById('dvGrafica5');
            data.datasets[0].label = TipoGraficas.mensajeOver5; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica5; //Tipo de grafica que se va a crear
            option.title.text = Titulos.titulo5;
            //document.getElementById('spnGrafica5').classList.remove('hidden');
            break;
        default:
            canvas = document.getElementById('dvGrafica6');
            data.datasets[0].label = TipoGraficas.mensajeOver6; //cuando se pasa el mouse por encima se muestra esto concatenado al data de abajo
            myBarChart = TipoGraficas.tipoGrafica6; //Tipo de grafica que se va a crear
            option.title.text = Titulos.titulo6;
            //document.getElementById('spnGrafica6').classList.remove('hidden');
            break;
    }
    if (valor2.length > 0) {
        myBarChart = "bar";
        option.legend.display = true;
        data.datasets[0].borderWidth = 1;
        data.datasets[0].backgroundColor = "rgba(64, 123, 197, 0.8)";
        data.datasets[0].hoverBackgroundColor = "rgba(64, 123, 197, 1)";
        data.datasets[0].hoverBorderColor = "rgba(64, 123, 197, 1)";
        data.datasets[0].label = "Credito";
        data.datasets.push({
            label: "Contado", //Mensaje que se muestra al pasar el mouse por encima
            backgroundColor: "rgba(210, 76, 29, 0.8)",
            hoverBackgroundColor: "rgba(210, 76, 29, 1)", //color al pasar el mouse por encima
            hoverBorderColor: "rgba(210, 76, 29, 1)", //color al pasar el mouse por encima
            borderWidth: 1,
            data: valor2 //este dato es el que se concatena mostrando por ejemplo cantidad : ##
        });
    }
    if (valor3.length > 0) {
        data.datasets.push({
            label: "Apartado", //Mensaje que se muestra al pasar el mouse por encima
            backgroundColor: "rgba(233, 194, 21, 0.8)",
            hoverBackgroundColor: "rgba(233, 194, 21, 1)", //color al pasar el mouse por encima
            hoverBorderColor: "rgba(233, 194, 21, 1)", //color al pasar el mouse por encima
            borderWidth: 1,
            data: valor3 //este dato es el que se concatena mostrando por ejemplo cantidad : ##
        });
    }
    if (myBarChart == "pie") {
        data.datasets[0].backgroundColor = colores;
    }
    else if (myBarChart == "bar") {
        data.datasets[0].backgroundColor = "#407BC5";
    } 
    //canvas.width = 300;
    //canvas.height = 150;
    //por ultimo se dibuja la grafica
    chartInstance = new Chart(canvas, {
        type: myBarChart,
        data: data,
        options: option
    });
}


function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    color += letters[Math.floor(Math.random() * 10)];
    for (var i = 0; i < 5; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
function NoExisteTexto(text, texto) {
    for (var i in texto) {
        if (texto[i] == text) return false;
    }
    return true;
}