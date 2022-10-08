using KinderGarten.Models;
using Microsoft.AspNetCore.Identity;

namespace KinderGarten.Repositories
{
    public class AccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterUserModel model)
        {
            var user = new IdentityUser()
            {
                Email = model.Username,
                UserName = model.Username
            };

            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}
