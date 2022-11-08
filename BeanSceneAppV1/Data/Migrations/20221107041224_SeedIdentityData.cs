using BeanSceneAppV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Migrations
{
    public partial class SeedIdentityData : Migration
    {
        private MigrationBuilder? _migrationBuilder;
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Make sure the migration builder is available to other methods
            _migrationBuilder = migrationBuilder;

            //guids from https://guidgenerator.com/online-guid-generator.aspx
            /*
             * 
             * 
             * 
             * 
             * 
             * 4aad9167-fe03-4100-ba60-01246bd96745
             * f989bd56-388e-48c3-821b-878911d6984e
             */

            // Assign role and user ids
            string roleMemberId = "86fa9752-0fba-4a40-bc94-fdce825eb417";
            string roleStaffId = "bd5300a0-47f6-48c3-8cf1-f44265ec13fb";
            string roleManagerId = "0c696da5-1792-4243-8310-70a50a86830b";
            string user1 = "4aad9167-fe03-4100-ba60-01246bd96745";
            string user2 = "a8b2fc99-3400-4e20-a722-4147bb670dca";
            string user3 = "eab9b0af-8098-4777-a67e-6e3ff5afe005";
            // Add roles to the AspNetRoles table
            //string roleId = Guid.NewGuid().ToString();
            CreateRole(roleMemberId, "Member");
            CreateRole(roleStaffId, "Staff");
            CreateRole(roleManagerId, "Manager");
            // Add users to the AspNetUsers table and assign roles
                    
            // Manager
            CreateUser(user1, "BarryBeanScene", "Barry123", "Barry@BeanScene.com", null, "Barry", "Bayman"
               , new string[] { roleStaffId, roleManagerId });
           
            // Staff
            CreateUser(user2, "MitchBeanScene", "Mitch123", "Mitch@BeanScene.com", null, "Mitch", "Michaels"
                , new string[] { roleStaffId }); 
            // Member
            CreateUser(user3, "MemberGary", "Garfaulk", "GaryFaulkner@Gmail.com", "04100", "Gary", "Faulkner"
               , new string[] { roleMemberId }); 
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Make sure the migration builder is available to other methods
            _migrationBuilder = migrationBuilder;

            //cleanup


            // Assign role and user ids
            string roleMemberId = "86fa9752-0fba-4a40-bc94-fdce825eb417";
            string roleStaffId = "bd5300a0-47f6-48c3-8cf1-f44265ec13fb";
            string roleManagerId = "0c696da5-1792-4243-8310-70a50a86830b";
            string user1 = "4aad9167-fe03-4100-ba60-01246bd96745";
            string user2 = "a8b2fc99-3400-4e20-a722-4147bb670dca";
            string user3 = "eab9b0af-8098-4777-a67e-6e3ff5afe005";
            // Delete roles from the AspNetRoles table
            DeleteRole(roleMemberId);
            DeleteRole(roleStaffId);
            DeleteRole(roleManagerId);
            // Delete users from the AspNetUsers table
            DeleteUser(user1);
            DeleteUser(user2);
            DeleteUser(user3);
        }
        void CreateRole(string id, string name)
        {
            //TODO 1 Validation

            // Our new role object to hold all the data
            IdentityRole role = new IdentityRole();
            role.Id = id;
            role.Name = name;

            // Generate normalised name ( so you don't have 2 practically identical records
            role.NormalizedName = name.ToUpperInvariant();
            // Concurrency stamp is a random value that must change whenever a user is persisted to the app
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            // Build Query
            string[] fields = { "Id", "Name", "NormalizedName", "ConcurrencyStamp" };
            string[] data = { role.Id, role.Name, role.NormalizedName, role.ConcurrencyStamp };
            // Insert record into DB
            _migrationBuilder.InsertData("AspNetRoles", fields, data);
        }

        void CreateUser(string id, string userName, string password, string email, string phone, string firstName, string lastName, string[]? roleIds = null)
        {
            //TODO 1 Validation

            // Our new user object to hold all the data
            ApplicationUser user = new ApplicationUser();

            user.Id = id;
            user.UserName = userName;
            user.Email = email;
            user.PhoneNumber = phone;
            user.First_Name = firstName;
            user.Last_Name = lastName;

            // Generate normalised name ( so you don't have 2 practically identical records
            user.NormalizedUserName = userName.ToUpperInvariant();
            user.NormalizedEmail = email.ToUpperInvariant();
            // Concurrency stamp is a random value that must change whenever a user is persisted to the app
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            // Security stamp is a random value that must change whenever a user's credentials change
            user.SecurityStamp = Guid.NewGuid().ToString();
            // Generate password hash from plaintext password
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);
            // Other data
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            user.TwoFactorEnabled = false;
            user.LockoutEnd = null;
            user.LockoutEnabled = true;
            user.AccessFailedCount = 0;

            // Build Query
            string[] fields = { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp",
                "PhoneNumber", "PhoneNumberConfirmed","TwoFactorEnabled" ,"LockoutEnd" , "LockoutEnabled","AccessFailedCount" ,"First_Name" , "Last_Name" };
            object[] data = { user.Id, user.UserName, user.NormalizedUserName, user.Email, user.NormalizedEmail, user.EmailConfirmed, user.PasswordHash, user.SecurityStamp, user.ConcurrencyStamp,
                user.PhoneNumber, user.PhoneNumberConfirmed,user.TwoFactorEnabled ,user.LockoutEnd ,user.LockoutEnabled,user.AccessFailedCount ,user.First_Name , user.Last_Name };
            // Insert record into DB
            _migrationBuilder.InsertData("AspNetUsers", fields, data);

            // Assign roles to user
            if (roleIds != null)
            {
                foreach (string roleId in roleIds)
                {
                    AssignRoleToUser(user.Id, roleId);
                }
            }
        }
        void AssignRoleToUser(string userId, string roleId)
        {
            //TODO validation check if both role and user exist

            //build query
            string[] fields = { "UserId", "RoleId" };
            object[] data = { userId, roleId };
            // Insert record into DB
            _migrationBuilder.InsertData("AspNetUserRoles", fields, data);
        }
        void DeleteRole(string id)
        {
            //TODO 1 Validation

            // Insert record into DB
            _migrationBuilder.DeleteData("AspNetRoles", "Id", id);
        }
        void DeleteUser(string id)
        {
            //TODO 1 Validation

            // Insert record into DB
            _migrationBuilder.DeleteData("AspNetUsers", "Id", id);
        }
    }
}
