using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;

namespace Twitter.DAL.Context
{
    
    public class TwitterDBContext:IdentityDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostImage> Image { get; set; }
        public DbSet<Follow> Follow { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<OnlineUser> OnlineUser { get; set; }
        public DbSet<Groupchat> Groupchat { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public TwitterDBContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Mapping Strategy
            //Use Table-per-Type Strategy 
            builder.Entity<IdentityUser>()
                .UseTptMappingStrategy();

            //Use Table-per-Hierarchy Strategy 
            //builder.Entity<IdentityUser>()
            //    .UseTphMappingStrategy();
            #endregion

            #region User
            //Setting Primary Key for User
            //builder.Entity<User>()
            //    .HasKey(i => i.UserName);

            builder.Entity<User>()
                .HasMany(i => i.Posts)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
            #endregion

            #region Post
            //Setting Primary Key for Post
            builder.Entity<Post>()
                .HasKey(i => i.Id);

            //This Relation is commented because it's already
            //Configured in User
            //builder.Entity<Post>()
            //    .HasOne(i => i.User)
            //    .WithMany(i => i.Posts)
            //    .HasForeignKey(i => i.Id);
            #endregion

            #region Image
            builder.Entity<PostImage>()
                .HasKey(i => i.ImgName);
            builder.Entity<PostImage>()
                .HasOne(i => i.Post)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.PostId);
            #endregion

            #region Follow
            builder.Entity<Follow>()
                .HasKey(i => new {i.FollowerID, i.FollowingID});

            builder.Entity<Follow>()
                .HasOne(u => u.Following)
                .WithMany(u => u.Follower)
                .HasForeignKey(u => u.FollowingID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Follow>()
                .HasOne(u => u.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(u => u.FollowerID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Like
            builder.Entity<Like>()
                .HasKey(i => new {i.PostId,i.UserID});
            builder.Entity<Like>()
                .HasOne(i => i.Post)
                .WithMany(i => i.Likes)
                .HasForeignKey(i=>i.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Like>()
                .HasOne(i => i.User)
                .WithMany(i => i.Likes)
                .HasForeignKey(i => i.UserID)
                .OnDelete(DeleteBehavior.Restrict);


            #endregion

            #region Reply
            builder.Entity<Reply>()
                .HasKey(i => i.Id);
            builder.Entity<Reply>()
                .HasOne(i => i.User)
                .WithMany(i=>i.Replies)
                .HasForeignKey(i=>i.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Reply>()
                .HasOne(i => i.Post)
                .WithMany(i=>i.Replies)
                .HasForeignKey(i=>i.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region OnlineUsers
            builder.Entity<OnlineUser>()
                .HasKey(i => new {i.ConnectionId,i.UserId});
            #endregion

            #region Groupchat
            builder.Entity<Groupchat>()
                .HasKey(i=>i.Id);
            #endregion

            #region UserGroups
            builder.Entity<UserGroup>()
                .HasKey(i => new{i.UserId,i.GroupId});
            builder.Entity<UserGroup>()
                .HasOne(i=>i.User)
                .WithMany(i=>i.UserGroups)
                .HasForeignKey(i=>i.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserGroup>()
                .HasOne(i=>i.Groupchat)
                .WithMany(i=>i.UserGroups)
                .HasForeignKey(i=>i.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

        }
    }
}
