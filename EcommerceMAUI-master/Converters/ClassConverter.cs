using EcommerceMAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.Converters
{
    public class ClassConverter
    {
        public UserProduct ConvertToTargets(CategoriesModel source)
        {
            int UserId = Preferences.Default.Get("UserId", -1);

            return new UserProduct()
            {
                ProductId = source.id,
                ProductName = source.name,
                ProductImageFilePath = source.image_link,
                UserId = UserId,
                Price = Convert.ToDecimal(source.price)


            };
        }

        public UserFav ConvertToFavTargets(CategoriesModel source)
        {
            int UserId = Preferences.Default.Get("UserId", -1);

            return new UserFav()
            {
                ProductId = source.id,
                ProductFavName = source.name,
                ProductImageFilePath = source.image_link,
                ProductFavPrice = (int)Convert.ToDecimal(source.price),
                UserId = UserId

            };
        }

    }
}
