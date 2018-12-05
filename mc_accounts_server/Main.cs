using CitizenFX.Core;
using CitizenFX.Core.Native;
using mc_accounts_server.DAL;
using mc_accounts_server.Models;
using System;

namespace mc_accounts_server
{
    public class Main : BaseScript
    {
        private readonly string DBName;

        public Main()
        {
            DBName = API.GetConvar("database_name", "") + ".db";

            Exports.Add("createAccount", new Func<string, string, string, bool>(OnCreateAccount));
            Exports.Add("findAccount", new Func<string, bool>(OnFindAccount));
            Exports.Add("getPassword", new Func<string, string>(OnGetPassword));
            Exports.Add("updatePassword", new Func<string, string, bool>(OnUpdatePassword));
            Exports.Add("deletePassword", new Func<string, bool>(OnDeleteAccount));
        }

        public bool OnCreateAccount(string username, string password, string identifier)
        {
            Account account = new Account()
            {
                Username = username,
                Password = password,
                Identifier = identifier
            };

            return AccountDB.Create(DBName, account);
        }

        public bool OnFindAccount(string identifier)
        {
            return AccountDB.Find(DBName, identifier);
        }

        public string OnGetPassword(string identifier)
        {
            return AccountDB.GetPassword(DBName, identifier);
        }

        public bool OnUpdatePassword(string identifier, string newPass)
        {
            return AccountDB.UpdatePassword(DBName, identifier, newPass);
        }

        public bool OnDeleteAccount(string identifier)
        {
            return AccountDB.DeleteAccount(DBName, identifier);
        }
    }
}
