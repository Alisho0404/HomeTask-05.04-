﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
    }
}
