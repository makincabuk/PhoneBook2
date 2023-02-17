namespace PhoneBook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeritabaniOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Epostas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UUID = c.String(),
                        posta = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kisis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UUID = c.String(),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Firma = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Konums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UUID = c.String(),
                        konum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UUID = c.String(),
                        telefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Telefons");
            DropTable("dbo.Konums");
            DropTable("dbo.Kisis");
            DropTable("dbo.Epostas");
        }
    }
}
