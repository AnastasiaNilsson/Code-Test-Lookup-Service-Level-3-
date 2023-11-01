﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(CreditDataContext))]
    partial class CreditDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("backend.Models.CreditData", b =>
                {
                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "address");

                    b.Property<int>("AssessedIncome")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "assessed_income");

                    b.Property<TimeSpan>("CacheLimit")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Complaints")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "complaints");

                    b.Property<DateTime>("CreatedAtTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DebtBalance")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "balance_of_debt");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "last_name");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("CreditDataSet");
                });
#pragma warning restore 612, 618
        }
    }
}
