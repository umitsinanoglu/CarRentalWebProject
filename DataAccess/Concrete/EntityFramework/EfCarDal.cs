using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentingDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentingDbContext context = new CarRentingDbContext())
            {
                var result = (from c in context.Cars
                              join b in context.Brands on c.BrandId equals b.id
                              join cl in context.Colors on c.ColorId equals cl.id
                              select new CarDetailDto
                              {
                                  CarName = c.ModelName,
                                  BrandName = b.name,
                                  ColorName = cl.name,
                                  DailyPrice = c.DailyPrice
                              });
                return result.ToList();
            }
        }

        public List<Car> GetList()
        {
            using (CarRentingDbContext context = new CarRentingDbContext())
            {
                var result = context.Cars.ToList();
                return result;
            }
        }
    }
}
