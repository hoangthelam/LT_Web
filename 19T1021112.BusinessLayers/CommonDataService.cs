using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021112.DataLayers;
using _19T1021112.DomainModels;
using System.Configuration;
//test

namespace _19T1021112.BusinessLayers
{
    /// <summary>
    /// Cung cấp các chức năng nghiệp vụ xử lý dữ liệu chung liên quan đến:
    /// Quốc gia, Nhà cung cấp, Khách hàng, Người giao hàng, Nhân viên, Loại hàng.
    /// </summary>
    public static class CommonDataService
    {
        private static ICountryDAL countryDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Shipper> shipperDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Category> categoryDB;

        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            countryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
        }

        #region Xử lý liên quan đến quốc gia

        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }

        #endregion


        #region Nhà cung cấp

        /// <summary>
        /// Tìm kiếm và lấy danh sách của nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page,
                                                    int pageSize,
                                                    string searchValue,
                                                    out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }


        /// <summary>
        /// Tìm kiếm và lấy danh sách của nhà cung cấp (không phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue = "")
        {
            return supplierDB.List(1, 0, searchValue).ToList();
        }

        /// <summary>
        /// Lấy thông tin của 1 nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);
        }

        /// <summary>
        /// Bổ sung nhà cung cấp, Hàm trả về mã của nhà cung cấp được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }

        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }

        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int data)
        {
            return supplierDB.Delete(data);
        }

        /// <summary>
        /// Kiểm tra xem nhà cung cấp có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierID)
        {
            return supplierDB.InUsed(supplierID);
        }
        #endregion

        #region Người giao hàng

        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Shipper> ListOfShippers(string searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);
        }
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        public static bool DeleteShipper(int data)
        {
            return shipperDB.Delete(data);
        }
        public static bool InUsedShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }
        #endregion

        #region Khách hàng

        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Customer> ListOfCustomers(string searchValue = "")
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        public static bool DeleteCustomer(int data)
        {
            return customerDB.Delete(data);
        }
        public static bool InUsedCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }
        #endregion

        #region Nhân viên

        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Employee> ListOfEmployees(string searchValue = "")
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        public static bool DeleteEmployee(int data)
        {
            return employeeDB.Delete(data);
        }
        public static bool InUsedEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }
        #endregion

        #region Mặt hàng

        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Category> ListOfCategories(string searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        public static bool DeleteCategory(int data)
        {
            return categoryDB.Delete(data);
        }
        public static bool InUsedCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }
        #endregion
    }
}
