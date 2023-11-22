using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class OpSystem
    {
        [Key]
        public int OpSystemID { get; set; }
        public string OpSystemName { get; set; }
        public string Description { get; set; }
    }
}