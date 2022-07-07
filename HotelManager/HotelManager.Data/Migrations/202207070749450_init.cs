﻿namespace HotelManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomdationPackagePicture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccomdationPackageId = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomdationPackage", t => t.AccomdationPackageId, cascadeDelete: true)
                .Index(t => t.AccomdationPackageId);
            
            CreateTable(
                "dbo.AccomdationPackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccomodationTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        NoOfRoom = c.String(),
                        PericeNigeth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomodationType", t => t.AccomodationTypeId, cascadeDelete: true)
                .Index(t => t.AccomodationTypeId);
            
            CreateTable(
                "dbo.AccomodationType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccomdationPicture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        AccomdationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accomdation", t => t.AccomdationId, cascadeDelete: true)
                .Index(t => t.AccomdationId);
            
            CreateTable(
                "dbo.Accomdation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccomdationPackageId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomdationPackage", t => t.AccomdationPackageId, cascadeDelete: true)
                .Index(t => t.AccomdationPackageId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AccomdationPicture", "AccomdationId", "dbo.Accomdation");
            DropForeignKey("dbo.Accomdation", "AccomdationPackageId", "dbo.AccomdationPackage");
            DropForeignKey("dbo.AccomdationPackage", "AccomodationTypeId", "dbo.AccomodationType");
            DropForeignKey("dbo.AccomdationPackagePicture", "AccomdationPackageId", "dbo.AccomdationPackage");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Accomdation", new[] { "AccomdationPackageId" });
            DropIndex("dbo.AccomdationPicture", new[] { "AccomdationId" });
            DropIndex("dbo.AccomdationPackage", new[] { "AccomodationTypeId" });
            DropIndex("dbo.AccomdationPackagePicture", new[] { "AccomdationPackageId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Accomdation");
            DropTable("dbo.AccomdationPicture");
            DropTable("dbo.AccomodationType");
            DropTable("dbo.AccomdationPackage");
            DropTable("dbo.AccomdationPackagePicture");
        }
    }
}
