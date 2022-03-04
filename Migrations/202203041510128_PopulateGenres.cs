namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Action')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Comedy')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Family')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Family')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'History')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Mystery')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Sci-Fi')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'War')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Adventure')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Crime')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Fantasy')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Horror')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'News')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Sport')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Western')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Animation')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Documentary')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Musical')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Biography')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Drama')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Musical')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Romance')");
            Sql("INSERT [dbo].[Genres] ([Name]) VALUES (N'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
