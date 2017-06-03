Imports System.Web.UI.MasterPage
Imports System.Data
Imports Operacion.Configuracion.Constante
Imports System.Web.UI.DataVisualization.Charting

Public Class WucGraficaCXP
    Inherits UserControl


    Public Sub SetAxisInterval(ByVal axis As Axis, ByVal interval As Double, ByVal intervalType As DateTimeIntervalType)
        ' Set interval-related properties
        axis.Interval = interval
        axis.IntervalType = intervalType
        'axis.IntervalOffset = intervalOffset
        'axis.IntervalOffsetType = intervalOffsetType
    End Sub 'SetAxisInterval
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAxisInterval(Chart1.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        SetAxisInterval(Chart2.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        SetAxisInterval(Chart4.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        SetAxisInterval(Chart5.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        Chart6.Series("Series1").IsValueShownAsLabel = True
        Chart7.Series("Series1").IsValueShownAsLabel = True
        Chart6.Legends(0).Enabled = True
        Chart7.Legends(0).Enabled = True

        Chart6.Legends("Default").LegendStyle = LegendStyle.Row
        Chart6.Legends("Default").Docking = Docking.Bottom
        Chart6.Legends("Default").Alignment = Drawing.StringAlignment.Center
        Chart7.Legends("Default").LegendStyle = LegendStyle.Row
        Chart7.Legends("Default").Docking = Docking.Bottom
        Chart7.Legends("Default").Alignment = Drawing.StringAlignment.Center

        Chart6.ChartAreas("ChartArea1").Position.Auto = False
        Chart6.ChartAreas("ChartArea1").Position.Width = 55
        Chart6.ChartAreas("ChartArea1").Position.Height = 55
        Chart6.ChartAreas("ChartArea1").Position.X = 27
        Chart6.ChartAreas("ChartArea1").Position.Y = 27

        Chart7.ChartAreas("ChartArea1").Position.Auto = False
        Chart7.ChartAreas("ChartArea1").Position.Width = 55
        Chart7.ChartAreas("ChartArea1").Position.Height = 55
        Chart7.ChartAreas("ChartArea1").Position.X = 27
        Chart7.ChartAreas("ChartArea1").Position.Y = 27

        'Dim Tabla As New DataTable
        'Dim NegocioMovimiento As New Negocio.CREMovimiento()
        'Dim EntidadConsultarMovimiento As New Entidad.Movimiento()
        'EntidadConsultarMovimiento.Tarjeta = Session("Tarjeta")
        'EntidadConsultarMovimiento.FechaInicio = EntidadConsultarMovimiento.Tarjeta.FechaTrabajo
        'NegocioMovimiento.GraficaDeConceptosCierre(EntidadConsultarMovimiento)
        'Tabla = EntidadConsultarMovimiento.TablaConsulta

        ' Chart3.ChartAreas(0).AxisX.Interval = 1
        'Chart1.ChartAreas(0).AxisX.IsInterlaced = True
        'Chart3.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        'Chart3.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        'Chart3.Legends(0).Enabled = True
        'Chart3.DataSource = Tabla

        'If Not Page.IsPostBack Then
        '    MultiView1.SetActiveView(View1)
        'End If

    End Sub
    Protected Sub SqlDataSource1_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

    Protected Sub SqlDataSource4_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

    Protected Sub SqlDataSource5_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource5.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

    Protected Sub SqlDataSource6_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource6.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

    Protected Sub SqlDataSource7_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource7.Selecting
        e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    End Sub

End Class
