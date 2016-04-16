using System.Security.Cryptography.X509Certificates;
using FizzWare.NBuilder;
using Flashcards.Web.Models;

namespace Flashcards.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlashcardsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FlashcardsDbContext";
        }

        protected override void Seed(FlashcardsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var subject = new Subject();
            subject.Name = "Physics";
            var set1 = new Set();
            set1.Name = "Quantum Physics";
            set1.Subject = subject;
            var set2 = new Set();
            set2.Name = "Real Physics";
            set2.Subject = subject;

            var cards = Builder<Card>.CreateListOfSize(40)
                .All().With(x => x.frontText = Faker.NameFaker.MaleFirstName())
                .With(x=>x.backText = Faker.NameFaker.FemaleFirstName())
                .With(x=>x.Subject=subject)
                .With(x=>x.Set=set1)
                .Random(20)
                .With(x=>x.Set=set2) 
                .Random(20)
                .Build();
        }
    }
}