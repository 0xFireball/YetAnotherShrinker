using Nancy;
using YetAnotherShrinker.Services.Shrinker;

namespace YetAnotherShrinker.Modules
{
    public class RouterModule : NancyModule
    {
        public RouterModule() : base("/r")
        {
            Get("{su}", async args =>
            {
                var targetUrl = await ShrinkerService.RetrieveShrunkUrlAsync((string)args.su);
                if (targetUrl == null)
                {
                    return new Response().WithStatusCode(HttpStatusCode.NotFound);
                }
                // Log request, analytics, etc.
                

                // Redirect user
                return Response.AsRedirect(targetUrl.Target);
            });
        }
    }
}