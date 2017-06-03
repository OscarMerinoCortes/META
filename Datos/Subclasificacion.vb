Imports System.Data.SqlClient
Imports Entidad
Imports Operacion.Configuracion.Constante

Public Class Subclasificacion
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadSubclasificacion As EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadSubclasificacion1 As New Entidad.Subclasificacion()
        EntidadSubclasificacion1 = EntidadSubclasificacion
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActSubClaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadSubclasificacion1.IdSubclasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadSubclasificacion1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadSubclasificacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INGanancia", EntidadSubclasificacion1.Ganancia))
            sqlcom1.Parameters.Add(New SqlParameter("@INPorcentaje", EntidadSubclasificacion1.Porcentaje))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSubclasificacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSubclasificacion1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSubclasificacion1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSubclasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubclasificacion = EntidadSubclasificacion1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadSubclasificacion As EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadSubclasificacion1 = New Entidad.Subclasificacion()
        EntidadSubclasificacion1 = EntidadSubclasificacion
        EntidadSubclasificacion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadSubclasificacion1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSubClaDet", sqlcon1)
                    sqldat1.Fill(EntidadSubclasificacion1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSubClaBas", sqlcon1)
                    sqldat1.Fill(EntidadSubclasificacion1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSubClaCod", sqlcon1)
                    sqldat1.SelectCommand = SqlComParametros(EntidadSubclasificacion1, "ERP_ConSubClaCod", sqlcon1)
                    sqldat1.Fill(EntidadSubclasificacion1.TablaConsulta)
                Case Consulta.ConsultaDetalladaPorId
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSubClaCodId", sqlcon1)
                    sqldat1.SelectCommand = SqlComParametros(EntidadSubclasificacion1, "ERP_ConSubClaCodId", sqlcon1)
                    sqldat1.Fill(EntidadSubclasificacion1.TablaConsulta)
            End Select
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSubclasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubclasificacion = EntidadSubclasificacion1
        End Try
    End Sub
    Private Function SqlComParametros(ByVal EntidadSubclasificacion As Entidad.EntidadBase, ByVal Procedimiento As String, ByVal SqlCon As SqlConnection) As SqlCommand
        Dim EntidadSubclasificacion1 = New Entidad.Subclasificacion()
        EntidadSubclasificacion1 = EntidadSubclasificacion
        EntidadSubclasificacion1.TablaConsulta = New DataTable()
        Dim sqlcom As New SqlCommand(Procedimiento, SqlCon)
        sqlcom.CommandType = CommandType.StoredProcedure
        sqlcom.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadSubclasificacion1.IdClasificacion))
        Return sqlcom
    End Function
    Public Overridable Sub Insertar(ByRef EntidadSubclasificacion As EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadSubclasificacion1 As New Entidad.Subclasificacion()
        EntidadSubclasificacion1 = EntidadSubclasificacion
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsSubClaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadSubclasificacion1.IdSubclasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadSubclasificacion1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadSubclasificacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INGanancia", EntidadSubclasificacion1.Ganancia))
            sqlcom1.Parameters.Add(New SqlParameter("@INPorcentaje", EntidadSubclasificacion1.Porcentaje))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSubclasificacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadSubclasificacion1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadSubclasificacion1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSubclasificacion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSubclasificacion1.FechaActualizacion))
            sqlcom1.Parameters("@INIdSubclasificacion").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadSubclasificacion1.IdSubclasificacion = sqlcom1.Parameters("@INIdSubclasificacion").Value
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSubclasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSubclasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubclasificacion = EntidadSubclasificacion1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadSubclasificacion As EntidadBase) Implements ICatalogo.Obtener
    End Sub
    Public Overridable Sub ObtenerFiltro(ByRef EntidadSubclasificacion As EntidadBase)
        Dim EntidadSubclasificacion1 As New Entidad.Subclasificacion()
        EntidadSubclasificacion1 = EntidadSubclasificacion
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadSubclasificacion.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_ConSubFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadSubclasificacion1.IdSubclasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadSubclasificacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadSubclasificacion1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSubclasificacion1.IdEstado))
            sqldat1.Fill(EntidadSubclasificacion.TablaConsulta)
            EntidadSubclasificacion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadSubclasificacion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadSubclasificacion.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
