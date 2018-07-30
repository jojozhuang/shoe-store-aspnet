using Johnny.ShoeStore.Domain.Concrete;
using Johnny.ShoeStore.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnny.ShoeStore.Domain.Identity
{
    public class CustomUserValidator : UserValidator<AppUser>
    {

        public CustomUserValidator(AppUserManager mgr)
            : base(mgr)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
