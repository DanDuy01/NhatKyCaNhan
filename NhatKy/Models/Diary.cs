using System;
using System.Collections.Generic;

namespace NhatKy.Models
{
    public partial class Diary
    {
        public int DiaryId { get; set; }
        public string? Mood { get; set; }
        public DateTime Time { get; set; }
        public string? Note { get; set; }
        public bool? Favourite { get; set; }
    }
}
