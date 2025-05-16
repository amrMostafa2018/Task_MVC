using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Seed(migrationBuilder);
        }

        private void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Name", "CreatedDate", "CreatedById", "CreatedByName" },
                values: new object[,]
                {
                    {"HR Department" , DateTime.Now , "1" ,  "Test"},
                    {"Development Department", DateTime.Now , "1" ,  "Test"}
                });

            migrationBuilder.InsertData(
                 table: "Employees",
                 columns: new[] { "FirstName", "LastName", "Salary", "DepartmentId", "ManagerId", "CreatedDate", "CreatedById", "CreatedByName" },
                 values: new object[,]
                  {
                    {"Amr" ,"Mostafa" ,2500 ,1 , null , DateTime.Now , "1" ,  "Test"},
                    {"Ahmed" ,"Mohamed" ,5000,1 , 1 , DateTime.Now , "1" ,  "Test"},
                  });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
