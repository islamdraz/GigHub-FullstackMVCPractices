using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Core.Models
{
    public class Genre
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }




    }
}