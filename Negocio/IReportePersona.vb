Public Interface IReportePersona
    Function Consultar(ByRef Entidad As Entidad.Persona) As DataTable
    Function Obtener(ByRef Entidad As Entidad.Persona) As Entidad.Persona
End Interface
