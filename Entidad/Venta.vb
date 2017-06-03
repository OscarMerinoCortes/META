Imports System.Collections.ObjectModel

Public Class Venta
    Inherits EntidadBase
    Public Property Id As Integer
    Public Property IdPersona As Integer
    Public Property Persona As String
    Public Property SaldoDisponible As Double
    Public Property Folio As String
    Public Property FolioFisico As String
    Public Property IdTipoEntrega As Integer
    Public Property DomicilioEntrega As String
    Public Property DescuentoPorcentaje As Double
    Public Property DescuentoMonto As Double
    Public Property CargoMonto As Double
    Public Property Subtotal As Double
    Public Property Total As Double
    Public Property IdVendedor As Integer
    Public Property Vendedor As String
    Public Property IdSucursal As Integer
    Public Property IdAlmacen As Integer
    Public Property Sucursal As String
    Public Property Almacen As String
    Public Property Observacion As String
    Public Property IdTipoVenta As Operacion.Configuracion.Constante.TipoVenta
    Public Property IdVentaEstado As Operacion.Configuracion.Constante.TipoVentaEstado
    Public Property Detalle As ObservableCollection(Of VentaDetalle)
    Public Property Cargo As ObservableCollection(Of VentaCargo)
    Public Property Descuento As ObservableCollection(Of VentaDescuento)
    Public Property Obsequio As ObservableCollection(Of VentaObsequio)
    Public Property Credito As VentaCredito
    Public Property Descripcion As String
    Public Property Identificacion As String
    Public Property IdEstado As Integer

End Class

Public Class VentaDetalle
    Public Property Id As Integer
    Public Property IdProducto As Integer
    Public Property IdProductoCorto As String
    Public Property Cantidad As Integer
    Public Property CantidadInventario As Integer
    Public Property Producto As String
    Public Property PrecioBase As Double
    Public Property PrecioCredito As Double
    Public Property PrecioContado As Double
    Public Property DescuentoPorcentaje As Double
    Public Property DescuentoContado As Double
    Public Property DescuentoCredito As Double
    Public Property SubtotalCredito As Double
    Public Property SubtotalContado As Double
    Public Property TotalCredito As Double
    Public Property TotalContado As Double
    Public Property Ganancia As Double
    Public Property IdAlmacen As Integer
    Public Property Almacen As String
    Public Property Promocion As String
    Public Property IdEstado As Integer
    Public Property IdProductoEntrega As Integer
    Public Property VentaExistenciaCero As Integer
    Public Property AfectaInventario As Integer
    Public Property PromocionBoolean As Boolean

End Class


Public Class VentaCredito
    Public Property Id As Integer
    ' Public Property SaldoCliente As Double
    Public Property IdAval As Integer
    Public Property Aval As String
    Public Property Anticipo As Double
    Public Property Extra As Integer
    Public Property Gracia As Integer
    Public Property IdPlazoCredito As Integer
    Public Property IdPlazoContado As Integer
    Public Property PlazoCredito As String
    Public Property PlazoContado As String
    Public Property PlazoCreditoCantidad As Integer
    Public Property PlazoContadoCantidad As Integer
    Public Property IdCalendario As Integer
    Public Property IdPeriodo As Integer
    Public Property Periodo As String
    Public Property IdPersonaDomicilio As Integer
    Public Property PeriodoCredito As Integer
    Public Property PeriodoContado As Integer
    Public Property ImporteContado As Double
    Public Property ImporteCredito As Double
    Public Property Subtotal As Double
    'Public Property SubtotalContado As Double
    Public Property Total As Double
    'Public Property TotalContado As Double
    Public Property Interes As Double
    Public Property IVA As Double
    Public Property FechaInicio As DateTime
    Public Property FechaFinCredito As DateTime
    Public Property FechaFinContado As DateTime
    Public Property IdTipoDocumento As Integer
    Public Property Serie As String
    Public Property IEPS As Integer
    Public Property IdTipoCCP As Integer
    Public Property IdEstado As Integer
    Public Property AvalDomicilio As String
    Public Property AvalTelefono As String
    Public Property IdVentaAval As Integer
End Class

Public Class VentaDescuento
    Public Property Id As Integer
    Public Property IdPromocion As Integer
    Public Property Descripcion As String
    Public Property Gracia As Integer
    Public Property Extra As Integer
    Public Property IdTipoDescuento As Integer
    Public Property DescuentoPorcentaje As Double
    Public Property Descuento As Double
    Public Property Observacion As String
    Public Property IdTipoGracia As Integer
    Public Property IdTipoExtra As Integer
    Public Property IdProducto As Integer
    Public Property DescripcionDetalle As String
    Public Property DescripcionOriginal As String
    Public Property IdProductoCorto As String
    Public Property IdEstado As Integer
End Class

Public Class VentaCargo
    Public Property Id As Integer
    Public Property IdTipoCargoVenta As Integer
    Public Property IdTipo As Integer
    Public Property Cargo As String
    'Public Property MontoPorcentaje As Double
    Public Property Total As Double
    Public Property Monto As Double
    Public Property TipoMonto As Integer
    Public Property IdEstado As Integer
    Public Property TipoCargoVenta As String
    Public Property Activo As Boolean
End Class

Public Class VentaObsequio
    Public Property IdTipoCargo As Integer
    Public Property IdProductoCorto As String
    Public Property Id As Integer
    Public Property IdPromocion As Integer
    Public Property Descripcion As String
    Public Property Detalle As ObservableCollection(Of VentaObsequioDetalle)
    Public Property Cargo As Double
    Public Property CargoPorcentaje As Double
    Public Property IdProducto As Integer
    Public Property Observacion As String
    Public Property DescripcionDetalle As String
    Public Property DescripcionOriginal As String
    Public Property IdEstado As Integer
End Class

Public Class VentaObsequioDetalle
    Public Property Id As Integer
    Public Property Total As Double
    Public Property IdProducto As Integer
    Public Property Producto As String
    Public Property PrecioBase As Double
    Public Property CantidadRegalada As Integer
    'Public Property CantidadTotal As Integer
    Public Property IdProductoCorto As String
    Public Property Ganancia As Double
    Public Property CantidadRegalo As Integer
    Public Property IdEstado As Integer
    Public Property IdAlmacen As Integer
    Public Property Almacen As String
    Public Property VentaExistenciaCero As Integer

End Class

Public Class VentaBusqueda
    Public Property IdVenta As Integer
    Public Property Cliente As String
    Public Property Codigo As String
    Public Property Venta As String
    Public Property VentaEstado As String
    Public Property FechaCreacion As String
    Public Property Total As Double
End Class

Public Class VentaPromocion
    Public Property IdProducto As Integer
    Public Property IdPromocion As Integer
    Public Property IdTipoPromocion As Integer
    Public Property Descripcion As String
    Public Property TipoDescuento As Integer
    Public Property Descuento As double
    Public Property IdTipoExtra As Integer
    Public Property Extra As Integer
    Public Property IdTipoGracia As Integer
    Public Property Gracia As Integer
    Public Property Observacion As String
    Public Property DescripcionOriginal As String
    Public Property DescripcionDetalle As String
    Public Property IdProductoCorto As String
End Class