using KinderGarten.Models;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        //[Route("signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        //[Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
    }
}
