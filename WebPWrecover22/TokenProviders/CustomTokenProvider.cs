using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPWrecover.TokenProviders
{
    public class CustomEmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider,
            IOptions<EmailConfirmationTokenProviderOptions> options) : base(dataProtectionProvider, options)
        {

        }
    }
    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = "EmailDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromSeconds(30);
        }
    }

    public class CustomPasswordResetTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomPasswordResetTokenProvider(IDataProtectionProvider dataProtectionProvider,
            IOptions<PasswordResetTokenProviderOptions> options) : base(dataProtectionProvider, options)
        {

        }
    }
    public class PasswordResetTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public PasswordResetTokenProviderOptions()
        {
            Name = "PasswordResetDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromSeconds(45);
        }
    }
}
