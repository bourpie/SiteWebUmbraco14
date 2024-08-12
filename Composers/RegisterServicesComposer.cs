using SiteWeb.Services;
using Umbraco.Cms.Core.Composing;

namespace SiteWeb.Composers
{
	public class RegisterServicesComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.Services.AddTransient<ISearchService, SearchService>();
		}
	}
}
