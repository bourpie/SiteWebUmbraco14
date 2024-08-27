using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Web.Common.Security;
using Umbraco.Cms.Web.Website.Controllers;

public class MemberController : SurfaceController
{
    private readonly IMemberSignInManager _signInManager;

    public MemberController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        IMemberSignInManager signInManager)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _signInManager = signInManager;
    }

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return Redirect("~/pageDeConnection"); // Rediriger vers la page d'accueil ou une autre page après la déconnexion
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Redirect("~/modeles");
        }

        ModelState.AddModelError("", "Échec de la connexion. Veuillez vérifier vos informations.");
        return View("~/pageDeConnection");
    }

    public IActionResult Login()
    {
        return View();
    }
}
