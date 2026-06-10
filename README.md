<div align="center">

# 🍽️ RestoApp

### Full-Stack Restaurant Management System web application

[![ASP.NET](https://img.shields.io/badge/ASP.NET-Web%20Forms-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.8-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)](LICENSE)

A production-ready restaurant web application featuring a customer-facing storefront with menu browsing, table reservations, shopping cart, and reviews — alongside a comprehensive admin dashboard for full restaurant operations management.

</div>

---

## 📸 Screenshots

<details>
<summary><b>🏠 Customer-Facing Pages</b> (click to expand)</summary>
<br>

| Page              | Preview                                                 |
| ----------------- | ------------------------------------------------------- |
| **Home Page**     | ![Home Page](screenshots/home%20page.png)               |
| **Menu & Items**  | ![Menu Items](screenshots/menu%20items%20page.png)      |
| **Item Details**  | ![Item Details](screenshots/item%20page.png)            |
| **Shopping Cart** | ![Cart](screenshots/cart%20page.png)                    |
| **Tables List**   | ![Tables](screenshots/reservations%20tables%20page.png) |
| **Table Details** | ![Table Details](screenshots/table%20page.png)          |
| **Book a Table**  | ![Book a Table](screenshots/book%20table%20page.png)    |
| **Reviews**       | ![Reviews](screenshots/reviews%20page.png)              |

</details>

<details>
<summary><b>🔐 Authentication Flow</b> (click to expand)</summary>
<br>

| Step                     | Preview                                                                                                                    |
| ------------------------ | -------------------------------------------------------------------------------------------------------------------------- |
| **Sign Up**              | ![Sign Up](<screenshots/signup%201(create%20account%20by%20verify%20by%20email).png>)                                      |
| **Email Verification**   | ![Verify Email](<screenshots/signup%202(recieved%20verify%20link%20by%20email%20to%20complete%20account%20creation)).png>) |
| **Login**                | ![Login](<screenshots/login%201(after%20created%20account).png>)                                                           |
| **Forgot Password**      | ![Forgot Password](<screenshots/password%20reset%201(send%20link%20by%20email).png>)                                       |
| **Reset Email Received** | ![Reset Email](<screenshots/password%20reset%202(%20recieved%20reset%20link).png>)                                         |
| **New Password Form**    | ![Reset Password](<screenshots/passwrod%20reset%203(change%20password%20form).png>)                                        |

</details>

<details>
<summary><b>⚙️ Admin Dashboard</b> (click to expand)</summary>
<br>

| Page                    | Preview                                                |
| ----------------------- | ------------------------------------------------------ |
| **Dashboard Overview**  | ![Dashboard](screenshots/admin%20dashboard.png)        |
| **Manage Menus**        | ![Menus](screenshots/manage%20menus.png)               |
| **Manage Items**        | ![Items](screenshots/manage%20items.png)               |
| **Manage Tables**       | ![Tables](screenshots/manage%20tables.png)             |
| **Manage Reservations** | ![Reservations](screenshots/manage%20reservations.png) |
| **Manage Reviews**      | ![Reviews](screenshots/manage%20reviews.png)           |
| **Manage Users**        | ![Users](screenshots/manage%20users.png)               |

</details>

---

## ✨ Features

### 🛍️ Customer Portal

| Feature                | Description                                                                        |
| ---------------------- | ---------------------------------------------------------------------------------- |
| **Menu Browsing**      | Browse categorized menus with item photos, prices, ingredients, and origin details |
| **Table Reservations** | View available tables with photos and capacity, then book with date/time selection |
| **Shopping Cart**      | Session-based cart with add/remove functionality and quantity management           |
| **Customer Reviews**   | Submit star ratings and comments; view approved community reviews                  |
| **Secure Auth**        | Full signup → email verification → login flow with password reset capability       |

### ⚙️ Admin Dashboard

| Feature                 | Description                                                              |
| ----------------------- | ------------------------------------------------------------------------ |
| **Dashboard Analytics** | At-a-glance stats for users, reservations, items, and feedbacks          |
| **Menu Management**     | Create, edit, reorder, and toggle menu categories                        |
| **Item Management**     | Full CRUD for food/drink items with photos, pricing, and availability    |
| **Table Management**    | Configure tables with seating capacity, location, photos, and status     |
| **Reservation Control** | Approve, cancel, or complete bookings with automatic email notifications |
| **User Administration** | Manage roles (Admin/Client), activate/deactivate accounts                |
| **Review Moderation**   | Approve, reject, or delete customer feedback before public display       |

---

## 🛠️ Tech Stack

| Layer              | Technology                                                     |
| ------------------ | -------------------------------------------------------------- |
| **Frontend**       | HTML5, CSS3, Bootstrap 5.3, FontAwesome 6                      |
| **Backend**        | ASP.NET Web Forms, C# (.NET Framework 4.8)                     |
| **Database**       | SQL Server LocalDB with ADO.NET                                |
| **Authentication** | BCrypt.Net-Next (password hashing), HMAC-SHA256 (auth tokens)  |
| **Email**          | SMTP via Gmail (configurable in Web.config)                    |
| **Architecture**   | Repository Pattern, Master Page layout, Code-Behind separation |

---

## 🔒 Security

- **BCrypt Password Hashing** — Industry-standard password storage with cost factor 11
- **HMAC-SHA256 Auth Tokens** — Tamper-proof "Remember Me" cookies
- **Email Verification** — Token-based account activation with expiry
- **Secure Password Reset** — Time-limited reset tokens sent via email
- **Role-Based Authorization** — Admin pages protected with server-side role checks
- **SQL Injection Prevention** — Parameterized queries and table name whitelisting
- **XSS Protection** — HTML-encoded output with `<%: %>` syntax
- **HttpOnly Cookies** — Cookie theft prevention via `httpOnlyCookies` setting
- **Custom Error Pages** — No stack trace leakage in production (`customErrors`)

---

## 📁 Project Structure

```
RestoApp/
├── AdminRepo/              # Data access layer for admin operations
│   ├── FeedbackRepository  # CRUD for feedback moderation
│   ├── ItemRepository      # CRUD for menu items + photos
│   ├── MenuRepository      # CRUD for menu categories
│   ├── ReservationRepository # Reservation status management
│   ├── TableRepository     # CRUD for restaurant tables
│   └── UserRepository      # User role & status management
├── AdminView/              # Admin panel pages
│   ├── Dashboard/          # Stats overview
│   ├── Feedbacks/          # Review moderation
│   ├── Items/              # Item management
│   ├── Menus/              # Menu management
│   ├── Reservations/       # Booking management
│   ├── Tables/             # Table management
│   └── Users/              # User administration
├── App_Data/               # Database files
│   ├── RestoDB.mdf         # SQL Server LocalDB database
│   ├── restoDb.sql         # Schema creation script
│   └── dummyData.sql       # Sample seed data
├── Authentication/         # Auth pages
│   ├── Login.aspx          # User login
│   ├── Signup.aspx         # Registration + email verify
│   ├── ForgotPassword.aspx # Password reset request
│   ├── ResetPassword.aspx  # New password form
│   └── Verify.aspx         # Email verification
├── ClientRepo/             # Data access layer for customers
├── ClientsView/            # Customer-facing pages
│   ├── Cart/               # Shopping cart
│   ├── Feedbacks/          # Reviews display + submission
│   ├── Items/              # Item detail view
│   ├── Menu/               # Menu browsing
│   ├── Reservationn/       # Reservation request form
│   ├── TableDetails/       # Individual table view
│   └── Tables/             # Table listing + search
├── Helper/                 # Utilities
│   ├── DbHelper.cs         # Database connection manager
│   └── EmailService.cs     # SMTP email sender
├── Models/                 # Data models (POCOs)
├── Default.aspx            # Landing page
├── Site.Master             # Shared layout (navbar + footer)
└── Web.config              # App configuration
```

---

## 🗄️ Database Schema

```mermaid
erDiagram
    Users ||--o{ Reservations : makes
    Users ||--o{ Feedbacks : writes
    Menus ||--|{ Items : contains
    Items ||--o{ ItemPhotos : has
    RestaurantTables ||--o{ Reservations : "booked for"
    Reservations ||--o{ Feedbacks : "reviewed via"

    Users {
        int UserId PK
        string FullName
        string Email UK
        string PasswordHash
        string Role
        bit IsEmailVerified
        bit IsActive
    }
    Menus {
        int MenuId PK
        string MenuName
        int DisplayOrder
        bit IsActive
    }
    Items {
        int ItemId PK
        int MenuId FK
        string ItemName
        decimal Price
        bit IsAvailable
    }
    RestaurantTables {
        int TableId PK
        string TableNumber UK
        int SeatingCapacity
        string Location
        bit IsActive
    }
    Reservations {
        int ReservationId PK
        int UserId FK
        int TableId FK
        datetime ReservationDate
        string Status
    }
    Feedbacks {
        int FeedbackId PK
        int UserId FK
        int ReservationId FK
        int VisitRating
        bit IsApproved
    }
```

---

## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2019+** (with ASP.NET and web development workload)
- **SQL Server LocalDB** (included with Visual Studio)
- **.NET Framework 4.8** SDK

### Installation

1. **Clone the repository**

    ```bash
    git clone https://github.com/YOUR-USERNAME/RestoApp.git
    cd RestoApp
    ```

2. **Open in Visual Studio**

    ```
    Open RestoApp/RestoApp.slnx
    ```

3. **Set up the database**
    - Open SQL Server Object Explorer in Visual Studio
    - Connect to `(LocalDB)\MSSQLLocalDB`
    - Run `App_Data/restoDb.sql` to create the schema
    - Run `App_Data/dummyData.sql` to seed sample data

4. **Configure email** _(optional — for signup/reset flows)_
    - Update `Web.config` → `<appSettings>`:
        ```xml
        <add key="SmtpEmail" value="your-email@gmail.com" />
        <add key="SmtpPassword" value="your-app-password" />
        ```
    - Generate a [Gmail App Password](https://support.google.com/accounts/answer/185833) for the password field

5. **Run the application**
    - Press `F5` (debug) or `Ctrl+F5` (without debug)
    - The app opens at `http://localhost:PORT/`

### Demo Credentials

| Role       | Email                   | Password      |
| ---------- | ----------------------- | ------------- |
| **Admin**  | `alice.smith@email.com` | `Password123` |
| **Client** | `bob.jones@email.com`   | `Password123` |

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

<div align="center">

**Built with ❤️ as a full-stack portfolio project**

_Demonstrating ASP.NET Web Forms · C# · SQL Server · Bootstrap · Repository Pattern · Secure Authentication_

</div>

