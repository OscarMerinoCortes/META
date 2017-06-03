
Imports System.Diagnostics
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography

Partial Class _Inicio
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Tarjeta") Is Nothing Then
            Response.Redirect("/Account/Login.aspx")
        End If
        'Usuario
        'Label1.Text = My.Computer.Name.ToString
        ''Ipv6
        'Dim ip As System.Net.IPHostEntry
        'ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
        'Label2.Text = ip.AddressList(0).ToString
        ''IPv4
        'Dim localIp As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        'Label3.Text = localIp.AddressList(1).ToString
        ''mac
        'Label4.Text = getMacAddress()
    End Sub

    Private Function getMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For ' Got a mac so exit for
                        End If
                End Select
            Next adapter
            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


End Class
