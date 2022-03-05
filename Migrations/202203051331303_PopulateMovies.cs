namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Movies] ON 
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (1, N'The Shawshank Redemption', 3, CAST(N'1994-10-14T00:00:00.0000000' AS DateTime2), 10, 0, CAST(N'2016-01-02T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (2, N'The Godfather', 1, CAST(N'1974-03-24T00:00:00.0000000' AS DateTime2), 10, 0, CAST(N'2018-03-04T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (3, N'The Dark Knight', 1, CAST(N'2008-07-18T00:00:00.0000000' AS DateTime2), 10, 0, CAST(N'2019-04-05T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (4, N'12 Angry Men', 3, CAST(N'1957-04-10T00:00:00.0000000' AS DateTime2), 5, 0, CAST(N'2020-05-06T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (5, N'Schindler''s List', 3, CAST(N'1994-02-04T00:00:00.0000000' AS DateTime2), 5, 0, CAST(N'2017-02-03T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (6, N'The Lord of the Rings: The Return of the King', 1, CAST(N'2003-12-17T00:00:00.0000000' AS DateTime2), 10, 0, CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (7, N'Pulp Fiction', 3, CAST(N'1994-10-14T00:00:00.0000000' AS DateTime2), 2, 3, CAST(N'2010-07-06T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (8, N'The Good, the Bad and the Ugly', 1, CAST(N'1967-12-29T00:00:00.0000000' AS DateTime2), 10, 2, CAST(N'2010-06-06T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (9, N'Fight Club', 4, CAST(N'1994-07-06T00:00:00.0000000' AS DateTime2), 9, 6, CAST(N'2010-02-03T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (10, N'Forrest Gump', 4, CAST(N'1994-07-06T00:00:00.0000000' AS DateTime2), 9, 6, CAST(N'2010-02-03T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (11, N'Inception', 1, CAST(N'2010-07-16T00:00:00.0000000' AS DateTime2), 8, 8, CAST(N'2010-06-07T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (12, N'The Matrix', 1, CAST(N'1999-03-31T00:00:00.0000000' AS DateTime2), 12, 2, CAST(N'2016-08-09T00:00:00.0000000' AS DateTime2))
            INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [ReleaseDate], [NumberInStock], [NumberAvailable], [DateAdded]) VALUES (13, N'Goodfellas', 2, CAST(N'1990-09-21T00:00:00.0000000' AS DateTime2), 4, 0, CAST(N'2022-02-23T11:08:33.4937584' AS DateTime2))
            SET IDENTITY_INSERT [dbo].[Movies] OFF
            ");
        }

        public override void Down()
        {
        }
    }
}
