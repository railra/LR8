using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinally1.Models
{
    [Table("small_tasks")]
    public class SmallTasks
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Discription { get; set; }
        [NotNull]
        public bool Completed { get; set; }
    }
}
