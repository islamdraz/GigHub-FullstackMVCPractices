using System.ComponentModel.DataAnnotations;

namespace GigHub.Model.Models
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