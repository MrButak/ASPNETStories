// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stories.Data;

#nullable disable

namespace Stories.Migrations
{
    [DbContext(typeof(StoriesContext))]
    [Migration("20230225003106_AddRelationshipFromStoriesTableToParagraphsTable")]
    partial class AddRelationshipFromStoriesTableToParagraphsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stories.Models.ParagraphsTable", b =>
                {
                    b.Property<int>("ParagraphId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParagraphId"));

                    b.Property<string>("ParagraphText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("ParagraphId");

                    b.HasIndex("StoryId");

                    b.ToTable("ParagraphsTable");
                });

            modelBuilder.Entity("Stories.Models.StoriesTable", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoryId"));

                    b.Property<DateTime>("StoryCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("StoryTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StoryUpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StoryId");

                    b.ToTable("StoriesTable");
                });

            modelBuilder.Entity("Stories.Models.ParagraphsTable", b =>
                {
                    b.HasOne("Stories.Models.StoriesTable", "StoriesTable")
                        .WithMany("ParagraphsTable")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoriesTable");
                });

            modelBuilder.Entity("Stories.Models.StoriesTable", b =>
                {
                    b.Navigation("ParagraphsTable");
                });
#pragma warning restore 612, 618
        }
    }
}
