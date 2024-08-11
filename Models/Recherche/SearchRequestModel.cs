namespace SiteWeb.Models.Recherche
{
	public class SearchRequestModel
	{
		public string? Query { get; set; }

		public SearchRequestModel(string? query) 
		{ 
			Query = query;
		}
	}
}
