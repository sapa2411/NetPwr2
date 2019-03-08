using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using WebPWrecover.TokenProviders;

namespace WebPWrecover.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class EmailConfirmationRequiredModel : PageModel
    {
        private readonly IOptions<EmailConfirmationTokenProviderOptions> _emailConfirmationProtectionoptions;
        private readonly IOptions<DataProtectionTokenProviderOptions> _defaultProtectionoptions;

        public EmailConfirmationRequiredModel(IOptions<EmailConfirmationTokenProviderOptions> emailConfirmationProtectionoptions,
            IOptions<DataProtectionTokenProviderOptions> defaultProtectionoptions)
        {
            _emailConfirmationProtectionoptions = emailConfirmationProtectionoptions;
            _defaultProtectionoptions = defaultProtectionoptions;
        }
        public string PathToEmailFile { get; private set; }
        public TimeSpan EmailTokenLifeSpan { get; private set; }
        public TimeSpan DefaultTokenLifeSpan { get; private set; }

        public void OnGet()
        {
            PathToEmailFile = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"))
           + "EmailMessage.html";
            DefaultTokenLifeSpan = _defaultProtectionoptions.Value.TokenLifespan;
            EmailTokenLifeSpan = _emailConfirmationProtectionoptions.Value.TokenLifespan;
        }
    }
}