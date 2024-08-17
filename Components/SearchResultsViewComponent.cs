using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models.Recherche;

namespace SiteWeb.Components;

[ViewComponent(Name = "SearchResults")]
public class SearchResultsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(SearchResponseModel model)
    {
        return View(model);
    }
}