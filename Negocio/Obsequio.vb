Public Class Obsequio
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadObsequio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosObsequio As New Datos.Obsequio()
        DatosObsequio.Consultar(EntidadObsequio)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadObsequio As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadObsequio1 As New Entidad.Obsequio()
        Dim DatosObsequio As New Datos.Obsequio()
        EntidadObsequio1 = EntidadObsequio
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadObsequio1.IdPromocion), "El Campo [IdPromocion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadObsequio1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadObsequio1.idUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadObsequio1.FechaCreacion = Now
            EntidadObsequio1.idUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadObsequio1.FechaActualizacion = Now
            DatosObsequio.InsertarActualizar(EntidadObsequio1)
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
'TablaPromocionDetalle.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
'            TablaPromocionDetalle.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
'            TablaPromocionDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
'            TablaPromocionDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
''TablaPromocionDetalle.Columns.Add(New DataColumn("Descuento", System.Type.GetType("System.String")))
'            TablaPromocionDetalle.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
'            TablaPromocionDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
'            VistaPromocionDetalle = TablaPromocionDetalle.DefaultView
'            Session("TablaPromocionDetalle") = TablaPromocionDetalle
'            Session("VistaPromocionDetalle") = VistaPromocionDetalle