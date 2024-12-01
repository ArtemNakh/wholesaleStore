using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class FieldActivity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Enterprice> Enterprices { get; set; } = new List<Enterprice>();
}
