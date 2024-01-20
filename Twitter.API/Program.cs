
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Twitter.BL.Managers.Users;
using Twitter.BL.Managers.Posts;
using Twitter.DAL.Context;
using Twitter.DAL.Repos.Posts;
using Twitter.DAL.Repos.Users;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.FileProviders;
using Twitter.DAL.Repos.PostImages;
using Twitter.BL.Managers.PostImages;
using Twitter.DAL.Repos.Follows;
using Twitter.BL.Managers.Follows;
using Twitter.DAL.Repos.Likes;
using Twitter.BL.Managers.Likes;
using Twitter.DAL.Repos.Replies;
using Twitter.BL.Managers.Replies;
using Twitter.DAL.UnitOfWork;
using Twitter.API.Hubs.Chat;
using Twitter.API.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Twitter.DAL.Repos.OnlineUsers;
using Twitter.BL.Managers.OnlineUsers;
using Twitter.DAL.Repos.GroupChat;
using Twitter.BL.Managers.GroupChats;
using Twitter.DAL.Repos.UserGroups;
using Twitter.BL.Managers.UserGroups;

namespace Twitter.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Default
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Allow All", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            #endregion
                
            #region Repos Services
            builder.Services.AddScoped<IUsersRepo, UsersRepo>();
            builder.Services.AddScoped<IPostsRepo, PostsRepo>();
            builder.Services.AddScoped<IPostImagesRepo, PostImagesRepo>();
            builder.Services.AddScoped<IFollowRepo, FollowRepo>();
            builder.Services.AddScoped<ILikeRepo, LikeRepo>();
            builder.Services.AddScoped<IReplyRepo, ReplyRepo>();
            builder.Services.AddScoped<IOnlineUserRepo, OnlineUsersRepo>();
            builder.Services.AddScoped<IGroupChatRepo, GroupChatRepo>();
            builder.Services.AddScoped<IUserGroupRepo, UserGroupRepo>();
            #endregion

            #region Managers Services
            builder.Services.AddScoped<IUsersManager, UsersManager>();
            builder.Services.AddScoped<IPostsManager, PostsManager>();
            builder.Services.AddScoped<IPostImagesManager, PostImagesManager>();
            builder.Services.AddScoped<IFollowManager, FollowManager>();
            builder.Services.AddScoped<ILikesManager, LikesManager>();
            builder.Services.AddScoped<IReplyManager, ReplyManager>();
            builder.Services.AddScoped<IOnlineUsersManager, OnlineUsersManager>();
            builder.Services.AddScoped<IGroupChatManager, GroupChatManager>();
            builder.Services.AddScoped<IUserGroupsManager, UserGroupsManager>();
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Context
            //string? ConnectionString = builder.Configuration.GetConnectionString("ConnectionString");
            string? ConnectionString = builder.Configuration.GetValue<string>("ConnectionString");
            builder.Services.AddDbContext<TwitterDBContext>(option =>
            option.UseSqlServer(ConnectionString));
            #endregion

            #region Identity
            //Mainly specify the context and the type of the user that the UserManger will use
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                options => {
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<TwitterDBContext>();
            #endregion

            #region Authentication

            //Configuring Authentication Service by:
            //choosing Authentication scheme => JWT Bearer
            //Providing Secret Key

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "AuthName";
                option.DefaultChallengeScheme = "AuthName";

                //Use JWT Bearer
                //Install-Package microsoft.aspnetcore.authentication.jwtbearer
            }).AddJwtBearer("AuthName", option => {

                string? keyString = builder.Configuration.GetValue<string>("SecretKey");
                byte[] keyInBytes = Encoding.ASCII.GetBytes(keyString!);
                SymmetricSecurityKey key = new SymmetricSecurityKey(keyInBytes);

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,

                };
                //Authentication for ChatHub
                option.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context => {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken)
                            && path.StartsWithSegments("/chatHub"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("For Users", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "User")
                    .RequireClaim(ClaimTypes.NameIdentifier);
                    //policy.RequireClaim("Role", "AppUser","other value of roles") 
                });
            });
            #endregion

            #region SignalR
            builder.Services.AddSignalR();
            #endregion

            var app = builder.Build();



            #region Middlewares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region Images Handling
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "Images");
            //Configuration to let app use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/Images" //Localhost:####/(Request Path)/Capture.PNG(Static File Name)

            });
            #endregion

            app.UseHttpsRedirection();

            app.UseCors("Allow All");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapHub<ChatHub>("/chatHub");


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
