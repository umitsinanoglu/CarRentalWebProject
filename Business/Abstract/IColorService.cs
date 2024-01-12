using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(string ColorName);
        IResult Update(Color color);
        IDataResult<List<Color>> GetList();
        IDataResult<Color> GetById(int id);
    }
}
