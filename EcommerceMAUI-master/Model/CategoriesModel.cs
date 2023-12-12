
namespace EcommerceMAUI.Model
{
    public class CategoriesModel
    {

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


    }
}
