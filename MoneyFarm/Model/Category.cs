using System.Data.Linq.Mapping;

namespace MoneyFarm.Model
{
    [Table(Name = "Categories")]
    public class Category
    {
        [Column(Name = "Id", DbType = "INT", IsPrimaryKey = true)]
        public int? Id { get; set; }

        [Column(Name = "Group", DbType = "NVARCHAR", CanBeNull = false)]
        public string Group { get; set; }
    }
}
