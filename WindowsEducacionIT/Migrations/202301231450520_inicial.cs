namespace WindowsEducacionIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDEstado = c.Int(nullable: false),
                        IDPlanilla = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.IDEstado, cascadeDelete: true)
                .ForeignKey("dbo.Planilla", t => t.IDPlanilla, cascadeDelete: true)
                .Index(t => t.IDEstado)
                .Index(t => t.IDPlanilla);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Planilla",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        IDCurso = c.Int(nullable: false),
                        IDCarrera = c.Int(nullable: false),
                        IDMateria = c.Int(nullable: false),
                        IDProfesor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.IDCurso, cascadeDelete: true)
                .ForeignKey("dbo.Materia", t => t.IDMateria, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.IDProfesor, cascadeDelete: true)
                .Index(t => t.IDCurso)
                .Index(t => t.IDCarrera)
                .Index(t => t.IDMateria)
                .Index(t => t.IDProfesor);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: true)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(),
                        Calle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.String(),
                        IDLocalidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: true)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDTipo = c.Int(nullable: false),
                        IDEstudiante = c.Int(nullable: false),
                        IDDetalle = c.Int(nullable: false),
                        Nota = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Detalle", t => t.IDDetalle, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.IDEstudiante, cascadeDelete: true)
                .ForeignKey("dbo.Tipo", t => t.IDTipo, cascadeDelete: true)
                .Index(t => t.IDTipo)
                .Index(t => t.IDEstudiante)
                .Index(t => t.IDDetalle);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        IDCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .Index(t => t.IDCarrera);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plan", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Evaluacion", "IDTipo", "dbo.Tipo");
            DropForeignKey("dbo.Evaluacion", "IDEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "IDDetalle", "dbo.Detalle");
            DropForeignKey("dbo.Estudiante", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Detalle", "IDPlanilla", "dbo.Planilla");
            DropForeignKey("dbo.Planilla", "IDProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Profesor", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Planilla", "IDMateria", "dbo.Materia");
            DropForeignKey("dbo.Planilla", "IDCurso", "dbo.Curso");
            DropForeignKey("dbo.Planilla", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Detalle", "IDEstado", "dbo.Estado");
            DropIndex("dbo.Plan", new[] { "IDCarrera" });
            DropIndex("dbo.Evaluacion", new[] { "IDDetalle" });
            DropIndex("dbo.Evaluacion", new[] { "IDEstudiante" });
            DropIndex("dbo.Evaluacion", new[] { "IDTipo" });
            DropIndex("dbo.Estudiante", new[] { "IDLocalidad" });
            DropIndex("dbo.Profesor", new[] { "IDLocalidad" });
            DropIndex("dbo.Planilla", new[] { "IDProfesor" });
            DropIndex("dbo.Planilla", new[] { "IDMateria" });
            DropIndex("dbo.Planilla", new[] { "IDCarrera" });
            DropIndex("dbo.Planilla", new[] { "IDCurso" });
            DropIndex("dbo.Detalle", new[] { "IDPlanilla" });
            DropIndex("dbo.Detalle", new[] { "IDEstado" });
            DropTable("dbo.Plan");
            DropTable("dbo.Tipo");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Localidad");
            DropTable("dbo.Profesor");
            DropTable("dbo.Materia");
            DropTable("dbo.Planilla");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Carrera");
        }
    }
}
