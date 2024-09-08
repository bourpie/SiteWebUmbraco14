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
    public class RechercheController : RenderController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISearchService _searchService;

        public RechercheController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IHttpContextAccessor httpContextAccessor,
            ISearchService searchService) 
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _searchService = searchService;
        }

        public override IActionResult Index()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var query = httpContext?.Request.Query["query"];
            var page = httpContext?.Request.Query["page"];

            if (CurrentPage == null) return BadRequest();

            // Vérifier si la 'query' est renseignée
            if (string.IsNullOrWhiteSpace(query))
            {
                // Si la query est vide, retourner un modèle vide ou un message
                var emptyModel = new RechercheContentModel(CurrentPage)
                {
                    SearchRequest = new SearchRequestModel(query, page, 1),
                    SearchResponse = null,  // Aucune recherche effectuée
                    Paginaton = null  // Pas de pagination
                };
                
                // Retourner la vue sans résultat
                return CurrentTemplate(emptyModel);
            }

            var pageSize = 1;

            var searchRequest = new SearchRequestModel(query, page, pageSize);

            var searchResponse = _searchService.Search(searchRequest);

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
