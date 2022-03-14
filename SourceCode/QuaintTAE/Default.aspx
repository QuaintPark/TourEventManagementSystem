<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuaintTAE.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Home"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- slider start here -->
            <div class="slice">
                <div class="slideshow owl-carousel">
                    <div class="item">
                        <img src="Assets/images/banner1.jpg" class="img-responsive" />
                    </div>
                    <div class="item">
                        <img src="Assets/images/banner1.jpg" class="img-responsive" />
                    </div>
                    <div class="item">
                        <img src="Assets/images/banner1.jpg" class="img-responsive" />
                    </div>
                    <div class="item">
                        <img src="Assets/images/banner1.jpg" class="img-responsive" />
                    </div>
                </div>
            </div>
            <!-- slider end here -->

            <!-- Event start here -->
            <div class="placetop">
                <div class="container">
                    <div class="row">
                        <div class="places col-sm-12">
                            <div class="pull-left">
                                <h1>Events</h1>
                                <hr />
                                <div class="bor"></div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <asp:Repeater ID="rptrEvent" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="product-thumb">
                                        <div class="caption">
                                            <div class="inner">
                                                <h3><%# Eval("Title") %></h3>
                                                <h5 class="fa fa-calendar-check-o">From Date : <%# Convert.ToDateTime(Eval("FromDate")).ToString("dd-MMM-yyyy") %></h5>
                                                <h5 class="fa fa-calendar-check-o">To Date : <%# Convert.ToDateTime(Eval("ToDate")).ToString("dd-MMM-yyyy") %></h5>
                                            </div>
                                            <div class="button-login">
                                                <a runat="server" class="btn btn-default btn-lg" href='<%# string.Format("~/Pages/Registration.aspx?Id=" + QuaintPark.QuaintSecurityManager.EncryptUrl(Eval("LocationId").ToString())) %>'>Booking Now</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <hr>
                    </div>
                </div>
            </div>
            <!-- event end here -->

            <!-- video start here -->
            <div class="video">
                <img src="Assets/images/video-bg.jpg" class="img-responsive" alt="video-bg" title="video-bg" />
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="matter text-center">
                                <h5>Awesome Experiences for</h5>
                                <h6>Tourism & Traveling.</h6>
                                <a class="play-btn popup-youtube wow bounceInUp" data-wow-duration="2s" data-wow-delay=".1s" href="https://www.youtube.com/watch?v=LMbQsI1PKVw"><i class="fa fa-play" aria-hidden="true"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- video end here -->


            <!-- testimonial start here -->
            <%--<div class="testimonail">
                <div class="container">
                    <div class="row">
                        <div class="places">
                            <h1>what travelers are saying</h1>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas a suscipit quam, ut vestibulum lorem.</p>
                            <hr>
                        </div>
                        <div class="testimonails owl-carousel">
                            <div class="item">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="box">
                                        <img src="Assets/images/pic1.png" alt="pic1" title="pic1" class="img-responsive" />
                                        <div class="caption">
                                            <h4>John William</h4>
                                            <div class="rate">
                                                <div class="pull-right">
                                                    <span>FROM CANADA</span>
                                                </div>
                                                <div class="pull-left">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star-half-o" aria-hidden="true"></i>
                                                </div>
                                            </div>
                                            <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut cursus suscipit malesuada. Cras nec hendrerit lacus. Curabitur nec elementum justo. Sed vitae dapibus augue."</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="box">
                                        <img src="Assets/images/pic2.png" alt="pic2" title="pic2" class="img-responsive" />
                                        <div class="caption">
                                            <h4>John William</h4>
                                            <div class="rate">
                                                <div class="pull-right">
                                                    <span>FROM CANADA</span>
                                                </div>
                                                <div class="pull-left">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star-half-o" aria-hidden="true"></i>
                                                </div>
                                            </div>
                                            <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut cursus suscipit malesuada. Cras nec hendrerit lacus. Curabitur nec elementum justo. Sed vitae dapibus augue."</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="box">
                                        <img src="Assets/images/pic1.png" alt="pic1" title="pic1" class="img-responsive" />
                                        <div class="caption">
                                            <h4>John William</h4>
                                            <div class="rate">
                                                <div class="pull-right">
                                                    <span>FROM CANADA</span>
                                                </div>
                                                <div class="pull-left">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star-half-o" aria-hidden="true"></i>
                                                </div>
                                            </div>
                                            <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut cursus suscipit malesuada. Cras nec hendrerit lacus. Curabitur nec elementum justo. Sed vitae dapibus augue."</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="box">
                                        <img src="Assets/images/pic2.png" alt="pic2" title="pic2" class="img-responsive" />
                                        <div class="caption">
                                            <h4>John William</h4>
                                            <div class="rate">
                                                <div class="pull-right">
                                                    <span>FROM CANADA</span>
                                                </div>
                                                <div class="pull-left">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star-half-o" aria-hidden="true"></i>
                                                </div>
                                            </div>
                                            <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut cursus suscipit malesuada. Cras nec hendrerit lacus. Curabitur nec elementum justo. Sed vitae dapibus augue."</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- testimonial end here -->

            <!-- logo start here -->
            <div class="logo">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-xs-12">
                            <ul class="list-inline">
                                <li>
                                    <img src="Assets/images/logo_1.png" class="img-responsive" alt="logo" title="logo"></li>
                                <li>
                                    <img src="Assets/images/logo_2.png" class="img-responsive" alt="logo" title="logo"></li>
                                <li>
                                    <img src="Assets/images/logo_3.png" class="img-responsive" alt="logo" title="logo"></li>
                                <li>
                                    <img src="Assets/images/logo_4.png" class="img-responsive" alt="logo" title="logo"></li>
                                <li>
                                    <img src="Assets/images/logo_5.png" class="img-responsive" alt="logo" title="logo"></li>
                                <li>
                                    <img src="Assets/images/logo_6.png" class="img-responsive" alt="logo" title="logo"></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- logo end here -->

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
