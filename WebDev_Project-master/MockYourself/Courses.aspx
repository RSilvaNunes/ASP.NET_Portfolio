<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="MockYourself.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Courses</h1>
            <p>MockYourself offers a robust catalog of professional development and continuing education training. From Agile and Scrum to Windows Systems, we offer over various IT courses covering the most trending and unique IT certification paths — and we're always adding more. Our IT courses are offered as online training giving you the flexibility you need. You'll gain access to elite instructors and an unmatched hands-on experience. So, let's get ready to grow your career.</p>
            <hr />
            <asp:PlaceHolder ID="CourseBoxes" runat="server"></asp:PlaceHolder>
        </div>           
    </div>
</asp:Content>
