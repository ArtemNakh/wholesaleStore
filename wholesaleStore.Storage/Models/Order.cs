using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateOrder { get; set; }

    public int Cost { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
