using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSessionLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // อ่านชื่อผู้ใช้และรหัสผ่านจาก Session
            // credentials เป็น tuple ที่เก็บ username และ password
            var credentials = ReadSession();

            // ตรวจสอบการเข้าสู่ระบบ 
            if (!string.IsNullOrEmpty(credentials.username) && !string.IsNullOrEmpty(credentials.password))
            {
                // ตรวจสอบการเข้าสู่ระบบ
                // ส่ง tuple ที่ประกอบด้วย username และ password ไปยัง CheckLogin
                CheckLogin(credentials);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // อ่านชื่อผู้ใช้และรหัสผ่านจาก TextBox
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // เขียนข้อมูลลงใน Session
            WriteSession(username, password);

            // ตรวจสอบการเข้าสู่ระบบ
            // credentials เป็น tuple ที่เก็บ username และ password
            var credentials = ReadSession();
            // ส่ง tuple ที่ประกอบด้วย username และ password ไปยัง CheckLogin
            CheckLogin(credentials);

        }
        private void CheckLogin((string username, string password) credentials)
        {
            string username = credentials.username;
            string password = credentials.password;
            if (username == "username" && password == "password")  
            {
                // ย้ายหน้า
                Server.Transfer("Welcome.aspx");
            }
            else
            {
                // ข้อความผิดพลาด
                //Response.Write("Error!!");
                // หรือแสดงกล่องข้อความ
                ShowMessage("Invalid username or password!");
            }
        }
        private void WriteSession(string username, string password)
        {
            string combined = $"{username}|{password}";
            Session["userLogin"] = combined;
        }
        private (string username, string password) ReadSession()
        {
            if (Session["userLogin"] == null)
            {
                return (string.Empty, string.Empty);
            }

            // แยกชื่อผู้ใช้และรหัสผ่านจากสตริงที่รวมกัน
            string combined = Session["userLogin"].ToString();
            string[] parts = combined.Split('|');

            // ตรวจสอบความถูกต้องของการแยกข้อมูล
            if (parts.Length != 2)
            {
                return (string.Empty, string.Empty);
            }

            string username = parts[0];
            string password = parts[1];

            return (username, password);
        }

        private void ShowMessage(string message)
        {
            string script = $"<script type=\"text/javascript\">alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
    }
}