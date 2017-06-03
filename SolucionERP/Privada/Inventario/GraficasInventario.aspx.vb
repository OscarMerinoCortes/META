Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Tarjeta As New Entidad.Tarjeta()
        Tarjeta = Session("Tarjeta")
        'Tarjeta.IdTransaccion = Operacion.Configuracion.Constante.Transaccion.VisualizarGraficosInformativosModuloCredito
        'Tarjeta.IdOpcion = Operacion.Configuracion.Constante.Opcion.MenuNingunoCredito
        'Tarjeta.IdModulo = Operacion.Configuracion.Constante.Modulo.Credito
        Session("Tarjeta") = Tarjeta
    End Sub     
End Class