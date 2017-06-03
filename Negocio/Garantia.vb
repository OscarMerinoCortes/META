Public Class Garantia
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosGarantia As New Datos.Garantia()
        DatosGarantia.Consultar(EntidadGarantia)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadGarantia1 As New Entidad.Garantia()
        Dim DatosGarantia As New Datos.Garantia()
        EntidadGarantia1 = EntidadGarantia
        Dim DSResRul As String = ""             
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadGarantia1.IdUsuarioCreacion = 1
            EntidadGarantia1.FechaCreacion = Now
            EntidadGarantia1.IdUsuarioActualizacion = 1
            EntidadGarantia1.FechaActualizacion = Now
            DatosGarantia.Upsert(EntidadGarantia1)
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosGarantia As New Datos.Garantia()
        DatosGarantia.Obtener(EntidadGarantia)
    End Sub
End Class
