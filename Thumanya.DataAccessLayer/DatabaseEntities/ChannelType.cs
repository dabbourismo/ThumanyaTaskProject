using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thumanya.DataAccessLayer.DatabaseEntities
{
    [Table("ChannelTypes")]
    public class ChannelType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
