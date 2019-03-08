using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using WebPWrecover.TokenProviders;

namespace WebPWrecover.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        private readonly IOptions<EmailConfirmationTokenProviderOptions> _emailConfirmationProtectionoptions;
        private readonly IOptions<DataProtectionTokenProviderOptions> _defaultProtectionoptions;
        private readonly IOptions<PasswordResetTokenProviderOptions> _passwordResetProtectionoptions;

        public ForgotPasswordConfirmation(IOptions<EmailConfirmationTokenProviderOptions> emailConfirmationProtectionoptions,
            IOptions<DataProtectionTokenProviderOptions> defaultProtectionoptions,
            IOptions<PasswordResetTokenProviderOptions> passwordResetProtectionoptions)
        {
            _emailConfirmationProtectionoptions = emailConfirmationProtectionoptions;
            _defaultProtectionoptions = defaultProtectionoptions;
            _passwordResetProtectionoptions = passwordResetProtectionoptions;
        }
        public string PathToEmailFile { get; private set; }
        public TimeSpan EmailTokenLifeSpan { get; private set; }
        public TimeSpan PasswordResetProtectionoptions { get; private set; }
        public TimeSpan DefaultTokenLifeSpan { get; private set; }

        public void OnGet()
        {
            PathToEmailFile = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"))
           + "EmailMessage.html";
            DefaultTokenLifeSpan = _defaultProtectionoptions.Value.TokenLifespan;
            EmailTokenLifeSpan = _emailConfirmationProtectionoptions.Value.TokenLifespan;
            PasswordResetProtectionoptions = _passwordResetProtectionoptions.Value.TokenLifespan;


        }
    }


}
