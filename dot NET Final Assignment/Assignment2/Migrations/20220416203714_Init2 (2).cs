using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokerages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fee = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokerages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerageID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisements_Brokerages_BrokerageID",
                        column: x => x.BrokerageID,
                        principalTable: "Brokerages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    BrokerageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID1 = table.Column<int>(type: "int", nullable: true),
                    SubscriptionsClientID = table.Column<int>(type: "int", nullable: true),
                    SubscriptionsBrokerageID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => new { x.ClientID, x.BrokerageID });
                    table.ForeignKey(
                        name: "FK_Subscriptions_Brokerages_BrokerageID",
                        column: x => x.BrokerageID,
                        principalTable: "Brokerages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Clients_ClientID1",
                        column: x => x.ClientID1,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                        columns: x => new { x.SubscriptionsClientID, x.SubscriptionsBrokerageID },
                        principalTable: "Subscriptions",
                        principalColumns: new[] { "ClientID", "BrokerageID" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_BrokerageID",
                table: "Advertisements",
                column: "BrokerageID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BrokerageID",
                table: "Subscriptions",
                column: "BrokerageID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClientID1",
                table: "Subscriptions",
                column: "ClientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                table: "Subscriptions",
                columns: new[] { "SubscriptionsClientID", "SubscriptionsBrokerageID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Brokerages");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
