﻿// <auto-generated />
using System;
using AgentopsServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentopsServer.Migrations
{
    [DbContext(typeof(AgentServerDbContext))]
    partial class AgentServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgentopsServer.Models.Agent", b =>
                {
                    b.Property<string>("AgentId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("AgentopsServer.Models.AgentSession", b =>
                {
                    b.Property<int>("AgentSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AgentSessionId"));

                    b.Property<int>("AgentId")
                        .HasColumnType("integer");

                    b.Property<string>("EndState")
                        .HasColumnType("text");

                    b.Property<string>("EndStateReason")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InitTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AgentSessionId");

                    b.ToTable("AgentSessions");
                });

            modelBuilder.Entity("AgentopsServer.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChoiceId"));

                    b.Property<string>("FinishReason")
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<int?>("MessageId")
                        .HasColumnType("integer");

                    b.Property<int>("ReturnId")
                        .HasColumnType("integer");

                    b.HasKey("ChoiceId");

                    b.HasIndex("MessageId");

                    b.HasIndex("ReturnId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("AgentopsServer.Models.Completion", b =>
                {
                    b.Property<int>("CompletionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompletionId"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("CompletionId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Completions");
                });

            modelBuilder.Entity("AgentopsServer.Models.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AgentExtGuid")
                        .HasColumnType("text");

                    b.Property<int>("CompletionTokens")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventExtGuid")
                        .HasColumnType("text");

                    b.Property<string>("EventType")
                        .HasColumnType("text");

                    b.Property<DateTime>("InitTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<int>("PromptTokens")
                        .HasColumnType("integer");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("AgentopsServer.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<int>("ChoiseId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("FunctionCall")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("ToolCalls")
                        .HasColumnType("text");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AgentopsServer.Models.Param", b =>
                {
                    b.Property<int>("ParamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParamId"));

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<bool>("Stream")
                        .HasColumnType("boolean");

                    b.HasKey("ParamId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Params");
                });

            modelBuilder.Entity("AgentopsServer.Models.Prompt", b =>
                {
                    b.Property<int>("PromptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PromptId"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("PromptId");

                    b.HasIndex("EventId");

                    b.ToTable("Prompts");
                });

            modelBuilder.Entity("AgentopsServer.Models.Return", b =>
                {
                    b.Property<int>("ReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReturnId"));

                    b.Property<int>("Created")
                        .HasColumnType("integer");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Object")
                        .HasColumnType("text");

                    b.Property<string>("ReturnExternalId")
                        .HasColumnType("text");

                    b.Property<string>("ServiceTier")
                        .HasColumnType("text");

                    b.HasKey("ReturnId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("AgentopsServer.Models.Usage", b =>
                {
                    b.Property<int>("UsageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsageId"));

                    b.Property<int>("CachedTokens")
                        .HasColumnType("integer");

                    b.Property<int>("CompletionTokens")
                        .HasColumnType("integer");

                    b.Property<int>("PromptTokens")
                        .HasColumnType("integer");

                    b.Property<int>("ReasoningTokens")
                        .HasColumnType("integer");

                    b.Property<int>("ReturnId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalTokens")
                        .HasColumnType("integer");

                    b.HasKey("UsageId");

                    b.HasIndex("ReturnId")
                        .IsUnique();

                    b.ToTable("Usage");
                });

            modelBuilder.Entity("AgentopsServer.Models.Choice", b =>
                {
                    b.HasOne("AgentopsServer.Models.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.HasOne("AgentopsServer.Models.Return", null)
                        .WithMany("Choices")
                        .HasForeignKey("ReturnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("AgentopsServer.Models.Completion", b =>
                {
                    b.HasOne("AgentopsServer.Models.Event", null)
                        .WithOne("Completion")
                        .HasForeignKey("AgentopsServer.Models.Completion", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgentopsServer.Models.Param", b =>
                {
                    b.HasOne("AgentopsServer.Models.Event", null)
                        .WithOne("Params")
                        .HasForeignKey("AgentopsServer.Models.Param", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgentopsServer.Models.Prompt", b =>
                {
                    b.HasOne("AgentopsServer.Models.Event", null)
                        .WithMany("Prompt")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgentopsServer.Models.Return", b =>
                {
                    b.HasOne("AgentopsServer.Models.Event", null)
                        .WithOne("Returns")
                        .HasForeignKey("AgentopsServer.Models.Return", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgentopsServer.Models.Usage", b =>
                {
                    b.HasOne("AgentopsServer.Models.Return", null)
                        .WithOne("Usage")
                        .HasForeignKey("AgentopsServer.Models.Usage", "ReturnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgentopsServer.Models.Event", b =>
                {
                    b.Navigation("Completion")
                        .IsRequired();

                    b.Navigation("Params");

                    b.Navigation("Prompt");

                    b.Navigation("Returns");
                });

            modelBuilder.Entity("AgentopsServer.Models.Return", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("Usage");
                });
#pragma warning restore 612, 618
        }
    }
}
