Public Class CalculoPlazo
    Public Property IdPlazoCredito As Integer
    Public Property IdPlazoContado As Integer
    Public Property Credito As String
    Public Property Contado As String
    Public Property PlazoCredito As Integer
    Public Property PlazoContado As Integer
    Public Property TotalCredito As Double
    Public Property TotalContado As Double
    Public Property IdProducto As Integer

    Sub New(ByVal IdPlazoCredito As Integer, _
            ByVal IdPlazoContado As Integer, _
            ByVal Credito As String, _
            ByVal Contado As String, _
            ByVal PlazoCredito As Integer, _
            ByVal PlazoContado As Integer, _
            ByVal TotalCredito As Double, _
            ByVal TotalContado As Double, _
            ByVal IdProducto As Integer)
        Me.IdPlazoCredito = IdPlazoCredito
        Me.IdPlazoContado = IdPlazoContado
        Me.Credito = Credito
        Me.Contado = Contado
        Me.PlazoCredito = PlazoCredito
        Me.PlazoContado = PlazoContado
        Me.TotalCredito = TotalCredito
        Me.TotalContado = TotalContado
        Me.IdProducto = IdProducto
    End Sub
    Sub New()
    End Sub
End Class
