using _19T1021112.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021112.Web.Models
{
    public class ShipperSearchOutput: PaginationSearchOutput
    {
        public List<Shipper> Data { get; set; }
    }
}