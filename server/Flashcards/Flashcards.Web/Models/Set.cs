using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Web.Models
{
    public class Set
    {
        public int Id { get; set; }
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }
    }
}