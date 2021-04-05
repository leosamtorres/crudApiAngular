namespace Entrevista.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Versao_Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 120),
                    CPF = c.String(nullable: false, maxLength: 11),
                    Email = c.String(nullable: false, maxLength: 50),
                    Telefone = c.String(nullable: false, maxLength: 15),
                    idSexo = c.Int(nullable: false),
                    DataNascimento = c.String(nullable: false, maxLength: 10)

                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CPF, unique: true, name: "IX_USUARIO_CPF");

            //CreateTable(
            //    "dbo.TipoSexo",
            //    c => new
            //    {
            //        idSexo = c.Int(nullable: false, identity: true),
            //        Sexo = c.String(nullable: false, maxLength: 20)
            //    })
            //    .PrimaryKey(t => t.idSexo);

            //AlterColumn("dbo.Usuario", "idSexo", c => c.Int(nullable: false));
            //CreateIndex("dbo.Usuario", "idSexo");
            //AddForeignKey("dbo.Usuario", "idSexo", "dbo.TipoSexo", "idSexo");

        }

        public override void Down()
        {
            DropIndex("dbo.Usuario", "IX_USUARIO_CPF");
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoSexo");

        }

        //public override void Up()
        //{
        //    CreateTable(
        //        "dbo.Cliente",
        //        c => new
        //        {
        //            Id = c.Int(nullable: false, identity: true),
        //            CNPJ = c.String(nullable: false, maxLength: 14),
        //            Nome = c.String(nullable: false, maxLength: 120),
        //        })
        //        .PrimaryKey(t => t.Id)
        //        .Index(t => t.CNPJ, unique: true, name: "IX_CLIENTE_CNPJ");

        //}

        //public override void Down()
        //{
        //    DropIndex("dbo.Cliente", "IX_CLIENTE_CNPJ");
        //    DropTable("dbo.Cliente");
        //}

    }
}
