using System;
namespace working.Models.DataModel
{
    public class User
    {
        public int ID
        {
            get;
            set;
        }    
        public int DepartmentID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int RoleID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}