<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MockYourself.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerBarLinkContainer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pageContent" runat="server">
     <div class="row">
         <div class="col-lg-12">
             <h1 class="page-header">
                Users
             </h1>
             <div>
                 
             </div>
             <h1 class="page-header">
                Courses
             </h1>  
             <div>
                 <div class="newItem">
                    <asp:Label ID="lblCourseName" runat="server" Text="Name: "></asp:Label><br />
                     <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox><br />
                      <asp:Label ID="lblCoursePrice" runat="server" Text="Price: "></asp:Label><br />
                     <asp:TextBox ID="txtCoursePrice" runat="server" MaxLength="7" Width="80px" Text="0.00" ></asp:TextBox><br />
                    <asp:Label ID="lblCourseDescription" runat="server" Text="Description: "></asp:Label><br />
                     <textarea runat="server" id="txtCourseDescr" cols="20" rows="5"></textarea><br /><br />
                     <asp:Button ID="Button1" runat="server" Text="Add New Course" OnClick="Button1_Click" />
                </div>
                <asp:PlaceHolder ID="CoursesContainer" runat="server"></asp:PlaceHolder>
             </div>
             <h1 class="page-header">
                Quizzes
             </h1>
             <div>

             </div>
             <br />
         </div>         
        
     </div>
</asp:Content>
