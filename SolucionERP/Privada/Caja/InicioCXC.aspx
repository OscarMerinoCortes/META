<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="InicioCXC.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCGraficaCXC.ascx" TagName="wucGraficaCXC" TagPrefix="WUCGC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <WUCGC:wucGraficaCXC ID="wucGraficaCXC1" runat="server" />
</asp:Content>
