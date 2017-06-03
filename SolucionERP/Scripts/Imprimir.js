function doPrint() {
    if (window.print)
        window.print();
    else
        alert("Lo siento, pero a tu navegador no se le puede ordenar imprimir" +
          " desde la web. Actualizate o hazlo desde los menús");

}

function abrirImprimir() {
    try {
        //alert("Ruta.aspx");
        window.open("../../../Imprimir/Imprimir.aspx", '_newtab');
    } catch (e) {
        alert(e.message);
    } 
    //if (window.print)
    //    window.print();
    //else
    //    alert("Lo siento, pero a tu navegador no se le puede ordenar imprimir" +
    //      " desde la web. Actualizate o hazlo desde los menús");
}
