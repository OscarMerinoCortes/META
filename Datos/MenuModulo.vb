Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class MenuModulo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadMenuModulo1 As New Entidad.MenuModulo()
        'EntidadMenuModulo1 = EntidadMenuModulo
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActClaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadMenuModulo1.IdClasificacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadMenuModulo1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMenuModulo1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMenuModulo1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMenuModulo1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadMenuModulo1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadMenuModulo = EntidadMenuModulo1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadMenuModulo1 = New Entidad.MenuModulo()
        EntidadMenuModulo1 = EntidadMenuModulo
        EntidadMenuModulo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadMenuModulo1.Tarjeta.Consulta
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ObtOpcModPermCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IdModulo", EntidadMenuModulo1.IdModulo))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadMenuModulo1.IdTipoUsuario))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
                Case Consulta.ConsultaDetalladaPorId
                    'seguridad modulos
                    sqlcom1 = New SqlCommand("ERP_ObtModPerm", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadMenuModulo1.IdTipoUsuario))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
                    'Dim sqldat1 As New SqlDataAdapter("ERP_ConBasClaCod", sqlcon1)
                    'sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
            End Select
            EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMenuModulo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMenuModulo = EntidadMenuModulo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadMenuModulo1 As New Entidad.MenuModulo()
        'EntidadMenuModulo1 = EntidadMenuModulo
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsClaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadMenuModulo1.IdClasificacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadMenuModulo1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMenuModulo1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMenuModulo1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMenuModulo1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMenuModulo1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMenuModulo1.FechaActualizacion))
        '    sqlcom1.Parameters("@INIdClasificacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadMenuModulo1.IdClasificacion = sqlcom1.Parameters("@INIdClasificacion").Value
        '    EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadMenuModulo1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadMenuModulo = EntidadMenuModulo1
        'End Try

    End Sub
    Public Overridable Sub Obtener(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadMenuModulo1 = New Entidad.MenuModulo()
        EntidadMenuModulo1 = EntidadMenuModulo
        EntidadMenuModulo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadMenuModulo1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica


                    sqlcom1 = New SqlCommand("ERP_ObtSegMod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadMenuModulo1.IdTipoUsuario))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
                Case Consulta.ConsultaPorIdPadre
                    'opciones por modulo
                    sqlcom1 = New SqlCommand("ERP_ConOpcModCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IdModulo", EntidadMenuModulo1.IdModulo))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadMenuModulo1.IdTipoUsuario))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
                Case Consulta.ConsultaPorFiltro
                    'acciones por opcion
                    sqlcom1 = New SqlCommand("ERP_ConTranOpcCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdOpcion", EntidadMenuModulo1.IdOpcion))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
                Case Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_ConOpcBas", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadMenuModulo1.IdTipoUsuario))
                    sqldat1.Fill(EntidadMenuModulo1.TablaConsulta)
            End Select

            EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMenuModulo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMenuModulo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMenuModulo = EntidadMenuModulo1
        End Try
    End Sub
End Class
