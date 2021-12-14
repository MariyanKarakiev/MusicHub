using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicHub.Infrastructure.Commons;


namespace MusicHub.Infrastructure
{
    public class Producer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_PSEUDONYM)]
        public string Pseudonym { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_PHONENUMBER)]
        public string PhoneNumber { get; set; }

        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
