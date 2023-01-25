using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _191_MOMENT_2.Models
{
    public class ProductModel
    {
        //properties (data fields)
        public int id { get; set; }

        //required to fill in to form
        [Required(ErrorMessage = "Please fill in the product name!")]
        //display specific name
        [Display(Name = "Product title:")]
        public string? product_title { get; set; }
        [Required(ErrorMessage = "Please fill in the full EAN number!")]
        [Display(Name = "EAN:")]
        public string? ean_number { get; set; }
        [Required(ErrorMessage = "Please fill in a short description!")]
        [Display(Name = "Description:")]
        [MaxLength(250)]
        public string? product_description { get; set; }
        [Required(ErrorMessage = "Please fill in the amount in storage now!")]
        [Display(Name = "Amount storage:")]
        public int? amount_storage { get; set; }
        [Required(ErrorMessage = "Please fill in the price, in SEK!")]
        [Display(Name = "Price (SEK):")]
        public decimal? price { get; set; }
        [Required(ErrorMessage = "Please fill in the earliest expiration date!")]
        [Display(Name = "Expiration date:")]
        public string? expiration_date { get; set; }

        [Display(Name = "Category:")]
        public ProductSize category { get; set; }
        [Display(Name = "Made in Sweden?")]
        public bool isSwedish { get; set; }

        //limits other types: email, phone, min.length etc

    }
    public enum ProductSize { Small, Medium, Large }
}