using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wholesaleStore.Core.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Enterprice Enterprice { get; set; }
    }
}
