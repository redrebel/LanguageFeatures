using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public String Index()
        {
			return "Navigate to a URL to show an example";
        }

		public ViewResult AutoProperty()
		{
			// 새로운 product  개체를 생성한다.
			Product myProduct = new Product();

			// 속성값을 설정한다.
			myProduct.Name = "Kayak";

			// 속성값을 가져온다.
			string productName = myProduct.Name;

			// 뷰를 생성한다.
			return View("Result", (object)String.Format("Product name: {0}", productName));
		}

		public ViewResult CreateProduct()
		{
			// 새로운 Product 개체를 생성하고 속성 값들을 설정한다.
			Product myProduct = new Product
			{
				ProductID = 100,
				Name = "Kayak",
				Description = "A boat for one person",
				Price = 275M,
				Category = "Watersports"
			};

			return View("Result",
				(object)String.Format("Category: {0}", myProduct.Category));
		}

		public ViewResult UseExtension()
		{
			// ShoppingCart 개체를 생성하고 속성 값을 설정한다.
			ShoppingCart cart = new ShoppingCart
			{
				Products = new List<Product>
				 {
					 new Product { Name = "Kayak", Price = 275M},
					 new Product { Name = "Lifejacket", Price = 48.95M },
					 new Product { Name = "Soccer ball", Price = 19.50M },
					 new Product {Name = "Corner flag", Price = 34.95M }
				 }
			};

			// 카트에 담긴 제품들의 합계 값을 구한다.
			decimal cartTotal = cart.TotalPrices();

			return View("Result", (object)string.Format("Total: {0:c}", cartTotal));
		}

		public ViewResult UseExtensionEnumerable()
		{
			IEnumerable<Product> products = new ShoppingCart
			{
				Products = new List<Product>
				{
					 new Product { Name = "Kayak", Price = 275M},
					 new Product { Name = "Lifejacket", Price = 48.95M },
					 new Product { Name = "Soccer ball", Price = 19.50M },
					 new Product {Name = "Corner flag", Price = 34.95M }
				}
			};

			// Product 개체들의 배열을 생성하고 데이터를 채워 넣는다.
			Product[] productArray =
			{
					new Product { Name = "Kayak", Price = 275M},
					 new Product { Name = "Lifejacket", Price = 48.95M },
					 new Product { Name = "Soccer ball", Price = 19.50M },
					 new Product {Name = "Corner flag", Price = 34.95M }
			};

			//  카트에 존재하는 제품들의 합계를 구한다.
			decimal cartTotal = products.TotalPrices();
			decimal arrayTotal = productArray.TotalPrices();

			return View("Result", (object)String.Format("Cart Total: {0}. Array Total: {1}",
				cartTotal, arrayTotal));
		}

		public ViewResult UseFilterExtensionMethod()
		{
			IEnumerable<Product> products = new ShoppingCart
			{
				Products = new List<Product>
				{
					new Product { Name = "Kayak", Category="Watersports", Price = 275M},
					new Product { Name = "Lifejacket", Category="Watersport", Price = 48.95M },
					new Product { Name = "Soccer ball", Category="Soccer",Price = 19.50M },
					new Product {Name = "Corner flag", Category="Soccer", Price = 34.95M }
				}
			};

			decimal total = 0;

			foreach(Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
			{
				total += prod.Price;
			}

			return View("Result", (object)String.Format("Total: {0}", total));

		}
    }
}