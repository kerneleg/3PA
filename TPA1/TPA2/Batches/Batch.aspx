<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Batch.aspx.cs" Inherits="TPA2.Batches.Batch" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <h1 style="font-weight: bolder; font-size: xx-large; padding: 15px">Batch ID: 
        <asp:Label ID="BatchTitle" runat="server" Text="Label"></asp:Label></h1>
    <table style="width: 50%; border: 2px solid black; empty-cells: show; padding-left: 10px;empty-cells:show">
        <tr>
            <td style="padding-top: 10px; padding-left: 10px">
                <asp:Label Text="Provider: " Font-Bold="true" ID="providerlbl" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ProviderTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
            <td>
                <asp:Label Text="Batch Type: " Font-Bold="true" ID="Label2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="BatchTypeTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-left: 10px">
                <asp:Label Text="Policy Holder: " Font-Bold="true" ID="Label1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PHolderTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
            <td>
                <asp:Label Text="Policy: " Font-Bold="true" ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PolicyTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-left: 10px">
                <asp:Label Text="Receiving Date: " Font-Bold="true" ID="Label3" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ReceivingDateTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
            <td>
                <asp:Label Text="Creation Date: " Font-Bold="True" ID="Label5" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CreationDateTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-left: 10px">
                <asp:Label Text="Starting Date: " Font-Bold="True" ID="Label7" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="StartingDateText" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
            <td>
                <asp:Label Text="Ending Date:" Font-Bold="True" ID="Label8" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="EndingDateText" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-left: 10px; padding-bottom: 10px">
                <asp:Label Text="Creator:" Font-Bold="True" ID="Label6" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CreatorTxt" runat="server" Height="16px" Width="164px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <h1 style="font-weight: bolder; font-size: xx-large; padding: 15px">Claims</h1>
    <asp:Panel ID="UnderInPanel" runat="server" Width="90%" Visible="false" CssClass="claimpanels">
        <asp:GridView ID="UnderInGrid" runat="server" AutoGenerateColumns="False" DataSourceID="GetClaimUnderInSDS" EmptyDataText="No Claims Available" Width="90%" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="5" AllowPaging="True" AllowSorting="True" BackColor="White" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                <asp:BoundField DataField="Claim No" HeaderText="Claim No" InsertVisible="False" ReadOnly="True" SortExpression="Claim No" />
                <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No" />
                <asp:BoundField DataField="Starting Date" HeaderText="Starting Date" SortExpression="Starting Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Ending Date" HeaderText="Ending Date" SortExpression="Ending Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Gross" HeaderText="Gross" SortExpression="Gross" DataFormatString="{0:0,0.00}" />
                <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" DataFormatString="{0:0,0.00}" />
                <asp:BoundField DataField="Deductable" HeaderText="Deductable" SortExpression="Deductable" DataFormatString="{0:0,0.00}" />
                <asp:BoundField DataField="Net" HeaderText="Net" ReadOnly="True" SortExpression="Net" DataFormatString="{0:0,0.00}" />
                <asp:CheckBoxField DataField="Modification" HeaderText="Modification" SortExpression="Modification" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="GetClaimUnderInSDS" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ahmed\Documents\GitHub\3PA-----13-5-2015\TPA1\TPA2\Database\TPA.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="GetClaimsUnderIn" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="batch" QueryStringField="b" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="UnderOutPanel" runat="server" Width="90%" Visible="false" CssClass="claimpanels">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"  CellPadding="5" CellSpacing="5" DataSourceID="GetClaimUnderOutSDS" ForeColor="Black" GridLines="Vertical" Width="90%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                <asp:BoundField DataField="Claim No" HeaderText="Claim No" InsertVisible="False" ReadOnly="True" SortExpression="Claim No" />
                <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No" />
                <asp:BoundField DataField="Starting Date" DataFormatString="{0:d}" HeaderText="Starting Date" SortExpression="Starting Date" />
                <asp:BoundField DataField="Gross" HeaderText="Gross" SortExpression="Gross" />
                <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
                <asp:BoundField DataField="Deductable" HeaderText="Deductable" SortExpression="Deductable" />
                <asp:BoundField DataField="Net" HeaderText="Net" ReadOnly="True" SortExpression="Net" />
                <asp:CheckBoxField DataField="Modification" HeaderText="Modification" SortExpression="Modification" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="GetClaimUnderOutSDS" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ahmed\Documents\GitHub\3PA-----13-5-2015\TPA1\TPA2\Database\TPA.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="GetClaimsUnderOut" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="batch" QueryStringField="b" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="ApprovalInPanel" runat="server" Visible="false" Width="90%" CssClass="claimpanels">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="5" DataSourceID="GetClaimApprovalInSDS" ForeColor="Black" GridLines="Vertical" Width="90%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                <asp:BoundField DataField="Claim No" HeaderText="Claim No" InsertVisible="False" ReadOnly="True" SortExpression="Claim No" />
                <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No" />
                <asp:BoundField DataField="Starting Date" DataFormatString="{0:d}" HeaderText="Starting Date" SortExpression="Starting Date" />
                <asp:BoundField DataField="Ending Date" DataFormatString="{0:d}" HeaderText="Ending Date" SortExpression="Ending Date" />
                <asp:BoundField DataField="Net" DataFormatString="{0:0,0.00}" HeaderText="Net" ReadOnly="True" SortExpression="Net" />
                <asp:BoundField DataField="Approved" DataFormatString="{0:0,0.00}" HeaderText="Approved" SortExpression="Approved" />
                <asp:BoundField DataField="Diff" DataFormatString="{0:0,0.00}" HeaderText="Diff" SortExpression="Diff" />
                <asp:BoundField DataField="Denied" DataFormatString="{0:0,0.00}" HeaderText="Denied" SortExpression="Denied" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="GetClaimApprovalInSDS" runat="server" ConnectionString="<%$ ConnectionStrings:TPAConnectionString %>" SelectCommand="GetClaimsApprovalIn" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="batch" QueryStringField="b" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="ApprovalOutPanel" runat="server" Visible="false" Width="90%" CssClass="claimpanels">
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="GetClaimsApprovalOutSDS" ForeColor="Black" GridLines="Vertical" Width="90%" CellSpacing="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                <asp:BoundField DataField="Claim No" HeaderText="Claim No" InsertVisible="False" ReadOnly="True" SortExpression="Claim No" />
                <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No" />
                <asp:BoundField DataField="Starting Date" DataFormatString="{0:d}" HeaderText="Starting Date" SortExpression="Starting Date" />
                <asp:BoundField DataField="Net" DataFormatString="{0:0,0.00}" HeaderText="Net" ReadOnly="True" SortExpression="Net" />
                <asp:BoundField DataField="Approved" DataFormatString="{0:0,0.00}" HeaderText="Approved" SortExpression="Approved" />
                <asp:BoundField DataField="Diff" DataFormatString="{0:0,0.00}" HeaderText="Diff" SortExpression="Diff" />
                <asp:BoundField DataField="Denied" DataFormatString="{0:0,0.00}" HeaderText="Denied" SortExpression="Denied" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="GetClaimsApprovalOutSDS" runat="server" ConnectionString="<%$ ConnectionStrings:TPAConnectionString %>" SelectCommand="GetClaimsApprovalOut" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="batch" QueryStringField="b" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="AddClaimPanel" runat="server" Visible="false" CssClass="claimpanels">
        <table style="width:50%; border: 2px solid black; empty-cells:show; padding-left:20px;padding-top:20px">
            <tr>
                <td><h1 style="font-weight: bolder; font-size:large; padding-left: 10px;padding-top:15px"> Patient ID:</h1></td>
                <td>
                    <asp:TextBox ID="ClientIDTxt" runat="server" AutoPostBack="True" OnTextChanged="ClientIDTxt_TextChanged"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="ClientIDTxt_AutoCompleteExtender" runat="server" 
                        ServiceMethod="SearchPatientID"
                    MinimumPrefixLength="1"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                     FirstRowSelected = "false"
                        TargetControlID="ClientIDTxt">
                    </cc1:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="ClientIdRFV" runat="server" ErrorMessage="*" ControlToValidate="ClientIDTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td><h1 style="font-weight: bolder; font-size:large;padding-left: 10px;padding-top:15px"> Patient Name:</h1></td>
                <td>
                    <asp:TextBox ID="ClientNameTxt" runat="server" OnTextChanged="ClientNameTxt_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="ClientNameTxt_AutoCompleteExtender" runat="server"
                         ServiceMethod="SearchPatientName"
                    MinimumPrefixLength="1"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                     FirstRowSelected = "false"
                        TargetControlID="ClientNameTxt">
                    </cc1:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="ClientNameRFV" runat="server" ErrorMessage="*" ControlToValidate="ClientNameTxt" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                  <td><h1 style="font-weight: bolder; font-size:large; padding-left: 10px;padding-top:15px">Invoice No:</h1></td>
                <td>
                    <asp:TextBox ID="InvoiceTxt" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="InvoiceRFV" runat="server" ControlToValidate="InvoiceTxt" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                 <td>
                     <h1 style="font-weight: bolder; font-size: large; padding-left: 10px; padding-top: 15px">Starting Date:</h1></td>
                <td>
                    <asp:Calendar ID="StartingCalendar" runat="server"></asp:Calendar>
                </td>
                <td><h1 style="font-weight: bolder; font-size:large; padding-left: 10px;padding-top:15px">Ending Date:</h1></td>
                <td>
                    <asp:Calendar ID="EndingCalendar" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                 <td>&nbsp;</td>
                <td>&nbsp;</td>
                 <td style="padding-bottom:10px;padding-bottom:10px">
                     <asp:Button ID="Button1" runat="server" Text="Add Claim" Font-Bold="true" Width="141px" Height="39px" />
                 </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
