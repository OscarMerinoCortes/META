Public Class IVA
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosIVA As New Datos.IVA()
        DatosIVA.Consultar(EntidadIVA)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadIVA1 As New Entidad.IVA()
        Dim DatosIVA As New Datos.IVA()
        EntidadIVA1 = EntidadIVA
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadIVA1.IVA), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadIVA1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadIVA1.idUsuarioCreacion = 1
            'EntidadIVA1.Tarjeta.IdUsuario
            'EntidadIVA1.UsuarioCreacion = EntidadIVA1.Tarjeta.Username.ToUpper()
            EntidadIVA1.FechaCreacion = Now
            EntidadIVA1.idUsuarioActualizacion = 1
            'EntidadIVA1.Tarjeta.IdUsuario
            'EntidadIVA1.UsuarioActualizacion = EntidadIVA1.Tarjeta.Username.ToUpper()
            EntidadIVA1.FechaActualizacion = Now


            DatosIVA.InsertarActualizar(EntidadIVA1)


        End If
    End Sub
    Public Sub Obtener(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
