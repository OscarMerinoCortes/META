Public Class Devolucion
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosDevolucion As New Datos.Devolucion()
        DatosDevolucion.Consultar(EntidadDevolucion)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadDevolucion1 As New Entidad.Devolucion()
        Dim DatosDevolucion As New Datos.Devolucion()
        EntidadDevolucion1 = EntidadDevolucion
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadDevolucion1.IdUsuarioCreacion = 1
            EntidadDevolucion1.FechaCreacion = Now
            EntidadDevolucion1.IdUsuarioActualizacion = 1
            EntidadDevolucion1.FechaActualizacion = Now
            DatosDevolucion.Upsert(EntidadDevolucion1)
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosDevolucion As New Datos.Devolucion()
        DatosDevolucion.Obtener(EntidadDevolucion)
    End Sub
    Public Sub Aplicar(ByRef EntidadDevolucion As Entidad.EntidadBase)
        Dim DatosDevolucion As New Datos.Devolucion()
        DatosDevolucion.Aplicar(EntidadDevolucion)
    End Sub
End Class
