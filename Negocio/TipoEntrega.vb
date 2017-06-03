Public Class TipoEntrega
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoEntrega As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoEntrega As New Datos.TipoEntrega()
        DatosTipoEntrega.Consultar(EntidadTipoEntrega)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoEntrega As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoEntrega1 As New Entidad.TipoEntrega()
        Dim DatosTipoEntrega As New Datos.TipoEntrega()
        EntidadTipoEntrega1 = EntidadTipoEntrega
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoEntrega1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoEntrega1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoEntrega1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoEntrega1.FechaCreacion = Now
            EntidadTipoEntrega1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoEntrega1.FechaActualizacion = Now
            If EntidadTipoEntrega1.IdTipoEntrega = 0 Then
                DatosTipoEntrega.Insertar(EntidadTipoEntrega1)
            Else
                DatosTipoEntrega.Actualizar(EntidadTipoEntrega1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
