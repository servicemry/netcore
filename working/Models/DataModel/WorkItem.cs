using System;
namespace working.Models.DataModel
{
    public class WorkItem
    {
        public int ID
        {
            get;
            set;
        }    
        public string CreateTime
        {
            get;
            set;
        }
        public int CreateUserID
        {
            get;
            set;
        }
        public string Memos
        {
            get;
            set;
        }
        public string RecordDate
        {
            get;
            set;
        }
        public string WorkContent
        {
            get;
            set;
        }

    }
}