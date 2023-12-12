using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.Model
{
    [SQLite.Table("UserProduct")]
    public class UserProduct
    {
        [PrimaryKey, AutoIncrement]
        public int UserProductId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageFilePath { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(UserTable))]
        public int UserId { get; set; }

      
    }
}
