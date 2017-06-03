Public Class ReporteExistenciaEmpresa
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Consultar
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub ReporteExistenciaEmpresa(ByRef EntidadReporteExistenciaempresa As Entidad.ReporteExistenciaEmpresa)
        Dim DatosReporteExistenciaEmpresa As New Datos.ReporteExistenciaEmpresa()
        DatosReporteExistenciaEmpresa.ReporteExistenciaEmpresa(EntidadReporteExistenciaempresa)
    End Sub
    Public Sub ReporteListadoAlmacen(ByRef EntidadReporteExistenciaempresa As Entidad.ReporteExistenciaEmpresa)
        Dim DatosReporteExistenciaEmpresa As New Datos.ReporteExistenciaEmpresa()
        DatosReporteExistenciaEmpresa.ReporteListadoAlmacen(EntidadReporteExistenciaempresa)
    End Sub
End Class
