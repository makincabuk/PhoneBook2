namespace PhoneBook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeritabaniGuncelle2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Epostas", "Etiket", c => c.String());
            AddColumn("dbo.Konums", "Etiket", c => c.String());
            AddColumn("dbo.Telefons", "Etiket", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telefons", "Etiket");
            DropColumn("dbo.Konums", "Etiket");
            DropColumn("dbo.Epostas", "Etiket");
        }
    }
}
