using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FinalApp.Models
{
    internal class ProductViewModel : Product
    {
        public ProductViewModel() : this(null)
        {

        }
        public ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            Category = product.Category;
            CategoryId = product.CategoryId;
            ProductName = product.ProductName;
            PurchaseDate = product.PurchaseDate;
            ExpirationDate = product.ExpirationDate;
            UserName = product.UserName;
        }
    }

}
