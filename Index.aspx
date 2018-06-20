<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Welcome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="content">
        <asp:RadioButtonList ID="rblChoose" runat="server" RepeatDirection="Horizontal" 
            Font-Bold="True" Font-Size="Large" ForeColor="#CCFF66" AutoPostBack="True" 
            onselectedindexchanged="rblChoose_SelectedIndexChanged">
           <%-- <asp:ListItem>Customer</asp:ListItem>--%>
            <asp:ListItem>Manager</asp:ListItem>
            <asp:ListItem>Customer</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Login ID="Login1" runat="server" Visible="false" BackColor="#FFFBD6" BorderColor="#FFDFAD" 
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="Large" ForeColor="#333333" Height="118px" TextLayout="TextOnTop" 
            Width="358px" onauthenticate="Login1_Authenticate">
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
        </asp:Login>
        <asp:Label ID="LabelError" runat="server" ></asp:Label>
    </div>
    </form>
</body>
</html>
