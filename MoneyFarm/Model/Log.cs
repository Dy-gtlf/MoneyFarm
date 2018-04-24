using System;
using System.Data.Linq.Mapping;

namespace MoneyFarm.Model
{
    [Table(Name = "Logs")]
    public class Log
    {
        [Column(Name = "Id", DbType = "INT", IsPrimaryKey = true)]
        public int? Id { get; set; }

        [Column(Name = "Category", DbType = "NVARCHAR", CanBeNull = false)]
        public string Category { get; set; }

        [Column(Name = "Detail", DbType = "NVARCHAR")]
        public string Detail { get; set; }

        [Column(Name = "Balance", DbType = "NVARCHAR", CanBeNull = false)]
        public string Balance { get; set; }

        [Column(Name = "Amount", DbType = "INT", CanBeNull = false)]
        public int Amount { get; set; }

        [Column(Name = "Date", DbType = "NVARCHAR", CanBeNull = false)]
        public string Date { get; set; }
    }
}
