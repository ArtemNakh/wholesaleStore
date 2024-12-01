using System;
using System.Collections.Generic;

namespace wholesaleStore.Storage.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int? Phone { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int EnterpriceId { get; set; }

    public virtual Enterprice Enterprice { get; set; } = null!;
}
