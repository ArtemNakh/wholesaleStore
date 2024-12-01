using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace wholesaleStore.Core.Models
{
    public class Enterprice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public virtual FieldActivity FieldActivity { get; set; }
        public virtual Addresses Addresses { get; set; }



    }
}
