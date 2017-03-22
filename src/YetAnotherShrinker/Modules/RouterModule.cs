using Nancy;
using System;
using YetAnotherShrinker.Models;
using YetAnotherShrinker.Services.RedirectLogger;
using YetAnotherShrinker.Services.Shrinker;

namespace YetAnotherShrinker.Modules
{
    public class RouterModule : NancyModule
    {
        public RouterModule() : base("/r")
        {
            Get("{su}", async args =>
            {
                var shrunkUrl = await ShrinkerService.RetrieveShrunkUrlAsync((string)args.su);
                if (shrunkUrl == null)
                {
                    return new Response().WithStatusCode(HttpStatusCode.NotFound);
                }
                // Log request, analytics, etc.
                await RedirectLoggerService.LogRedirectAsync(new UrlRedirectEvent
                {
                    ClientAddress = Request.UserHostAddress,
                    EventId = Guid.NewGuid().ToString("N"),
                    Referrer = Request.Headers.Referrer,
                    ShrunkUrl = shrunkUrl,
                    Timestamp = DateTime.Now
                });

                // Redirect user
                return Response.AsRedirect(shrunkUrl.Target);
            });
        }
    }
}