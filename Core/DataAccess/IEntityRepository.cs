using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //Generic constraints
    //Class : referans tip
    //IEntity : TEntity olabilir veya implemente edilen bir nesne olabilir.
    //Newlenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        //List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        //Daha önce ürünler için DAL imzaları oluşturmuştuk, 
        //Şimdi Generic Repository Design Patterni takip ederek yapıyı tekrar tasarlamış (refactor) oluyoruz.
        // List<Product> GetAll();
        // void Add(Product product);
        // void Delete(Product product);
        // void Update(Product product);
        // List<Product> GetAllByCategoryId(int categoryId);
        // Product GetByCategoryId(int categoryId);
        // List<Product> GetAllByUnitPriceRange(int min, int max);
    }
}
