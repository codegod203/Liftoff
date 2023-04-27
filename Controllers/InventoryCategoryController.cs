
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moonwalkers.Data;
using Moonwalkers.Models;
using Moonwalkers.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moonwalkers.Controllers
{
	public class InventoryCategoryController : Controller
	{
		private InventoryDbContext context;

		public InventoryCategoryController(InventoryDbContext dbContext)
		{
			context = dbContext;
		}

		// GET: /<controller>/
		[HttpGet]
		public IActionResult Index()
		{
			List<InventoryCategory> categories = context.Categories.ToList();

			return View(categories);
		}

		[HttpGet]
		[Route("InventoryCategory/Create")]
		public IActionResult Create()
		{
			AddInventoryCategoryViewModel addInventoryCategoryViewModel = new AddInventoryCategoryViewModel();

			return View(addInventoryCategoryViewModel);
		}

		[HttpPost]
		public IActionResult ProcessCreateInventoryCategoryForm(AddInventoryCategoryViewModel addInventoryCategoryViewModel)
		{
			if (ModelState.IsValid)
			{
				InventoryCategory theCategory = new InventoryCategory
				{
					Name = addInventoryCategoryViewModel.Name
				};

				context.Categories.Add(theCategory);
				context.SaveChanges();

				return Redirect("/InventoryCategory");
			}
			return View("Create", addInventoryCategoryViewModel);
		}
	}
}


