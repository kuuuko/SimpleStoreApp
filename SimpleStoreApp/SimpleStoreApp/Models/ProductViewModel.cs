using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStoreApp.Models
{
    public class ProductViewModel
    {
        [Required]
        public int viewProductId { get; set; }

        [Required]
        public int viewProductCategoryId { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        [Display(Name = "Name", Description = "Product Name")]
        public string viewProductName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "ValidFrom", Description = "valid from")]
        public DateTime viewProductValidFrom { get; set; }

        [Required]
        [Display(Name = "Quantity", Description = "Product Quantity")]
        public int viewProductQuantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price", Description = "Product Price")]
        public decimal viewProductPrice { get; set; }
    }
}