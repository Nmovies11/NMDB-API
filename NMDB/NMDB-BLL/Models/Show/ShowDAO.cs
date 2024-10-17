using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_BLL.Models.Season;

namespace NMDB_BLL.Models.Show
{
    public class ShowDAO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        
        public ICollection<SeasonDAO>? Seasons { get; set; }
    }
}
