using ConsoleDiablo2.Common;
using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;
using System;
using System.Linq;

namespace ConsoleDiablo2.Services
{
    public class AccountService : IAccountService
    {
        private readonly ConsoleDiabloDbContext db;

        public AccountService(ConsoleDiabloDbContext db)
        {
            this.db = db;
        }

        public int CountCharactersInAnAccount(int accountId)
        {
            var account = GetAccountById(accountId);
            int counter = 0;

            foreach (var character in account.Characters)
            {
                counter++;
            }

            return counter;
        }

        public Account GetAccountByName(string accountName)
        {
            var account = this.db.Accounts.FirstOrDefault(a => a.AccountName == accountName);

            return account;
        }

        public Account GetAccountById(int accountId)
        {
            var account = this.db.Accounts.FirstOrDefault(a => a.Id == accountId);

            return account;
        }

        public bool TryCreatingAnAccount(string accountName, string password)
        {
            bool validAccountName = !string.IsNullOrEmpty(accountName) && accountName.Length > 3 && accountName.Length <= GlobalConstants.AccountNameMaxLength;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length > 3 && password.Length <= GlobalConstants.PasswordMaxLength;

            if (!validAccountName || !validPassword)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAccountNameOrPasswordLength);
            }

            bool accountAlreadyExists = this.db.Accounts.Any(a => a.AccountName.Equals(accountName));

            if (accountAlreadyExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AccountAlreadyExists, accountName));
            }

            Account account = new Account(accountName, password);

            this.db.Accounts.Add(account);

            this.db.SaveChanges();

            this.TryLoggingIn(accountName, password);

            return true;
        }

        public bool TryLoggingIn(string accountName, string password)
        {
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            Account account = this.db.Accounts.FirstOrDefault(a => a.AccountName == accountName && a.Password == password);

            if (account == null)
            {
                return false;
            }

            if (this.db.Characters.Any())
            {
                var characters = this.db.Characters.Where(ch => ch.AccountId == account.Id);

                foreach (var character in characters)
                {
                    account.Characters.Add(character);
                }
            }

            return account.IsLoggedIn = true;
        }
    }
}