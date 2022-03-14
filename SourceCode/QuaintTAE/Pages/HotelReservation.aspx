<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelReservation.aspx.cs" Inherits="QuaintTAE.Pages.HotelReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Hotel Reservation"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- main container start here -->
            <div class="bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="places">
                                <h1>Book your hotel</h1>
                                <hr>
                                <div class="placetop">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtHotelName"> Hotel Name:<span>*</span></label>
                                                <asp:TextBox ID="txtHotelName" runat="server" CssClass="form-control" placeholder="Hotel Name" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtArrivalDate"> Arrival Date:<span>*</span></label>
                                                <asp:TextBox ID="txtArrivalDate" runat="server" CssClass="form-control datepicker" placeholder="Arrival Date" TextMode="Date" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtDepartureDate"> Departure Date:<span>*</span></label>
                                                <asp:TextBox ID="txtDepartureDate" runat="server" CssClass="form-control datepicker" placeholder="Departure Date" TextMode="Date" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtRoomType">Room Type:<span>*</span></label>
                                                <asp:TextBox ID="txtRoomType" runat="server" CssClass="form-control" placeholder="Single/ Double/ Semi-Double" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtBookedBy">Booked By:<span>*</span></label>
                                                <asp:TextBox ID="txtBookedBy" runat="server" CssClass="form-control" placeholder="Booked By" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Email:</label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtContactNumber">Contact Number:<span>*</span></label>
                                                <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" placeholder="Contact Number" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtAddress">Address:</label>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                            </div>
                                        </div>                                        
                                        <div class="col-sm-12">
                                            <%--<button class="btn-primary" type="submit">Confirm Booking</button>--%>
                                            <asp:Button ID="btnConfirm" runat="server" class="btn-primary" Text="Confirm Booking" OnClick="btnConfirm_Click" />
                                        </div>                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
