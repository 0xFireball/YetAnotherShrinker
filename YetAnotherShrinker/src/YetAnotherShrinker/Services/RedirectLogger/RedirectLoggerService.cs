using System.Threading.Tasks;
using YetAnotherShrinker.Models;
using YetAnotherShrinker.Services.Database;

namespace YetAnotherShrinker.Services.RedirectLogger
{
    public static class RedirectLoggerService
    {
        public static async Task LogRedirectAsync(UrlRedirectEvent redirEvent)
        {
            await Task.Run(() =>
            {
                var db = DatabaseAccessService.OpenOrCreateDefault();
                var storedUrls = db.GetCollection<UrlRedirectEvent>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);

                using (var trans = db.BeginTrans())
                {
                    storedUrls.Insert(redirEvent);

                    storedUrls.EnsureIndex(x => x.EventId);
                    storedUrls.EnsureIndex(x => x.ShrunkUrl.ShrunkPath);

                    trans.Commit();
                }
            });
        }
    }
}