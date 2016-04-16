using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Flashcards.Web.Models
{
    public class Card
    {
        public int Id { get; set; }
        //TODO: Required tags
        public string frontText { get; set; }

        public string backText { get; set; }
        public Set Set { get; set; }
        public Subject Subject { get; set; }
    }
}