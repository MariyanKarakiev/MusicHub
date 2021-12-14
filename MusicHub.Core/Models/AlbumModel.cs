using System;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Core.Models
{
    public class AlbumModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_NAME, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(0.01, 1000.00, ErrorMessage = "{0} must be between {1}$ and {2}$!")]
        public decimal Price { get; set; }

        [Required]
        public int? ProducerId { get; set; }
        public string Producer { get; set; }
    }
}
