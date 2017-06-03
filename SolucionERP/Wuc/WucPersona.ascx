<%@ Control Language="vb" AutoEventWireup="false" CodeFile="WucPersona.ascx.vb" Inherits="WucPersona" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Wuc/WucConsultarPersonaCaja.ascx" TagName="wucConsultarPersonaCaja" TagPrefix="WUCPC" %>
<%--<%@ Register src="WucConsultarPersonaCaja.ascx" tagname="WucConsultarPersonaCaja" tagprefix="uc1" %>--%>
<table>
    <tr>
        <td>
            Id Cliente</td>
        <td>
            <asp:TextBox ID="TBIdPersona" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox>
            <asp:ImageButton ID="BTConsultarPersona" runat="server" ImageUrl="~/Imagenes/zoom.png" ToolTip="Buscar Persona" />
        </td>
        <td>
            &nbsp;&nbsp;<asp:HiddenField ID="HFConsultarPersona" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Equivalencia</td>
        <td>
            <asp:TextBox ID="TBEquivalencia" runat="server"
                BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            Nombre Cliente</td>
        <td colspan="2">
            <asp:TextBox ID="TBNombrePersona" runat="server" Width="300px"
                BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
    </tr>
</table>

    <asp:ModalPopupExtender ID="MPEConsultarPersona" runat="server" TargetControlID="BTConsultarPersona" PopupControlID="PanelConsultarPersona" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
    <asp:Panel ID="PanelConsultarPersona" runat="server" >
                <WUCPC:wucConsultarPersonaCaja ID="wucConsultarPersona1" runat="server" />
    </asp:Panel>

