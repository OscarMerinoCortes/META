Public Class PlazoVencimiento
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadPlazoVencimiento As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosPlazoVencimiento As New Datos.PlazoVencimiento()
        DatosPlazoVencimiento.Consultar(EntidadPlazoVencimiento)
    End Sub

    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadPlazoVencimiento As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadPlazoVencimiento1 As New Entidad.PlazoVencimiento()
        Dim DatosPlazoVencimiento As New Datos.PlazoVencimiento()
        EntidadPlazoVencimiento1 = EntidadPlazoVencimiento
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadPlazoVencimiento1.DescripcionPlazoVen), "El Campo [Descripcion Plazo Vencimiento] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPlazoVencimiento1.MaximoPlazoVen), "El Campo [Maximo Plazo Vencimiento] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPlazoVencimiento1.MinimoPlazoVen), "El Campo [Minimo Plazo Vencimiento] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPlazoVencimiento1.IdEstado), "El Campo [Id Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadPlazoVencimiento1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPlazoVencimiento1.FechaCreacion = Now
            EntidadPlazoVencimiento1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPlazoVencimiento1.FechaActualizacion = Now
            If EntidadPlazoVencimiento1.IdPlazoVencimiento = 0 Then
                DatosPlazoVencimiento.Insertar(EntidadPlazoVencimiento1)
            Else
                DatosPlazoVencimiento.Actualizar(EntidadPlazoVencimiento1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
