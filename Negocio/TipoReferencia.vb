Public Class TipoReferencia
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoReferencia As New Datos.TipoReferencia()
        DatosTipoReferencia.Consultar(EntidadTipoReferencia)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoReferencia1 As New Entidad.TipoReferencia()
        Dim DatosTipoReferencia As New Datos.TipoReferencia()
        EntidadTipoReferencia1 = EntidadTipoReferencia
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoReferencia1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoReferencia1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoReferencia1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoReferencia1.FechaCreacion = Now
            EntidadTipoReferencia1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoReferencia1.FechaActualizacion = Now
            If EntidadTipoReferencia1.IdTipoReferencia = 0 Then
                DatosTipoReferencia.Insertar(EntidadTipoReferencia1)
            Else
                DatosTipoReferencia.Actualizar(EntidadTipoReferencia1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
