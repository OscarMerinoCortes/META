Public Class PerfilProducto
    Inherits EntidadBase
    Public Property IdProducto As Integer
    Public Property TablaCompra As New DataTable()
    Public Property TablaVenta As New DataTable()
    Public Property TablaExistencia As New DataTable()
    Public Property TablaProveedor As New DataTable()
End Class
