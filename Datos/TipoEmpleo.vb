Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoEmpleo
    Implements ICatalogo

    Public Sub Actualizar(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoEmpleo1 As New Entidad.TipoEmpleo()
        EntidadTipoEmpleo1 = EntidadTipoEmpleo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipEmpCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", EntidadTipoEmpleo1.IdTipoEmpleo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoEmpleo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoEmpleo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoEmpleo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoEmpleo1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEmpleo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEmpleo = EntidadTipoEmpleo1
        End Try
    End Sub

    Public Sub Consultar(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoEmpleo1 As New Entidad.TipoEmpleo()
        EntidadTipoEmpleo1 = EntidadTipoEmpleo
        EntidadTipoEmpleo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoEmpleo.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEmpDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoEmpleo1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEmpBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoEmpleo1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEmpleo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEmpleo = EntidadTipoEmpleo1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoEmpleo1 As New Entidad.TipoEmpleo()
        EntidadTipoEmpleo1 = EntidadTipoEmpleo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipEmpCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoEmpleo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoEmpleo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoEmpleo1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoEmpleo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoEmpleo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoEmpleo1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoEmpleo1.IdTipoEmpleo).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoEmpleo1.IdTipoEmpleo = sqlcom1.Parameters(EntidadTipoEmpleo1.IdTipoEmpleo).Value
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoEmpleo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoEmpleo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoEmpleo = EntidadTipoEmpleo1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
