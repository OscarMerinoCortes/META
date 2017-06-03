Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoEntrega
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoEntrega As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoEntrega1 As New Entidad.TipoEntrega()
        EntidadTipoEntrega1 = EntidadTipoEntrega
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipEntCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEntrega", EntidadTipoEntrega1.IdTipoEntrega))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoEntrega1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoEntrega1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoEntrega1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoEntrega1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEntrega1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEntrega = EntidadTipoEntrega1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoEntrega As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoEntrega1 = New Entidad.TipoEntrega()
        EntidadTipoEntrega1 = EntidadTipoEntrega
        EntidadTipoEntrega1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoEntrega1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEntDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoEntrega1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEntBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoEntrega1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEntrega1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEntrega = EntidadTipoEntrega1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoEntrega As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoEntrega1 As New Entidad.TipoEntrega()
        EntidadTipoEntrega1 = EntidadTipoEntrega
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipEntCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEntrega", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoEntrega1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoEntrega1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoEntrega1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoEntrega1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoEntrega1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoEntrega1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoEntrega1.IdTipoEntrega).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoEntrega1.IdTipoEntrega = sqlcom1.Parameters(EntidadTipoEntrega1.IdTipoEntrega).Value
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEntrega1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEntrega1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEntrega1 = EntidadTipoEntrega
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
