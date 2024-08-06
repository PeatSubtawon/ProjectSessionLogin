using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSessionLogin
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีค่าใน Session["userLogin"] หรือไม่
            var userLogin = Session["userLogin"] as string;
            if (string.IsNullOrEmpty(userLogin))
            {
                Server.Transfer("Login.aspx");
                return;
            }

            // แยกข้อมูลการล็อกอินจาก Session
            var parts = userLogin.Split('|');
            if (parts.Length != 2)
            {
                Server.Transfer("Login.aspx");
                return;
            }

            string username = parts[0];
            string password = parts[1];

            // ตรวจสอบข้อมูลการล็อกอิน
            if (!IsValidUser(username, password))
            {
                Server.Transfer("Login.aspx");
            }
        }
        private bool IsValidUser(string username, string password)
        {
            // ตรวจสอบความถูกต้องของชื่อผู้ใช้และรหัสผ่าน 
            return username == "username" && password == "password";
        }
    }
}