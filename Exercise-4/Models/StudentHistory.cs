using System;
using System.Collections.Generic;

namespace Exercise_4.Models
{
    public partial class StudentHistory
    {
        public int StudentHistoryId { get; set; }
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? ActionTaken { get; set; }
        public string? Username { get; set; }
        public DateTime? Today { get; set; }
    }
}
