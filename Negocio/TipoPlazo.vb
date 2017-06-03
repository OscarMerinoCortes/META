Public Class TipoPlazo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoPlazo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoPlazo As New Datos.TipoPlazo()
        DatosTipoPlazo.Consultar(EntidadTipoPlazo)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoPlazo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoPlazo1 As New Entidad.TipoPlazo()
        Dim DatosTipoPlazo As New Datos.TipoPlazo()
        EntidadTipoPlazo1 = EntidadTipoPlazo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoPlazo1.Plazo), "El Campo [Plazo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoPlazo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoPlazo1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoPlazo1.FechaCreacion = Now
            EntidadTipoPlazo1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoPlazo1.FechaActualizacion = Now

            If EntidadTipoPlazo1.IdTipoPlazo = 0 Then
                DatosTipoPlazo.Insertar(EntidadTipoPlazo1)
            Else
                DatosTipoPlazo.Actualizar(EntidadTipoPlazo1)
            End If
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
