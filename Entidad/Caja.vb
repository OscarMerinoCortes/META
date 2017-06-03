Public Class Caja
    Inherits EntidadBase
    Public Property IdCaja As Integer
    Public Property Recibo As String
    Public Property IdPersona As Integer
    Public Property PagoAbono As Double
    Public Property IdFormaPago As Integer
    Public Property Descuento As Double
    Public Property Porcentaje As Integer
    Public Property Observacion As String
    Public Property FechaActual As DateTime
    Public Property IdVenta As Integer
    Public Property IdCCP As Integer

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
    Public Property IdEstado As Integer

    Public Property IdSucursal As Integer
    Public Property FechaInicio As DateTime
    Public Property FechaFin As DateTime

    Public Property Buscar As String
End Class
