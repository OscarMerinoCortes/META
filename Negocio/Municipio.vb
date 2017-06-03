Public Class Municipio
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadMunicipio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosMunicipio As New Datos.Municipio()
        DatosMunicipio.Consultar(EntidadMunicipio)
    End Sub

    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadMunicipio As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadMunicipio1 As New Entidad.Municipio()
        Dim DatosMunicipio As New Datos.Municipio()
        EntidadMunicipio1 = EntidadMunicipio
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadMunicipio1.Descripcion), "El Campo [Descripcion Municipio] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadMunicipio1.IdPais), "El Campo [Pais Municipio] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadMunicipio1.IdEntidadFederativa), "El Campo [Entidad Federativa Municipio] esta Vacio")     
        AddRul(DSResRul, Vacio(EntidadMunicipio1.IdEstado), "El Campo [Estado Municipio] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadMunicipio1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadMunicipio1.FechaCreacion = Now
            EntidadMunicipio1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadMunicipio1.FechaActualizacion = Now
            If EntidadMunicipio1.IdMunicipio = 0 Then
                DatosMunicipio.Insertar(EntidadMunicipio1)
            Else
                DatosMunicipio.Actualizar(EntidadMunicipio1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
