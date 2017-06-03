Public Class RegistroInventario
    Inherits EntidadBase
    Public Property IdInventario As Integer
    Public Property Descripcion As String
    Public Property Observaciones As String
    Public Property IdEstado As Integer
    Public Property IdSucursal As Integer
    Public Property IdAlmacen As Integer
    Public Property IdClasificacion As Integer
    Public Property IdSubClasificacion As Integer
    ''Para guardar informacion de inventario Detalle
    Public Property idAplicar As Integer
    Public Property IdInventarioAplicar As Integer
    Public Property TablaInventarioDetalle As DataTable
    Public Property IdProducto As Integer
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
End Class
