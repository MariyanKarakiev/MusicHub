using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MusicHub.Infrastructure.Commons;

namespace MusicHub.Infrastructure
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string Name { get; set; }

        [MaxLength(Constants.MAX_LENGTH_PSEUDONYM)]
        public string Pseudonym { get; set; }

        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
