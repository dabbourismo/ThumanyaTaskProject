using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thumanya.DataAccessLayer.DatabaseEntities
{
    [Table("Channels")]
    public class Channel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int ChannelTypeId { get; set; }

        public virtual ChannelType ChannelType { get; set; }
    }
}
