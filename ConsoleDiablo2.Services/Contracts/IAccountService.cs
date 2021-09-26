using ConsoleDiablo2.DataModels;

namespace ConsoleDiablo2.Services.Contracts
{
    public interface IAccountService
    {
        bool TryCreatingAnAccount(string accountName, string password);

        bool TryLoggingIn(string accountName, string password);

        Account GetAccountByName(string accountName);

        Account GetAccountById(int accountId);

        int CountCharactersInAnAccount(int accountId);
    }
}
