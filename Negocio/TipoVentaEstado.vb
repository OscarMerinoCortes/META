Public Class TipoVentaEstado
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoVentaEstado As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoVentaEstado As New Datos.TipoVentaEstado()
        DatosTipoVentaEstado.Consultar(EntidadTipoVentaEstado)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoVentaEstado As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoVentaEstado1 As New Entidad.TipoVentaEstado()
        Dim DatosTipoVentaEstado As New Datos.TipoVentaEstado()
        EntidadTipoVentaEstado1 = EntidadTipoVentaEstado
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoVentaEstado1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoVentaEstado1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoVentaEstado1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoVentaEstado1.FechaCreacion = Now
            EntidadTipoVentaEstado1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoVentaEstado1.FechaActualizacion = Now

            If EntidadTipoVentaEstado1.IdTipoVentaEstado = 0 Then
                DatosTipoVentaEstado.Insertar(EntidadTipoVentaEstado1)
            Else
                DatosTipoVentaEstado.Actualizar(EntidadTipoVentaEstado1)
            End If
        End If
    End Sub



    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
