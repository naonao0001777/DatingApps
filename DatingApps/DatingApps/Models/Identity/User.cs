﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApps.Models
{
    public class User
    {  
        public string Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string Sex { get; set; }

        public string BirthDay { get; set; }
    }
}