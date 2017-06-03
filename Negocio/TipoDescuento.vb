Public Class TipoDescuento
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoDescuento As New Datos.TipoDescuento()
        DatosTipoDescuento.Consultar(EntidadTipoDescuento)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosTipoDescuento As New Datos.TipoDescuento()
        Dim EntidadTipoDescuento1 As New Entidad.TipoDescuento()
        EntidadTipoDescuento1 = EntidadTipoDescuento
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoDescuento1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoDescuento1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoDescuento1.IdUsuarioCreacion = 1
            'EntidadTipoDescuento1.Tarjeta.IdUsuario
            'EntidadTipoDescuento1.UsuarioCreacion = EntidadTipoDescuento.Tarjeta.Username.ToUpper()
            EntidadTipoDescuento1.FechaCreacion = Now
            EntidadTipoDescuento1.IdUsuarioActualizacion = 1
            'EntidadTipoDescuento1.Tarjeta.IdUsuario
            'EntidadTipoDescuento1.UsuarioActualizacion = EntidadTipoDescuento.Tarjeta.Username.ToUpper()
            EntidadTipoDescuento1.FechaActualizacion = Now
            If EntidadTipoDescuento1.IdTipoDescuento = 0 Then
                DatosTipoDescuento.Insertar(EntidadTipoDescuento1)
            Else
                DatosTipoDescuento.Actualizar(EntidadTipoDescuento1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
