using LiteDB;
using System;
using System.Collections.Generic;
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
                    storedUrls.EnsureIndex(x => x.Timestamp);
                    storedUrls.EnsureIndex(x => x.ShrunkUrl.ShrunkPath);

                    trans.Commit();
                }
            });
        }

        public static async Task<IEnumerable<UrlRedirectEvent>> GetRedirectHistory(ShrunkUrl shrunkUrl, DateTime earliestDate)
        {
            return await Task.Run(() =>
            {
                var db = DatabaseAccessService.OpenOrCreateDefault();
                var storedUrls = db.GetCollection<UrlRedirectEvent>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
                return storedUrls.Find(Query.Where(nameof(UrlRedirectEvent.Timestamp), x => x.AsDateTime > earliestDate));
            });
        }
    }
}