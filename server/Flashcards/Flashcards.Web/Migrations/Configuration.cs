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
                var movies = new Subject() { Name = "Movie and Actors" };
                context.Subjects.Add(movies);
                var moviesandActors = new Set()
                {
                    Name = "Movies and Actors",
                    Subject = movies,
                    Cards = new List<Card>()
                    {
                        new Card() {frontText = "Airplane!", backText = "Leslie Nielson"},
                        new Card() {frontText = "Forrest Gump", backText = "Tom Hanks"},
                        new Card() {frontText = "Office Space", backText = "Ron Livingston"},
                        new Card() {frontText = "Toy Story", backText = "Tim Allen"},
                        new Card() {frontText = "The Godfather", backText = "Marlon Brando"},
                        new Card() {frontText = "Goldfinger", backText = "Sean Connery"}
                    }
                };


                context.Sets.Add(moviesandActors);
                var movieQuotes = new Set()
                {
                    Name = "Movie Quotes",
                    Subject = movies,
                    Cards = new List<Card>()
                    {
                        new Card() {frontText = "Surely you can't be serious! I am serious. And don't...", backText = "Call me Shirley."},
                        new Card() {frontText = "My momma always said, Life was like a box of...", backText = "Potatoes"},
                        new Card() {frontText = "It's not that I'm lazy, it's that...", backText = "I don't care."},
                        new Card() {frontText = "To infinity...", backText = "And beyond!"},
                        new Card() {frontText = "I'm gonna make him an offer he...", backText = "Can't refuse."},
                        new Card() {frontText = "A martini. Shaken...", backText = "Not Stirred"}
                    }
                };
                context.Sets.Add(movieQuotes);

                var music = new Subject() { Name = "Music" };
                context.Subjects.Add(music);

                var songArtists = new Set()
                {
                    Name = "Song and Artist",
                    Subject = music,
                    Cards = new List<Card>()
                    {
                        new Card() {frontText = "Work", backText = "Rihanna"},
                        new Card() {frontText = "Stressed Out", backText = "Ywenty One Pilots"},
                        new Card() {frontText = "7 Years", backText = "Lukas Graham"},
                        new Card() {frontText = "NO", backText = "Meghan Trainor"},
                        new Card() {frontText = "PILLOWTALK", backText = "ZAYN"},
                        new Card() {frontText = "I Took A Pill In Ibiza", backText = "Mike Posner"},
                        new Card() {frontText = "Cake By The Ocean", backText = "DNCE"},
                        new Card() {frontText = "Somewhere On A Beach", backText = "Dierks Bentley"}
                    }
                };


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
                context.Sets.Add(songArtists);
                context.Sets.Add(moviesandActors);
                context.Sets.Add(movieQuotes);
                context.SaveChanges();
            }
        }
    }
}