using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class ass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Brokerages_BrokerageID",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Clients_ClientID",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Clients_ClientID1",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ClientID1",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ClientID1",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionsBrokerageID",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionsClientID",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "SubscriptionID",
                table: "Subscriptions",
                newName: "SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "BrokerageID",
                table: "Subscriptions",
                newName: "BrokerageId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Subscriptions",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_BrokerageID",
                table: "Subscriptions",
                newName: "IX_Subscriptions_BrokerageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Brokerages_BrokerageId",
                table: "Subscriptions",
                column: "BrokerageId",
                principalTable: "Brokerages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Clients_ClientId",
                table: "Subscriptions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Brokerages_BrokerageId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Clients_ClientId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Subscriptions",
                newName: "SubscriptionID");

            migrationBuilder.RenameColumn(
                name: "BrokerageId",
                table: "Subscriptions",
                newName: "BrokerageID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Subscriptions",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_BrokerageId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_BrokerageID");

            migrationBuilder.AddColumn<int>(
                name: "ClientID1",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionsBrokerageID",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionsClientID",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClientID1",
                table: "Subscriptions",
                column: "ClientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                table: "Subscriptions",
                columns: new[] { "SubscriptionsClientID", "SubscriptionsBrokerageID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Brokerages_BrokerageID",
                table: "Subscriptions",
                column: "BrokerageID",
                principalTable: "Brokerages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Clients_ClientID",
                table: "Subscriptions",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Clients_ClientID1",
                table: "Subscriptions",
                column: "ClientID1",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Subscriptions_SubscriptionsClientID_SubscriptionsBrokerageID",
                table: "Subscriptions",
                columns: new[] { "SubscriptionsClientID", "SubscriptionsBrokerageID" },
                principalTable: "Subscriptions",
                principalColumns: new[] { "ClientID", "BrokerageID" });
        }
    }
}
