Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text
Imports Entidad
Imports Operacion.Configuracion.Constante
Public Class Dashboard
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Actualizar

    End Sub
    Public Sub Consultar(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Consultar

    End Sub
    Public Sub Insertar(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Insertar

    End Sub

    Public Sub ObtenerDashboardVentas(ByRef EntidadDashboard As Entidad.EntidadBase)
        Dim EntidadDashboard1 = New Entidad.Dashboard()
        EntidadDashboard1 = EntidadDashboard
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadDashboard1.DasboardOpcion
                Case DasboardOpcion.Grafica1
                    sqlcom1 = New SqlCommand("ERP_ObtVenAnoCan", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica1 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader(), True)
                Case DasboardOpcion.Grafica2
                    sqlcom1 = New SqlCommand("ERP_ObtVenAnoMon", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica2 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica3
                    sqlcom1 = New SqlCommand("ERP_ObtVenMesSuc", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica3 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica4
                    sqlcom1 = New SqlCommand("ERP_ObtVenMesVen", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica4 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica5
                    sqlcom1 = New SqlCommand("ERP_ObtVenMesCla", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica5 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica6
                    sqlcom1 = New SqlCommand("ERP_ObtVenMesPro", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica6 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
            End Select
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadDashboard1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDashboard = EntidadDashboard1
        End Try
    End Sub
    Public Sub ObtenerDashboardCompras(ByRef EntidadDashboard As Entidad.EntidadBase)
        Dim EntidadDashboard1 = New Entidad.Dashboard()
        EntidadDashboard1 = EntidadDashboard
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadDashboard1.DasboardOpcion
                Case DasboardOpcion.Grafica1
                    sqlcom1 = New SqlCommand("ERP_LisNumComp", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica1 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader(), True)
                Case DasboardOpcion.Grafica2
                    sqlcom1 = New SqlCommand("ERP_LisMonComp", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica2 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica3
                    sqlcom1 = New SqlCommand("ERP_LisCompProv", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica3 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica4
                    sqlcom1 = New SqlCommand("ERP_LisComProd", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica4 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica5
                    sqlcom1 = New SqlCommand("ERP_LisComClas", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica5 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
            End Select
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadDashboard1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDashboard = EntidadDashboard1
        End Try
    End Sub
    Public Sub ObtenerDashboardCaja(ByRef EntidadDashboard As Entidad.EntidadBase)
        Dim EntidadDashboard1 = New Entidad.Dashboard()
        EntidadDashboard1 = EntidadDashboard
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadDashboard1.DasboardOpcion
                Case DasboardOpcion.Grafica1
                    sqlcom1 = New SqlCommand("ERP_LisNumCXC", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica1 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader(), True)
                Case DasboardOpcion.Grafica2
                    sqlcom1 = New SqlCommand("ERP_LisMonCXC", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica2 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica3
                    sqlcom1 = New SqlCommand("ERP_LisEstMesCXC", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica3 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica4
                    sqlcom1 = New SqlCommand("ERP_LisNumCXCEst", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica4 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica5
                    sqlcom1 = New SqlCommand("ERP_LisCXCConCob", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica5 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
                Case DasboardOpcion.Grafica6
                    sqlcom1 = New SqlCommand("ERP_LisSalCXCEst", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    'En esta linea se ejecuta el reader y se convierte a string con formato json
                    EntidadDashboard1.TablaGrafica6 = Comun.Presentacion.Herramientas.ConvierteSqlDataReaderAJSON(sqlcom1.ExecuteReader())
            End Select
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadDashboard1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadDashboard1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDashboard = EntidadDashboard1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadDashboard As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
