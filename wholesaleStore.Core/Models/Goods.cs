using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Models
{
    public class Goods
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Numbers { get; set; }
        public virtual Enterprice Enterprice { get; set; }
        public string Maker { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }



        public virtual ICollection<Orders> Orders { get; set; }
    }
}
