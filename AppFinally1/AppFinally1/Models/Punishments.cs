using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinally1.Models
{
    [Table("punishments")]
    public class Punishments
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Discription { get; set; }
    }
}
