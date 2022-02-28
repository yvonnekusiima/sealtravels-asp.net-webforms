<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightPayment.aspx.cs" Inherits="SealTravels.FlightPayment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />

    <title>Flight Payment</title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="Assets/img/globe.png" rel="icon" />

</head>

<body style="font-family: Heebo">

    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-gradient-primary">
                        <h1 style="font-weight: 700; margin-left: 100px; margin-top: 180px; color: white">Seal Travels <i class="fa fa-globe-americas"></i></h1>
                    </div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div>
                                <h4 style="color: #4e73df; font-family: Heebo"><strong>Payment Information</strong> <i class="fa fa-credit-card"></i></h4>
                                <br />
                            </div>

                            <!--Payment Information Form-->
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
                                    <!--Payment Method-->

                                    <div class="form-check float-left" style="color: #4e73df; font-weight: bold; font-size: 13px;">
                                        <input type="radio" runat="server" id="visacard" />
                                        Visa Card
                                    </div>
                                    <div class="form-check float-left" style="color: #4e73df; font-weight: bold; font-size: 13px;">
                                        <input type="radio" runat="server" id="americanexpress" />
                                        American Express
                                    </div>
                                    <div class="form-check float-left" style="color: #4e73df; font-weight: bold; font-size: 13px;">
                                        <input type="radio" runat="server" id="mastercard" />
                                        Master Card
                                    </div>

                                </div>

                                <div class="form-group row">
                                    <!--Card Number-->
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Card Number</label>
                                        <input runat="server" id="cardnumber" class="form-control" placeholder="Card Number" style="font-size: 13px;" />
                                    </div>

                                    <!--CVV-->
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">CVV</label>
                                        <input runat="server" id="cvv" type="password" class="form-control" placeholder="CVV" style="font-size: 13px;" />
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <!--Expiry Date-->
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Expiry Date</label>
                                        <input runat="server" id="expirydate" class="form-control" type="date" style="font-size: 13px;" />
                                    </div>

                                    <!--Amount-->
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <label style="width: 150px; color: #4e73df; font-weight: bold; font-size: 13px">Amount</label>
                                        <input runat="server" id="amount" class="form-control" placeholder="Amount" style="font-size: 13px;" />
                                    </div>
                                </div>

                                <!--Submit-->
                                <div class="form-group">
                                    <asp:Button runat="server" ID="submitpayment" Text="SUBMIT PAYMENT" CssClass="btn btn-primary btn-block" Font-Bold="true" OnClick="submitpayment_Click" Font-Size="13px"></asp:Button>
                                </div>

                                <!--Error Message-->
                                <label runat="server" class="alert-danger" id="errormessage" style="font-size: 15px; font-weight: bold"></label>

                            </form>

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


    <!-- End of Page Wrapper -->


    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="Assets/vendor/jquery/jquery.min.js"></script>
    <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="Assets/js/sb-admin-2.min.js"></script>

</body>
</html>

