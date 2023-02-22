using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinally1.Models
{
    [Table("achievments")]
    public class Achievments
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        public int Parrent { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Date { get; set; }
    }
}
