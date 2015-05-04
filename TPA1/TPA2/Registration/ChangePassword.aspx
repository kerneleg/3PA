<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TPA2.Registration.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:Panel ID="ForgotPanel" runat="server" CssClass="loginpanel">
            <div style="font-family: Arial">
                <table style="border: 2px solid black;width:40%">
                    <tr>
                        <td colspan="2">
                            <asp:Label Text="Change Password:" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>New Password
                        </td>
                        <td>:<asp:TextBox ID="txtNewPassword" TextMode="Password"
                            runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword"
                                runat="server" ErrorMessage="New Password required"
                                Text="*" ControlToValidate="txtNewPassword" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm New Password
                        </td>
                        <td>:<asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmNewPassword"
                                runat="server" ErrorMessage="Confirm New Password required" Text="*"
                                ControlToValidate="txtConfirmNewPassword"
                                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                ErrorMessage="New Password and Confirm New Password must match"
                                ControlToValidate="txtConfirmNewPassword" ForeColor="Red"
                                ControlToCompare="txtNewPassword"
                                Display="Dynamic" Type="String" Operator="Equal" Text="*">
                            </asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>&nbsp;<asp:Button ID="btnSave" runat="server"
                            Text="Save" OnClick="btnSave_Click" Width="70px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                ForeColor="Red" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>

        </asp:Panel>
    </form>
</asp:Content>
