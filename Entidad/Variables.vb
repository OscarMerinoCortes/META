Public Class Variables
        Private PSNombre As String
        Private PSValor As Object
        Private PSTamanio As Short

        Public Property Nombre() As String
            Get
                Return PSNombre
            End Get
            Set(ByVal Value As String)
                PSNombre = Value
            End Set
        End Property

        Public Property Valor() As Object
            Get
                Return PSValor
            End Get
            Set(ByVal Value As Object)
                PSValor = Value
            End Set
        End Property

        Public Property Tamanio() As Short
            Get
                Return PSTamanio
            End Get
            Set(ByVal Value As Short)
                PSTamanio = Value
            End Set
        End Property


    End Class
