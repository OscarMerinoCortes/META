Public Class Producto
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.Consultar(EntidadProducto)
    End Sub
    Public Sub ObtenerPerfil(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.ObtenerPerfil(EntidadProducto)
    End Sub
    Public Sub ObtenerPerfilWuc(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.ObtenerPerfilWuc(EntidadProducto)
    End Sub
    Public Sub WucEstadisticaVenta(ByRef EntidadVenta As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Producto()
        DatosVenta.WucEstadistica(EntidadVenta)
    End Sub
    Public Sub WucBusquedaProductoEstadisticas(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Producto()
        DatosVenta.WucBusquedaProductoEstadisticas(EntidadProducto)
    End Sub
    Public Sub Guardar(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadProducto1 As New Entidad.Producto()
        Dim DatosProducto As New Datos.Producto()
        EntidadProducto1 = EntidadProducto
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadProducto1.IdProductoCorto), "El Campo [ID Producto Corto] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProducto1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProducto1.IdTipo), "El Campo [Tipo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProducto1.IdUnidad), "El Campo [Unidad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProducto1.IdSubclasificacion), "El Campo [Subclasificacion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProducto1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadProducto1.idUsuarioCreacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioCreacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadProducto1.FechaCreacion = Now
            EntidadProducto1.idUsuarioActualizacion = 1
            'EntidadProducto1.Tarjeta.IdUsuario
            'EntidadProducto1.UsuarioActualizacion = EntidadProducto1.Tarjeta.Username.ToUpper()
            EntidadProducto1.FechaActualizacion = Now
            If EntidadProducto1.IdProducto = 0 Then
                DatosProducto.Insertar(EntidadProducto1)
            Else
                DatosProducto.Actualizar(EntidadProducto1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.Obtener(EntidadProducto)
    End Sub
    Public Sub VentaObtener(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.VentaObtener(EntidadProducto)
    End Sub
    Public Sub ReporteProducto(ByRef EntidadReporteProducto As Entidad.ReporteProducto)
        Dim DatosReporteProducto As New Datos.Producto()
        DatosReporteProducto.ReporteProducto(EntidadReporteProducto)
    End Sub
    Public Sub PerfilProducto(ByRef EntidadPerfilProducto As Entidad.EntidadBase)

    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim DatosProducto As New Datos.Producto()
        DatosProducto.ObtenerFiltro(EntidadProducto)
    End Sub

End Class
