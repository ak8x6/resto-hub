<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="RestoApp.Pages.ResetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password - RestoApp</title>
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
                    <h3 class="text-center mb-2 font-weight-bold">Reset Password</h3>
                    <p class="text-center text-muted small mb-4">Please enter your new password below.</p>
                    
                    <form id="form1" runat="server">
                        
                        <div class="text-center mb-3">
                            <asp:Label ID="lblMessage" runat="server" CssClass="small fw-bold"></asp:Label>
                        </div>
                        
                        <div class="mb-4">
                            <label class="form-label text-muted">New Password</label>
                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="••••••••"></asp:TextBox>
                        </div>
                        
                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary btn-lg w-100" Text="Reset Password" OnClick="btnReset_Click" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
