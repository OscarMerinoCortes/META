Public Class ListaProductos
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Consultar
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Guardar
    End Sub
    Public Sub Obtener(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosListaProductos As New Datos.ListaProductos()
        DatosListaProductos.Obtener(EntidadListaProductos)
    End Sub  
End Class
