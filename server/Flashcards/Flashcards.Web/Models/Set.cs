using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Web.Models
{
    public class Set
    {
        public int Id { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public string Name { get; set; }
        [Required]
        public Subject Subject { get; set; }
    }
}