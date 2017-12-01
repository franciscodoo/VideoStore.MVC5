namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Description) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Description) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Description) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Description) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Description) VALUES (5, 'Comedy')");


            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Hangover I','2009-6-18','2017-11-30','8',5)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Hangover II','2011-6-2','2017-11-30','4',5)");
        }
        
        public override void Down()
        {
        }
    }
}
