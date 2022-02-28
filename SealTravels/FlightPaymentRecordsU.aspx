<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightPaymentRecordsU.aspx.cs" Inherits="SealTravels.FlightPaymentRecordsU" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">

    <title>Flight Payment Records</title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="Assets/css/table-search.css" rel="stylesheet" />
    <link href="Assets/img/globe.png" rel="icon" />

</head>

<body style="font-family: Heebo">

    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="#">
                <div class="sidebar-brand-icon rotate-n-0">
                    <img src="Assets/img/globe2.png" width="30" height="30" />
                </div>
                <div class="sidebar-brand-text mx-3">Seal Travels</div>
            </a>

            <!-- Divider -->
            <hr class="sidebar-divider my-0">

            <!-- Nav Item - Dashboard -->
            <li class="nav-item active">
                <a class="nav-link" href="UserPage.aspx">
                    <i class="fa fa-user-alt"></i>
                    <span>Users Dashboard</span>
                </a>
            </li>

            <!-- Divider -->
            <hr class="sidebar-divider">

            <!-- Heading -->
            <div class="sidebar-heading">
                Interface
            </div>
            <!--Nav Item - FlightBooking Collapse Menu-->
            <li class="nav-item">
                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                    <i class="fa fa-plane"></i>
                    <span>Flight Booking</span>
                </a>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
                    <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Select</h6>
                        <a class="collapse-item" href="RoundtripBookingU.aspx">Book Roundtrip flight</a>
                        <a class="collapse-item" href="OnewayBookingU.aspx">Book Oneway flight</a>
                        <a class="collapse-item" href="RoundtripRecordsU.aspx">Roundtrip flight records</a>
                        <a class="collapse-item" href="OnewayRecords.aspxU">Oneway flight records</a>
                        <a class="collapse-item" href="FlightTicketRecordsU.aspx">Flight Tickets records</a>
                        <a class="collapse-item" href="FlightPaymentRecordsU.aspx">Flight Payment records</a>
                    </div>
                </div>
            </li>

            <!--Nav Item - HotelBooking Collapse Menu-->
            <li class="nav-item">
                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseUtilities" aria-expanded="true" aria-controls="collapseUtilities">
                    <i class="fa fa-hotel"></i>
                    <span>Hotel Booking</span>
                </a>
                <div id="collapseUtilities" class="collapse" aria-labelledby="headingUtilities" data-parent="#accordionSidebar">
                    <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Select</h6>
                        <a class="collapse-item" href="HotelBookingU.aspx">Book a hotel</a>
                        <a class="collapse-item" href="HotelRecordsU.aspx">Update a hotel booking</a>
                        <a class="collapse-item" href="HotelRecordsU.aspx">Hotel Booking records</a>
                    </div>
                </div>
            </li>



            <!--Nav Item - CarServices Collapse Menu-->
            <li class="nav-item">
                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePages" aria-expanded="true" aria-controls="collapsePages">
                    <i class="fa fa-car"></i>
                    <span>Car Services</span>
                </a>
                <div id="collapsePages" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                    <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header"><i class="fa fa-car" style="margin-right: 2px"></i>Car Companies:</h6>
                        <a class="collapse-item" href="#">Elite Car Services</a>
                        <a class="collapse-item" href="#">Renee Car Services</a>
                        <a class="collapse-item" href="#">Oregon Car Services</a>
                    </div>
                </div>
            </li>



            <!-- Divider -->
            <hr class="sidebar-divider d-none d-md-block">

            <!-- SIDEBAR Toggler (Sidebar) -->
            <div class="text-center d-none d-md-inline">
                <button class="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
        <!-- End of Sidebar -->
        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                    <!-- Sidebar Toggle (Topbar) -->
                    <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
                        <i class="fa fa-bars"></i>
                    </button>

                    <!-- Topbar Search -->
                    <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
                        <div class="input-group">
                            <input type="text" class="form-control bg-light small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
                            <div class="input-group-append">
                                <button class="btn-primary" type="button" style="border: none">
                                    <i class="fa fa-search"></i>
                                </button>
                            </div>
                        </div>
                    </form>


                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - Search Dropdown (Visible Only XS) -->
                        <li class="nav-item dropdown no-arrow d-sm-none">
                            <a class="nav-link dropdown-toggle" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fa fa-search"></i>
                            </a>


                            <div class="topbar-divider d-none d-sm-block"></div>

                            <!-- Nav Item - User Information -->
                            <li class="nav-item dropdown no-arrow">
                                <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <input runat="server" id="username" class="mr-2 d-none d-lg-inline text-gray-600 small" readonly="readonly" style="border: none; outline: none; text-align: right" />
                                    <img class="img-profile rounded-circle" src="Assets/img/globe.png">
                                </a>
                                <!-- Dropdown - User Information -->
                                <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                    <a class="dropdown-item" href="UserActivityLogU.aspx">
                                        <i class="fas fa-list fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Activity Log
                                    </a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="ChangePasswordU.aspx">
                                        <i class="fa fa-edit fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Change Password
                                    </a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                                        <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Logout
                                    </a>
                                </div>
                            </li>
                    </ul>

                </nav>
                <!-- End of Topbar -->

                <!--Begin Page Content-->
                <div class="container-fluid">

                    <!--Error Message-->
                    <label runat="server" class="alert-danger" id="errormessage" style="font-size: 15px; font-weight: bold"></label>

                    <form runat="server">

                        <div class="card shadow mb-4 my-2">
                            <div class="card-header py-3">
                                <h6 class="m-0 font-weight-bold text-primary">Flight Payments</h6>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">

                                    <div class="form-group">
                                        <input class="search pull-left" placeholder="Search for Payment" style="font-size: 13px" />
                                        <span class="counter pull-right"></span>
                                    </div>

                                    <asp:GridView CssClass="table-hover table-bordered results" ID="flightpaymentrecords" runat="server" ForeColor="#4e73df" Font-Size="13px" AutoGenerateColumns="false" DataKeyNames="Id">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="Id" HeaderStyle-Font-Bold="true" Visible="false" />
                                            <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="email" HeaderText="Email" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="paymentmethod" HeaderText="Payment Method" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="cardnumber" HeaderText="Card Number" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="cvv" HeaderText="CVV" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="expirydate" HeaderText="Expiry Date" HeaderStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="amount" HeaderText="Amount" HeaderStyle-Font-Bold="true" />
                                            <asp:CommandField HeaderText="EDIT" ShowEditButton="true" ShowCancelButton="false" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#4e73df" ControlStyle-ForeColor="White" ControlStyle-Width="80px" ControlStyle-Font-Size="13px" />
                                            <asp:CommandField HeaderText="DELETE" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#4e73df" ControlStyle-ForeColor="White" ControlStyle-Width="80px" ControlStyle-Font-Size="13px" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                    </form>

                </div>

                <!-- Footer -->
                <footer class="sticky-footer bg-white">
                    <div class="container my-auto">
                        <div class="copyright text-center my-auto">
                            <span>Copyright &copy;
                                <script>document.write(new Date().getFullYear());</script>
                            </span>
                        </div>
                    </div>
                </footer>
                <!-- End of Footer -->
                <!-- End of Main Content -->

            </div>
            <!-- End of Content Wrapper -->
        </div>
        <!-- End of Page Wrapper -->
        <!-- Scroll to Top Button-->
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fas fa-angle-up"></i>
        </a>

        <!-- Logout Modal-->
        <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                    <div class="modal-footer">
                        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                        <a class="btn btn-primary" href="../UserLogin.aspx">Logout</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="Assets/vendor/jquery/jquery.min.js"></script>
    <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="Assets/js/sb-admin-2.min.js"></script>
    <script src="Assets/js/tablesearch.js"></script>

</body>

</html>

