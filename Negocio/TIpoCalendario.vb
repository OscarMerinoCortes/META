Public Class TipoCalendario
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoCalendario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoCalendario As New Datos.TipoCalendario()
        DatosTipoCalendario.Consultar(EntidadTipoCalendario)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoCalendario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoCalendario1 As New Entidad.TipoCalendario()
        Dim DatosTipoCalendario As New Datos.TipoCalendario()
        EntidadTipoCalendario1 = EntidadTipoCalendario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoCalendario1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoCalendario1.Mes), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoCalendario1.Ano), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoCalendario1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoCalendario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoCalendario1.IdUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoCalendario1.FechaCreacion = Now
            EntidadTipoCalendario1.IdUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoCalendario1.FechaActualizacion = Now

            DatosTipoCalendario.InsertarActualizar(EntidadTipoCalendario1)
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
