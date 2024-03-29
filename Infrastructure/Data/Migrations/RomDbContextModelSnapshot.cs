﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(RomDbContext))]
    partial class RomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Entities.Billing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("text");

                    b.Property<string>("CreditLimit")
                        .HasColumnType("text");

                    b.Property<int>("ProcessResponseId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("ProcessResponseId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("Core.Entities.DefectiveComponentDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ComponentName")
                        .HasColumnType("text");

                    b.Property<string>("ComponentType")
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("DefectiveComponentDetails");
                });

            modelBuilder.Entity("Core.Entities.ProcessRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<int>("DefectiveComponentDetailId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("DefectiveComponentDetailId");

                    b.ToTable("ProcessRequests");
                });

            modelBuilder.Entity("Core.Entities.ProcessResponse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfDelivery")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("PackagingAndDeliveryCharge")
                        .HasColumnType("numeric");

                    b.Property<int>("ProcessRequestId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ProcessingCharge")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("ProcessRequestId");

                    b.ToTable("ProcessResponse");
                });

            modelBuilder.Entity("Core.Entities.Billing", b =>
                {
                    b.HasOne("Core.Entities.ProcessResponse", "ProcessResponse")
                        .WithMany()
                        .HasForeignKey("ProcessResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessResponse");
                });

            modelBuilder.Entity("Core.Entities.ProcessRequest", b =>
                {
                    b.HasOne("Core.Entities.DefectiveComponentDetail", "ComponentDetail")
                        .WithMany()
                        .HasForeignKey("DefectiveComponentDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComponentDetail");
                });

            modelBuilder.Entity("Core.Entities.ProcessResponse", b =>
                {
                    b.HasOne("Core.Entities.ProcessRequest", "ProcessRequest")
                        .WithMany()
                        .HasForeignKey("ProcessRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
