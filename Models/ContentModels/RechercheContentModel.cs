using SiteWeb.Models.Recherche;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;


namespace SiteWeb.Models.ContentModels
{
    public class RechercheContentModel(IPublishedContent? content) : ContentModel(content)
    {
        public SearchRequestModel? SearchRequest { get; set; }

    }
}
