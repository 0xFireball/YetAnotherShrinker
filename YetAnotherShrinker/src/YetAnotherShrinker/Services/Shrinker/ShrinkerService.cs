using YetAnotherShrinker.Services.Database;
using YetAnotherShrinker.Utilities;
using System;
using System.Collections;
using System.Security;
using System.Threading.Tasks;
using YetAnotherShrinker.Models;

namespace YetAnotherShrinker.Services.Shrinker
{
    /// <summary>
    /// A user manager service. Provides access to common operations with users, and abstracts the database
    /// </summary>
    public static class ShrinkerService
    {
        public static async Task<RegisteredUser> FindUserByUsernameAsync(string username)
        {
            return await Task.Run(() =>
            {
                RegisteredUser storedUserRecord = null;
                var db = new DatabaseAccessService().OpenOrCreateDefault();
                var registeredUsers = db.GetCollection<RegisteredUser>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
                var userRecord = registeredUsers.FindOne(u => u.Username == username);
                storedUserRecord = userRecord;

                if (storedUserRecord == null)
                {
                    return null;
                }
                return storedUserRecord;
            });
        }

        public static async Task<ShrunkUrl> RetrieveShrunkUrlAsync(string shrunkPath)
        {
            return await Task.Run(() =>
            {
                var db = new DatabaseAccessService().OpenOrCreateDefault();
                var storedUrls = db.GetCollection<ShrunkUrl>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
                return storedUrls.FindOne(x => x.ShrunkPath == shrunkPath);
            });
        }

        public static async Task<ShrunkUrl> ShrinkUrlAsync(ShrinkRequest req)
        {
            var db = new DatabaseAccessService().OpenOrCreateDefault();
            var storedUrls = db.GetCollection<ShrunkUrl>(DatabaseAccessService.ShrunkUrlCollectionDatabaseKey);
            var newShrunkUrl = new ShrunkUrl
            {
                Target = req.Url,
                ShrunkPath = StringUtils.SecureRandomString(7)
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