using Core.Utilities.Results.Abstract;
using Entities.Concrete.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage>GetImagesById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
        IResult Add(Microsoft.AspNetCore.Http.IFormFile file,  CarImage carImage);
        IResult Update(Microsoft.AspNetCore.Http.IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
