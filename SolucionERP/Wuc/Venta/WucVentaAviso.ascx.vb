Imports System.Collections.ObjectModel
Imports System.Data
Imports Entidad
Imports Operacion.Configuracion.Constante

Partial Class WucVentaAviso
    Inherits UserControl
    Public Event Cancelado As EventHandler
    Public Event Pendiente As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub

    Public Sub MostrarAviso(titulo As String, detalle As String, tipoAviso As TipoAviso)
        LBTitulo.Text = titulo
        LBDetalle.Text = detalle
        BTNVPendiente.Visible = False
        If tipoAviso = TipoAviso.Advertencia Then
            IMImagen.ImageUrl() = "~/Imagenes/IMVentaAviso.png"
            BTNVPendiente.Visible = True
        ElseIf tipoAviso = TipoAviso.Errorr Then
            IMImagen.ImageUrl() = "~/Imagenes/IMVentaError.png"
        ElseIf tipoAviso = TipoAviso.Guardar Then
            IMImagen.ImageUrl() = "~/Imagenes/IMVentaCompleta.png"
        ElseIf tipoAviso = tipoAviso.Aviso Then
            IMImagen.ImageUrl() = "~/Imagenes/IMVentaAviso.png"
        End If
    End Sub

    Protected Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNVCancelar.Click
        RaiseEvent Cancelado(New Object, New EventArgs)
    End Sub

    Protected Sub BTNPendiente_Click(sender As Object, e As EventArgs) Handles BTNVPendiente.Click
        RaiseEvent Pendiente(New Object, New EventArgs)
    End Sub

    Protected Sub BTNQuitarProducto_OnClick(sender As Object, e As EventArgs)

    End Sub
End Class

Public Enum TipoAviso
    Advertencia = 1
    Errorr = 2
    Aviso = 3
    Guardar = 4
End Enum
