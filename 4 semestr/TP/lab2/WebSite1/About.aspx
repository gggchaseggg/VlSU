<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:DataList ID="NewList" runat="server">
        <ItemStyle BackColor="#99ccff" HorizontalAlign="Center"/>
        <AlternatingItemStyle BorderStyle="Double" BackColor="White" HorizontalAlign="Left"/>

        <ItemTemplate>
             <%# DataBinder.Eval(Container.DataItem, "Country")%>
        </ItemTemplate>
        <AlternatingItemTemplate >
             <%# DataBinder.Eval(Container.DataItem, "Duration")%>
             <%# DataBinder.Eval(Container.DataItem, "When") %>
        </AlternatingItemTemplate>
    </asp:DataList>

</asp:Content>
