using System.ComponentModel.DataAnnotations;

namespace MusicHub.Core.Models
{
    public class WriterModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_NAME, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_PSEUDONYM, ErrorMessage = "{0} is too long!")]
        [MinLength(Constants.MIN_LENGTH_PSEUDONYM, ErrorMessage = "{0} must be at least {1} letters long!")]
        public string Pseudonym { get; set; }

    }
}
