using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_BLL.Models.Season
{
    public class SeasonDTO
    {
        [Column("runtime")]
        int ShowId;
        [Column("season_number")]
        int SeasonNumber;
        [Column("season_name")]
        string SeasonName;
        [Column("episode_count")]
        int EpisodeCount;
        [Column("release_date")]
        DateTime ReleaseDate;
        [Column("description")]
        string Description;
        [Column("poster_url")]
        string ImageUrl;

        public ICollection<EpisodeDTO>? Episodes { get; set; }

    }
}
