using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MusicHub.Infrastructure.Commons;

namespace MusicHub.Infrastructure
{
    public class Performer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string LastName { get; set; }

        [MaxLength(Constants.MAX_LENGTH_PSEUDONYM)]
        public string Pseudonym { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_COUNTRY)]
        public string Country { get; set; }

        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
