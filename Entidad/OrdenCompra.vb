Public Class OrdenCompra
    Inherits EntidadBase
    Public Property IdOrden As Integer
    Public Property Observacion As String
    Public Property IdTipoPrioridad As Integer
    Public Property IdTipoSolicitudEstado As Integer
    Public Property IdCliente As Integer
    Public Property IdEstado As Integer
    Public Property TablaOrdenDetalle As DataTable
    Public Property TablaSolicitudDetalle As DataTable
    Public Property Cancelar As Integer
End Class
