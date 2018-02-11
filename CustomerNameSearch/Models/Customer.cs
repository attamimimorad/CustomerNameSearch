using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomerNameSearch.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string MiddleName { get; set; }
        [StringLength(10)]
        public string LastName { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }



    }
}