using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using SiteWeb.Models.ContentModels;
using SiteWeb.Models.Recherche;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace SiteWeb.Controllers.Render
{
    public class RechercheController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        IHttpContextAccessor httpContextAccessor) 
            : RenderController(logger, compositeViewEngine, umbracoContextAccessor)
    {
        public override IActionResult Index()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var query = httpContext?.Request.Query["query"];

            var searchRequest = new SearchRequestModel(query);

            var model = new RechercheContentModel(CurrentPage)
            {
				SearchRequest = searchRequest
			};

            return CurrentTemplate(model);
        }
    }
}
