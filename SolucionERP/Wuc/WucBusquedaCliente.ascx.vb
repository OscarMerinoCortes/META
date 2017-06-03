Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class Wuc_WebUserControl
    Inherits System.Web.UI.UserControl

    Public ArregloCliente() As String
    Public Shared StringArregloCliente As String
    Public total As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MUWucConsultaCliente.SetActiveView(VWCliente)
        End If
        LlenarArregloCliente()
    End Sub
    '//////////Espacio para implementacion del WUC por Proveedores//////////
    Public Function ObtenerIdPersona() As String

        Dim EntidadConsultarCliente As New Entidad.Persona
        Dim NegocioConsultarCliente As New Negocio.Persona
        Dim Clientes = Session("WucBusquedaCliente")
        Dim IdPersona As String

        Try
            Dim Filtro As String
            Dim IndiceFecha As Integer
            Dim NombreFinal As String
            Dim FechaNacimiento As String

            Try

                IndiceFecha = TBBNombreCliente.Value.IndexOf(" __________ ")
                NombreFinal = TBBNombreCliente.Value.Remove(IndiceFecha)
                FechaNacimiento = TBBNombreCliente.Value.Remove(0, IndiceFecha + 12)

            Catch
                NombreFinal = ""
                FechaNacimiento = ""
            End Try

            EntidadConsultarCliente.IdPersona = 0
            EntidadConsultarCliente.NombreCompleto = NombreFinal.Replace(" ", "")
            EntidadConsultarCliente.FechaNacimiento = FechaNacimiento
            EntidadConsultarCliente.Tarjeta.Consulta = Consulta.ConsultaPorNombreCompleto
            NegocioConsultarCliente.Consultar(EntidadConsultarCliente)

            Try
                If Clientes = Nothing Then
                    Clientes = New ObservableCollection(Of Entidad.WucBusquedaCliente)
                End If
            Catch ex As Exception
                Clientes.Clear()
            End Try
            Dim fila As Entidad.WucBusquedaCliente
            For Each row In EntidadConsultarCliente.TablaConsulta.Rows
                fila = New Entidad.WucBusquedaCliente
                fila.IdPersona = CInt(row("IdPersona"))
                IdPersona = CInt(row("IdPersona"))
                fila.NombreCliente = CStr(row("NombreCliente"))
                fila.FechaNacimiento = CDate(row("FechaNacimiento"))
                Clientes.Add(fila)
                Exit For
            Next
            Return IdPersona
        Catch ex As Exception

        End Try

    End Function

    Public Function ObtenerNombrePersona() As String

        Dim Filtro As String
        Dim IndiceFecha As Integer
        Dim NombreFinal As String
        Dim FechaNacimiento As String

        Try

            IndiceFecha = TBBNombreCliente.Value.IndexOf(" __________ ")
            NombreFinal = TBBNombreCliente.Value.Remove(IndiceFecha)
            FechaNacimiento = TBBNombreCliente.Value.Remove(0, IndiceFecha + 12)

        Catch
            NombreFinal = ""
            FechaNacimiento = ""
        End Try
        Return NombreFinal
    End Function
    Public Sub Limpiar()
        TBBNombreCliente.Value = ""
    End Sub
    Public Sub RegresarFoco()
        TBBNombreCliente.Value = ""
        TBBNombreCliente.Focus()
    End Sub

    Public Sub ObtenerPersona(ByRef IdPersona As Integer, ByRef Equivalencia As String, ByRef Nombre As String)
        IdPersona = CInt(IIf(ObtenerIdPersona() Is String.Empty, 0, ObtenerIdPersona()))
        Equivalencia = ""
        Nombre = IIf(ObtenerNombrePersona() Is String.Empty, "0", ObtenerNombrePersona)
    End Sub

    Public Sub AsignarPersona(Nombre As String)
        TBBNombreCliente.Value = Nombre
    End Sub
    '////////////////////////////////////////////////////////////////

    Public Sub LlenarArregloCliente()
        Dim EntidadCliente1 = New Entidad.Persona
        Dim NegocioCliente = New Negocio.Persona
        Dim TablaCliente As New DataTable
        EntidadCliente1.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioCliente.Consultar(EntidadCliente1)
        TablaCliente = EntidadCliente1.TablaConsulta

        Dim total As Integer
        total = TablaCliente.Rows.Count - 1
        ReDim ArregloCliente(0 To total)
        For i = 0 To total
            ArregloCliente(i) = "'" + TablaCliente.Rows(i)(2) + " __________ " + TablaCliente.Rows(i)(3) + "'"
        Next

        StringArregloCliente = Join(ArregloCliente, ",")

    End Sub


End Class
