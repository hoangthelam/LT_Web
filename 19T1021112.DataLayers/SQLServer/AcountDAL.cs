using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021112.DomainModels;

namespace _19T1021112.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản
    /// </summary>
    public interface IUserAccount
    {
        /// <summary>
        /// Kiểm Tra thông tin đăng nhập 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        ///ĐỔi mật khẩu người dùng
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
