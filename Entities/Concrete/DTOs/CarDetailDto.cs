﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
   public class CarDetailDto:IDto
    { 
        public int CarId { get; set; }
        public string BrandName { get; set; } 
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice {  get; set; }
        public string ImagePath {  get; set; }
        public int MinIndexsScore { get; set; }

    }
}
