using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021112.BusinessLayers;
using _19T1021112.DomainModels;


namespace _19T1021112.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "--Chọn Quốc Gia--"
            });
            foreach (var Item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = Item.CountryName,
                    Text = Item.CountryName
                });
            }
            return list;
        }
        /// <summary>
        /// Danh sách Loại hàng
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Categories()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "---Chọn Loại hàng---",
            });

            foreach (var item in CommonDataService.ListOfCategories())
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(item.CategoryID),
                    Text = item.CategoryName,
                });
            }

            return list;
        }

        /// <summary>
        /// Danh sách Nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Suppliers()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "---Chọn Nhà cung cấp---",
            });

            foreach (var item in CommonDataService.ListOfSuppliers())
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(item.SupplierID),
                    Text = item.SupplierName,
                });
            }

            return list;
        }
    }
}