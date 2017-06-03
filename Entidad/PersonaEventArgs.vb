Public Class PersonaEventArgs
    Inherits EventArgs
    Public Property Renglon As Integer
    Public Property Persona As Entidad.Persona
    Public Sub New(Persona As Entidad.Persona)
        Me.Persona = Persona
    End Sub
    Public Sub New(ByVal Persona As Entidad.Persona, ByVal Renglon As Integer)
        Me.Persona = Persona
        Me.Renglon = Renglon
    End Sub
End Class