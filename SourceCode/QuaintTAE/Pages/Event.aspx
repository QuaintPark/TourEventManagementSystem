<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="QuaintTAE.Pages.Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Event"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section id="rates" class="rates common-page">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="places">
                        <h1>Choose Your Tour</h1>
                        <hr>
                    </div>
                </div>
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
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
