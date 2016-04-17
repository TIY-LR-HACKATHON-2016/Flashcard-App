using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Web.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
        [Required]
        public string Name { get; set; }

        public string ImgURL { get; set; }
      
    }
}