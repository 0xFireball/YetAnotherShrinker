using Nancy;
using Nancy.ModelBinding;
using YetAnotherShrinker.Models;

namespace YetAnotherShrinker.Modules
{
    public class ShrinkApiModule : NancyModule
    {
        public ShrinkApiModule() : base("/x")
        {
            Post("/shrink" _ =>
            {
                var req = this.Bind<ShrinkRequest>();
                return Response.AsJsonNet();
            });
        }
    }
}
