Imports System.Threading
Imports System.Data.SqlClient
Imports Entidad

Public Class Usuario
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadUsuario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadUsuario1 As New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActUsuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVUsername", EntidadUsuario1.Username))
            sqlcom1.Parameters.Add(New SqlParameter("@IVAbreviacion", EntidadUsuario1.Abreviacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadUsuario1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadUsuario1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadUsuario1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadUsuario1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@INDia", EntidadUsuario1.Dia))
            sqlcom1.Parameters.Add(New SqlParameter("@INMes", EntidadUsuario1.Mes))
            sqlcom1.Parameters.Add(New SqlParameter("@INAno", EntidadUsuario1.Ano))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadUsuario1.IdTipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadUsuario1.IdSucursal))
            'sqlcom1.Parameters.Add(New SqlParameter("@IVClave", EntidadUsuario1.Clave))
            sqlcom1.Parameters.Add(New SqlParameter("@IVVigencia", EntidadUsuario1.Vigencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVCorreo", EntidadUsuario1.Correo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", EntidadUsuario1.Telefono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadUsuario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUsuario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUsuario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadUsuario = EntidadUsuario1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadUsuario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadUsuario1 = New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        EntidadUsuario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadUsuario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_ConUsuCod", sqlcon1)
                    sqldat1.Fill(EntidadUsuario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_ConUsuBas", sqlcon1)
                    sqldat1.Fill(EntidadUsuario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    'Dim sqldat1 As New SqlDataAdapter("ERP_ConUsuPermOp", sqlcon1)
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
                    ' sqldat1.Fill(EntidadUsuario1.TablaConsulta)
                    'Permisos se fue a seguridad
                    'sqlcom1 = New SqlCommand("ERP_ConUsuPermOp", sqlcon1)
                    'sqldat1 = New SqlDataAdapter(sqlcom1)
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdUsuario", EntidadUsuario1.IdUsuario))
                    'sqldat1.Fill(EntidadUsuario1.TablaConsulta)

            End Select
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadUsuario = EntidadUsuario1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadUsuario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadUsuario1 As New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsUsuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVUsername", EntidadUsuario1.Username))
            sqlcom1.Parameters.Add(New SqlParameter("@IVAbreviacion", EntidadUsuario1.Abreviacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadUsuario1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadUsuario1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadUsuario1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadUsuario1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@INDia", EntidadUsuario1.Dia))
            sqlcom1.Parameters.Add(New SqlParameter("@INMes", EntidadUsuario1.Mes))
            sqlcom1.Parameters.Add(New SqlParameter("@INAno", EntidadUsuario1.Ano))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadUsuario1.IdTipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadUsuario1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@IVClave", EntidadUsuario1.Clave))
            sqlcom1.Parameters.Add(New SqlParameter("@IVVigencia", EntidadUsuario1.Vigencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVCorreo", EntidadUsuario1.Correo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", EntidadUsuario1.Telefono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadUsuario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadUsuario1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadUsuario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUsuario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUsuario1.FechaActualizacion))
            sqlcom1.Parameters("@INIdUsuario").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadUsuario1.IdUsuario = sqlcom1.Parameters("@INIdUsuario").Value
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadUsuario = EntidadUsuario1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub






    '----------------------Seguridad------------------------------------
    Public Sub InsertarPermisoOpcion(ByRef EntidadUsuario As Entidad.EntidadBase)
        Dim EntidadUsuario1 As New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsPerUsuOpc", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioPermiso", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INGuardar", EntidadUsuario1.Guardar))
            sqlcom1.Parameters.Add(New SqlParameter("@INActualizar", EntidadUsuario1.Actualizar))
            sqlcom1.Parameters.Add(New SqlParameter("@INConsultar", EntidadUsuario1.Consultar))
            sqlcom1.Parameters.Add(New SqlParameter("@INCancelar", EntidadUsuario1.Cancelar))
            sqlcom1.Parameters.Add(New SqlParameter("@INExportar", EntidadUsuario1.Exportar))
            sqlcom1.Parameters.Add(New SqlParameter("@INImprimir", EntidadUsuario1.Imprimir))
            sqlcom1.Parameters.Add(New SqlParameter("@INAplicar", EntidadUsuario1.Aplicar))
            sqlcom1.Parameters.Add(New SqlParameter("@INCatalogos", EntidadUsuario1.Catalogo))
            sqlcom1.Parameters.Add(New SqlParameter("@INProceso", EntidadUsuario1.Proceso))
            sqlcom1.Parameters.Add(New SqlParameter("@INReporte", EntidadUsuario1.Reporte))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadUsuario1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadUsuario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUsuario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUsuario1.FechaActualizacion))
            sqlcom1.Parameters(EntidadUsuario1.IdTipoUsuario).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadUsuario1.IdTipoUsuario = sqlcom1.Parameters(EntidadUsuario1.IdTipoUsuario).Value
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadUsuario = EntidadUsuario1
        End Try
    End Sub

    Public Sub ActualizarPermisoOpcion(ByRef EntidadUsuario As Entidad.EntidadBase)
        Dim EntidadUsuario1 As New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActPerUsuOpc", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioPermiso", EntidadUsuario1.IdTipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INGuardar", EntidadUsuario1.Guardar))
            sqlcom1.Parameters.Add(New SqlParameter("@INActualizar", EntidadUsuario1.Actualizar))
            sqlcom1.Parameters.Add(New SqlParameter("@INConsultar", EntidadUsuario1.Consultar))
            sqlcom1.Parameters.Add(New SqlParameter("@INCancelar", EntidadUsuario1.Cancelar))
            sqlcom1.Parameters.Add(New SqlParameter("@INExportar", EntidadUsuario1.Exportar))
            sqlcom1.Parameters.Add(New SqlParameter("@INImprimir", EntidadUsuario1.Imprimir))
            sqlcom1.Parameters.Add(New SqlParameter("@INAplicar", EntidadUsuario1.Aplicar))
            sqlcom1.Parameters.Add(New SqlParameter("@INCatalogos", EntidadUsuario1.Catalogo))
            sqlcom1.Parameters.Add(New SqlParameter("@INProceso", EntidadUsuario1.Proceso))
            sqlcom1.Parameters.Add(New SqlParameter("@INReporte", EntidadUsuario1.Reporte))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUsuario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUsuario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadUsuario = EntidadUsuario1
        End Try
    End Sub

    Public Sub ConsultarVenta(ByRef entidadUsuario As EntidadBase)
        Dim EntidadUsuario1 = New Entidad.Usuario()
        EntidadUsuario1 = entidadUsuario
        EntidadUsuario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcom1 = New SqlCommand("ERP_ConVenUsuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqldat1.Fill(EntidadUsuario1.TablaConsulta)

            If EntidadUsuario1.TablaConsulta.Rows.Count > 0 Then
                EntidadUsuario1.PrimerNombre = EntidadUsuario1.TablaConsulta.Rows(0).Item("PrimerNombre")
                EntidadUsuario1.SegundoNombre = EntidadUsuario1.TablaConsulta.Rows(0).Item("SegundoNombre")
                EntidadUsuario1.ApellidoPaterno = EntidadUsuario1.TablaConsulta.Rows(0).Item("ApellidoPaterno")
                EntidadUsuario1.ApellidoMaterno = EntidadUsuario1.TablaConsulta.Rows(0).Item("ApellidoMaterno")
                EntidadUsuario1.Correo = EntidadUsuario1.TablaConsulta.Rows(0).Item("Correo")
            Else
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadUsuario1.Tarjeta.Excepcion = "Consulta sin registros"
            End If

            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            entidadUsuario = EntidadUsuario1
        End Try
    End Sub
End Class
