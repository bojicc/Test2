using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class DeviceModel
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int BrandID { get; set; }
        public decimal Price { get; set; }
        public int RAM { get; set; }
        public int StorageCapacity { get; set; }
        public int OpSystemID { get; set; }

        public Brand Brand { get; set; }
        public OpSystem OpSystem { get; set; }
    }
}