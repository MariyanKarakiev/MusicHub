using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MusicHub.Infrastructure.Commons;
using MusicHub.Infrastructure.Enums;

namespace MusicHub.Infrastructure
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_NAME)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(Constants.MAX_LENGTH_URL)]
        public string PictureURL { get; set; }


        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [Required]
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
