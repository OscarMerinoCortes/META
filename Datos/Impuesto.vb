Imports System.Threading
Imports System.Data.SqlClient
Public Class Impuesto
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadImpuesto As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadImpuesto1 As New Entidad.Impuesto()
        'EntidadImpuesto1 = EntidadImpuesto
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActInsIVACod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdIva", EntidadImpuesto1.IdImpuesto))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVIVA", EntidadImpuesto1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadImpuesto1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadImpuesto1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadImpuesto1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadImpuesto1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadImpuesto = EntidadImpuesto1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadImpuesto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadImpuesto1 = New Entidad.Impuesto()
        EntidadImpuesto1 = EntidadImpuesto
        EntidadImpuesto1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadImpuesto1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConImpCod", sqlcon1)
                    sqldat1.Fill(EntidadImpuesto1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConImpCodId", sqlcon1) 'no se usa y no esta declarado el procedimiento
                    sqldat1.Fill(EntidadImpuesto1.TablaConsulta)
                Case Else
            End Select
            EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadImpuesto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadImpuesto = EntidadImpuesto1
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadImpuesto As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadImpuesto1 As New Entidad.Impuesto()
        EntidadImpuesto1 = EntidadImpuesto
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActInsImpCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdImpuesto", EntidadImpuesto1.IdImpuesto))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadImpuesto1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVImpuesto", EntidadImpuesto1.Impuesto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadImpuesto1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadImpuesto1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadImpuesto1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadImpuesto1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadImpuesto1.FechaActualizacion))
            If EntidadImpuesto1.IdImpuesto = 0 Then
                sqlcom1.Parameters(EntidadImpuesto1.IdImpuesto).Direction = ParameterDirection.InputOutput
            End If


            sqlcom1.ExecuteNonQuery()
            EntidadImpuesto1.IdImpuesto = sqlcom1.Parameters(EntidadImpuesto1.IdImpuesto).Value
            EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadImpuesto1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadImpuesto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadImpuesto = EntidadImpuesto1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
