Public Class TipoCaja
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoCaja As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoCaja As New Datos.TipoCaja()
        DatosTipoCaja.Consultar(EntidadTipoCaja)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoCaja As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoCaja1 As New Entidad.TipoCaja()
        Dim DatosTipoCaja As New Datos.TipoCaja()
        EntidadTipoCaja1 = EntidadTipoCaja
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoCaja1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoCaja1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoCaja1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoCaja1.FechaCreacion = Now
            EntidadTipoCaja1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoCaja1.FechaActualizacion = Now

            If EntidadTipoCaja1.IdTipoCaja = 0 Then
                DatosTipoCaja.Insertar(EntidadTipoCaja1)
            Else
                DatosTipoCaja.Actualizar(EntidadTipoCaja1)
            End If
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
