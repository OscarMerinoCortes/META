Public Class Pais
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosPais As New Datos.Pais()
        DatosPais.Consultar(EntidadPais)
    End Sub

    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadPais1 As New Entidad.Pais()
        Dim DatosPais As New Datos.Pais()
        EntidadPais1 = EntidadPais
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadPais1.Descripcion), "El Campo [Descripcion Pais] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPais1.Gentilicio), "El Campo [Descripcion Gentilicio] esta Vacio")        
        AddRul(DSResRul, Vacio(EntidadPais1.IdEstado), "El Campo [Id Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadPais1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPais1.FechaCreacion = Now
            EntidadPais1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPais1.FechaActualizacion = Now
            If EntidadPais1.IdPais = 0 Then
                DatosPais.Insertar(EntidadPais1)
            Else
                DatosPais.Actualizar(EntidadPais1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
