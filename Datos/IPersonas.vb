Public Interface IPersonas
    Function Consultar(ByRef EntidadBase As Entidad.Persona) As DataTable
    Function Insertar(ByRef EntidadBase As Entidad.Persona) As Integer
    Sub Actualizar(ByRef EntidadBase As Entidad.Persona)
    Function Obtener(ByRef EntidadBase As Entidad.Persona) As DataTable
    Function ObtenerTablas(ByRef EntidadBase As Entidad.Persona) As DataTable
    Function ReportePersona(ByRef EntidadBase As Entidad.Persona) As DataTable
End Interface
