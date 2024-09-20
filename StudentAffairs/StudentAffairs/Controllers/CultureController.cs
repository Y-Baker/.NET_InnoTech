namespace StudentAffairs;

[Microsoft.AspNetCore.Mvc.Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture != null)
        {
            RequestCulture? requestCulture = new RequestCulture(culture, culture);
            string? cookieName = CookieRequestCultureProvider.DefaultCookieName;
            string? cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            HttpContext.Response.Cookies.Append(cookieName, cookieValue);
        }

        return LocalRedirect(redirectUri);
    }
}
