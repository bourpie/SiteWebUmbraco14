using SiteWeb.Models.Recherche;

namespace SiteWeb.Services
{
	public interface ISearchService
	{
		public SearchResponseModel Search(SearchRequestModel searchRequest);
	}
}
