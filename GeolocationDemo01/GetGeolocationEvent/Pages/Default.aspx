<%-- Die folgenden vier Zeilen sind ASP.NET-Direktiven, die bei der Verwendung von SharePoint-Komponenten erforderlich sind. --%>

<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%-- Markup und Skript im folgenden Inhaltselement werden im <head> der Seite platziert. --%>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>

    <!-- Fügen Sie Ihre CSS-Stile der folgenden Datei hinzu. -->
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />

    <!-- Fügen Sie Ihr JavaScript der folgenden Datei hinzu. -->
    <script type="text/javascript" src="../Scripts/App.js"></script>

      <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <script type="text/javascript" src="file://C:\Users\michae\Documents\visual studio 2012\Projects\GetGeolocationEvent\GetGeolocationEvent\SP\MicrosoftAjax.js" />
        <script type="text/javascript" src="file://C:\Users\michae\Documents\visual studio 2012\Projects\GetGeolocationEvent\GetGeolocationEvent\SP\SP.Runtime.debug.js" />
        <script type="text/javascript" src="file://C:\Users\michae\Documents\visual studio 2012\Projects\GetGeolocationEvent\GetGeolocationEvent\SP\SP.debug.js" />
        <script type="text/javascript" src="file://C:\Users\michae\Documents\visual studio 2012\Projects\GetGeolocationEvent\GetGeolocationEvent\SP\SP.Core.debug.js" />
        <script type="text/javascript" src="file://C:\Users\michae\Documents\visual studio 2012\Projects\GetGeolocationEvent\GetGeolocationEvent\SP\SP.Ribbon.debug.js" />
    </asp:PlaceHolder>
    <SharePoint:ScriptLink ID="SPScriptLink" runat="server" LoadAfterUI="true" Localizable="false" Name="SP.js" />
</asp:Content>

<%-- Das Markup im folgenden Inhaltselement wird im TitleArea der Seite platziert. --%>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Map View
</asp:Content>

<%-- Markup und Skript im folgenden Inhaltselement werden im <body> der Seite platziert. --%>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">


    <div id='myMap' style="position:relative; width:400px; height:400px;" onclick="GetMap();"></div>
    <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>
    <script src="../Scripts/LoadBingMaps.js"></script>


</asp:Content>
