using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPWrecover.TokenProviders;

namespace WebPWrecover.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CustomEmailConfirmationTokenProvider<IdentityUser> _customEmailConfirmationTokenProvider;
        private readonly DataProtectorTokenProvider<IdentityUser> _dataProtectorTokenProvider;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(CustomEmailConfirmationTokenProvider<IdentityUser> customEmailConfirmationTokenProvider,
    DataProtectorTokenProvider<IdentityUser> dataProtectorTokenProvider, UserManager<IdentityUser> userManager)
        {
            _customEmailConfirmationTokenProvider = customEmailConfirmationTokenProvider;
            _dataProtectorTokenProvider = dataProtectorTokenProvider;
            _userManager = userManager;
        }
        public Dictionary<string, TokenProviderDescriptor> ProviderMap { get; set; }

        public string EmailConfirmationTokenProvider { get; set; }
        public string PasswordResetTokenProvider { get; private set; }

        public void OnGet()
        {
            ProviderMap = _userManager.Options.Tokens.ProviderMap;
            EmailConfirmationTokenProvider = _userManager.Options.Tokens.EmailConfirmationTokenProvider;
            PasswordResetTokenProvider= _userManager.Options.Tokens.PasswordResetTokenProvider;
        }
    }
}
