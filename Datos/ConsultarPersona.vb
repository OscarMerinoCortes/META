Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class ConsultarPersona
    Implements IPersona
    Public Sub Actualizar(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements IPersona.Actualizar
    End Sub

    Public Sub Consultar(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements IPersona.Consultar
        Dim EntidadConsultarPersona1 = New Entidad.ConsultarPersona()
        EntidadConsultarPersona1 = EntidadConsultarPersona
        EntidadConsultarPersona1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisPerIdDes", sqlcon1)
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadConsultarPersona1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVNombrePersona", EntidadConsultarPersona1.Nombre))
            sqldat1.Fill(EntidadConsultarPersona1.TablaConsulta)
            EntidadConsultarPersona1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadConsultarPersona1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadConsultarPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadConsultarPersona = EntidadConsultarPersona1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadConsultarPersona As Entidad.EntidadBase) Implements IPersona.Insertar
    End Sub

    Public Sub Obtener(ByRef EntidadConsultarPersona As Entidad.Persona) Implements IPersona.Obtener

    End Sub
End Class
