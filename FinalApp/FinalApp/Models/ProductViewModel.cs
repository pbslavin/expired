using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApp.Models
{
    public class ProductViewModel : Product
    {
        public ProductViewModel() : this(null)
        {

        }
        public ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            Brand = product.Brand;
            ProductName = product.ProductName;
            PurchaseDate = product.PurchaseDate;
            ExpirationDate = product.ExpirationDate;
        }
    }

}
