Public Class Proveedor
    Inherits EntidadBase
    Public Property IdProveedor As Integer
    Public Property Equivalencia As String
    Public Property IdTipoPersona As Integer
    Public Property RazonSocial As String
    Public Property PrimerNombre As String
    Public Property SegundoNombre As String
    Public Property ApellidoPaterno As String
    Public Property ApellidoMaterno As String
    Public Property RFC As String
    Public Property Observacion As String
    Public Property LimiteCredito As Integer
    Public Property TablaContacto As DataTable
    Public Property TablaDireccion As DataTable
    Public Property TablaProducto As DataTable
    Public Property IdEstado As Integer

    Public Property IdProducto As Integer
    Public Property IdProductoCorto As String

End Class
