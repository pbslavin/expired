using FinalApp.Models;
using FinalApp.Areas.Identity.Pages.Account;
using FinalApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FinalApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Http;
using FinalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalAppTest
{
    public class UnitTest1
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly UserManager<IdentityUser> _userManager;

        [Fact]
        public async Task Category_ShouldCreateNewCategoryAsync()
        {
            // Assemble
            var context = new ApplicationContext(DbAssembly().Options);
            var categoryController = new CategoryController(context);
            var category = (new Category());

            // Act
            await categoryController.Create(category);

            // Assert
            Assert.NotEmpty(context.Categories);
        }

        [Fact]
        public async Task Product_ShouldCreateNewProductAsync()
        {
            // Assemble 
            var context = new ApplicationContext(DbAssembly().Options);
            var productController = new ProductController(context, _userManager);
            var product = (new Product());
            product.PurchaseDate = DateTime.MinValue;
            product.ExpirationDate = DateTime.MaxValue;

            // Act
            await productController.Create(product);

            // Assert
            Assert.NotEmpty(context.Products);
        }

        [Fact]
        public void HomeController_IndexActionShouldReturnIndexView()
        {
            //Assemble
            var homeController = new HomeController();

            //Act
            var result = homeController.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        public DbContextOptionsBuilder<ApplicationContext> DbAssembly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            return optionsBuilder;
        }
    }
}
