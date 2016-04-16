using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class FlashcardsDbContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public FlashcardsDbContext() : base("name=FlashcardsDbContext")
    {
    }

    public System.Data.Entity.DbSet<Flashcards.Web.Models.Card> Cards { get; set; }
    public System.Data.Entity.DbSet<Flashcards.Web.Models.Set> Sets { get; set; }
    public System.Data.Entity.DbSet<Flashcards.Web.Models.Subject> Subjects { get; set; }
}
