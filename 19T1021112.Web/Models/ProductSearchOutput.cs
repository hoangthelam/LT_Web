using _19T1021112.DomainModels;
using _19T1021112.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021112.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductSearchOutput : PaginationSearchOutput
    {
        public List<Product> Data { get; set; }

        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        //public int From => (Page - 1) * PageSize + 1;

        //public int To => (Page - 1) * PageSize + Data.Count;
    }
}