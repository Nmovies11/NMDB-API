using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Models
{
    public class EpisodeDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("director")]
        public string Director { get; set; }
        [Column("runtime)]")]   
        public int Runtime { get; set; }
        [Column("show_id")]
        public int ShowId { get; set; }
    }
}
