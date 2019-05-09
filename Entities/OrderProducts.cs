using System;
using System.Collections.Generic;

namespace NotsP_EntityFrameworkDemo.Entities
{
    public partial class OrderProducts
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
