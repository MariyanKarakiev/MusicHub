
using System.ComponentModel.DataAnnotations;


namespace MusicHub.Core.Models
{
    public class PerformerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_NAME, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_NAME, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string LastName { get; set; }

        [MaxLength(Constants.MAX_LENGTH_PSEUDONYM, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_PSEUDONYM, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string Pseudonym { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_COUNTRY, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_COUNTRY, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string Country { get; set; }
    }
}
