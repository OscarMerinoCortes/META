Public Class Persona
    Inherits EntidadBase
    Public Property IdPersona As Integer
    Public Property Equivalencia As String
    Public Property IdTipoPersona As Integer
    Public Property RazonSocial As String
    Public Property PrimerNombre As String
    Public Property SegundoNombre As String
    Public Property ApellidoPaterno As String
    Public Property ApellidoMaterno As String
    Public Property NombreCompleto As String
    Public Property FechaNacimiento As DateTime
    Public Property IdTipoGenero As Integer
    Public Property IdTipoEstadoCivil As Integer
    Public Property IdEstado As Integer
    Public Property IdConyugue As Integer
    Public Property Observaciones As String
    Public Property Buscar As String
    Public Property TablaIdentificacion As DataTable
    Public Property TablaContacto As DataTable 
    Public Property TablaDomicilio As DataTable   
    Public Property TablaEmpleo As DataTable   
    Public Property TablaReferencia As DataTable  
    Public Property TablaLineaCredito As DataTable 
    Public Property TablaIndicador As DataTable
    Public Property TablaConyugue As DataTable
    Public Property TablaLimiteCredito As DataTable
End Class
