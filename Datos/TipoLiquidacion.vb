Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoLiquidacion
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoLiquidacion1 As New Entidad.TipoLiquidacion()
        EntidadTipoLiquidacion1 = EntidadTipoLiquidacion
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipLiqCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoLiquidacion", EntidadTipoLiquidacion1.IdTipoLiquidacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoLiquidacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoLiquidacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoLiquidacion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoLiquidacion1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoLiquidacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoLiquidacion = EntidadTipoLiquidacion1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoLiquidacion1 = New Entidad.TipoLiquidacion()
        EntidadTipoLiquidacion1 = EntidadTipoLiquidacion
        EntidadTipoLiquidacion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoLiquidacion1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipLiqDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoLiquidacion1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipLiqBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoLiquidacion1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoLiquidacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoLiquidacion = EntidadTipoLiquidacion1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoLiquidacion1 As New Entidad.TipoLiquidacion()
        EntidadTipoLiquidacion1 = EntidadTipoLiquidacion
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipLiqCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoLiquidacion", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoLiquidacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoLiquidacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoLiquidacion1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoLiquidacion1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoLiquidacion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoLiquidacion1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoLiquidacion1.IdTipoLiquidacion).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoLiquidacion1.IdTipoLiquidacion = sqlcom1.Parameters(EntidadTipoLiquidacion1.IdTipoLiquidacion).Value
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoLiquidacion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoLiquidacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoLiquidacion = EntidadTipoLiquidacion1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoLiquidacion As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
