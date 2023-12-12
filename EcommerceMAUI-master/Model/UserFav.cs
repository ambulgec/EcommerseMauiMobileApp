//using Intents;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.Model
{
    [SQLite.Table("UserFav")]
    public class UserFav
    {
        [PrimaryKey, AutoIncrement]
        public int ProductsFavId { get; set; }
        public string ProductFavName { get; set; }
        public string ProductImageFilePath { get; set; }
        public int ProductId { get; set; }
        public int ProductFavPrice { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(UserTable))]
        public int UserId { get; set; }


    }
}
