Imports System.Web.UI.MasterPage
Imports System.Data
Imports Operacion.Configuracion.Constante
Imports System.Web.UI.DataVisualization.Charting

Public Class WucGraficaCompra
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
        'SetAxisInterval(Chart2.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        SetAxisInterval(Chart4.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)
        'SetAxisInterval(Chart5.ChartAreas(0).AxisX, 1, DateTimeIntervalType.Days)

        Chart2.Legends(0).Enabled = True
        'Chart1.ChartAreas(0).AxisX.IsInterlaced = True
        Chart2.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart2.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart2.Legends(0).Enabled = True

        Chart3.Legends(0).Enabled = True
        'Chart1.ChartAreas(0).AxisX.IsInterlaced = True
        Chart3.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart3.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart3.Legends(0).Enabled = True

        Chart5.Legends(0).Enabled = True
        'Chart1.ChartAreas(0).AxisX.IsInterlaced = True
        Chart5.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart5.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart5.Legends(0).Enabled = True



        'Chart7.Series("Series1").IsValueShownAsLabel = True
        'Chart7.Legends(0).Enabled = True

        'Chart7.Legends("Default").LegendStyle = LegendStyle.Row
        'Chart7.Legends("Default").Docking = Docking.Bottom
        'Chart7.Legends("Default").Alignment = Drawing.StringAlignment.Center

        'Chart7.ChartAreas("ChartArea1").Position.Auto = False
        'Chart7.ChartAreas("ChartArea1").Position.Width = 55
        'Chart7.ChartAreas("ChartArea1").Position.Height = 55
        'Chart7.ChartAreas("ChartArea1").Position.X = 27
        'Chart7.ChartAreas("ChartArea1").Position.Y = 27

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

    'Protected Sub SqlDataSource5_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource5.Selecting
    '    e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    'End Sub

    'Protected Sub SqlDataSource6_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource6.Selecting
    '    e.Command.CommandTimeout = 120 'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    'End Sub

    'Protected Sub SqlDataSource7_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource7.Selecting
    '    e.Command.CommandTimeout = 120'Operacion.Configuracion.Constante.TiempoDeEspera.Grafica
    'End Sub

End Class
