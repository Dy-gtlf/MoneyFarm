using System;
using System.Data.Linq.Mapping;

namespace MoneyFarm.Model
{
    [Table(Name = "Logs")]
    class Log
    {
        [Column(Name = "Id", DbType = "INT", IsPrimaryKey = true)]
        public Int32? Id { get; set; }
        [Column(Name = "Content", DbType = "NVARCHAR", CanBeNull = false)]
        public String Content { get; set; }
        [Column(Name = "Category", DbType = "NVARCHAR", CanBeNull = false)]
        public String Category { get; set; }
        [Column(Name = "Memo", DbType = "NVARCHAR")]
        public String Memo { get; set; }
        [Column(Name = "Date", DbType = "NVARCHAR", CanBeNull = false)]
        public String Date { get; set; }
    }
}
