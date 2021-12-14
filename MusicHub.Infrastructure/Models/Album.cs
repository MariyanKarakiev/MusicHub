using MusicHub.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Infrastructure
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }
       
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public virtual ICollection<Song> Songs { get; set; }

    }
}
