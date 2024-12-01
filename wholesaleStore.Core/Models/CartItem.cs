using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wholesaleStore.Core.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public virtual User User { get; set; } // зв'язок з користувачем
        public virtual Goods Product { get; set; } // товар в корзині
        public int Quantity { get; set; } // кількість
        public DateTime DateAdded { get; set; } // дата додавання
    }
}
