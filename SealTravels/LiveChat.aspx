<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiveChat.aspx.cs" Inherits="SealTravels.LiveChat" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0" />

    <title></title>

    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@100;200;300;400;500;600;700;800;900" rel="stylesheet" />
    <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet" />

</head>

<body style="font-family: Heebo">
    <div class="container">
        <div class="card shadow mb-4 my-2">
            <div class="card-header py-3">
                <h2 class="m-0 font-weight-bold text-primary" style="float: left">Chat With Us <i class="fa fa-comment"></i></h2>
                <input type="text" class="form-control" id="message" style="float: left; margin-left: 10px" />
                <input type="button" id="sendmessage" class="btn btn-primary" value="Send" />
                <h6 style="float: right; color: #4e73df"><b>SEAL TRAVELS</b></h6>
            </div>

            <input type="hidden" id="displayname" />

            <div class="card-body" id="discussion" style="height: 400px"></div>
        </div>
    </div>


    @section scripts {
        <!--Script references. -->
    <!--The jQuery library is required and is referenced by default in _Layout.cshtml. -->
    <!--Reference the SignalR library. -->
    <script src="~/Scripts/jquery.signalR-2.4.1.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="~/signalr/hubs"></script>
    <!--SignalR script to update the chat page and send messages.-->
    <script>
        $(function () {
            // Reference the auto-generated proxy for the hub.
            var chat = $.connection.chatHub;
            // Create a function that the hub can call back to display messages.
            chat.client.addNewMessageToPage = function (name, message) {
                // Add the message to the page.
                $('#discussion').append('<div><b style="color:#4e73df"><i class="fa fa-user-alt"></i> ' + htmlEncode(name)
                    + '</b>', '<b style="font-size:13px">' + htmlEncode(message) + '</b></div>');
            };
            // Get the user name and store it to prepend to messages.
            $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub.
                    chat.server.send($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        });
        // This optional function html-encodes messages for display in the page.
        function htmlEncode(value) {
            var encodedValue = $('<div />').text(value).html();
            return encodedValue;
        }
    </script>
    }
   
</body>
</html>

