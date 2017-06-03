Public Class RegistroInventario
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosRegistroInventario As New Datos.RegistroInventario()
        DatosRegistroInventario.Consultar(EntidadRegistroInventario)
    End Sub

    Public Sub Guardar(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        Dim DatosRegistroInventario As New Datos.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadRegistroInventario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadRegistroInventario1.idUsuarioCreacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioCreacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaCreacion = Now
            EntidadRegistroInventario1.idUsuarioActualizacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioActualizacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaActualizacion = Now
            If EntidadRegistroInventario1.IdInventario = 0 Then
                DatosRegistroInventario.Insertar(EntidadRegistroInventario1)
            Else
                DatosRegistroInventario.Actualizar(EntidadRegistroInventario1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosRegistroInventario As New Datos.RegistroInventario()
        DatosRegistroInventario.Obtener(EntidadRegistroInventario)
    End Sub
    Public Sub Aplicar(ByRef EntidadRegistroInventario As Entidad.EntidadBase)
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        Dim DatosRegistroInventario As New Datos.RegistroInventario()
        Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadRegistroInventario1.IdAlmacen), "El Campo [Almacen] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadRegistroInventario1 = EntidadRegistroInventario
            EntidadRegistroInventario1.idUsuarioCreacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioCreacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaCreacion = Now
            EntidadRegistroInventario1.idUsuarioActualizacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioActualizacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaActualizacion = Now
            DatosRegistroInventario.Aplicar(EntidadRegistroInventario1)
        End If
    End Sub
    Public Sub Cancelar(ByRef EntidadRegistroInventario As Entidad.EntidadBase)
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        Dim DatosRegistroInventario As New Datos.RegistroInventario()
        Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadRegistroInventario1.IdAlmacen), "El Campo [Almacen] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadRegistroInventario1 = EntidadRegistroInventario
            EntidadRegistroInventario1.idUsuarioCreacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioCreacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaCreacion = Now
            EntidadRegistroInventario1.idUsuarioActualizacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioActualizacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadRegistroInventario1.FechaActualizacion = Now
            DatosRegistroInventario.Cancelar(EntidadRegistroInventario1)
        End If
    End Sub
End Class
