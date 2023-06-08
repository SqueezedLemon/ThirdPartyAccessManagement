using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThirdPartyAccessManagement.Data;
using ThirdPartyAccessManagement.Models;

namespace ThirdPartyAccessManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<UserManager> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(UserManager<UserManager> userManager, ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        //Dashboard view
        public IActionResult Index()
        {
            return View();
        }

        //All APIs Table View
        public IActionResult ApiEndpoint(BaseViewModel model)
        {
            var pages = _dbContext.Pages.ToList();
            var methods = _dbContext.Methods.ToList();
            if (pages != null)
            {
                model.Pages = pages;
            }
            if (methods != null) 
            {
                model.Methods = methods;
            }
            return View(model);
        }

        //Add New API View
        [HttpGet]
        public IActionResult AddNewApi()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddNewApi(BaseViewModel model, Page newPage, Method newMethod)
		{
            if (model.Api != null && model.Api.PageName != null)
            {
                if (!newPage.PageExists(_dbContext, model.Api.PageName))
                {
					var currentUser = await _userManager.GetUserAsync(User);
                    newPage.PageName = model.Api.PageName;
                    newPage.CreatedById = currentUser.Id;
                    newPage.CreatedDate = DateTime.Now;
                    _dbContext.Add(newPage);
                    _dbContext.SaveChanges();
				}
                else
                {
                    newPage = _dbContext.Pages.FirstOrDefault(np => np.PageName == model.Api.PageName);
                }
            }
			if (model.Api != null && model.Api.MethodName != null)
			{
				if (!newMethod.MethodExists(_dbContext, model.Api.MethodName))
				{
					var currentUser = await _userManager.GetUserAsync(User);
					newMethod.MethodName = model.Api.MethodName;
                    newMethod.PageId = newPage.Id;
					newMethod.CreatedById = currentUser.Id;
					newMethod.CreatedDate = DateTime.Now;
					_dbContext.Add(newMethod);
					_dbContext.SaveChanges();
				}
			}
			return RedirectToAction("ApiEndpoint");
		}

        //Edit Existing Api
        [HttpGet]
        public IActionResult EditApi(BaseViewModel model, int id)
        { 
            var method = _dbContext.Methods.FirstOrDefault(m => m.Id == id);
			if (method == null)
            {
                return NotFound();
            }
			var pageId = method.PageId;
            var page = _dbContext.Pages.FirstOrDefault(m => m.Id == pageId);
			if (method != null && page != null)
			{
				model.Api.PageName = page.PageName;
				model.Api.MethodName = method.MethodName;
			};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditApi(int id, BaseViewModel model, Page newPage)
        {
            //getting method and page
			var method = _dbContext.Methods.Include(m => m.Page).FirstOrDefault(m => m.Id == id);
			if (method == null)
			{
				return NotFound();
			}
			var pageId = method.PageId;

            //finding new page if it exists or creating new one
			if (model.Api != null && model.Api.PageName != null)
			{
				if (!method.Page.PageExists(_dbContext, model.Api.PageName))
				{
					var currentUser = await _userManager.GetUserAsync(User);
					newPage.PageName = model.Api.PageName;
					newPage.CreatedById = currentUser.Id;
					newPage.CreatedDate = DateTime.Now;
					_dbContext.Add(newPage);
					_dbContext.SaveChanges();
				}
				else
				{
					newPage = _dbContext.Pages.FirstOrDefault(np => np.PageName == model.Api.PageName);
				}
			}

            //updating the existing method
			if (model.Api != null && model.Api.MethodName != null)
			{
				if (!method.MethodExists(_dbContext, model.Api.MethodName))
				{
					var currentUser = await _userManager.GetUserAsync(User);
					method.MethodName = model.Api.MethodName;
					method.PageId = newPage.Id;
					method.CreatedById = currentUser.Id;
					method.CreatedDate = DateTime.Now;
					_dbContext.SaveChanges();
				}
			}

            //deleting page if empty after changing method
			var otherMethod = _dbContext.Methods.FirstOrDefault(om => om.PageId == pageId);
			if (otherMethod is null)
			{
				var page = _dbContext.Pages.FirstOrDefault(p => p.Id == pageId);
				_dbContext.Remove(page);
				_dbContext.SaveChanges();
			}
			return RedirectToAction("ApiEndpoint");
        }

		//Delete Api Endpoint
		[HttpGet]
        public IActionResult DeleteApi(int id)
        {
            var getMethod = _dbContext.Methods.FirstOrDefault(gm => gm.Id == id);
            if (getMethod is null)
            {
                return NotFound();
            }
            var pageId = getMethod.PageId;
            _dbContext.Remove(getMethod);
            _dbContext.SaveChanges();
            var otherMethod = _dbContext.Methods.FirstOrDefault(om => om.PageId == pageId);
            if (otherMethod is null) 
            {
                var page = _dbContext.Pages.FirstOrDefault(p => p.Id == pageId);
                _dbContext.Remove(page);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("ApiEndpoint");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}