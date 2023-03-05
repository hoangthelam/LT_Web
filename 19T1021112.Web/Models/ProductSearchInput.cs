using _19T1021112.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021112.Web.Models
{
    /// <summary>
    /// Lưu trữu thông tin đầu vào dùng để tìm kiếm Mặt hàng, phân trang
    /// </summary>
    public class ProductSearchInput : PaginationSearchInput
    {
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }
}