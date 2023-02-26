using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace _19T1021112.Web
{
  /// <summary>
  /// Lớp cung cấp các hàm chuyển đổi dữ liệu
  /// </summary>
    public static class Converter
    { 
        /// <summary>
        /// chuyển chuổi ngày dạng d/MM/yyy sang giá trị ngày
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
      public static DateTime? DMYStringToDateTime(string s, string format="d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            }
            catch 
            { 
                return null; 
            }
        }
    }
}