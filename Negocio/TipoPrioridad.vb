Public Class TipoPrioridad
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoPrioridad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoPrioridad As New Datos.TipoPrioridad()
        DatosTipoPrioridad.Consultar(EntidadTipoPrioridad)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoPrioridad As Entidad.EntidadBase) Implements ICatalogo.Guardar
        'Dim EntidadTipoPrioridad1 As New Entidad.TipoPrioridad()
        'Dim DatosTipoPrioridad As New Datos.TipoPrioridad()
        'EntidadTipoPrioridad1 = EntidadTipoPrioridad
        'Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadTipoPrioridad1.Plazo), "El Campo [Plazo] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadTipoPrioridad1.IdEstado), "El Campo [Estado] esta Vacio")
        'If Not Vacio(DSResRul) Then
        '    Exit Sub
        'Else
        '    EntidadTipoPrioridad1.idUsuarioCreacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoPrioridad1.FechaCreacion = Now
        '    EntidadTipoPrioridad1.idUsuarioActualizacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoPrioridad1.FechaActualizacion = Now

        '    If EntidadTipoPrioridad1.IdTipoPrioridad = 0 Then
        '        DatosTipoPrioridad.Insertar(EntidadTipoPrioridad1)
        '    Else
        '        DatosTipoPrioridad.Actualizar(EntidadTipoPrioridad1)
        '    End If
        'End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
