
Partial Class Wuc_WUCDatosAuditoria
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Public Sub SeleccionarIndice(ByVal EntIdad As Object)
        If TypeOf EntIdad Is System.Data.DataRow Then
            HFidUsuarioCreacion.Value = UCase(EntIdad.Item("IdUsuarioCreacion"))
            LBidUsuarioCreacion.Text = UCase(EntIdad.Item("UsuarioCreacion"))
            LAFechaCreacion.Text = EntIdad.Item("FechaCreacion")
            LBidUsuarioActualizacion.Text = UCase(EntIdad.Item("UsuarioActualizacion"))
            HFIdUsuarioActualizacion.Value = UCase(EntIdad.Item("IdUsuarioActualizacion"))
            LAFechaActualizacion.Text = EntIdad.Item("FechaActualizacion")
        Else
            HFIdUsuarioCreacion.Value = EntIdad.IdUsuarioCreacion
            LBIdUsuarioCreacion.Text = UCase(EntIdad.UsuarioCreacion)
            LAFechaCreacion.Text = EntIdad.FechaCreacion
            LBIdUsuarioActualizacion.Text = UCase(EntIdad.UsuarioActualizacion)
            HFIdUsuarioActualizacion.Value = EntIdad.IdUsuarioActualizacion
            LAFechaActualizacion.Text = EntIdad.FechaActualizacion
        End If

    End Sub
    Public Sub Actualizar(ByVal EntIdad As Object)
        LBIdUsuarioActualizacion.Text = UCase(EntIdad.Tarjeta.UserName)
        HFIdUsuarioActualizacion.Value = UCase(EntIdad.Tarjeta.IdUsuario)
        LAFechaActualizacion.Text = EntIdad.FechaActualizacion
    End Sub
    Public Sub Guardar(ByVal EntIdad As Object)
        LBIdUsuarioCreacion.Text = EntIdad.IdUsuarioCreacion
        HFIdUsuarioCreacion.Value = UCase(EntIdad.Tarjeta.IdUsuario)
        LAFechaCreacion.Text = EntIdad.FechaCreacion
        LBIdUsuarioActualizacion.Text = EntIdad.IdUsuarioActualizacion
        HFIdUsuarioActualizacion.Value = UCase(EntIdad.Tarjeta.IdUsuario)
        LAFechaActualizacion.Text = EntIdad.FechaActualizacion
    End Sub
    Public Sub Nuevo()
        LAFechaCreacion.Text = ""
        LAFechaActualizacion.Text = ""
        LBidUsuarioActualizacion.Text = ""
        LBidUsuarioCreacion.Text = ""
    End Sub

    'Protected Sub LBIdUsuarioCreacion_Click(sender As Object, e As EventArgs) Handles LBIdUsuarioCreacion.Click
    '    wucUsuarioResumen1.Obtener(HFIdUsuarioCreacion.Value)
    '    MPEUsuarioResumen.Show()
    'End Sub

    'Protected Sub LBIdUsuarioActualizacion_Click(sender As Object, e As EventArgs) Handles LBIdUsuarioActualizacion.Click
    '    wucUsuarioResumen1.Obtener(HFIdUsuarioActualizacion.Value)
    '    MPEUsuarioResumen.Show()
    'End Sub

    'Public Function NombreUsuarioCreacion() As String
    '    Return LBIdUsuarioCreacion.Text
    'End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
