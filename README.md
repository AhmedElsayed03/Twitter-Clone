Twitter-Clone
This is a Twitter clone project built using ASP.NET Core 8.0. It includes the following features and technologies:

Features
Register: Users can create new accounts.
Login: Users can authenticate themselves to access the application.
Follow User: Users can follow other users to receive updates on their activities.
Add Post with Images: Users can create posts and attach images to them.
Give Like: Users can like posts from other users.
Get User Profile: Users can view profiles of other users.
Add Reply as a new post: Users can reply to posts by creating new posts.
Group Chats: Users can engage in group chats with other users.
Technologies and Packages Used
ASP.NET Core 8.0: The web framework used for building the application.
EF Core 8.0: The object-relational mapping (ORM) framework used for database access.
JWT Authentication: Used for authentication and authorization using JSON Web Tokens.
RESTful API: The application follows the principles of REST architecture for its API design.
WebSocket API: WebSocket protocol is used for real-time communication.
Architecture and Patterns
Architecture Used: The project follows the Clean/Layered Architecture to maintain separation of concerns and improve maintainability.
Patterns Used:
Repository Pattern: Used to abstract the data access layer and provide a consistent interface for working with data.
Unit Of Work Pattern: Used to manage transactions and ensure atomicity when working with multiple repositories.
Dependency Injection: Used to manage the dependencies between different components of the application.
Packages
The following packages are used in the project:

Database Context:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Authentication:
Microsoft.AspNetCore.Authentication.JwtBearer
System.IdentityModel.Tokens.Jwt
Microsoft.IdentityModel.Tokens
Real-Time Chat:
Microsoft.AspNetCore.SignalR.Client