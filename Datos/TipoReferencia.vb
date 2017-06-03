Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoReferencia
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoReferencia1 As New Entidad.TipoReferencia()
        EntidadTipoReferencia1 = EntidadTipoReferencia
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActRefCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", EntidadTipoReferencia1.IdTipoReferencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoReferencia1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoReferencia1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoReferencia1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoReferencia1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoReferencia1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoReferencia = EntidadTipoReferencia1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoReferencia1 = New Entidad.TipoReferencia()
        EntidadTipoReferencia1 = EntidadTipoReferencia
        EntidadTipoReferencia1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoReferencia1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipRefDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoReferencia1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipRefBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoReferencia1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoReferencia1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoReferencia = EntidadTipoReferencia1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoReferencia1 As New Entidad.TipoReferencia()
        EntidadTipoReferencia1 = EntidadTipoReferencia
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsRefCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoReferencia1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoReferencia1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoReferencia1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoReferencia1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoReferencia1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoReferencia1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoReferencia1.IdTipoReferencia).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoReferencia1.IdTipoReferencia = sqlcom1.Parameters(EntidadTipoReferencia1.IdTipoReferencia).Value
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoReferencia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoReferencia1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoReferencia = EntidadTipoReferencia1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
