Public Class TipoMedio
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoMedio As New Datos.TipoMedio()
        DatosTipoMedio.Consultar(EntidadTipoMedio)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoMedio1 As New Entidad.TipoMedio()
        Dim DatosTipoMedio As New Datos.TipoMedio()
        EntidadTipoMedio1 = EntidadTipoMedio
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoMedio1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoMedio1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoMedio1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoMedio1.FechaCreacion = Now
            EntidadTipoMedio1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoMedio1.FechaActualizacion = Now
            If EntidadTipoMedio1.IdTipoMedio = 0 Then
                DatosTipoMedio.Insertar(EntidadTipoMedio1)
            Else
                DatosTipoMedio.Actualizar(EntidadTipoMedio1)
            End If

        End If
    End Sub
    Public Sub Obtener(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
