using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ShopThuCungMVC.Services
{
    public static class MailService
    {
        public static void SendMailForSignUp(string code, string email)
        {
            string text = "<p style=\"padding: 0;font-size: 17px;color: #707070;font-family:sans-serif\">Tài khoản SHOPTHUCUNGNLU</p><h1 style=\"padding: 0;font-size: 41px;color: #2672ec;font-family:sans-serif\">Xác nhận tài khoản</h1><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Để hoàn tất việc đăng ký tài khoản, chúng tôi chỉ cần đảm bảo địa chỉ email này là địa chỉ email mà bạn đã sử dụng để đăng ký.</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Để xác minh email của bạn, hãy sử dụng mã bảo mật này: <strong>" + code + "</strong>, thời hạn sử dụng mã này là <strong>180</strong> giây</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Sau khi hết thời gian thì mã bảo mật sẽ hết bạn, hãy nhanh tay nhập nhé!</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Cảm ơn bạn,</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">SHOPTHUCUNGNLU</p>";
            string subject = "Xác nhận email cho tài khoản SHOPTHUCUNGNLU";
            WebMail.Send(email, subject, text, null, null, null, true, null, null, null, null, null, null);
        }
        public static void SendMailForForgotPassword(string code, string email)
        {
            string text = "<p style=\"padding: 0;font-size: 17px;color: #707070;font-family:sans-serif\">Tài khoản SHOPTHUCUNGNLU</p><h1 style=\"padding: 0;font-size: 41px;color: #2672ec;font-family:sans-serif\">Quên mật khẩu tài khoản</h1><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Để xác nhận việc đổi mật khẩu mới, chúng tôi chỉ cần đảm bảo địa chỉ email này là địa chỉ email mà bạn đã sử dụng để đăng ký tài khoản này.</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Để xác minh email của bạn, hãy sử dụng mã bảo mật này: <strong>" + code + "</strong>, thời hạn sử dụng mã này là <strong>180</strong> giây</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Sau khi hết thời gian thì mã bảo mật sẽ hết bạn, hãy nhanh tay nhập nhé!</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">Cảm ơn bạn,</p><p style=\"padding: 0;font-size: 14px;color: #2a2a2a;font-family:sans-serif\">SHOPTHUCUNGNLU</p>";
            string subject = "Mã xác nhận quên mật khẩu SHOPTHUCUNGNLU";
            WebMail.Send(email, subject, text, null, null, null, true, null, null, null, null, null, null);
        }
    }
}