﻿// <auto-generated />
using System;
using AstormPresistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstormAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210419185444_AddPendingRequest")]
    partial class AddPendingRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AstormDomain.Entities.AssignUsersToServer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignUsersToServers");
                });

            modelBuilder.Entity("AstormDomain.Entities.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("AstormDomain.Entities.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("AstormDomain.Entities.ChannelMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChannelId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SendMessageDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId")
                        .IsUnique();

                    b.HasIndex("ChannelId1");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("ChannelsMessages");
                });

            modelBuilder.Entity("AstormDomain.Entities.FriendOfUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FriendId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("FriendsOfUsers");
                });

            modelBuilder.Entity("AstormDomain.Entities.PendingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PendingRequests");
                });

            modelBuilder.Entity("AstormDomain.Entities.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("AstormDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AstormDomain.Entities.UserMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SendMessageDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasIndex("RecipientId")
                        .IsUnique();

                    b.ToTable("UsersMessages");
                });

            modelBuilder.Entity("AstormDomain.Entities.AssignUsersToServer", b =>
                {
                    b.HasOne("AstormDomain.Entities.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstormDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AstormDomain.Entities.Attribute", b =>
                {
                    b.HasOne("AstormDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AstormDomain.Entities.Channel", b =>
                {
                    b.HasOne("AstormDomain.Entities.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("AstormDomain.Entities.ChannelMessage", b =>
                {
                    b.HasOne("AstormDomain.Entities.Channel", "Channel")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.ChannelMessage", "ChannelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AstormDomain.Entities.Channel", null)
                        .WithMany("ChannelMessages")
                        .HasForeignKey("ChannelId1");

                    b.HasOne("AstormDomain.Entities.User", "Owner")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.ChannelMessage", "OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AstormDomain.Entities.FriendOfUser", b =>
                {
                    b.HasOne("AstormDomain.Entities.User", "Friend")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.FriendOfUser", "FriendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AstormDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AstormDomain.Entities.PendingRequest", b =>
                {
                    b.HasOne("AstormDomain.Entities.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstormDomain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.PendingRequest", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AstormDomain.Entities.UserMessage", b =>
                {
                    b.HasOne("AstormDomain.Entities.User", "Owner")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.UserMessage", "OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AstormDomain.Entities.User", "Recipient")
                        .WithOne()
                        .HasForeignKey("AstormDomain.Entities.UserMessage", "RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("AstormDomain.Entities.Channel", b =>
                {
                    b.Navigation("ChannelMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
