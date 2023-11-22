using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public ICollection<DeviceModel> DeviceModels { get; set; }
    }
}