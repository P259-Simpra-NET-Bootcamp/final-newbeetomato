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
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal? PointBalance { get; set; }
        public int CartId { get; set; }
    }
}
