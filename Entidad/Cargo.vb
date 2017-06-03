Public Class Cargo
    Inherits EntidadBase
    Public Property IdCargo As Integer
    Public Property Descripcion As String
    Public Property IdEstado As Integer

    'Para uso en venta - No afecta en nada si no se usan
    Public Property Equivalencia As String
    Public Property Monto As Double
    Public Property IdTipoMonto As Integer
    Public Property IdAutomatico As Integer
    Public Property IdTipoCargo As Integer 'Pertence al id de la tabla de tipo cargo que dice si se tiene que pagar inmediatamente, si afecta al total o si es sobre posible atraso
    Public Property Cargo As String 'Descripcion de esa tabla
    Public Property IdTipo As Integer 'Pertenece al que dice si se tiene que pagar inmediatamente, si afecta al total o si es sobre posible atraso
    Public Property Total As Double
    Public Property Checked As Boolean
End Class
