using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Question1 { get; set; } = null!;
        public string A { get; set; } = null!;
        public string B { get; set; } = null!;
        public string C { get; set; } = null!;
        public string D { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
