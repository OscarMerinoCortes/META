Public Class Credito
    Inherits EntidadBase

    Public Property IdTipoGenero As Integer
    Public Property IdTipoPersona As Integer
    Public Property IdCredito As Integer
    Public Property IdPersonaSolicitante As Integer
    Public Property FechaApertura As DateTime
    Public Property FechaVencimiento As DateTime
    Public Property Monto As Double
    Public Property IdEstadoCredito As Integer
    Public Property IdEstado As Integer
    '---VARIABLES FILTROS---------------------------
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property IdEstado2 As Integer
    Public Property TablaCredito As DataTable
End Class
