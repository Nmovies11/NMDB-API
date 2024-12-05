using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_Common.Entities
{
    [Table("movie_actors")]
    public class MovieActor
    {
        [Column("movie_id")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Column("actor_id")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        [Column("role_name")]
        public string Role { get; set; }

    }
}
