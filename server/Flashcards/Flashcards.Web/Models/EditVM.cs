using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flashcards.Web.Models
{
    public class EditCardVM
    {
        //[Required]
        public string frontText { get; set; }
        //[Required]
        public string backText { get; set; }
        //[Required]
        public string FrontImgURL { get; set; }
        //[Required]
        public string BackImgURL { get; set; }
        //[Required]
        public int Id { get; set; }
        [Required]
        public int SetId { get; set; }
    }

    public class EditSetVM
    {
        [Required]
        public string Name { get; set; }
       // [Required]
        public int Id { get; set; }
        public string ImgURL { get; set; }
        [Required]
        public int frontText { get; set; }
    }


    public class EditSubjectVM
    {
        [Required]
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public int Id { get; set; }
    }
}