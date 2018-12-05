using LiteDB;
using mc_accounts_server.Models;

using Logger = mc_accounts_server.Utility.Logger;

namespace mc_accounts_server.DAL
{
    static class AccountDB
    {
        public static bool Create(string dbName, Account account)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var col = db.GetCollection<Account>("account");

                    if (col.Insert(account) != null) return true;
                    return false;
                }
            }
            catch (LiteException ex)
            {
                Logger.WriteLog(Logger.LogLevel.ERROR, string.Format("Could not create account for identifier {0}: #{1} - {2}. Help: {3}", account.Identifier, ex.ErrorCode, ex.Message, ex.HelpLink), "red");
                return false;
            }
        }

        public static bool Find(string dbName, string identifier)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var col = db.GetCollection<Account>("account");

                    if (col.FindOne(x => x.Identifier == identifier) != null) return true;
                    else return false;
                }
            }
            catch (LiteException ex)
            {
                Logger.WriteLog(Logger.LogLevel.ERROR, string.Format("Could not run find for identifier {0}: #{1} - {2}. Help: {3}", identifier, ex.ErrorCode, ex.Message, ex.HelpLink), "red");
                return false;
            }
        }

        public static string GetPassword(string dbName, string identifier)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var col = db.GetCollection<Account>("account");

                    var result = col.FindOne(x => x.Identifier == identifier);

                    if (result != null) return result.Password;
                    else return "No account found.";
                }
            }
            catch (LiteException ex)
            {
                Logger.WriteLog(Logger.LogLevel.ERROR, string.Format("Could not run find for identifier {0}: #{1} - {2}. Help: {3}", identifier, ex.ErrorCode, ex.Message, ex.HelpLink), "red");
                return "No account found.";
            }
        }

        public static bool UpdatePassword(string dbName, string identifier, string newPass)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var col = db.GetCollection<Account>("account");

                    var result = col.FindOne(x => x.Identifier == identifier);

                    if (result != null)
                    {
                        result.Password = newPass;
                        return col.Update(result);
                    }
                    else return false;
                }
            }
            catch (LiteException ex)
            {
                Logger.WriteLog(Logger.LogLevel.ERROR, string.Format("Could not update password for identifier {0}: #{1} - {2}. Help: {3}", identifier, ex.ErrorCode, ex.Message, ex.HelpLink), "red");
                return false;
            }
        }

        public static bool DeleteAccount(string dbName, string identifier)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var col = db.GetCollection<Account>("account");

                    var result = col.FindOne(x => x.Identifier == identifier);

                    return col.Delete(result.ID);
                }
            }
            catch (LiteException ex)
            {
                Logger.WriteLog(Logger.LogLevel.ERROR, string.Format("Could not delete account for identifier {0}: #{1} - {2}. Help: {3}", identifier, ex.ErrorCode, ex.Message, ex.HelpLink), "red");
                return false;
            }
        }
    }
}
