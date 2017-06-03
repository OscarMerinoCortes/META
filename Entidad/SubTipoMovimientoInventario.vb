Public Class SubTipoMovimientoInventario
    Inherits EntidadBase
    Public Property IdSubTipo As Integer
    Public Property Descripcion As String
    Public Property IdTipo As Integer
    Public Property IdEstado As Integer
    '=====Variables Usadas para los filtros=====
    Public Property IdSubTipoFiltro As Integer
    Public Property DescripcionFiltro As String
    Public Property IdTipoFiltro As Integer
    Public Property IdEstadoFiltro As Integer
    Public Property TablaSubTipoMovimientoInventario As DataTable
End Class


