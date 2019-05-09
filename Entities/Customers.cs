using System;
using System.Collections.Generic;

namespace NotsP_EntityFrameworkDemo.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
