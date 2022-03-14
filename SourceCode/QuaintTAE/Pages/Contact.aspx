<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="QuaintTAE.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Contact"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="contacts">
                <div class="container">
                    <div class="row">
                        <div class="placetop col-sm-12">
                            <div class="row">
                                <div class="places">
                                    <h1>Get in Touch</h1>
                                    <hr>
                                </div>

                                <div class="clearfix"></div>

                                <form method="post" enctype="multipart/form-data">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <i class="fa fa-user"></i>
                                            <input type="text" name="username" value="name" placeholder="Name*" id="input-email" class="form-control" required="" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <i class="fa fa-envelope"></i>
                                            <input type="text" name="email" value="email" placeholder="email" id="email" class="form-control" required="" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <i class="fa fa-pencil"></i>
                                            <input type="text" name="subject" value="subject" placeholder="subject*" id="subject" class="form-control" required="" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <i class="fa fa-globe"></i>
                                            <input type="text" name="web" value="web" placeholder="website" id="web" class="form-control" required="" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <i class="fa fa-pencil-square-o"></i>
                                            <textarea class="form-control" id="message" name="message" placeholder="message" required=""></textarea>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <button type="submit" value="" class="btn btn-primary btn-block"><i class="fa fa-paper-plane" aria-hidden="true"></i>Send Message</button>
                                        </div>
                                    </div>
                                </form>

                                <div class="clearfix"></div>

                                <div class="col-sm-4 matter">
                                    <i class="fa fa-home" aria-hidden="true"></i>
                                    <div class="caption">
                                        <h3>Address</h3>
                                        <p>Zigatola, Dhanmondi, Dhaka</p>
                                    </div>
                                </div>
                                <div class="col-sm-4 matter">
                                    <i class="fa fa-phone" aria-hidden="true"></i>
                                    <div class="caption">
                                        <h3>phone no.</h3>
                                        <p>+88 01941738366<br>
                                            +88 01942142585</p>
                                    </div>
                                </div>
                                <div class="col-sm-4 matter">
                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                    <div class="caption">
                                        <h3>email</h3>
                                        <p>marufasruf2016@gmail.com<br>
                                            sabiaarefin2015@gmail.com</p>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="map">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d14606.93533415658!2d90.37954405!3d23.75686915!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sbd!4v1524413549535" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
