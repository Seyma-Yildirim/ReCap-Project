using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,CarRentalContext>,IBrandDal
    {

    }
}
