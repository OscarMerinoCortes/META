Public Class TipoIdentificacion
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosIdentificaciones As New Datos.TipoIdentificacion()
        DatosIdentificaciones.Consultar(EntidadIdentificaciones)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadIdentificaciones1 As New Entidad.TipoIdentificacion()
        Dim DatosIdentificaciones As New Datos.TipoIdentificacion()
        EntidadIdentificaciones1 = EntidadIdentificaciones
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadIdentificaciones1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadIdentificaciones1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadIdentificaciones1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadIdentificaciones1.FechaCreacion = Now
            EntidadIdentificaciones1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadIdentificaciones1.FechaActualizacion = Now
            If EntidadIdentificaciones1.IdTipoIdentificacion = 0 Then
                DatosIdentificaciones.Insertar(EntidadIdentificaciones1)
            Else
                DatosIdentificaciones.Actualizar(EntidadIdentificaciones1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
