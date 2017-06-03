Public Class CCP
    Inherits EntidadBase
    Public Property IdCaja As Integer
    Public Property Recibo As Integer
    'Public Property IdPersona As Integer
    Public Property PagoAbono As Double
    Public Property IdFormaPago As Integer
    Public Property Descuento As Double
    Public Property Porcentaje As Integer
    'Public Property Observacion As String
    Public Property FechaActual As DateTime
    Public Property IdVenta As Integer
    Public Property IdFormaPagoDetalle As Integer
    Public Property DolarDiario As Double
    Public Property NumeroVale As String
    Public Property IdBanco As Integer
    Public Property Referencia As String
    Public Property TablaAbonoCaja As DataTable
    Public Property TablaVentaCaja As DataTable
    Public Property TablaHistorialCaja As DataTable
    Public Property TablaFormaPagoDetalleCaja As DataTable
    Public Property TablaProyeccionLiquidacionCaja As DataTable
    'Public Property IdEstado As Integer
    'CCP encabezado
    Public Property IdCCP As Integer
    Public Property IdTipoDocumento As Integer
    Public Property Serie As String
    Public Property Folio As String
    Public Property IdPersona As Integer
    Public Property FechaExpedicion As DateTime
    Public Property FechaVencimiento As DateTime
    Public Property Descripcion As String
    Public Property Observacion As String
    Public Property Monto As Integer
    Public Property IVA As Integer
    Public Property IEPS As Integer
    Public Property Subtotal As Integer
    Public Property IdTipoCCP As Integer
    Public Property IdEstado As Integer
    'CCP movimiento
    Public Property IdCCPMovimiento As Integer
    Public Property IdCajaMovimiento As Integer
    Public Property Impuesto As Integer
    Public Property MontoTransaccion As Integer
    Public Property IdSucursal As Integer
    Public Property IdTransaccion As Integer
    Public Property TablaMovimientos As DataTable
    'COMPRA
    Public Property IdCompra As Integer

End Class
