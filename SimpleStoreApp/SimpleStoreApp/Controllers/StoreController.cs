using Kendo.Mvc.UI;
using SimpleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SimpleStoreApp.Controllers
{   
    [Authorize]
    public partial class StoreController : Controller
    {
        private myDBContext db = new myDBContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Categories([DataSourceRequest]DataSourceRequest request)
        {
            List<CategoryViewModel> categoriesList = new List<CategoryViewModel>();
            var categories = db.Categories.ToList();
            foreach (var item in categories)
            {
                categoriesList.Add(new CategoryViewModel
                {
                    viewCategoryId = item.CategoryId,
                    viewCategoryName = item.CategoryName,
                    viewCategoryValidFrom = item.CategoryValidFrom
                });
            }
            return Json(categoriesList.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    CategoryName = category.viewCategoryName,
                    CategoryValidFrom = category.viewCategoryValidFrom
                };
                db.Categories.Add(newCategory);
                db.SaveChanges();
                category.viewCategoryId = newCategory.CategoryId;
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    CategoryId = category.viewCategoryId,
                    CategoryName = category.viewCategoryName,
                    CategoryValidFrom = category.viewCategoryValidFrom
                };
                db.Categories.Attach(newCategory);
                db.Entry(newCategory).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null)
            {
                var newCategory = new Category() { CategoryId = category.viewCategoryId };
                db.Categories.Attach(newCategory);
                db.Categories.Remove(newCategory);

                var products = db.Products.Where(x => x.ProductCategoryId == category.viewCategoryId);
                foreach (var product in products)
                {
                    db.Products.Attach(product);
                    db.Products.Remove(product);
                }
                db.SaveChanges();
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Products([DataSourceRequest]DataSourceRequest request, string productCategoryId)
        {
            var categoryId = Int32.Parse(productCategoryId);
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var products = db.Products.Where(x => x.ProductCategoryId == categoryId);
            foreach (var item in products)
            {
                productList.Add(new ProductViewModel
                {
                    viewProductId = item.ProductId,
                    viewProductName = item.ProductName,
                    viewProductCategoryId = item.ProductCategoryId,
                    viewProductPrice = item.ProductPrice,
                    viewProductQuantity = item.ProductQuantity,
                    viewProductValidFrom = item.ProductValidFrom
                });
            }
            return Json(productList.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateProduct([DataSourceRequest] DataSourceRequest request, ProductViewModel product, string productCategoryId)
        {
            var categoryId = Int32.Parse(productCategoryId);
            if (product != null && ModelState.IsValid)
            {
                var newProduct = new Product()
                {
                    ProductName = product.viewProductName,
                    ProductCategoryId = categoryId,
                    ProductPrice = product.viewProductPrice,
                    ProductQuantity = product.viewProductQuantity,
                    ProductValidFrom = product.viewProductValidFrom
                };
                db.Products.Add(newProduct);
                db.SaveChanges();
                product.viewProductId = newProduct.ProductId;
            }
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateProduct([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                var newProduct = new Product()
                {
                    ProductId = product.viewProductId,
                    ProductName = product.viewProductName,
                    ProductCategoryId = product.viewProductCategoryId,
                    ProductPrice = product.viewProductPrice,
                    ProductQuantity = product.viewProductQuantity,
                    ProductValidFrom = product.viewProductValidFrom
                };
                db.Products.Attach(newProduct);
                db.Entry(newProduct).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DestroyProduct([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null)
            {
                var newProduct = new Product() { ProductId = product.viewProductId };
                db.Products.Attach(newProduct);
                db.Products.Remove(newProduct);
                db.SaveChanges();
            }
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}