<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MockYourself.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Contact
                </h1>
            </div>
            <div class="container">
        <p>Do you need help? That's what the MockYourself is for.<br /><br /></p>
        <div class="formcontainer">
            <table class="form">
                <tr>
                    <td class="tdform">First Name:</td>
                    <td><asp:TextBox ID="txtFirstName" class="textBox" runat="server"></asp:TextBox>
                        <span class="mandatory"><asp:Label ID="firstNameWarning" runat="server" /></span></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><asp:TextBox ID="txtLastName" class="textBox" runat="server"></asp:TextBox>
                        <span class="mandatory"><asp:Label ID="lastNameWarning" runat="server" /></span>
                    </td>
                </tr>
                <tr>
                    <td>E-Mail:</td>
                    <td><asp:TextBox ID="txtEmail" class="textBox" runat="server"></asp:TextBox>
                        <span class="mandatory"><asp:Label ID="emailWarning" runat="server" /></span>
                    </td>
                </tr>     
                <tr>
                    <td>Country:</td>
                    <td><asp:DropDownList ID="dropCountryList" CssClass="textBox" Height="26" runat="server"></asp:DropDownList>
                        <span class="mandatory"><asp:Label ID="countryWarning" runat="server" /></span>
                    </td>
                </tr>
                <tr>
                    <td>Reason for Inquiry:</td>
                    <td><asp:DropDownList ID="dropReasonList" CssClass="textBox" Height="26" runat="server"></asp:DropDownList>
                        <span class="mandatory"><asp:Label ID="reasonWarning" runat="server" /></span>
                    </td>
                </tr>
                <tr>
                    <td>What can we do for you?:</td>
                    <td><asp:TextBox ID="txtMessage" class="textBox" Height="120" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <span class="mandatory"><asp:Label ID="messageWarning" runat="server" /></span>
                    </td>
                </tr>                
            </table>
            <div class="buttonsContainer">
                <br /><br />
                <asp:Button ID="submitButton" class="btn btn-default formbutton" runat="server" Text="Submit" />
                <asp:Button ID="clearButton" class="btn btn-default formbutton" runat="server" Text="Clear" />
            </div>
        </div>
    </div>
     </div>
</asp:Content>
