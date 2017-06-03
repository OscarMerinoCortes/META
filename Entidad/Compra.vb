Public Class Compra
    Inherits EntidadBase
    Public Property IdCompra As Integer
    Public Property Observacion As String
    Public Property IdTipoDocumento As Integer
    Public Property Folio As String
    Public Property FechaDocumento As Date
    Public Property IdFormaPago As Integer
    Public Property IdPersona As Integer
    Public Property IdEstado As Integer
    Public Property TablaCompraDetalle As DataTable
    Public Property TablaOrdenDetalle As DataTable
    Public Property TablaProducto As DataTable
    Public Property TablaProductoPrecio As DataTable

    Public Property Monto As Decimal
    Public Property IVA As Decimal
    Public Property SubTotal As Decimal
    Public Property Cargo As Decimal
    Public Property Anticipo As Decimal
    Public Property Total As Decimal
    Public Property Serie As String
    Public Property TipoCompra As Integer
    Public Property TipoCompraEstado As Integer
    Public Property IdCompraCCP As Integer
    Public Property IdPlazoCredito As Integer
    Public Property IdPlazoContado As Integer
    Public Property IdPeriodo As Integer
    Public Property IdCalendario As Integer
    Public Property NumeroPerdiodosCredito As Integer
    Public Property NumeroPerdiodosContado As Integer
    Public Property ImporteCredito As Decimal
    Public Property ImporteContado As Decimal
    Public Property InteresCredito As Decimal
    Public Property InteresContado As Decimal
    Public Property TotalCredito As Decimal
    Public Property TotalContado As Decimal
    Public Property FechaVencimientoCredito As Date
    Public Property FechaVencimientoContado As Date

    Public Property IdProducto As Integer
    Public Property IdProductoCorto As String
    Public Property FechaInicio As Date
    Public Property FechaFin As Date



End Class
