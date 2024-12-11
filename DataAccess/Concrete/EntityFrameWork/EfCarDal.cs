using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Cars;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId= car.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ModelName = brand.BrandName + car.ModelYear,
                                 ImagePath = (from carImage in context.CarImages where car.CarId == carImage.CarId select carImage.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where b.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ModelName= b.BrandName+car.ModelYear,
                                 ImagePath = (from carImage in context.CarImages where car.CarId == carImage.CarId select carImage.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where car.CarId == carId
                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ModelName = b.BrandName + car.ModelYear,
                                 ImagePath = (from carImages in context.CarImages where car.CarId == carImages.CarId select carImages.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId)
        {
            using (CarRentalContext context = new CarRentalContext()) {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where c.ColorId == colorId && b.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ModelName = b.BrandName + car.ModelYear,
                                 ImagePath = (from carImages in context.CarImages where car.CarId== carImages.CarId select carImages.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where c.ColorId== colorId
                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ModelName = b.BrandName + car.ModelYear,
                                 ImagePath = (from carImages in context.CarImages where car.CarId == carImages.CarId select carImages.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }


    
    }
}       
    

   
