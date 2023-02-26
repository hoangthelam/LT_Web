using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021112.BusinessLayers;
using _19T1021112.DomainModels;
using System.Web.Mvc;

namespace _19T1021112.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list= new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text= "--Chọn Quốc Gia--"
            }) ;
            foreach (var Item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = Item.CountryName,
                    Text = Item.CountryName
                }) ;
            }
            return list;
        }
    }
}