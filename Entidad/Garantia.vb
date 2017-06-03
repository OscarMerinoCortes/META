Public Class Garantia
    Inherits EntidadBase
    Public Property IdGarantia As Integer
    Public Property IdGarantiaDetalle As Integer
    Public Property IdVenta As Integer
    Public Property IdCliente As Integer
    Public Property IdProducto As Integer
    Public Property Folio As String
    Public Property IdSucursal As Integer
    Public Property Telefono As String
    Public Property Falla As String
    Public Property Observacion As String
    Public Property Accesorios As String
    Public Property FechaEstimada As Date
    Public Property IdEstado As Integer
    Public Property De As Date
    Public Property Al As Date
    Public Property TablaGarantia As DataTable
    Public Property TablaGarantiaDetalle As DataTable

End Class
