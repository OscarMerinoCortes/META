Public Class TipoSolicitudEstado
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoSolicitudEstado As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoSolicitudEstado As New Datos.TipoSolicitudEstado()
        DatosTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoSolicitudEstado As Entidad.EntidadBase) Implements ICatalogo.Guardar
        'Dim EntidadTipoSolicitudEstado1 As New Entidad.TipoSolicitudEstado()
        'Dim DatosTipoSolicitudEstado As New Datos.TipoSolicitudEstado()
        'EntidadTipoSolicitudEstado1 = EntidadTipoSolicitudEstado
        'Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadTipoSolicitudEstado1.Plazo), "El Campo [Plazo] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadTipoSolicitudEstado1.IdEstado), "El Campo [Estado] esta Vacio")
        'If Not Vacio(DSResRul) Then
        '    Exit Sub
        'Else
        '    EntidadTipoSolicitudEstado1.idUsuarioCreacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoSolicitudEstado1.FechaCreacion = Now
        '    EntidadTipoSolicitudEstado1.idUsuarioActualizacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoSolicitudEstado1.FechaActualizacion = Now

        '    If EntidadTipoSolicitudEstado1.IdTipoSolicitudEstado = 0 Then
        '        DatosTipoSolicitudEstado.Insertar(EntidadTipoSolicitudEstado1)
        '    Else
        '        DatosTipoSolicitudEstado.Actualizar(EntidadTipoSolicitudEstado1)
        '    End If
        'End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
