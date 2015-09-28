using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStoreApp.Models
{
    public class CategoryViewModel
    {
        //TODO: Add validation
        public int viewCategoryId { get; set; }
        [Display(Name="Name")]
        public string viewCategoryName { get; set; }
        public DateTime viewCategoryValidFrom { get; set; } 
    }
}