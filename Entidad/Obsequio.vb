Public Class Obsequio
    Inherits EntidadBase
    Public Property IdPromocion As Integer
    Public Property Descripcion As String
    Public Property Observacion As String
    Public Property MontoPorcentaje As Double
    Public Property TipoMontoPorcentaje As Integer
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime
    Public Property TipoPromocion As Integer
    Public Property IdEstado As Integer
    Public Property PrecioCero As Integer

    Public Property Clasificacion As Integer
    Public Property IdSubClasificacion As Integer
    Public Property AplicarRedondeo As Integer

    Public Property IdClasificacion As Integer
    Public Property TablaProducto As DataTable
    'Public Property TablaPromocionDetalle As DataTable
    'Public Property TablaPromocionDetalleObsequio As DataTable
    'Public Property TablaConsultaPromocionDetalle As DataTable

    'Public Property TablaSucursal As DataTable
    Public Property IdPromocionDetalle As Integer
    Public Property EstadoActualizar As Integer
    Public Property IndicadorConsulta As Integer
    Public Property IndicadorEstado As Integer
    Public Property Sucursal As Integer

    'TABLAS PARA GUARDAR
    Public Property TablaPromocionObsequioDetalle As DataTable
    Public Property TablaPromocionObsequioProducto As DataTable
    Public Property TablaObsequioDetalleCantidad As DataTable
    Public Property TablaRegistro As DataTable
    Public Property TablaRegistroObsequio As DataTable
    Public Property TablaProductoObsequio1 As DataTable

End Class
