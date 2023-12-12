using System.Collections.ObjectModel;

namespace EcommerceMAUI.Model
{
    public class ProductDetail
    {
       

        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        //public List<string> Sizes { get; set; }
        //public List<ReviewModel> Reviews { get; set; }
        //public Color Colors { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }

        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }

       
    }

    //public class ReviewModel
    //{
    //    public string ImageUrl { get; set; }
    //    public string Name { get; set; }
    //    public string Review { get; set; }
    //    public float Rating { get; set; }
    //}
}
