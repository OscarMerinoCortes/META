Imports System.Data.SqlClient
Public Class Interes
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Actualizar

    End Sub

    Public Overridable Sub Consultar(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadInteres1 = New Entidad.Interes()
        EntidadInteres1 = EntidadInteres
        EntidadInteres1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadInteres1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTazIntDet", sqlcon1)
                    sqldat1.Fill(EntidadInteres1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTazIntBas", sqlcon1)
                    sqldat1.Fill(EntidadInteres1.TablaConsulta)
                Case Else
            End Select
            EntidadInteres1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadInteres1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadInteres1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadInteres = EntidadInteres1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Insertar

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class

