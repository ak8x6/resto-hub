<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="RestoApp.Pages.ForgotPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password - RestoApp</title>
    <!-- Add Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f4f7f6; height: 100vh; display: flex; align-items: center; justify-content: center; }
        .card { border-radius: 1rem; border: none; box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15); }
    </style>
</head>
<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card p-4">
                    <h3 class="text-center mb-2 font-weight-bold">Forgot Password</h3>
                    <p class="text-center text-muted small mb-4">Enter your email address to receive a password reset link.</p>
                    
                    <form id="form1" runat="server">
                        
                        <div class="mb-4">
                            <label class="form-label text-muted">Email Address</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" TextMode="Email" placeholder="name@example.com"></asp:TextBox>
                        </div>
                        
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-warning btn-lg w-100 text-white mb-3" Text="Send Reset Link" OnClick="btnSubmit_Click" />
                        
                        <div class="text-center">
                            <asp:Label ID="lblMessage" runat="server" CssClass="small fw-bold"></asp:Label>
                        </div>

                        <hr class="my-4" />
                        <div class="text-center">
                            <a href="Login.aspx" class="text-decoration-none fw-bold text-secondary">&larr; Back to Login</a>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
