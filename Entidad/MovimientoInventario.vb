Public Class MovimientoInventario
    Inherits EntidadBase
    Public Property IdMovimientoInventario As Integer
    Public Property Fecha As Date
    Public Property Observacion As String
    Public Property IdEstado As Integer
    Public Property IdSucursalOrigen As Integer
    Public Property IdSucursalDestino As Integer
    Public Property IdAlmacenOrigen As Integer
    Public Property IdAlmacenDestino As Integer
    Public Property IdTipo As Integer
    Public Property IdSubTipo As Integer
    Public Property IdProducto As Integer
    Public Property Cantidad As Integer
    Public Property TablaMovimientoDetalle As DataTable
    Public Property TablaPendientes As DataTable
    Public Property TablaPendientes2 As DataTable
    'Variables para seguimiento de Traspaso y Envio
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
    Public Property validar As Boolean
    Public Property Estatus As Integer
    'Tablas para las graficas
    Public Property TablaCantidadPorSucursal As DataTable
    Public Property TablaMontoPorSucursal As DataTable
    Public Property TablaExistenciaPorAlmacen As DataTable
    Public Property TablaExcedentes As DataTable
    Public Property TablaFaltantes As DataTable
End Class
