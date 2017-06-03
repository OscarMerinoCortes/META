Public Class EntidadBase

    Public Property IdUsuarioCreacion As Integer
    Public Property UsuarioCreacion As String
    Public Property FechaCreacion As DateTime
    Public Property IdUsuarioActualizacion As Integer
    Public Property UsuarioActualizacion As String
    Public Property FechaActualizacion As DateTime
    'Public Property Tarjeta As Tarjeta
    Public Property TablaConsulta As DataTable
    Public Property DatasetConsulta As DataSet
    'Private PIUsuarioCreacion As Integer
    'Private PSUsuarioCreacion As String
    'Private PDFechaCreacion As DateTime
    'Private PIUsuarioActualizacion As Integer
    'Private PSUsuarioActualizacion As String
    'Private PDFechaActualizacion As DateTime
    Private PDTarjeta As New Tarjeta
    'Private PDTablaConsulta As DataTable
    'Private PDatasetConsulta As New DataSet

    'Public Property DatasetConsulta As DataSet
    '    Get
    '        Return PDatasetConsulta
    '    End Get
    '    Set(ByVal value As DataSet)
    '        PDatasetConsulta = value
    '    End Set
    'End Property


    'Public Property TablaConsulta As DataTable
    '    Get
    '        Return PDTablaConsulta
    '    End Get
    '    Set(ByVal value As DataTable)
    '        PDTablaConsulta = value
    '    End Set
    'End Property

    'Public Property UsuarioCreacion As String
    '    Get
    '        Return PSUsuarioCreacion
    '    End Get
    '    Set(ByVal value As String)
    '        PSUsuarioCreacion = value
    '    End Set
    'End Property

    'Public Property UsuarioActualizacion As String
    '    Get
    '        Return PSUsuarioActualizacion
    '    End Get
    '    Set(ByVal value As String)
    '        PSUsuarioActualizacion = value
    '    End Set
    'End Property

    Public Property Tarjeta As Tarjeta
        Get
            Return PDTarjeta
        End Get
        Set(ByVal value As Tarjeta)
            PDTarjeta = value
        End Set
    End Property
    'Public Property IdUsuarioCreacion As Integer
    '    Get
    '        Return PIUsuarioCreacion
    '    End Get
    '    Set(ByVal value As Integer)
    '        PIUsuarioCreacion = value
    '    End Set
    'End Property

    'Public Property FechaCreacion As DateTime
    '    Get
    '        Return PDFechaCreacion
    '    End Get
    '    Set(ByVal value As DateTime)
    '        PDFechaCreacion = value
    '    End Set
    'End Property


    'Public Property IdUsuarioActualizacion As Integer
    '    Get
    '        Return PIUsuarioActualizacion
    '    End Get
    '    Set(ByVal value As Integer)
    '        PIUsuarioActualizacion = value
    '    End Set
    'End Property
    'Public Property FechaActualizacion As DateTime
    '    Get
    '        Return PDFechaActualizacion
    '    End Get
    '    Set(ByVal value As DateTime)
    '        PDFechaActualizacion = value
    '    End Set
    'End Property
End Class

