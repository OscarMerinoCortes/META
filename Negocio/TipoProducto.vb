Public Class TipoProducto
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoProducto As New Datos.TipoProducto()
        DatosTipoProducto.Consultar(EntidadTipoProducto)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosTipoProducto As New Datos.TipoProducto()
        Dim EntidadTipoProducto1 As New Entidad.TipoProducto()
        EntidadTipoProducto1 = EntidadTipoProducto
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoProducto1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoProducto1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoProducto1.IdUsuarioCreacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioCreacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadTipoProducto1.FechaCreacion = Now
            EntidadTipoProducto1.IdUsuarioActualizacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioActualizacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadTipoProducto1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadTipoProducto1.IdTipoProducto), "El Campo [ID] esta Vacio")
            If EntidadTipoProducto1.IdTipoProducto = 0 Then
                DatosTipoProducto.Insertar(EntidadTipoProducto1)
            Else
                DatosTipoProducto.Actualizar(EntidadTipoProducto1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
