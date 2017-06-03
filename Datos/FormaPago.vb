Imports System.Threading
Imports System.Data.SqlClient
Public Class FormaPago
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadFormaPago As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadFormaPago1 As New Entidad.FormaPago()
        EntidadFormaPago1 = EntidadFormaPago
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActForPagCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", EntidadFormaPago1.IdFormaPago))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadFormaPago1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadFormaPago1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadFormaPago1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadFormaPago1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadFormaPago1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadFormaPago = EntidadFormaPago1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadFormaPago As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadFormaPago1 = New Entidad.FormaPago()
        EntidadFormaPago1 = EntidadFormaPago
        EntidadFormaPago1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadFormaPago1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConForPagDet", sqlcon1)
                    sqldat1.Fill(EntidadFormaPago1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConForPagBas", sqlcon1)
                    sqldat1.Fill(EntidadFormaPago1.TablaConsulta)
                Case Else
            End Select
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadFormaPago1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadFormaPago = EntidadFormaPago1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadFormaPago As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadFormaPago1 As New Entidad.FormaPago()
        EntidadFormaPago1 = EntidadFormaPago
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsForPagCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadFormaPago1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadFormaPago1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadFormaPago1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadFormaPago1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadFormaPago1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadFormaPago1.FechaActualizacion))
            sqlcom1.Parameters(EntidadFormaPago1.IdFormaPago).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadFormaPago1.IdFormaPago = sqlcom1.Parameters(EntidadFormaPago1.IdFormaPago).Value
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadFormaPago1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadFormaPago1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadFormaPago = EntidadFormaPago1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
