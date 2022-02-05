namespace Vidly_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSeeds : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54e46fd0-dd41-4ea4-acb2-afc18142b3a6', N'admin@vidly.com', 0, N'ABgpQ++INAAjloZ2KJZyI2CsMZynUi8wo3Djs1UlK5fsE/fH0IdANkeGBAHrLi+8BA==', N'4429a09c-7310-4d62-a034-e52075f92da1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8adc2060-7280-4560-9379-92d78d116376', N'mosh@domain.com', 0, N'AKI7Xrjo//b+LrHZ7Vk9oFcLr620SFjfwczAdOnLZYEvPCp+W6PAaHh9ztNvNOVdPw==', N'd6f771a3-d01c-4386-ab9f-014c8adb0d25', NULL, 0, 0, NULL, 1, 0, N'mosh@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'adab0750-4729-49fa-8d1b-2f13f3fece42', N'guest@vidly.com', 0, N'AOONIbqwS0iYZJIwZtmVxRzma3+CRylY7uMHI+Stmo7pt7hcFVbXIHDvdc9SLhdpCQ==', N'97da188a-8a82-40a9-81b1-ebb13ccf43a4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5bb1e718-1694-40e5-8baf-67dc2114a651', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'54e46fd0-dd41-4ea4-acb2-afc18142b3a6', N'5bb1e718-1694-40e5-8baf-67dc2114a651')
");
        }
        
        public override void Down()
        {
        }
    }
}
