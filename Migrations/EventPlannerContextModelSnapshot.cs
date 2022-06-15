﻿// <auto-generated />
using System;
using EventsFactory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventsFactory.Migrations
{
    [DbContext(typeof(EventPlannerContext))]
    partial class EventPlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventsFactory.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("Availability")
                        .HasColumnType("int");

                    b.Property<string>("EventDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPeopleRequired")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("EventsFactory.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participant", (string)null);
                });

            modelBuilder.Entity("EventsFactory.Models.ParticipantAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("ParticipantAssignment");
                });

            modelBuilder.Entity("EventsFactory.Models.Event", b =>
                {
                    b.HasOne("EventsFactory.Models.Participant", null)
                        .WithMany("Events")
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("EventsFactory.Models.ParticipantAssignment", b =>
                {
                    b.HasOne("EventsFactory.Models.Event", "Event")
                        .WithMany("ParticipantAssignments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsFactory.Models.Participant", "Participant")
                        .WithMany("ParticipantAssignments")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("EventsFactory.Models.Event", b =>
                {
                    b.Navigation("ParticipantAssignments");
                });

            modelBuilder.Entity("EventsFactory.Models.Participant", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("ParticipantAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
