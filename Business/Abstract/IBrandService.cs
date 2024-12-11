using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Cars;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //GetAll, GetById, Insert, Update, Delete.
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand>GetById(int id);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
