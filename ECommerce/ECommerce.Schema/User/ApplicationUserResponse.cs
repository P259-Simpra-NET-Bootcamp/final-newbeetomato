using ECommerce.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.User
{
    public class ApplicationUserResponse : ApplicationUser
    {
        public long NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
