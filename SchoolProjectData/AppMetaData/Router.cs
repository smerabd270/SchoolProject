﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api";
        public const string Version = "V1";
        public const string Rule = Root + "/" + Version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "List";
            public const string Add = Prefix + "Add";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete";
            public const string PagenatedList = Prefix + "PagenatedList";


            public const string GetById = Prefix + "/{id}";

        }
        public static class Department
        {
            public const string Prefix = Rule + "Department";
            public const string List = Prefix + "List";
            public const string Add = Prefix + "Add";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete";
            public const string PagenatedList = Prefix + "PagenatedList";
            public const string GetById = Prefix + "/{id}";

        }
        public static class UserRouting
        {
            public const string Prefix = Rule + "User";
            public const string List = Prefix + "List";
            public const string Add = Prefix + "Register";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete";
            public const string PagenatedList = Prefix + "PagenatedList";
            public const string ChangePassword = Prefix + "Change-Password";
            public const string GetById = Prefix + "/{id}";

        }
        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
            public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";
            public const string ResetPassword = Prefix + "/ResetPassword";

        }

    }
}
