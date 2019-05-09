using System.Collections.Generic;
using System.Linq;
using NotsP_EntityFrameworkDemo.Entities;

namespace NotsP_EntityFrameworkDemo.Repositories
{
    public class ProductRepository : IRepository<Products>
    {
        private readonly WorkshopDBContext context;

        public ProductRepository(WorkshopDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}