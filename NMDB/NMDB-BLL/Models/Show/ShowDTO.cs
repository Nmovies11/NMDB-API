using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Models.Show
{
    public class ShowDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("Status")]
        public string Status { get; set; }
        [Column("director")]
        public string Director { get; set; }

        [Column("poster_url")]
        public string ImageUrl { get; set; }

    }
}
