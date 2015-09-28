using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStoreApp.Models
{
    public class ProductViewModel
    {
        //TODO: Add Validation
        public int viewProductId { get; set; }
        public int viewProductCategoryId { get; set; }
        [Required]
        [RegularExpression("^.{5,15}$", ErrorMessage = "User name needs to be between 5 and 15 char long!")]
        public string viewProductName { get; set; }
        public DateTime viewProductValidFrom { get; set; }
        public int viewProductQuantity { get; set; }
        public decimal viewProductPrice { get; set; }
    }
}