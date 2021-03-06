﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flashcards.Web.Models
{
    public class CreateCardVM
    {
        [Required]
        public string frontText { get; set; }
        [Required]
        public string backText { get; set; }
        public string FrontImgURL { get; set; }
        public string BackImgURL { get; set; }
        [Required]
        public int SetId { get; set; }
    }


    public class CreateSetVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public string ImgURL { get; set; }
    }


    public class CreateSubjectVM
    {
        [Required]
        public string Name { get; set; }
        public string ImgURL { get; set; }
    }
}