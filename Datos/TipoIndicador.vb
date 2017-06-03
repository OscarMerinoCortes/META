Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoIndicador
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadIndicadores1 As New Entidad.TipoIndicador()
        EntidadIndicadores1 = EntidadIndicadores
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActIndCivCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", EntidadIndicadores1.IdTipoIndicador))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadIndicadores1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIndicadores1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIndicadores1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIndicadores1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIndicadores1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIndicadores = EntidadIndicadores1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadIndicadores1 = New Entidad.TipoIndicador()
        EntidadIndicadores1 = EntidadIndicadores
        EntidadIndicadores1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadIndicadores1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipIndDet", sqlcon1)
                    sqldat1.Fill(EntidadIndicadores1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipIndBas", sqlcon1)
                    sqldat1.Fill(EntidadIndicadores1.TablaConsulta)
                Case Else
            End Select
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIndicadores1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIndicadores = EntidadIndicadores1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadIndicadores1 As New Entidad.TipoIndicador()
        EntidadIndicadores1 = EntidadIndicadores
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsIndCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadIndicadores1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIndicadores1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadIndicadores1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadIndicadores1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIndicadores1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIndicadores1.FechaActualizacion))
            sqlcom1.Parameters(EntidadIndicadores1.IdTipoIndicador).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadIndicadores1.IdTipoIndicador = sqlcom1.Parameters(EntidadIndicadores1.IdTipoIndicador).Value
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIndicadores1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIndicadores1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIndicadores = EntidadIndicadores1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
