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
    }
}