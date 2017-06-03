Public Class TipoDocumento
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoDocumento As New Datos.TipoDocumento()
        DatosTipoDocumento.Consultar(EntidadTipoDocumento)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoDocumento1 As New Entidad.TipoDocumento()
        Dim DatosTipoDocumento As New Datos.TipoDocumento()
        EntidadTipoDocumento1 = EntidadTipoDocumento
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoDocumento1.Descripcion), "El Campo [Plazo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoDocumento1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoDocumento1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoDocumento1.FechaCreacion = Now
            EntidadTipoDocumento1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoDocumento1.FechaActualizacion = Now
            DatosTipoDocumento.InsertarActualizar(EntidadTipoDocumento1)
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
