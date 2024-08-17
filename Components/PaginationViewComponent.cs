using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models.Recherche;
using SiteWeb.Models.ViewModels;

namespace SiteWeb.Components;

[ViewComponent(Name = "Pagination")]
public class PaginationViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(PaginationViewModel model)
	{
		model ??= new PaginationViewModel();

		return View(model);
	}
}