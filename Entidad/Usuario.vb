Public Class Usuario
    Inherits EntidadBase
    Public Property IdUsuario As Integer
    Public Property Username As String
    Public Property Abreviacion As String
    Public Property PrimerNombre As String
    Public Property SegundoNombre As String
    Public Property ApellidoPaterno As String
    Public Property ApellidoMaterno As String
    Public Property Dia As Integer
    Public Property Mes As Integer
    Public Property Ano As Integer
    Public Property IdTipoUsuario As Integer
    Public Property IdSucursal As Integer
    Public Property Sucursal As String
    Public Property IdAlmacen As Integer
    Public Property Almacen As String
    Public Property Clave As String
    Public Property Vigencia As Date
    Public Property Correo As String
    Public Property Telefono As String
    Public Property IdEstado As Integer




    Public Property Latitud As Integer
    Public Property Longitud As Integer
    Public Property NombreEquipo As String
    Public Property IPV6 As String
    Public Property IPV4 As String
    Public Property MacAdress As String

    '------------Permisos----------------------
    Public Property Guardar As Integer
    Public Property Actualizar As Integer
    Public Property Consultar As Integer
    Public Property Cancelar As Integer
    Public Property Exportar As Integer
    Public Property Imprimir As Integer
    Public Property Aplicar As Integer
    '------------Opciones----------------------
    Public Property Catalogo As Integer
    Public Property Proceso As Integer
    Public Property Reporte As Integer
End Class
