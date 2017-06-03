<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCUsuarioResumen.ascx.vb" Inherits="WUCUsuarioResumen" %>
<style type="text/css">
    .style3
    {
        width: 80px;
    }
    .PanelEmergenteContenido
    {}
</style>
                        <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0" class="PanelEmergenteTitulo">
                            <tr>
                                <td style="background-image: none; background-repeat: no-repeat; height: 25px; vertical-align: middle; text-align: left; color: #FFFFFF; font-size: 16px; font-family: Arial, Helvetica, sans-serif; font-weight: normal; background-color: #3A4F63;">
                                    &nbsp;&nbsp;&nbsp; Resumen de Usuario &nbsp;&nbsp; </td>

                            </tr>
                            </table>
                            <asp:Panel ID="PanelEstiloContenidoUsuarioResumen" runat="server" 
        CssClass="PanelEmergenteContenido">
                            <table style="width: 99%;"border="0" cellpadding="0" 
                                    cellspacing="0">
                            <tr>
                                <td class="style3" 
                                    style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td class="style3" 
                                    style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                                    ID
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label 
                                        ID="LidPersona" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3" 
                                    style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                                    Nombre
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label 
                                        ID="LNombre" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td class="style3" 
                                     style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                                    Telefono
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label 
                                        ID="LTelefono" runat="server"></asp:Label>
                                </td>
                            </tr>
                                <tr>
                                <td class="style3" 
                                        style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                                    Correo
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;<asp:Label 
                                        ID="LCorreo" runat="server"></asp:Label>
                                </td>
                            
                            </tr>
                            <tr>
                                <td class="style3">
                                    
                                </td>
                                <td align="right">
                                <br />
                                    <asp:Button ID="BTRegresar" runat="server" Text="Cancelar" 
                            CssClass="BotonRegresarPanelEmergenteContenido" />
                                <br />
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
