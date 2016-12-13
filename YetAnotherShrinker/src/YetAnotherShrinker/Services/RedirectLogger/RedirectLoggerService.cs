using System.Threading.Tasks;
using YetAnotherShrinker.Models;
using YetAnotherShrinker.Services.Database;

namespace YetAnotherShrinker.Services.RedirectLogger
{
    public static class RedirectLoggerService
    {
        public static async Task LogRedirectAsync(ShrunkUrl hitUrl)
        {
            var db = DatabaseAccessService.OpenOrCreateDefault();
        }
    }
}