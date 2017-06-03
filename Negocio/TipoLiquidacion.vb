Public Class TipoLiquidacion
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoLiquidacion As New Datos.TipoLiquidacion()
        DatosTipoLiquidacion.Consultar(EntidadTipoLiquidacion)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoLiquidacion1 As New Entidad.TipoLiquidacion()
        Dim DatosTipoLiquidacion As New Datos.TipoLiquidacion()
        EntidadTipoLiquidacion1 = EntidadTipoLiquidacion
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoLiquidacion1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoLiquidacion1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoLiquidacion1.idUsuarioCreacion = 1
            'EntidadTipoLiquidacion1.Tarjeta.IdUsuario
            'EntidadTipoLiquidacion1.UsuarioCreacion = EntidadTipoLiquidacion1.Tarjeta.Username.ToUpper()
            EntidadTipoLiquidacion1.FechaCreacion = Now
            EntidadTipoLiquidacion1.idUsuarioActualizacion = 1
            'EntidadTipoLiquidacion1.Tarjeta.IdUsuario
            'EntidadTipoLiquidacion1.UsuarioActualizacion = EntidadTipoLiquidacion1.Tarjeta.Username.ToUpper()
            EntidadTipoLiquidacion1.FechaActualizacion = Now

            If EntidadTipoLiquidacion1.IdTipoLiquidacion = 0 Then
                DatosTipoLiquidacion.Insertar(EntidadTipoLiquidacion1)
            Else
                DatosTipoLiquidacion.Actualizar(EntidadTipoLiquidacion1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
