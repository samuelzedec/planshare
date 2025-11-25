using System.Globalization;
using PlanShare.Domain.Extensions;

namespace PlanShare.Api.Middleware;

public class CultureMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);
        var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("en");
        if (culture.NotEmpty() && supportedLanguages.Any(s => s.Name.Equals(culture)))
            cultureInfo = new CultureInfo(culture);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        await next(context);
    }
}