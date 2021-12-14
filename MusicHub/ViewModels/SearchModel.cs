using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Core.Models
{
    public class SearchModel
    {
        public List<SongModel> Songs { get; set; }
        public SelectList Genres { get; set; }
        public string Genre { get; set; }
        public string SearchString { get; set; }
    }
}
