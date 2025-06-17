using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thumanya.DataAccessLayer.DatabaseEntities
{
    [Table("Authers")]
    public class Auther
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public string ProfileImage { get; set; }
    }
}
