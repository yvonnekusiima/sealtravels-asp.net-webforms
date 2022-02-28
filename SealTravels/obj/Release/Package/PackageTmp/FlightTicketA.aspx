<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightTicketA.aspx.cs" Inherits="SealTravels.FlightTicketA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Flight Ticket Form</title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="Assets/img/globe.png" rel="icon" />

</head>

<body style="font-family:Heebo">

    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-2">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">                             
                    <div class="col-lg-7">
                        <div class="p-3">
                            <div class="">                                                                
                                <form class="user">
                                    <div>
                                        <h5 class="m-0 text-primary" style="color:#4e73df; font-family:Heebo; float:left">
                                            <b>SEAL TRAVELS <i class="fa fa-globe-americas"></i></b>
                                            <strong style="font-size:15px">Flight Ticket & Itinerary</strong>                                           
                                        </h5>                                       
                                        <br />
                                        <hr />
                                        <div class="table-responsive">
                                                <table class="table-hover table-bordered results" style="font-size:13px">
                                                    <thead style="; font-weight:bold">
                                                        <tr>
                                                            <th>PASSENGER NAME</th>
                                                            <th>STATUS</th>
                                                            <th>CONTACT NO.</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody style="font-size:13px">
                                                        <tr>
                                                            <td>
                                                                <input runat="server" id="passengername" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                            <td>
                                                                <input runat="server" id="status" class="form-control" readonly="readonly" value="Confirmed" style="font-size: 13px; border:none" />
                                                            </td>
                                                             <td>
                                                                <input runat="server" id="contact" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table class="table-hover table-bordered results" style="font-size:13px">
                                                    <thead style="; font-weight:bold">
                                                        <tr>
                                                            <th>LEAVING FROM</th>
                                                            <th>GOING TO</th>
                                                            <th>EMAIL</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody style="font-size:13px">
                                                        <tr>
                                                            <td>
                                                                <input runat="server" id="leavingfrom" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                            <td>
                                                                <input runat="server" id="goingto" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                            <td>
                                                                <input runat="server" id="email" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table class="table-hover table-bordered results" style="font-size:13px">
                                                    <thead style="; font-weight:bold">
                                                        <tr>
                                                            <th>AIRLINE</th>
                                                            <th>TRAVEL CLASS</th>
                                                            <th>SEAT</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody style="font-size:13px">
                                                        <tr>
                                                            <td>
                                                                <input runat="server" id="airline" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                            <td>
                                                                <input runat="server" id="travelclass" class="form-control" readonly="readonly" style="font-size: 13px; border:none" />
                                                            </td>
                                                            <td>
                                                                <input runat="server" id="seat" class="form-control" placeholder="" style="font-size: 13px; border:none" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table class="table-hover table-bordered results" style="font-size:13px">
                                                    <thead style="; font-weight:bold">
                                                        <tr>
                                                            <th>FLIGHT</th>
                                                            <th>CHECK-IN</th>
                                                             <th>GATE</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody style="font-size:13px">
                                                        <tr>
                                                            <td>
                                                                <input runat="server" id="flight" class="form-control" placeholder="" style="font-size: 13px; border:none" />
                                                            </td>
                                                             <td>
                                                                <input runat="server" id="checkin" class="form-control" style="font-size: 13px; border:none" />
                                                            </td>
                                                             <td>
                                                                <input runat="server" id="gate" class="form-control" placeholder="" style="font-size: 13px; border:none" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>                
                                                <table class="table-hover table-bordered results" style="; float:left">
                                                    <thead style="; font-weight:bold">
                                                        <tr>
                                                            <th>DATE</th>                                                           
                                                        </tr>
                                                    </thead>
                                                    <tbody style="font-size:13px">
                                                        <tr>
                                                            <td>
                                                                <input runat="server" id="date" type="date" class="form-control" style="font-size: 13px; border:none" />
                                                            </td>                                                            
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div>
                                                    <img id="barcode" src="Assets/img/b2.jpg" width="205" height="60" />
                                                </div>
                                            </div>                                                                                
                                        </div>                                   
                                    </form>                           
                            </div>                           
                        </div>
                    </div>
                    <div class="col-lg-5 d-lg-block bg-gradient-primary">
                        <div class="p-3" style="color:white; ">
                            <h5 style="font-family:Heebo"><strong>Note:</strong></h5>
                            <p>&raquo We don't charge cancellation fess, if the airline charges cancellation fees it will be according to their poilices.</p>
                            <p>&raquo All timings are local</p></div>                      
                        <div class="p-3" style="color:white; ">
                            <h5 style="font-family:Heebo"><strong>Airline rules & regulations:</strong></h5>
                            <p>&raquo Gate closes 10 minutes before depature.</p>
                            <p>&raquo Name changes are not allowed.</p>
                            <p>&raquo Identfication is required.</p>
                        </div>            
                    </div>
                </div>
            </div>
        </div>
        <form runat="server" style="text-align:center">
            <asp:Button ID="printticket" runat="server" Text="PRINT TICKET" CssClass="btn btn-primary"  Font-Bold="true" />
            <asp:Button ID="saveticket" runat="server" Text="SAVE TICKET" CssClass="btn btn-primary"  Font-Bold="true" />
        </form>
        <br />
    </div>

    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="Assets/vendor/jquery/jquery.min.js"></script>
    <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="Assets/js/sb-admin-2.min.js"></script>

</body>
</html>
