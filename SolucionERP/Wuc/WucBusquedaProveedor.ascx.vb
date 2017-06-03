Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class Wuc_WebUserControl
    Inherits System.Web.UI.UserControl

    Public ArregloProveedor() As String
    Public Shared StringArregloProveedor As String
    Public total As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MUWucConsultaProveedor.SetActiveView(VWProveedor)
        End If
        LlenarArregloProveedor()
    End Sub
    '//////////Espacio para implementacion del WUC por Proveedores//////////
    Public Sub ObtenerPersona(ByRef IdPersona As Integer, ByRef Equivalencia As String, ByRef RazonSocial As String)

        Dim EntidadConsultarProveedor As New Entidad.Proveedor
        Dim NegocioConsultarProveedor As New Negocio.Proveedor
        Dim Proveedores = Session("WucProveedorSeleccion")



        Try
            Dim Indice As Integer
            Dim RazonSocial2 As String
            Dim Equivalencia2 As String
            Try

                Dim Limitador = "-------"
                Indice = TBBNombreProveedor.Value.IndexOf(Limitador) + 8
                RazonSocial2 = TBBNombreProveedor.Value.Substring(Indice)
                Equivalencia2 = TBBNombreProveedor.Value.Remove(Indice - 9)
            Catch
                Indice = 0
                RazonSocial2 = ""
                Equivalencia2 = ""
            End Try

            EntidadConsultarProveedor.IdProveedor = IdPersona
            EntidadConsultarProveedor.Equivalencia = Equivalencia2
            EntidadConsultarProveedor.PrimerNombre = ""
            EntidadConsultarProveedor.RazonSocial = RazonSocial2
            EntidadConsultarProveedor.Tarjeta.Consulta = Consulta.ConsultaPorFiltro
            NegocioConsultarProveedor.ConsultarProveedor(EntidadConsultarProveedor)

            Try
                If Proveedores = Nothing Then
                    Proveedores = New ObservableCollection(Of Entidad.WucProveedorSeleccion)
                End If
            Catch ex As Exception
                Proveedores.Clear()
            End Try
            Dim fila As Entidad.WucProveedorSeleccion
            For Each row In EntidadConsultarProveedor.TablaConsulta.Rows
                fila = New Entidad.WucProveedorSeleccion
                fila.IdProveedor = CInt(row("ID"))
                fila.Equivalencia = CStr(row("Equivalencia"))
                fila.RazonSocial = CStr(row("RazonSocial"))
                Proveedores.Add(fila)

                IdPersona = CInt(fila.IdProveedor)
                Equivalencia = fila.Equivalencia
                RazonSocial = fila.RazonSocial
                Exit For
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AsignarPersona(Equivalencia As String, RazonSocial As String)
        TBBNombreProveedor.Value = Equivalencia + " ------- " + RazonSocial
    End Sub


    Public Sub RegresarFoco()
        TBBNombreProveedor.Value = ""
        TBBNombreProveedor.Focus()
    End Sub

    '////////////////////////////////////////////////////////////////

    Public Sub LlenarArregloProveedor()
        Dim EntidadProveedor1 = New Entidad.Proveedor()
        Dim NegocioProveedor = New Negocio.Proveedor()
        Dim TablaProveedor As New DataTable()
        EntidadProveedor1.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioProveedor.Consultar(EntidadProveedor1)
        TablaProveedor = EntidadProveedor1.TablaConsulta
        Dim total As Integer

        total = TablaProveedor.Rows.Count - 1
        ReDim ArregloProveedor(0 To total)
        For i = 0 To total
            ArregloProveedor(i) = "'" + TablaProveedor.Rows(i)(0) + " ------- " + TablaProveedor.Rows(i)(1) + "'"
        Next

        StringArregloProveedor = Join(ArregloProveedor, ",")

    End Sub


End Class
