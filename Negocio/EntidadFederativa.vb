Public Class EntidadFederativa
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadEntidadFederativa As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosEntidadFederativa As New Datos.EntidadFederativa()
        DatosEntidadFederativa.Consultar(EntidadEntidadFederativa)
    End Sub

    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadEntidadFederativa As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadEntidadFederativa1 As New Entidad.EntidadFederativa()
        Dim DatosEntidadFederativa As New Datos.EntidadFederativa()
        EntidadEntidadFederativa1 = EntidadEntidadFederativa
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadEntidadFederativa1.Descripcion), "El Campo [Descripcion Entidad Federativa] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadEntidadFederativa1.IdPais), "El Campo [Pais Entidad Fedrativa] esta Vacio")        
        AddRul(DSResRul, Vacio(EntidadEntidadFederativa1.IdEstado), "El Campo [Id Estado Entidad Federativa] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadEntidadFederativa1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadEntidadFederativa1.FechaCreacion = Now
            EntidadEntidadFederativa1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadEntidadFederativa1.FechaActualizacion = Now
            If EntidadEntidadFederativa1.IdEntidadFederativa = 0 Then
                DatosEntidadFederativa.Insertar(EntidadEntidadFederativa1)
            Else
                DatosEntidadFederativa.Actualizar(EntidadEntidadFederativa1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        '    Dim DatosPais As New Datos.Pais()
        '    DatosPais.Obtener(EntidadPais)
    End Sub
End Class
