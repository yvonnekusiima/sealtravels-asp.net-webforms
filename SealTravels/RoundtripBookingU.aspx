<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoundtripBookingU.aspx.cs" Inherits="SealTravels.RoundtripBookingU" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />

    <title>Flight Booking - Roundtrip</title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />
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
                <!-- Begin Page Content -->
                <div class="container">
                    <!--Error Message-->
                    <label runat="server" class="alert-danger" id="errormessage" style="font-size: 15px; font-weight: bold"></label>

                    <div class="card o-hidden border-0 shadow-lg my-2">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-5 d-none d-lg-block bg-gradient-primary">
                                    <h1 style="font-weight: 700; margin-left: 100px; margin-top: 200px; color: white">Seal Travels <i class="fa fa-globe-americas"></i></h1>
                                </div>
                                <div class="col-lg-7">
                                    <div class="p-5">
                                        <div class="">
                                            <h4 class="" style="color: #4e73df; font-family: Heebo"><strong>Book a Roundtrip flight</strong> <i class="fa fa-plane"></i></h4>
                                            <br />
                                        </div>
                                        <!--Oneway Booking Form-->
                                        <form runat="server" class="user">

                                            <div class="form-group row">
                                                <!--Name-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Name</label>
                                                    <input runat="server" id="name" class="form-control" placeholder="Name" style="font-size: 13px;" />
                                                </div>

                                                <!--Email-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Email</label>
                                                    <input runat="server" id="email" class="form-control" placeholder="Email" style="font-size: 13px;" />
                                                </div>
                                            </div>

                                            <div class="form-group row">

                                                <!--Leaving From-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Leaving From</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="leavingfrom" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Nairobi</asp:ListItem>
                                                            <asp:ListItem>Kampala</asp:ListItem>
                                                            <asp:ListItem>Cairo</asp:ListItem>
                                                            <asp:ListItem>Kinshasa</asp:ListItem>
                                                            <asp:ListItem>Dodoma</asp:ListItem>
                                                            <asp:ListItem>Johannesburg</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>


                                                <!--Going To-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Going To</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="goingto" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Nairobi</asp:ListItem>
                                                            <asp:ListItem>Kampala</asp:ListItem>
                                                            <asp:ListItem>Cairo</asp:ListItem>
                                                            <asp:ListItem>Kinshasa</asp:ListItem>
                                                            <asp:ListItem>Dodoma</asp:ListItem>
                                                            <asp:ListItem>Johannesburg</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <!--Departing-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Departing</label>
                                                    <input runat="server" id="departing" class="form-control" placeholder="" type="date" style="font-size: 13px;" />
                                                </div>


                                                <!--Returning-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Returning</label>
                                                    <input runat="server" id="returning" class="form-control" placeholder="" type="date" style="font-size: 13px;" />
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <!--Adults-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Adults</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="adults" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>


                                                <!--Children-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Children</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="children" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>None</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <!--Trip Type-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">TripType</label>
                                                    <input runat="server" id="triptype" class="form-control" value="Roundtrip" style="font-size: 13px;" />
                                                </div>

                                                <!--Flight Type-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Flight Type</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="flighttype" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Nonstop</asp:ListItem>
                                                            <asp:ListItem>Refundable</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <!--Travel Class-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Travel Class</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="travelclass" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>First Class</asp:ListItem>
                                                            <asp:ListItem>Business</asp:ListItem>
                                                            <asp:ListItem>Economy</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <!--Airline-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Airline</label>
                                                    <div class="dropdown">
                                                        <asp:DropDownList ID="airline" runat="server" CssClass="form-control dropdown-toggle text-left" data-toggle="dropdown" Style="font-size: 13px">

                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Uganda Airlines</asp:ListItem>
                                                            <asp:ListItem>Kenya Airways</asp:ListItem>
                                                            <asp:ListItem>Ethiopia Airlines</asp:ListItem>
                                                            <asp:ListItem>Fly Dubai</asp:ListItem>
                                                            <asp:ListItem>Brussels Airlines</asp:ListItem>
                                                            <asp:ListItem>KLM</asp:ListItem>
                                                            <asp:ListItem>Qatar Airways</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <!--Contact-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Contact</label>
                                                    <input runat="server" id="contact" class="form-control" placeholder="Contact" style="font-size: 13px;" />
                                                </div>
                                                <!--Amount-->
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Amount</label>
                                                    <input runat="server" id="amount" class="form-control" placeholder="Amount" style="font-size: 13px;" />
                                                </div>
                                            </div>

                                            <!--Book-->
                                            <div>
                                                <asp:Button ID="bookflight" OnClick="bookflight_Click" runat="server" Text="BOOK FLIGHT" CssClass="btn btn-primary btn-block" Font-Bold="true" Font-Size="13px" />
                                            </div>

                                        </form>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- End of Main Content -->
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
            <!-- End of Content Wrapper -->
        </div>

        <!-- End of Page Wrapper -->
    </div>
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
                        <span aria-hidden="true">x</span>
                    </button>
                </div>
                <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary" href="UserLogin.aspx">Logout</a>
                </div>
            </div>
        </div>
    </div>


    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="Assets/vendor/jquery/jquery.min.js"></script>
    <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="Assets/js/sb-admin-2.min.js"></script>

</body>
</html>
