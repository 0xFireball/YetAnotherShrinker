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
        }
    }
}
