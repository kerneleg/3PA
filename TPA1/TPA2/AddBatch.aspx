<%@ Page Title="Add New Batch" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddBatch.aspx.cs" Inherits="TPA2.AddBatch" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"
EnablePageMethods = "true">
</asp:ScriptManager>
    <h1 style="font-weight: bolder; font-size: xx-large;padding:15px">Add New Batch</h1>
    <table style="width: 50%; border: 2px solid black; empty-cells: show;padding-left:10px">
        <tr>
            <td style="padding-top: 10px;padding-left:10px">
                <asp:Label Text="Provider: " Font-Bold="true" ID="providerlbl" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Providertxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="Provider_AutoCompleteExtender" runat="server"
                     ServiceMethod="SearchProviders"
                    MinimumPrefixLength="2"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                    TargetControlID="Providertxt"
                    FirstRowSelected = "false">
                </cc1:AutoCompleteExtender>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-top: 10px;padding-left:10px">
                <asp:Label Text="Policy Holder: " Font-Bold="true" ID="Label1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PHoldertxt" runat="server" Height="16px" Width="164px" OnTextChanged="PHoldertxt_TextChanged" AutoPostBack="true"></asp:TextBox>
                <cc1:AutoCompleteExtender
                     ID="PHoldertxt_AutoCompleteExtender"
                     runat="server"
                     ServiceMethod="SearchHolders"
                    MinimumPrefixLength="2"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                    FirstRowSelected = "false"
                     TargetControlID="PHoldertxt">
                </cc1:AutoCompleteExtender>
            </td>
            <td>
                <asp:Label Text="Policy: " Font-Bold="true" ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="Policylist" runat="server" Width="150" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px;padding-left:10px">
                <asp:Label Text="Batch Type: " Font-Bold="true" ID="Label2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Inpatient"></asp:ListItem>
                    <asp:ListItem Text="Outpatient"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-top: 10px;padding-left:10px">
                <asp:Label Text="Receiving Date: " Font-Bold="true" ID="Label3" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="resultlbl" runat="server" ForeColor="Green"></asp:Label></td>
            <td>&nbsp;</td>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <asp:Button ID="Button1" runat="server" Text="Add" Font-Bold="true" Height="39px" Width="128px" OnClick="Add_Click" />
            </td>

        </tr>
    </table>
</asp:Content>
