using System.Collections.Generic;

namespace Flashcards.Web.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public virtual ICollection<Set> Sets { get; set; }
        public string Name { get; set; }
    }
}