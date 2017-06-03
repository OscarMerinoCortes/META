Public Class Producto
    Inherits EntidadBase
    Public Property IdProducto As Integer
    Public Property IdProductoCorto As String
    Public Property Descripcion As String
    Public Property IdTipo As Integer
    Public Property IdUnidad As Integer
    Public Property IdClasificacion As Integer
    Public Property IdSubclasificacion As Integer
    Public Property VentaPrecioCero As Integer
    Public Property VentaExistenciaCero As Integer
    Public Property AfectaInventario As Integer
    Public Property PrecioBase As Double
    Public Property Ganancia As Double
    Public Property Porcentaje As Integer
    Public Property Proveedor As Integer
    Public Property IdEstado As Integer
    Public Property Cantidad As Integer
    Public Property IdSucursal As Integer
    Public Property IdAlmacen As Integer
    Public Property Almacen As String
    Public Property TablaCodigoBarra As DataTable
    Public Property TablaMaximoMinimo As DataTable
    Public Property TablaPrecio As DataTable
    Public Property TablaProveedor As DataTable
    Public Property Clasificacion As String
    Public Property Subclasificacion As String
    Public Property PrecioUltimaEntrada As Double
    Public Property IVA As Integer
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
End Class
