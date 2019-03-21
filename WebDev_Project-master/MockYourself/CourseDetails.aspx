<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="MockYourself.CourseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <asp:hyperlink runat="server" NavigateUrl="~/Courses.aspx" style="color:#222f3e;text-decoration:underline" >Courses</asp:hyperlink> - <asp:Label ID="lblCourseName" runat="server" Text="Label"></asp:Label>
            </h1>
            <div style="display:flex">
                <div style="flex-basis:80%">                
                <p>
                    <asp:label ID="lblCourseDescription" runat="server" text="Label"></asp:label>
                </p>           
                </div>
                <div style="float:right;margin-left:20px">
                    <div class="price-box">
                        <div class="price-label">Price:</div>
                        <div class="priceTag" style="flex-basis:15%;min-width:320px;">
                            <asp:label id="lblCoursePrice" runat="server" text="Label"></asp:label>
                        </div>
                        <hr />                                                
                        <asp:Button Text="Add to cart" runat="server" ID="btnAddToCart" CssClass="btn btn-default add-to-cart" OnClick="btnAddToCart_Click" />
                        <asp:Button Text="Checkout" runat="server" ID="btnCheckout" CssClass="btn btn-default btn-checkout" OnClick="btnCheckout_Click" />
                    </div>                   
                </div>
            </div>    
        </div> 
         
    </div>
</asp:Content>


