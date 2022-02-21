<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425</address>
    <address>
        &nbsp;</address>
    <address>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </address>
    <address>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="211px"></asp:TextBox>
    </address>
    <address>
        <a href="mailto:Support@example.com">
        <strong>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="216px" />
        </strong></a>
    </address>

    <address>
        <strong>Support:</strong> <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    <address>
        &nbsp;</address>
    <address>
        .555.0100
    </address>
    <address>
        &nbsp;</address>
    <address>
        &nbsp;</address>
    <address>
        &nbsp;</address>

    </asp:Content>
