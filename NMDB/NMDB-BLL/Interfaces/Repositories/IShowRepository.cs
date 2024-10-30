using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMDB_Common.Entities;

namespace NMDB_BLL.Interfaces.Repositories
{
    public interface IShowRepository
    {
        Task<List<Show>> GetRecentShows();
        Task<Show> GetShowById(int id);
    }
}
