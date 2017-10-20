using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flex.Core
{
    public class AuthUser
    {
        public static bool IsAuthorized
        {
            get
            {
                if (HttpContext.Current.Session["IsAuthorized"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsAuthorized"];
                }
                return false;
            }
            set { HttpContext.Current.Session["IsAuthorized"] = value; }
        }


        public static string Name
        {
            get
            {
                if (HttpContext.Current.Session["Name"] != null)
                {
                    return HttpContext.Current.Session["Name"].ToString();
                }
                return null;
            }
            set { HttpContext.Current.Session["Name"] = value; }
        }

        public static string Lastname
        {
            get
            {
                if (HttpContext.Current.Session["Lastname"] != null)
                {
                    return HttpContext.Current.Session["Lastname"].ToString();
                }
                return null;
            }
            set { HttpContext.Current.Session["Lastname"] = value; }
        }

        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] != null)
                {
                    return HttpContext.Current.Session["Email"].ToString();
                }
                return null;
            }
            set { HttpContext.Current.Session["Email"] = value; }
        }


        public static int? ID
        {
            get
            {
                if (HttpContext.Current.Session["ID"] != null)
                {
                    return (int)HttpContext.Current.Session["ID"];
                }
                HttpContext.Current.Session["ID"] = 1;
                return 1;
            }
            set
            {
                HttpContext.Current.Session["ID"] = value;
            }
        }

        

    }
}