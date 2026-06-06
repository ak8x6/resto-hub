<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestoApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .hero-section {
            background: linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url('https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?auto=format&fit=crop&w=1920&q=80') no-repeat center center;
            background-size: cover;
            color: #fff;
            padding: 100px 0;
            text-align: center;
        }
        .hero-section h1 {
            font-size: 3.5rem;
            font-weight: bold;
        }
        .hero-section p {
            font-size: 1.25rem;
            margin-bottom: 30px;
        }
        .info-card {
            transition: transform 0.3s ease;
        }
        .info-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.1);
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <section class="hero-section">
        <div class="container">
            <h1>Experience Fine Dining</h1>
            <p>Delicious food, wonderful atmosphere, and unforgettable memories.</p>
            <a href="~/ClientsView/Tables/Tables.aspx" runat="server" class="btn btn-primary btn-lg me-2">Book a Table</a>
            <a href="~/ClientsView/Menu/Menu.aspx" runat="server" class="btn btn-outline-light btn-lg">View Our Menu</a>
        </div>
    </section>

    <!-- Info Section Cards -->
    <div class="container my-5">
        <div class="row text-center">
            <div class="col-md-4 mb-4">
                <div class="card h-100 info-card border-0">
                    <div class="card-body">
                        <h1 class="display-4 text-warning mb-3"><i class="fa-solid fa-burger"></i></h1>
                        <h3 class="card-title">Gourmet Food</h3>
                        <p class="card-text text-muted">Exquisite dishes prepared by world-class chefs using fresh, locally sourced ingredients.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card h-100 info-card border-0">
                    <div class="card-body">
                        <h1 class="display-4 text-warning mb-3"><i class="fa-solid fa-wine-glass"></i></h1>
                        <h3 class="card-title">Curated Drinks</h3>
                        <p class="card-text text-muted">A fine selection of local and international wines, craft cocktails, and beverages.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card h-100 info-card border-0">
                    <div class="card-body">
                        <h1 class="display-4 text-warning mb-3"><i class="fa-solid fa-star"></i></h1>
                        <h3 class="card-title">5-Star Service</h3>
                        <p class="card-text text-muted">Exceptional hospitality guaranteeing a memorable dining experience.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
