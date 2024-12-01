using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int NumberStreet { get; set; }

    public virtual ICollection<Enterprice> Enterprices { get; set; } = new List<Enterprice>();
}
