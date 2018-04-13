﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    [Migration("20180411111222_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Destination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("ExcursionCost");

                    b.Property<string>("Location");

                    b.Property<DateTime>("VisitDate");

                    b.HasKey("ID");

                    b.ToTable("Destination");
                });
#pragma warning restore 612, 618
        }
    }
}
