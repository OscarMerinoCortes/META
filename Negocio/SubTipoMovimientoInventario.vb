Public Class SubTipoMovimientoInventario
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosSubTipoMovmientoInventario As New Datos.SubTipoMovimientoInventario()
        DatosSubTipoMovmientoInventario.Consultar(EntidadSubTipoMovimientoInventario)
    End Sub

    'Public Overridable Sub ConsultarNoEsGafi(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarNoEsGafi(EntidadPais)
    'End Sub

    'Public Overridable Sub ConsultarEsParaiso(ByRef EntidadPais As Entidad.EntidadBase)
    '    Dim DatosPais As New Datos.Pais()
    '    DatosPais.ConsultarEsParaiso(EntidadPais)
    'End Sub

    Public Overridable Sub Guardar(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadSubTipoMovimientoInventario1 As New Entidad.SubTipoMovimientoInventario()
        Dim DatosSubTipoMovimientoInventario As New Datos.SubTipoMovimientoInventario()
        EntidadSubTipoMovimientoInventario1 = EntidadSubTipoMovimientoInventario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadSubTipoMovimientoInventario1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadSubTipoMovimientoInventario1.IdTipo), "El Campo [Tipo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadSubTipoMovimientoInventario1.IdEstado), "El Campo [Id Estado] esta Vacio")        
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadSubTipoMovimientoInventario1.idUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadSubTipoMovimientoInventario1.FechaCreacion = Now
            EntidadSubTipoMovimientoInventario1.idUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadSubTipoMovimientoInventario1.FechaActualizacion = Now
            If EntidadSubTipoMovimientoInventario1.IdSubTipo = 0 Then
                DatosSubTipoMovimientoInventario.Insertar(EntidadSubTipoMovimientoInventario1)
            Else
                DatosSubTipoMovimientoInventario.Actualizar(EntidadSubTipoMovimientoInventario1)
            End If
        End If
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosSubTipoMovimientoInventario As New Datos.SubTipoMovimientoInventario()
        DatosSubTipoMovimientoInventario.Obtener(EntidadSubTipoMovimientoInventario)
    End Sub
End Class
