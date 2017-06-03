Public Class Promocion
    Inherits EntidadBase
    Public Property IdPromocion As Integer
    Public Property Descripcion As String
    Public Property Gracia As Integer
    Public Property TipoGracia As Integer
    Public Property Extra As Integer
    Public Property TipoExtra As Integer
    Public Property Descuento As Double
    Public Property TipoDescuento As Integer
    Public Property Observacion As String
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime
    Public Property TipoPromocion As Integer
    Public Property IdEstado As Integer

    Public Property Clasificacion As Integer
    Public Property IdSubClasificacion As Integer

    Public Property IdClasificacion As Integer
    Public Property TablaProducto As DataTable
    Public Property TablaPromocionDetalle As DataTable
    Public Property TablaPromocionDetalleObsequio As DataTable
    Public Property TablaConsultaPromocionDetalle As DataTable
    Public Property TablaSucursal As DataTable
    Public Property IdPromocionDetalle As Integer
    Public Property EstadoActualizar As Integer
    Public Property IndicadorEstado As Integer
    Public Property IndicadorConsulta As Integer
    Public Property IdSucursal As Integer
End Class
