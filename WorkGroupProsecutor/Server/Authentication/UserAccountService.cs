using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Authentication;

namespace WorkGroupProsecutor.Server.Authentication
{
    public class UserAccountService
    {
        private readonly ApplicationDbContext _dbContext; //b4Repo
        public UserAccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAccount?> GetUserAccountByUserName(string name)
        {
            return await _dbContext.UserAccount.FirstOrDefaultAsync(x => x.UserName == name);
        }

    }
}
