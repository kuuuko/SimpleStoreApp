using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStoreApp.Models
{
    public class CategoryViewModel
    {
        [Required]
        public int viewCategoryId { get; set; }

        [Required]
        [StringLength(maximumLength:20)]
        [Display(Name="Name", Description="Category Name")]
        public string viewCategoryName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "ValidFrom", Description = "valid from")]
        public DateTime viewCategoryValidFrom { get; set; } 
    }
}