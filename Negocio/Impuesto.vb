Public Class Impuesto
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadImpuesto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosImpuesto As New Datos.Impuesto()
        DatosImpuesto.Consultar(EntidadImpuesto)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadImpuesto As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadImpuesto1 As New Entidad.Impuesto()
        Dim DatosImpuesto As New Datos.Impuesto()
        EntidadImpuesto1 = EntidadImpuesto
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadImpuesto1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadImpuesto1.Impuesto), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadImpuesto1.idUsuarioCreacion = 1
            'EntidadIVA1.Tarjeta.IdUsuario
            'EntidadIVA1.UsuarioCreacion = EntidadIVA1.Tarjeta.Username.ToUpper()
            EntidadImpuesto1.FechaCreacion = Now
            EntidadImpuesto1.idUsuarioActualizacion = 1
            'EntidadIVA1.Tarjeta.IdUsuario
            'EntidadIVA1.UsuarioActualizacion = EntidadIVA1.Tarjeta.Username.ToUpper()
            EntidadImpuesto1.FechaActualizacion = Now


            DatosImpuesto.InsertarActualizar(EntidadImpuesto1)


        End If
    End Sub
    Public Sub Obtener(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
