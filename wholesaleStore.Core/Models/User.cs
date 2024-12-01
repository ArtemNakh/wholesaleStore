﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace wholesaleStore.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DateActivity { get; set; }
        public DateTime Birthday { get; set; }
    }
}
