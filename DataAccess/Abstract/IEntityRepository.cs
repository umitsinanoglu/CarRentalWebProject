using Core.Entities;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    //Generic constraints
    //Class : referans tip
    //IEntity : IEntity olabilir veya implemente edilen bir nesne olabilir.
    //Newlenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //List<T> GetAll(Expression<Func<T, bool>> filter = null);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
