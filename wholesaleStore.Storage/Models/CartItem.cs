using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class CartItem
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Good Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
