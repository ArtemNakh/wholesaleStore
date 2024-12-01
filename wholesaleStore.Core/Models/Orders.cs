
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wholesaleStore.Core.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public virtual User user { get; set; }
        public virtual DateTime DateOrder { get; set; }
        public int Cost { get; set; }
        public  virtual ICollection<Goods> Goods { get; set; }



    }
}
