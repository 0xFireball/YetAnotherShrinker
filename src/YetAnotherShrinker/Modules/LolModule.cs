using Nancy;

namespace VueAndNfx.Modules
{
    public class LolModule : NancyModule
    {
        public LolModule() : base("/a")
        {
            Get("/data", _ =>
            {
                return Response.AsText("Hello Worldy McWorldface!", "application/json");
            });
        }
    }
}