<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MockYourself.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
                <h1 class="page-header">
                    Cart
                </h1>
            <p><asp:Label ID="lblMessage" runat="server" /><br /><br /></p>
            </div>
            <div class="container">
                <p style="color: white;"></p>
                    <div class="panel-heading" style="margin-left:auto; margin-right:auto; width: 872px; height: 209px;">
                        <h4>
                            <asp:GridView ID="grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="850" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="Course Name" HeaderText="Course Name" SortExpression="Course Name" />
                                    <%--<asp:BoundField DataField="Course Description" HeaderText="Course Description" SortExpression="Course Description" />--%>
                                    <%--<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />--%>
                                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" />
                                    <%--<asp:TemplateField HeaderText="Remove Item">            
                                        <ItemTemplate>
                                            <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                                        </ItemTemplate>        
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>                
                            <br /><br />
                        </h4>

                    </div>
                    <div class="panel-body" style="margin-left:auto; margin-right:auto; width: 872px; height: 102px;">
                        <div>
                        <strong>
                            <br /><br /><br />
                            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
                            <br /><br /><br />
                        </strong> 
                    </div>
                    <br />
                        <div style="margin-left:auto; margin-right:auto; width: 420px; height: 30px;">
                            <asp:Button ID="btnPurchase" class="btn btn-default formbutton add-to-cart" runat="server" Text="Proceed to Payment" align="center" OnClick="btnPurchase_Click" Width="180px"/>
                            <asp:Button ID="btnCancel" class="btn btn-default formbutton" runat="server" Text="Cancel" align="center" Width="180px" OnClick="btnCancel_Click"/> 
                        </div>
                    </div>
                </div>     
        <div style="height: 200px;"></div>
    </div>
</asp:Content>
