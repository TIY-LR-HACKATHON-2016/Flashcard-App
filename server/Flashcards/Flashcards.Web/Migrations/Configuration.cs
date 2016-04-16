using System.Data.Entity.Migrations;
using System.Linq;
using Faker;
using FizzWare.NBuilder;
using Flashcards.Web.Models;

namespace Flashcards.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FlashcardsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FlashcardsDbContext";
        }

        protected override void Seed(FlashcardsDbContext context)
        {
            if (!context.Cards.Any())
            {
                var subject = new Subject {Name = "Physics"};
                context.Subjects.Add(subject);

                var sets = Builder<Set>.CreateListOfSize(5)
                    .All()
                    .With(s => s.Subject = subject)
                    .With(s => s.Name = CompanyFaker.Name())
                    .With(s => s.Cards = Builder<Card>.CreateListOfSize(NumberFaker.Number(10, 50))
                        .All()
                        .With(x => x.frontText = NameFaker.MaleFirstName())
                        .With(x => x.backText = NameFaker.FemaleFirstName())
                        .With(x => x.Set == s)
                        .Random(10).With(x => x.FrontImgURL = "http://i.imgur.com/lWS7uYp.jpg")
                        .Build())
                    .Build();

                context.Sets.AddRange(sets);
                context.SaveChanges();
            }
        }
    }
}