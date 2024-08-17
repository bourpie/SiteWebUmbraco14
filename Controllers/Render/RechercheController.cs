using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using SiteWeb.Helpers;
using SiteWeb.Models.ContentModels;
using SiteWeb.Models.Recherche;
using SiteWeb.Models.ViewModels;
using SiteWeb.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace SiteWeb.Controllers.Render
{
    public class RechercheController(
        ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        IHttpContextAccessor httpContextAccessor,
		ISearchService searchService) 
            : RenderController(logger, compositeViewEngine, umbracoContextAccessor)
    {
        public override IActionResult Index()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var query = httpContext?.Request.Query["query"];
			var page = httpContext?.Request.Query["page"];

			if (CurrentPage == null) return BadRequest();

			var pageSize = 1;

			var searchRequest = new SearchRequestModel(query, page, pageSize);

			var searchResponse = searchService.Search(searchRequest);

            var pagination = new PaginationViewModel
            {
                TotalResults = searchResponse.TotalResultCount,
                TotalPages = (int)Math.Ceiling((double)(searchResponse.TotalResultCount / searchRequest.PageSize)),
                ResultsPerPage = searchRequest.PageSize,
                CurrentPage = searchRequest.Page,
                PaginationUrlFormat = PaginationHelper.GetPaginationUrlFormat(Request.Path, Request?.QueryString.ToString(), page)
            };

			var model = new RechercheContentModel(CurrentPage)
            {
				SearchRequest = searchRequest,
                SearchResponse = searchResponse,
                Paginaton = pagination
			};

            return CurrentTemplate(model);
        }
    }
}
