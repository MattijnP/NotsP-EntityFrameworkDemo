using System.Collections.Generic;

namespace NotsP_EntityFrameworkDemo.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}