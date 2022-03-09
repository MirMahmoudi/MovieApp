namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e33060f-180d-437b-804a-719f7f78e6c1', N'guest@movieapp.com', 0, N'APUqGC7Y5/Q5W/SGqKzdKhK0KkbS/KqiYwIystYD3QQxKxYYdErHe2AxId1h+Q+6yw==', N'8ff0e732-8289-467f-bb88-359ec6604ccd', NULL, 0, 0, NULL, 1, 0, N'guest@movieapp.com')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b13dd95d-ebea-4542-944f-3b679e40bc0c', N'admin@movieapp.com', 0, N'ABcBc7M4yVcfAfYcZox58lBkFb+rpgyjnemX/NhSReLylCk7qKfw3adcESzYcrSEBQ==', N'28fbdb8d-aaf9-413d-87da-a696ebf189d0', NULL, 0, 0, NULL, 1, 0, N'admin@movieapp.com')

                INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4c600c66-e26c-47b7-9e94-842462f137ff', N'CanManageMovies')

                INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b13dd95d-ebea-4542-944f-3b679e40bc0c', N'4c600c66-e26c-47b7-9e94-842462f137ff')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
