﻿using System;
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
        public virtual Set Set { get; set; }

        public string FrontImgURL { get; set; }
        public string BackImgURL { get; set; }
    }
}