using System.Collections.Generic;

namespace Flashcards.Web.Models
{
    public class Set
    {
        public int Id { get; set; }
        public virtual ICollection<Card> Cards { get; set; }   
    }
}