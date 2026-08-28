
# Multi-Panel E-Commerce System

A multi-application e-commerce platform built with **ASP.NET Core MVC**, **Entity Framework Core (Database First)** and **Microsoft SQL Server**.

The system consists of five separate role-specific web applications that operate on a shared relational database.

> This project was developed during my internship as a large-scale ASP.NET Core MVC project.

---

## Overview

The goal of this project was to build an e-commerce platform that represents multiple operational sides of a real-world e-commerce ecosystem.

Instead of implementing everything inside a single web application, the system was divided into five separate ASP.NET Core MVC applications:

- Customer / Sales Panel
- Admin Panel
- Seller Company Panel
- Cargo Company Panel
- Technical Support Panel

Each application is responsible for a different part of the system while accessing the same underlying Microsoft SQL Server database.

The project was developed using a **Database First** approach with Entity Framework Core. The existing relational database schema was mapped into C# entity models and a shared DbContext.

---

## System Architecture

The repository contains five separate ASP.NET Core MVC applications:

| Application | Responsibility |
|---|---|
| **Sales Panel (`SatisPaneli`)** | Customer-facing e-commerce operations |
| **Admin Panel (`AdminPaneli`)** | Platform administration and management |
| **Seller Company Panel (`SaticiFirmaPaneli`)** | Seller/company operations |
| **Cargo Company Panel (`KargoFirmasiPaneli`)** | Cargo and shipment operations |
| **Technical Support Panel (`TeknikDestekElemanPaneli`)** | Technical support and communication workflows |

All five applications operate on the same relational database.

    ┌───────────────────────────────────────┐
    │         Microsoft SQL Server          │
    │          Shared Database              │
    └──────────────────┬────────────────────┘
                       │
          ┌────────────┼────────────┐
          │            │            │
          ▼            ▼            ▼
      Admin Panel   Sales Panel   Seller Panel
          │                         │
          └───────────┬─────────────┘
                      │
                ┌─────┴─────┐
                ▼           ▼
           Cargo Panel   Technical
                         Support Panel

This architecture separates different business responsibilities while allowing the applications to work with shared business data.

---

## Database Architecture

A major part of the project is its relational database structure.

The application uses **Microsoft SQL Server** as its database management system and **Entity Framework Core Database First** for the application-side data model.

The existing database schema was mapped to C# entity classes located under:

`DB/Models`

The generated/mapped model layer contains entities covering many different parts of the platform, including:

- Users
- Administrators
- Seller companies
- Products
- Categories
- Orders
- Order items
- Shopping carts
- Payments
- Cargo companies
- Cargo operations
- Product favorites
- Product reviews
- Campaigns
- Coupons
- Returns
- Complaints
- Messaging
- Technical support
- Seller applications
- User addresses
- Login/logout records
- Ratings
- Search statistics
- Competitions and giveaways
- Social responsibility operations

The Entity Framework Core context is represented by:

`Task3RealEcommerceContext.cs`

This shared data model allows the separate MVC applications to interact with the same business entities and relational data.

---

## Database First Approach

The project follows the **Database First** approach.

Rather than defining the database structure from C# entity classes, the relational database schema exists in Microsoft SQL Server and is represented in the application through Entity Framework Core models.

Conceptually:

    Microsoft SQL Server
            │
            ▼
      Database Schema
            │
            ▼
    Entity Framework Core
       (Database First)
            │
            ▼
      C# Entity Models
            │
            ▼
    ASP.NET Core MVC Apps

This approach provided hands-on experience working with a large relational schema and integrating it into multiple .NET applications.

---

## Technologies

### Backend

- C#
- ASP.NET Core MVC
- Entity Framework Core
- Entity Framework Core Database First

### Database

- Microsoft SQL Server
- Relational Database Design

### Frontend

- Razor Views
- HTML
- CSS
- JavaScript
- AJAX

### Development

- Visual Studio
- Git
- GitHub

---

## AJAX Integration

AJAX is used in parts of the system to perform asynchronous client-server operations without requiring complete page reloads.

This allows certain user interactions to communicate with ASP.NET Core controllers dynamically and provides a more responsive user experience.

---

## Repository Structure

    Task3_Eticaret/
    │
    ├── AdminPaneli/
    │
    ├── KargoFirmasiPaneli/
    │
    ├── SaticiFirmaPaneli/
    │
    ├── SatisPaneli/
    │
    ├── TeknikDestekElemanPaneli/
    │
    ├── DB/
    │   └── Models/
    │
    └── Task3_Eticaret.sln

### Applications

**AdminPaneli**

Contains functionality related to platform administration and management.

**SaticiFirmaPaneli**

Contains functionality for seller companies operating on the platform.

**SatisPaneli**

Contains the customer-facing e-commerce functionality.

**KargoFirmasiPaneli**

Handles functionality related to cargo companies and shipment operations.

**TeknikDestekElemanPaneli**

Contains technical support and communication functionality.

**DB**

Contains the Entity Framework Core Database First models and database context shared by the applications.

---

## Business Domains

Because the project represents multiple sides of an e-commerce platform, the data model covers considerably more than basic product and order operations.

Examples of implemented business domains include:

### E-Commerce

- Products
- Categories
- Shopping carts
- Orders
- Order items
- Payments
- Favorites
- Product views

### Seller Operations

- Seller companies
- Seller applications
- Company ratings
- Company campaigns
- Company social media information

### Cargo Operations

- Cargo companies
- Cargo branches
- Shipment requests
- Sent shipments
- Cargo notifications
- Cargo ratings

### Customer Operations

- User accounts
- Addresses
- Payment/card information
- Favorites
- Reviews
- Complaints
- Recommendations

### Communication & Support

- User-to-user messaging
- Admin-to-user messaging
- Admin-to-company messaging
- Company-to-user messaging
- Technical support messaging
- Complaints and support workflows

### Additional Platform Features

- Campaigns
- Coupons
- Search statistics
- Giveaways
- Competitions
- Returns
- Frequently asked questions
- Social responsibility activities

---

## Project Demonstration

The project was developed and tested locally during my internship.

Although the original development environment is no longer deployed publicly, recordings of the working application and its different panels are available in the following YouTube playlist:

[Watch the Project Demonstration on YouTube](https://www.youtube.com/playlist?list=PLvnmMhtx_6OFaSAygdYLeeMmhvZK_Av2X)

The videos demonstrate the actual locally running system and interactions between its different panels.

---

## What This Project Demonstrates

This project provided practical experience with:

- Developing multiple ASP.NET Core MVC applications
- Working with a large relational Microsoft SQL Server database
- Using Entity Framework Core with the Database First approach
- Mapping an existing database schema into C# entity models
- Designing software around multiple business domains
- Sharing a common data model across multiple applications
- Building role-specific web applications
- Implementing server-side functionality with C#
- Working with Razor-based MVC applications
- Using AJAX for asynchronous client-server interactions
- Managing a multi-project .NET solution
- Modeling real-world e-commerce workflows

---

## Background

This project was developed during my internship and represents one of my earlier large-scale ASP.NET Core projects.

The project was designed as a learning and engineering exercise around a relatively large e-commerce domain, with separate applications representing customers, administrators, seller companies, cargo companies, and technical support personnel.

While my more recent projects focus on modern backend architecture, production deployment and other software engineering areas, this project represents an important stage in my development as a .NET developer, particularly in **relational database modeling, ASP.NET Core MVC and multi-application system design**.

---

## Author

**Can Engin Çizmeci**

Computer Engineering Student

Interested in **Backend Engineering, .NET, AI Engineering and scalable software systems**.
