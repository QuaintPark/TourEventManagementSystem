<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="QuaintTAE.Pages.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="About"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- bg start here -->
            <div class="bg">
                <%--<img src="../Assets/images/bg.jpg"" class="img-responsive" alt="bg" title="bg" />--%>
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="places">
                                <h1>we are the best travel agency</h1>
                                <hr>
                                <p>
                                    Our project is Smart tour plans. This System is a web based application.
                                    The main purpose of system is to provide a convenient way for a
                                    customer to find the path in less time at lower cost for tour purposes.
                                    Every day the interest in the tour is increasing. Our purpose is that the
                                    people can easily go for tour anywhere in less time at low cost and can
                                    conveniently walk around them .This existing system also gives tours
                                    related information like which places are tourist attractions, cities, and
                                    provinces. So we will create a software to implement that which every
                                    person can easily reach their destinations at low cost.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- bg end here-->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
