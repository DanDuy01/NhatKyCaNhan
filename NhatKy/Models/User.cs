using System;
using System.Collections.Generic;

namespace NhatKy.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
