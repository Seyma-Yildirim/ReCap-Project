using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
       
            
             using (CarRentalContext context = new CarRentalContext())
             {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join user in context.Users on rental.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CarBrandName = brand.BrandName,
                                 Model = car.ModelYear,
                                 CarColor = color.ColorName,
                                 Description = car.Description,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
             }
            
        }

        public List<RentalDetailDto> GetRentalDetailsByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join user in context.Users on rental.UserId equals user.Id
                             where (car.CarId==carId)
                             select new RentalDetailDto
                             {
                                 RentalId= rental.RentalId,
                                 CarBrandName = brand.BrandName,
                                 CarColor = color.ColorName,
                                 Description = car.Description,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
