Public Class ReporteVenta
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadReporteVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosReporteVenta As New Datos.ReporteVenta()
        DatosReporteVenta.Consultar(EntidadReporteVenta)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub ReporteVenta(ByRef EntidadReporteVenta As Entidad.ReporteVenta)
        Dim DatosReporteVenta As New Datos.ReporteVenta()
        DatosReporteVenta.ReporteVenta(EntidadReporteVenta)
    End Sub
End Class
