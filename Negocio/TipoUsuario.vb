Public Class TipoUsuario
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoUsuario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoUsuario As New Datos.TipoUsuario()
        DatosTipoUsuario.Consultar(EntidadTipoUsuario)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoUsuario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosTipoUsuario As New Datos.TipoUsuario()
        Dim EntidadTipoUsuario1 As New Entidad.TipoUsuario()
        EntidadTipoUsuario1 = EntidadTipoUsuario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoUsuario1.TipoUsuario), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoUsuario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoUsuario1.idUsuarioCreacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioCreacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadTipoUsuario1.FechaCreacion = Now
            EntidadTipoUsuario1.idUsuarioActualizacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioActualizacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadTipoUsuario1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadTipoUsuario1.IdTipoUsuario), "El Campo [ID] esta Vacio")
            If EntidadTipoUsuario1.IdTipoUsuario = 0 Then
                DatosTipoUsuario.Insertar(EntidadTipoUsuario1)
            Else
                DatosTipoUsuario.Actualizar(EntidadTipoUsuario1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class