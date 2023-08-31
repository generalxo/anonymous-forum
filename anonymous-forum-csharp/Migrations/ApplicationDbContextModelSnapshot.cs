﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using anonymous_forum_csharp.Data;

#nullable disable

namespace anonymous_forum_csharp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("anonymous_forum_csharp.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "Welcome to Anonymous Forum! Feel free to post anything you want here. Just remember to follow the rules.",
                            Title = "Welcome to Anonymous Forum!",
                            TopicId = 1
                        },
                        new
                        {
                            Id = 2,
                            Text = "1. Be respectful to others. 2. No spamming. 3. No NSFW content. 4. No advertising. 5. No illegal content.",
                            Title = "Rules",
                            TopicId = 2
                        },
                        new
                        {
                            Id = 3,
                            Text = "To post, simply click on the \"New Post\" button on the top right corner of the page. You can also reply to other posts by clicking on the \"Reply\" button.",
                            Title = "How to post",
                            TopicId = 3
                        },
                        new
                        {
                            Id = 4,
                            Text = "You can format your post using Markdown.",
                            Title = "How to format your post",
                            TopicId = 4
                        },
                        new
                        {
                            Id = 5,
                            Text = "You can format your post using Markdown.",
                            Title = "How to format your post",
                            TopicId = 5
                        });
                });

            modelBuilder.Entity("anonymous_forum_csharp.Models.TopicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "General discussion",
                            Name = "General"
                        },
                        new
                        {
                            Id = 2,
                            Description = "News and announcements",
                            Name = "News"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Help and support",
                            Name = "Help"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Suggestions and feedback",
                            Name = "Suggestions"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Off-topic discussion",
                            Name = "Off-Topic"
                        });
                });

            modelBuilder.Entity("anonymous_forum_csharp.Models.PostModel", b =>
                {
                    b.HasOne("anonymous_forum_csharp.Models.TopicModel", "Topics")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("anonymous_forum_csharp.Models.TopicModel", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
