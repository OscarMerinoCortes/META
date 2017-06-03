Public Class Colonia
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadColonia As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosColonia As New Datos.Colonia()
        DatosColonia.Consultar(EntidadColonia)
    End Sub


    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadColonia As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadColonia1 As New Entidad.Colonia()
        Dim DatosColonia As New Datos.Colonia()
        EntidadColonia1 = EntidadColonia
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadColonia1.DescripcionColonia), "El Campo [Descripcion Colonia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.IdPaisColonia), "El Campo [Id Pais Colonia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.IdEntFedColonia), "El Campo [Id Entidad Federativa Coloniad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.IdMunColonia), "El Campo [Id Municipio Colonia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.IdCiudadColonia), "El Campo [Id Ciudad Colonia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.CPColonia), "El Campo [CP Colonia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadColonia1.IdEstadoColonia), "El Campo [Estado Colonia] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadColonia1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadColonia1.FechaCreacion = Now
            EntidadColonia1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadColonia1.FechaActualizacion = Now
            If EntidadColonia1.IdColonia = 0 Then
                DatosColonia.Insertar(EntidadColonia1)
            Else
                DatosColonia.Actualizar(EntidadColonia1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
