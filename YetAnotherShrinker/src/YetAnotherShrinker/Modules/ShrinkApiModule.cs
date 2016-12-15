using Nancy;
using Nancy.ModelBinding;
using YetAnotherShrinker.Models;
using YetAnotherShrinker.Services.Shrinker;
using YetAnotherShrinker.Utilities;

namespace YetAnotherShrinker.Modules
{
    public class ShrinkApiModule : NancyModule
    {
        public ShrinkApiModule() : base("/x")
        {
            Post("/shrink", async _ =>
            {
                var req = this.Bind<ShrinkRequest>();
                // Validate request
                if (!StringUtils.IsValidUrl(req.Url))
                {
                    return new Response().WithStatusCode(HttpStatusCode.BadRequest);
                }
                var shrunkUrl = await ShrinkerService.ShrinkUrlAsync(req);
                var resp = new ShrinkResponse
                {
                    ShrunkUrl = shrunkUrl
                };
                return Response.AsJsonNet(resp);
            });

            Get("/info/{su}", async args =>
            {
                var shrunkUrl = await ShrinkerService.RetrieveShrunkUrlAsync((string)args.su);
                if (shrunkUrl == null)
                {
                    return new Response().WithStatusCode(HttpStatusCode.NotFound);
                }
                // Probably no analytics on API

                var resp = new ShrinkResponse
                {
                    ShrunkUrl = shrunkUrl
                };
                return Response.AsJsonNet(resp);
            });

            Get("/stats/{su}", async args =>
            {
                var shrunkUrl = await ShrinkerService.RetrieveShrunkUrlAsync((string)args.su);
                if (shrunkUrl == null)
                {
                    return new Response().WithStatusCode(HttpStatusCode.NotFound);
                }
                // Fetch analytics

                // Dump analytics data
                var resp = 
                return Response.AsJsonNet(resp);
            });
        }
    }
}