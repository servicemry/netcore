using System;
namespace working.Models.DataModel
{
    public class FullDepartment:Department
    {
    /// <summary>
    /// 上级部门名称
    /// </summary>
    /// <value>The name of the PD epart.</value>
        public string PDepartMentName
        {
            get;
            set;
        }
    }
}
