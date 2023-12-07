using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeatStreakBackEnd.Models
{
    public class ChoreItemModel
    {
        public bool IsCompleted { get; set; }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Title { get; set; }

        public string? Date { get; set; }

        public string? Category { get; set; }

        public bool IsDeleted { get; set; }

        public ChoreItemModel() {}
    }
}