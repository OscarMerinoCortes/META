Public Class TipoCargo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoCargo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoCargo As New Datos.TipoCargo()
        DatosTipoCargo.Consultar(EntidadTipoCargo)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoCargo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        'Dim EntidadTipoCargo1 As New Entidad.TipoCargo()
        'Dim DatosTipoCargo As New Datos.TipoCargo()
        'EntidadTipoCargo1 = EntidadTipoCargo
        'Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadTipoCargo1.Plazo), "El Campo [Plazo] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadTipoCargo1.IdEstado), "El Campo [Estado] esta Vacio")
        'If Not Vacio(DSResRul) Then
        '    Exit Sub
        'Else
        '    EntidadTipoCargo1.idUsuarioCreacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoCargo1.FechaCreacion = Now
        '    EntidadTipoCargo1.idUsuarioActualizacion = 1
        '    'EntidadTipoDomicilio1.Tarjeta.IdUsuario
        '    'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
        '    EntidadTipoCargo1.FechaActualizacion = Now

        '    If EntidadTipoCargo1.IdTipoCargo = 0 Then
        '        DatosTipoCargo.Insertar(EntidadTipoCargo1)
        '    Else
        '        DatosTipoCargo.Actualizar(EntidadTipoCargo1)
        '    End If
        'End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
