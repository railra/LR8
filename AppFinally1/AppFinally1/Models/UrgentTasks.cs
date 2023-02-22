using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinally1.Models
{
    [Table("urgent_tasks")]
    public class UrgentTasks
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Date { get; set; }
        public int? PunishmentId { get; set; }
        [NotNull]
        public bool Completed { get; set; }


    }
}
