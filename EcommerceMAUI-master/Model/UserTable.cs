using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using SQLiteNetExtensions.Attributes;

namespace EcommerceMAUI.Model
{
    [SQLite.Table("UserTable")]
    public class UserTable
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<UserProduct> Products { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<UserFav> FavUserProduct { get; set; }
    }

   
}
