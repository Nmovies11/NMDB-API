using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMDB_Common.DTO.Actor
{
    public class ActorDTODetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
    }
}
