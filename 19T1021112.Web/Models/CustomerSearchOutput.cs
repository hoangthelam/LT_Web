﻿using _19T1021112.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021112.Web.Models
{
    public class CustomerSearchOutput : PaginationSearchOutput
    {
        public List<Customer> Data { get; set; }
    }
}