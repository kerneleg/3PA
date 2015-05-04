<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPA2.Account.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
        <asp:Panel ID="Panel1" runat="server" CssClass="loginpanel"  >
            <table style="width: 40%; border-color:black; border:solid; border-width:2px" >
                <tr >
                    <td style="padding-top: 7px; padding-left:10px">
                        <asp:Label ID="Username" runat="server" Font-Bold="true" Text="Username:"></asp:Label>
                    </td> 
                    <td style="padding-top: 10px; padding-left:10px">
                        <asp:TextBox ID="Usernametxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:10px">
                    
                        <asp:Label ID="Passlbl" runat="server" Font-Bold="true" Text="Password:"></asp:Label>
                    </td>
                    <td style="padding-left:10px">
                        <asp:TextBox ID="Passtxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px; height: 21px;">
                        <asp:CheckBox ID="Rememberme" Text="Remember Me" runat="server" />
                    </td>
                    <td style="padding-left:10px; height: 21px;">
                        <asp:Button ID="Loginbtn" runat="server" Text="Login" OnClick="Loginbtn_Click" Width="77px" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:10px; padding-bottom:10px">
                        <asp:HyperLink ID="Forgotlink" runat="server" NavigateUrl="~/ForgotPassword.aspx">Forgot Password?</asp:HyperLink>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            
        </asp:Panel>
        
    </form>
</asp:Content>
