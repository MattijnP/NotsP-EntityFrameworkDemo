using System;
using System.Collections.Generic;

namespace NotsP_EntityFrameworkDemo.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
