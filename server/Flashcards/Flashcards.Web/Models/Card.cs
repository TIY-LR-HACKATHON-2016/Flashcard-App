using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Web.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string frontText { get; set; }
        [Required]
        public string backText { get; set; }
        [Required]
        public Set Set { get; set; }
        [Required]
        public Subject Subject { get; set; }
    }
}