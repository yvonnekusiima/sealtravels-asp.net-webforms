<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorLogin.aspx.cs" Inherits="SealTravels.AdministratorLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />

    <title>Administrator Login</title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="Assets/img/globe.png" rel="icon" />

</head>

<body style="font-family: Heebo">

    <br />

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
                            <div class="">
                                <h5 class="" style="color: #4e73df; font-family: Heebo;"><strong>Administrator Login</strong> <i class="fa fa-sign-in-alt"></i></h5>
                                <br />
                            </div>

                            <!--Login Form-->

                            <form runat="server" class="user">

                                <div class="form-group">
                                    <input id="administratorid" runat="server" class="form-control" placeholder="Administrator Id" required="required" style="font-size: 13px" />
                                </div>

                                <div class="form-group">
                                    <input id="password" runat="server" class="form-control" placeholder="Password" type="password" required="required" style="font-size: 13px" />
                                </div>

                                <div class="form-group">
                                    <img src="Captcha.aspx" />
                                </div>

                                <div class="form-group">
                                    <input id="captcha" runat="server" class="form-control" placeholder="Enter Captcha Code" required="required" style="font-size: 13px" />
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="login" runat="server" CssClass="btn btn-primary btn-block" Text="LOGIN" OnClick="login_Click" Font-Bold="true" Font-Size="13px" />
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

    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="Assets/vendor/jquery/jquery.min.js"></script>
    <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="Assets/js/sb-admin-2.min.js"></script>

</body>

</html>
