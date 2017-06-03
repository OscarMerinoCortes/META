Public Interface IProductos
    Function Consultar(ByRef EntidadBase As Entidad.Producto) As DataTable
    Function Insertar(ByRef EntidadBase As Entidad.Producto) As Integer
    Sub Actualizar(ByRef EntidadBase As Entidad.Producto)
    Function Obtener(ByRef EntidadBase As Entidad.Producto) As DataTable
    Function ObtenerTablas(ByRef EntidadBase As Entidad.Producto) As DataTable
    Function ReporteProducto(ByRef EntidadBase As Entidad.Producto) As DataTable
End Interface
