Public Interface IPersona
    Function Consultar(ByRef Entidad As Entidad.Persona) As DataTable
    Function Guardar(ByRef Entidad As Entidad.Persona) As Integer
    Function Obtener(ByRef Entidad As Entidad.Persona) As DataTable
    Function ObtenerTablas(ByRef Entidad As Entidad.Persona) As DataTable
    Function ReportePersona(ByRef Entidad As Entidad.Persona) As DataTable

End Interface
