using NMDB_Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_Common.Entities
{
    public class Movie
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("release_date")]
        public DateOnly ReleaseDate { get; set; }
        [Column("director")]
        public string Director { get; set; }

        [Column("poster_url")]
        public string ImageUrl { get; set; }
        [Column("backdrop_url")]
        public string BackdropUrl { get; set; }
        [Column("testValue")]
        public string TestValue { get; set; }
        [Column("runtime")]
        public int Runtime { get; set; }
        [Column("genre")]
        public string Genre { get; set; }
        [Column("rating")]
        public double Rating { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }

    }
}
