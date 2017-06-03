Public Class ReporteMovimientoInventario
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Consultar
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub ReporteMovimientoInventario(ByRef EntidadReporteMovimientoInventario As Entidad.ReporteMovimientoInventario)
        Dim DatosReporteMovimientoInventario As New Datos.ReporteMovimientoInventario()
        DatosReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
    End Sub
End Class
