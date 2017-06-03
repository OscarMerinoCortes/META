Public Class ReporteExistenciaAlmacen
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Consultar
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub ReporteExistenciaAlmacen(ByRef EntidadReporteExistenciaAlmacen As Entidad.ReporteExistenciaAlmacen)
        Dim DatosReporteExistenciaAlmacen As New Datos.ReporteExistenciaAlmacen()
        DatosReporteExistenciaAlmacen.ReporteExistenciaAlmacen(EntidadReporteExistenciaAlmacen)
    End Sub
    Public Sub ReporteExistenciaSucursal(ByRef EntidadReporteExistenciaAlmacen As Entidad.ReporteExistenciaAlmacen)
        Dim DatosReporteExistenciaAlmacen As New Datos.ReporteExistenciaAlmacen()
        DatosReporteExistenciaAlmacen.ReporteExistenciaSucursal(EntidadReporteExistenciaAlmacen)
    End Sub

    Public Sub ExistenciaSucursal(ByRef EntidadReporteExistenciaAlmacen As Entidad.ReporteExistenciaAlmacen)
        Dim DatosReporteExistenciaAlmacen As New Datos.ReporteExistenciaAlmacen()
        DatosReporteExistenciaAlmacen.ExistenciaSucursalEstadistica(EntidadReporteExistenciaAlmacen)
    End Sub
End Class
