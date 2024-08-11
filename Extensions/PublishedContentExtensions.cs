using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace SiteWeb.Extensions
{
    public static class PublishedContentExtensions
    {
        public static Accueil? GetAccueil(this IPublishedContent publishedContent)
        {
            return publishedContent.AncestorOrSelf<Accueil>();
        }

        public static Preferences? GetPreferences(this IPublishedContent publishedContent)
        {
            var accueil = GetAccueil(publishedContent);
            if (accueil == null) return null;
            return accueil.FirstChild<Preferences>();
        }
    }
}