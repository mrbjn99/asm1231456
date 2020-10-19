﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AsmAppDev2.Models
{
  // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  public class ApplicationUser : IdentityUser
  {


    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
    public string Full_Name { get; set; }
    public string Education { get; set; }
    public string Programming_Language { get; set; }
    public string Experience_Details { get; set; }
    public string Department { get; set; }
    public string Working_Place { get; set; }
  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<AssignTraineetoCourse> AssignTraineetoCourses { get; set; }
    public DbSet<AssignTrainertoTopic> AssignTrainertoTopics { get; set; }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}