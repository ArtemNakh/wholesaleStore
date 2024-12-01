using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class Good
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Numbers { get; set; }

    public int EnterpriceId { get; set; }

    public string Maker { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Cost { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Enterprice Enterprice { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
