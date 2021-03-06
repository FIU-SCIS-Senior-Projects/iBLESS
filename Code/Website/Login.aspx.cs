﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Text;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validates that a user with Email (which can also be the username), and Password exists in the system
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod]
        public static int Validate(String Email, String Password)
        {
            int response = Database.Validate(Email, Password);

            if (response == 0)
            {
                int id = Database.GetID(Email);

                Subscription.CreateCookie("MyTestCookie", Email);
                Subscription.CreateCookie("ID", id.ToString());
                Database.SetCanCreateCookie(Email);
            }

            return response;
        }
    }
}