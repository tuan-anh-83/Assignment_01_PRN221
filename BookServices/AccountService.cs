using BookObject.Models;
using BookRepository;

namespace BookServices
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService()
        {
            accountRepository = new AccountRepository();
        }

        public BookManagementMember GetBookById(string id)
        {
            return accountRepository.GetBookById(id);
        }
    }
}
