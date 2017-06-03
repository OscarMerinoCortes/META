Public Class ConsultarPersona
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosConsultarPersona As New Datos.ConsultarPersona()
        DatosConsultarPersona.Consultar(EntidadConsultarPersona)
    End Sub
    Public Sub Guardar(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub

End Class
