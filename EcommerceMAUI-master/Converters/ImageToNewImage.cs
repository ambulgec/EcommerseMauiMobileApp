using System.Globalization;
using static System.Net.WebRequestMethods;

namespace EcommerceMAUI.Converters;

public class ImageToNewImage : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string originalImageLink)
        {
            // Implement your logic to determine the new image link
            string newImageLink = DetermineNewImageLink(originalImageLink);

            if(newImageLink == "https://cdn.shopify.com/s/files/1/1016/3243/products/LIPBALM_LID_grande.jpg?v=1496848378")// Return the new image link
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/dd6ee943412a416ecfe9e4a1b2bed107_ra,w158,h184_pa,w158,h184.jpg";
            }

          else if(newImageLink =="https://3bc01d2807fb1bc0d25c-a86d2521f1af8989841b9619f5314be5.ssl.cf1.rackcdn.com/products/market-img/rdn-serum-foundation-30-r-30ml.png?v=6ab9fcb8ca2abb9828afcf9dcdad9f94")
                        {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/dd6ee943412a416ecfe9e4a1b2bed107_ra,w158,h184_pa,w158,h184.jpg";
            }

            else if (newImageLink =="https://www.purpicks.com/wp-content/uploads/2018/06/Zorah-Biocosmetiques-Liquid-Liner.png")
                    {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3fd71730443a4f57b798668c24d0ad19_ra,w158,h184_pa,w158,h184.jpg";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/w3llpeople-Realist-Invisible-Setting-Powder.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/7fb45dded4fbe7603a9aa9f56a65eeca_ra,w158,h184_pa,w158,h184.png";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Sally-B_s-Skin-Yummies-B-Smudged-1.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/d45c12626255b3ebd4d674060e1a38b3_ra,w158,h184_pa,w158,h184.jpeg";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Rejuva-Minerals-Multi-Purpose-Powder-Blush-_-Eye-1.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3dc157e4a7e28f90dbe7e9849ccfc87a_ra,w158,h184_pa,w158,h184.jpg";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/csm/sunset-bronze-pennylaneorganics1.jpg")
                {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/648283e42d7fafb7c03e8c60274cd5e0_ra,w158,h184_pa,w158,h184.png";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Nudus-Amalia.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/7dab50d3ac08ea9c5f2373531a47dd17_ra,w158,h184_pa,w158,h184.png";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/csm/caramel_1024x1024_e5fbf151-0cfd-42c9-a5ec-f49d6104bcbc1.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/1b01ce49ace4842e034664361f1310de_ra,w158,h184_pa,w158,h184.jpg";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Maia%E2%80%99s-Mineral-Galaxy-Mineral-Eye-Brow-Liner-Charcoal-Brown.jpg")
                {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/648283e42d7fafb7c03e8c60274cd5e0_ra,w158,h184_pa,w158,h184.png";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/03/lotus-cosmetics-usa-mascara-black.png")
                {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/b52e199adc7a7a95d3b910cc234ffd65_ra,w158,h184_pa,w158,h184.jpeg";
            }

            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Green-People-Volumising-Mascara-Black.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/7dab50d3ac08ea9c5f2373531a47dd17_ra,w158,h184_pa,w158,h184.png";
            }


            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/coastal-classic-creations-conch-lipstick.png")
                {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/7dab50d3ac08ea9c5f2373531a47dd17_ra,w158,h184_pa,w158,h184.png";
            }


            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/04/cest-moi-reflect-lip-gloss-1.png")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/1b01ce49ace4842e034664361f1310de_ra,w158,h184_pa,w158,h184.jpg";
            }


            else if (newImageLink == "http://www.purpicks.com/wp-content/uploads/2018/06/Alva-Liquid-Eye-Shadow-1-Pale-Almond.png")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/648283e42d7fafb7c03e8c60274cd5e0_ra,w158,h184_pa,w158,h184.png";
            }

            else if (newImageLink == "https://cdn.shopify.com/s/files/1/1338/0845/products/foundations-lineup_800x1200.jpg?v=1528927785")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3fd71730443a4f57b798668c24d0ad19_ra,w158,h184_pa,w158,h184.jpg";
            }



            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/02/Ombre-Amazonie-CC.png")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/648283e42d7fafb7c03e8c60274cd5e0_ra,w158,h184_pa,w158,h184.png";
            }



            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/06/Sally-B_s-Skin-Yummies-B-Glossy-Lip-Gloss.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3fd71730443a4f57b798668c24d0ad19_ra,w158,h184_pa,w158,h184.jpg";
            }



            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/csm/Photo10_12001.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3fd71730443a4f57b798668c24d0ad19_ra,w158,h184_pa,w158,h184.jpg";
            }


            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/03/lotus-cosmetics-usa-creme-to-powder-blush.png")

            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/648283e42d7fafb7c03e8c60274cd5e0_ra,w158,h184_pa,w158,h184.png";
            }



            else if (newImageLink == "http://www.purpicks.com/wp-content/uploads/2018/03/lotus-cosmetics-usa-eye-shadow-palette-mesmerize.png")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/3fd71730443a4f57b798668c24d0ad19_ra,w158,h184_pa,w158,h184.jpg";
            }



            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2018/03/rejuva-minerals-bronzer.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/1b01ce49ace4842e034664361f1310de_ra,w158,h184_pa,w158,h184.jpg";
            }





            else if (newImageLink == "https://www.purpicks.com/wp-content/uploads/2017/06/marie-natie-perfect-lash-mascara.png")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/dd6ee943412a416ecfe9e4a1b2bed107_ra,w158,h184_pa,w158,h184.jpg";
            }




            else if (newImageLink == "https://www.dior.com/beauty/version-5.1432748111912/resize-image/ep/0/214/90/0/v6_packshots_sku_pdg%252FPDG_Y0002959-F000355494.jpg")
            {
                return "https://d3t32hsnjxo7q6.cloudfront.net/i/1b01ce49ace4842e034664361f1310de_ra,w158,h184_pa,w158,h184.jpg";
            }


            return newImageLink;
        }

        // If the value is not a string or any other error occurs, return null
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // This is not used for one-way binding, so you can leave it empty
        throw new NotImplementedException();
    }

    private string DetermineNewImageLink(string originalImageLink)
    {
        // Implement your logic here to determine the new image link
        // For example, you can use a switch statement or if-else conditions

        // Here's a simple example where you replace "image1.jpg" with "image2.jpg"
        if (originalImageLink == "image1.jpg")
        {
            return "image2.jpg";
        }
        else
        {
            // If no match is found, return the original link
            return originalImageLink;
        }
    }
}