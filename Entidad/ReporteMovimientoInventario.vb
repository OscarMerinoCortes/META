Public Class ReporteMovimientoInventario
    Inherits EntidadBase
    Public Property IdMovimiento As Integer
    Public Property IdSucursalOrigen As Integer
    Public Property IdAlmacenOrigen As Integer
    Public Property IdSucursalDestino As Integer
    Public Property IdAlmacenDestino As Integer
    Public Property IdTipoMovimiento As Integer
    Public Property IdSubTipoMovimiento As Integer
    Public Property IdEstado As Integer
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime
End Class
