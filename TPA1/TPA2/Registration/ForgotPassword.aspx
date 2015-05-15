<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TPA2.WebForm2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
        <asp:Panel ID="ForgotPanel" runat="server" CssClass="loginpanel"  >
            <table style="width: 40%; border-color:black; border:solid; border-width:2px; empty-cells:show" >
                <tr>
                        <td colspan="2" style="padding-top: 10px; padding-left:10px">
                            <asp:Label ID="Label1" Text="Forgot Password:" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
                        </td>
                    </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left:10px">
                        <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true"></asp:Label>
                    </td>
                    <td style="padding-top: 10px; padding-left:10px">
                        <asp:TextBox ID="Username" runat="server" Width="270px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="padding-top: 10px; padding-right:10px; vertical-align: middle; text-align: right">
                        <asp:Button ID="Forgotbtn" runat="server" Text="Submit" Width="145px" OnClick="Forgotbtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-bottom: 10px; padding-left:10px">
                    <asp:Label ID="Resultlbl" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                </tr>
            </table>
     </asp:Panel>
        
    </form>
</asp:Content>
