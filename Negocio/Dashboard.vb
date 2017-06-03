Imports Entidad

Public Class Dashboard
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Consultar
        'Dim DatosVenta As New Datos.Venta()
        'DatosVenta.Consultar(EntidadDashboard)
    End Sub

    Public Sub Guardar(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Guardar
        'Dim EntidadDashboard1 As New Entidad.Venta()
        'Dim DatosVenta As New Datos.Venta()
        'EntidadDashboard1 = EntidadDashboard
        'If EntidadDashboard1.Id = 0 Then
        '    DatosVenta.Insertar(EntidadDashboard1)
        'Else
        '    DatosVenta.Actualizar(EntidadDashboard1)
        'End If
    End Sub

    Public Sub Obtener(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Obtener
        'Dim DatosVenta As New Datos.Venta()
        'DatosVenta.Obtener(EntidadDashboard)
    End Sub

    Public Sub ObtenerDashboardVentas(EntidadDashboard As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Dashboard()
        DatosVenta.ObtenerDashboardVentas(EntidadDashboard)
    End Sub

    Public Sub ObtenerDashboardCompras(EntidadDashboard As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Dashboard()
        DatosVenta.ObtenerDashboardCompras(EntidadDashboard)
    End Sub
    Public Sub ObtenerDashboardCaja(EntidadDashboard As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Dashboard()
        DatosVenta.ObtenerDashboardCaja(EntidadDashboard)
    End Sub
End Class
