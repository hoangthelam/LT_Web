using _19T1021112.BusinessLayers;
using _19T1021112.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _19T1021112.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập vào hệ thống
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous] // cho phép dùng trang mà không cần đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName = "", string password = "")
        {
            ViewBag.UserName = userName;
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }

            var userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }

            //Ghi cookie cho phiên đăng nhập
            string cookiesString = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount); //chuyển đối tượng thành chuỗi 
            FormsAuthentication.SetAuthCookie(cookiesString, false);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        //Đổi mật khẩu
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(UserAccount data, string newPassword, string confirmNewPassword)
        {
            // Kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.Password))
                ModelState.AddModelError(nameof(data.Password), "Trường bắt buộc!");
            if (string.IsNullOrWhiteSpace(newPassword))
                ModelState.AddModelError(nameof(newPassword), "Trường bắt buộc!");
            if (string.IsNullOrWhiteSpace(confirmNewPassword))
                ModelState.AddModelError(nameof(confirmNewPassword), "Trường bắt buộc!");
            if (!newPassword.Equals(confirmNewPassword))
                ModelState.AddModelError(nameof(confirmNewPassword), "Mật khẩu xác nhận và Mật khẩu mới không trùng khớp!");

            if (ModelState.IsValid == false)    // Kiểm tra dữ liệu đầu vào có hợp lệ hay không
            {
                ModelState.AddModelError("", "Thay đổi thông tin thất bại!");
                return View("Index", data);
            }

            // Đổi mật khẩu
            var useAccount = UserAccountService.ChangePassword(AccountTypes.Employee, data.UserName, data.Password, newPassword);

            if (!useAccount)
            {
                ModelState.AddModelError("", "Thay đổi thông tin thất bại!");
                return View("Index", data);
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thông tin thành công!");
            }

            // Chuyển chuỗi thông tin đăng nhập thành json
            string cookieString = Newtonsoft.Json.JsonConvert.SerializeObject(new UserAccount
            {
                UserID = data.UserID,
                UserName = data.UserName,
                Photo = data.Photo,
                FullName = data.FullName,
                Email = data.Email,
                RoleName = data.RoleName,
                Password = newPassword
            });
            // Ghi cookie cho phiên đăng nhập
            FormsAuthentication.SetAuthCookie(cookieString, false);

            return View("Index", data);
        }

    }
}