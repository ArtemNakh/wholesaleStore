using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class Enterprice
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public string Email { get; set; } = null!;

    public int Phone { get; set; }

    public int FieldActivityId { get; set; }

    public int AddressesId { get; set; }

    public virtual Address Addresses { get; set; } = null!;

    public virtual ICollection<Administrator> Administrators { get; set; } = new List<Administrator>();

    public virtual FieldActivity FieldActivity { get; set; } = null!;

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
