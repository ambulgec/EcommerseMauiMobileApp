using System.Collections.ObjectModel;

namespace EcommerceMAUI.Model
{
    public class ProductListModel
    {
        private ProductListModel kl;

        public ProductListModel()
        {
        }

        public ProductListModel(ProductListModel kl)
        {
            this.kl = kl;
        }

        public int id { get; set; }
        public string brand { get; set; }
        public object Brand { get; internal set; }
        public string name { get; set; }
        public string price { get; set; }
        public string price_sign { get; set; }
        public string currency { get; set; }
        public string image_link { get; set; }
        public string product_link { get; set; }
        public string website_link { get; set; }
        public string description { get; set; }
        public object rating { get; set; }
        public string category { get; set; }
        public string product_type { get; set; }
        public string[] tag_list { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string product_api_url { get; set; }
        public string api_featured_image { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }



        //Regular Emart
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; }

        public static implicit operator ObservableCollection<object>(ProductListModel v)
        {
            throw new NotImplementedException();
        }
    }
}
