using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApp.Models
{
    public class Product : IValidatableObject
    {

        public int ProductId { get; set; }

        [Required]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public string ProductName { get; set; }

        //Purchase Date
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        //Expiration Date
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public string UserName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var purchaseDate = (DateTime)validationContext.ObjectInstance;
            if (purchaseDate > DateTime.Now)
            {
                yield return new ValidationResult("Purchase date cannot be in the future.");
            }
        }

    }
}
