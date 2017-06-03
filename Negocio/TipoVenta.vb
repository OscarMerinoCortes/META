Public Class TipoVenta
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoVenta As New Datos.TipoVenta()
        DatosTipoVenta.Consultar(EntidadTipoVenta)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoVenta As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoVenta1 As New Entidad.TipoVenta()
        Dim DatosTipoVenta As New Datos.TipoVenta()
        EntidadTipoVenta1 = EntidadTipoVenta
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoVenta1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoVenta1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoVenta1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoVenta1.FechaCreacion = Now
            EntidadTipoVenta1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoVenta1.FechaActualizacion = Now

            If EntidadTipoVenta1.IdTipoVenta = 0 Then
                DatosTipoVenta.Insertar(EntidadTipoVenta1)
            Else
                DatosTipoVenta.Actualizar(EntidadTipoVenta1)
            End If
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
