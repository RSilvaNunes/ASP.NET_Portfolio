<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MockYourself.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- this space is for loading libraries and/or css files specific to this page. -->
</asp:Content>
<asp:Content ID="carousel" ContentPlaceHolderID="pageCarousel" runat="server">
    <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" runat="server" ID="carouselContainer">
            <div class="item active">
                <div class=""><img src="/img/carousel/androidCourse.jpg" width="100%"></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
            <div class="item">
                <div class=""><img src="/img/carousel/javaCourse.jpg" width="100%"></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
            <div class="item">
                <div class=""><img src="/img/carousel/vvnet.png" width="100%"></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
            <div class="item">
                <div class=""><img src="/img/carousel/web.png" width="100%"></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>
</asp:Content>


<asp:Content ID="content" ContentPlaceHolderID="pageContent" runat="server">
           <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12"">
                <h1 class="page-header">
                    Welcome to MockYourself!
                </h1>
                <p>MockYourself is an online platform for IT professionals to prepare for job interviews. Our Courses offer a broad range of must-know topics in the IT industry. No matter your level of seniority, we have the right training for you!<br /><br /><br /> </p>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-check"></i>Effective and to the point!</h4>
                    </div>
                    <div class="panel-body">
                        <p>Our courses cover all you need to know to succeed in your area of expertise. Stop wasting your time, energy and money on things you don't need to know. Learn what matters!</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-briefcase"></i>Get market-ready!</h4>
                    </div>
                    <div class="panel-body">
                        <p>From junior analysts to senior architects, our courses add valuable knowledge to all kinds of IT professionals. Tired of feeling stuck in your current job? Get ready to take your career to the next level!</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-money"></i>Pay once, access for life!</h4>
                    </div>
                    <div class="panel-body">
                        <p>Not only are our courses offered at a very competitive price, but they will be available to you forever and ever. If you ever forget, just go back anytime and have a quick recap!</p>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->

        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Why MockYourself?</h2>
            </div>
            <div class="col-md-6">
                <p>The modern IT industry is looking for high potential professionals. The bigger the challenge, the bigger the pay - and the bigger the competition. Our platform is:</p>
                <ul>
                    <li><strong>Perfect for students.</strong>
                    </li>
                    <li>Highly indicated for junior professionals.</li>
                    <li>Full of options for senior analysts and programmers.</li>
                    <li>Great for front-end, back-end, or full-stack development.</li>
                    <li>Satisfaction guaranteed.</li>
                </ul>
                <p><br />Plus, we're really cool people. Check out our courses and see for yourself!</p>
            </div>
            <div class="col-md-6">
                <img class="img-responsive" src="/img/yay.jpg" alt="">
            </div>
        </div>
        <!-- /.row -->

        <hr>

        <!-- Call to Action Section -->
        <div class="well">
            <div class="row">
                <div class="col-md-8">
                    <p>This is where your success starts. Are you ready to take your career to the next level? </p>
                </div>
                <div class="col-md-4">
                    <a class="btn btn-lg btn-default btn-block" href="Courses.aspx">YES!</a>
                </div>
            </div>
        </div>

       




</asp:Content>
