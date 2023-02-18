namespace PhoneBook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeritabaniGuncelle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Epostas", "Uid", c => c.Int(nullable: false));
            AddColumn("dbo.Konums", "Uid", c => c.Int(nullable: false));
            AddColumn("dbo.Telefons", "Uid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telefons", "Uid");
            DropColumn("dbo.Konums", "Uid");
            DropColumn("dbo.Epostas", "Uid");
        }
    }
}
