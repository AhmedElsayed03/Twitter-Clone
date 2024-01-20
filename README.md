# Twitter-Clone
Twitter Clone using:
ASP.NET Core 8.0
EF Core 8.0
JWT Authentication
RESTful API
WebSocket API

Functionalities:
Register
Login
Follow User
Add Post with Images
Give Like
Get User Profile
Add Reply as a new post
Group Chats

Architecture Used:
Clean/Layered Architecture

Patterns Used:
Repository Pattern
Unit Of Work Pattern
Dependency Injection

Packages:
[Database Context]
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.EntityFrameworkCore
[Authentication]
Microsoft.AspNetCore.Authentication.JwtBearer
System.IdentityModel.Tokens.Jwt
Microsoft.IdentityModel.Tokens
[Real-Time Chat]
Microsoft.AspNetCore.SignalR.Client
