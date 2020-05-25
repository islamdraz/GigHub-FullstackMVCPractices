namespace FullStackCourse1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Id,Name ) Values (1,'Jazz')");
            Sql("insert into Genres(Id,Name ) Values (2,'Blues')");
            Sql("insert into Genres(Id,Name ) Values (3,'Rock')");
            Sql("insert into Genres(Id,Name ) Values (4,'Country')");
        }
        
        public override void Down()
        {
            Sql("Delete From Genres where id in (1,2,3,4)");
        }
    }
}
