namespace HotelManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColUserIdToColHotelUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookAccmodation", name: "HotelUser_Id", newName: "HotelUserId");
            RenameIndex(table: "dbo.BookAccmodation", name: "IX_HotelUser_Id", newName: "IX_HotelUserId");
            DropColumn("dbo.BookAccmodation", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookAccmodation", "UserId", c => c.String());
            RenameIndex(table: "dbo.BookAccmodation", name: "IX_HotelUserId", newName: "IX_HotelUser_Id");
            RenameColumn(table: "dbo.BookAccmodation", name: "HotelUserId", newName: "HotelUser_Id");
        }
    }
}
