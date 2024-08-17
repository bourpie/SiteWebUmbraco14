using Microsoft.AspNetCore.Mvc;
using SiteWeb.Models.Recherche;

namespace SiteWeb.Components;

[ViewComponent(Name = "SearchForm")]
public class SearchFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(SearchRequestModel model)
    {
        return View(model);
    }
}