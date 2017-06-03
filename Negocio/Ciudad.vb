Public Class Ciudad
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadCiudad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCiudad As New Datos.Ciudad()
        DatosCiudad.Consultar(EntidadCiudad)
    End Sub


    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadCiudad As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCiudad1 As New Entidad.Ciudad()
        Dim DatosCiudad As New Datos.Ciudad()
        EntidadCiudad1 = EntidadCiudad
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCiudad1.DescripcionCiudad), "El Campo [Descripcion Ciudad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCiudad1.IdPaisCiudad), "El Campo [Pais Ciudad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCiudad1.IdEntFedCiudad), "El Campo [Entidad Federativa Ciudad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCiudad1.IdMunCiudad), "El Campo [Municipio Ciudad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCiudad1.EquivalenciaCiudad), "El Campo [Equivalencia Ciudad] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCiudad1.IdEstadoCiudad), "El Campo [Estado Ciudad] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCiudad1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadCiudad1.FechaCreacion = Now
            EntidadCiudad1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadCiudad1.FechaActualizacion = Now
            If EntidadCiudad1.IdCiudad = 0 Then
                DatosCiudad.Insertar(EntidadCiudad1)
            Else
                DatosCiudad.Actualizar(EntidadCiudad1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
