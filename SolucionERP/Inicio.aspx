<%@ Page Title="Página principal" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="_Inicio" UICulture="es-MX" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <script type="text/javascript">
        if(navigator.geolocation){
                navigator.geolocation.getCurrentPosition(coords);
        }else{
                // El navegador no soporta la geolicalización
        } 
        function coords(position){
                alert("Latitud: " +  position.coords.latitude);
                alert("Longitud: " +  position.coords.longitude);
        }
</script>--%>
    <table>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                 <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                 <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
