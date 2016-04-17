using System.Collections.Generic;
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
                var music = new Subject() {Name = "Music"};
                context.Subjects.Add(music);

                var songArtists = new Set() {Name = "Song and Artist", Subject = music};
                var weeksAtNumberOne = new Set()
                {
                    Name = "Consecutive Weeks at #1",
                    Subject = music,
                    Cards = new List<Card>()
                    {
                        new Card() {frontText = "Yeah! by Usher", backText = "12"},
                        new Card() {frontText = "Faith by George Michael", backText = "4"},
                        new Card() {frontText = "(Everything I Do) I Do It for You by Bryan Adams", backText = "7"},
                        new Card() {frontText = "I Want to Hold Your Hand by The Beatles", backText = "7"},
                        new Card() {frontText = "I Gotta Feeling by the eBlack Eyed Peas", backText = "14"},
                        new Card() {frontText = "Theme from Shaft by Isaac Hayes", backText = "2"},
                        new Card() {frontText = "One More Night by Maroon 5", backText = "9"},
                        new Card() {frontText = "Mack the Knife by Bobby Darin", backText = "6"},
                        new Card() {frontText = "Call Me by Blondie", backText = "6"},
                        new Card() {frontText = "Uptown Funk by Mark Ronson", backText = "14"},
                    }
                };


                context.Sets.Add(weeksAtNumberOne);
                context.SaveChanges();
            }
        }
    }
}