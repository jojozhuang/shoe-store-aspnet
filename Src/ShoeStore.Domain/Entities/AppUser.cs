using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnny.ShoeStore.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        // additional properties will go here
        //[Required]
        //public string Password { get; set; }
    }
}
