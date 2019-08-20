namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d751197-549d-43ac-ab59-fc1f4275a0dd', N'hoaqn.1811@gmail.com', 0, N'APkGXfhWoUnTb7ELV6KvdKEPzZy8PT4vfxtzc8HPvgaMFf79R4COI+GziIdTXryC9Q==', N'ebb8dff9-95b2-4ead-ac31-f3576a9b845a', NULL, 0, 0, NULL, 1, 0, N'hoaqn.1811@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f348d61c-5eee-47b6-af70-400a7265befa', N'admin@vidly.com', 0, N'AGG+rwsuEENdPA5Sgd2TaSazE8ouoHVQOMF8fgmnMgjGV2ZbZSKfk2LXnJaXKSo68A==', N'745923ba-7e50-4a39-8f89-2ceee6c80fe0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a527e5b8-2918-415d-88a6-8173950d244e', N'CanManagerMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f348d61c-5eee-47b6-af70-400a7265befa', N'a527e5b8-2918-415d-88a6-8173950d244e')

");
            
        }
        
        public override void Down()
        {
        }
    }
}
