using System;
using System.Threading.Tasks;
using YetAnotherShrinker.Models;
using YetAnotherShrinker.Services.Database;
using YetAnotherShrinker.Utilities;

namespace YetAnotherShrinker.Services.Shrinker
{
    /// <summary>
    /// A user manager service. Provides access to common operations with users, and abstracts the database
    /// </summary>
    public static class ShrinkerService
    {
        public static async Task<ShrunkUrl> RetrieveShrunkUrlByTargetAsync(string target)
        {
            return await Task.Run(() =>
            {
                var db = DatabaseAccessService.OpenOrCreateDefault();
                var storedUrls = db.GetCollection<ShrunkUrl>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
                return storedUrls.FindOne(x => x.Target == target);
            });
        }

        public static async Task<ShrunkUrl> RetrieveShrunkUrlAsync(string shrunkPath)
        {
            return await Task.Run(() =>
            {
                var db = DatabaseAccessService.OpenOrCreateDefault();
                var storedUrls = db.GetCollection<ShrunkUrl>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
                return storedUrls.FindOne(x => x.ShrunkPath == shrunkPath);
            });
        }

        public static async Task<ShrunkUrl> ShrinkUrlAsync(ShrinkRequest req)
        {
            var db = DatabaseAccessService.OpenOrCreateDefault();
            // Return existing URL if it exists
            var existingUrl = await RetrieveShrunkUrlByTargetAsync(req.Url);
            if (existingUrl != null) return existingUrl;
            var storedUrls = db.GetCollection<ShrunkUrl>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
            var newShrunkUrl = new ShrunkUrl
            {
                Target = req.Url,
                ShrunkPath = StringUtils.SecureRandomString(7),
                CreatedTimestamp = DateTime.Now
            };
            await Task.Run(() =>
            {
                using (var trans = db.BeginTrans())
                {
                    // save new url

                    storedUrls.Insert(newShrunkUrl);
                    storedUrls.EnsureIndex(x => x.ShrunkPath);
                    storedUrls.EnsureIndex(x => x.Target);

                    trans.Commit();
                }
            });
            return newShrunkUrl;
        }
    }
}