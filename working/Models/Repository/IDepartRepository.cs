using System;
using System.Collections.Generic;
using working.Models.DataModel;

namespace working.Models.Repository
{
    /// <summary>
    /// 部门仓储接口
    /// </summary>
    public interface IDepartRepository
    {
        List<FullDepartment> GetPDepartment();//带父级部门的
        List<FullDepartment> GetALLDepartment();//所有部门
        bool AddDepartment(Department department);//添加部门
        bool ModifyDepartment(Department department);//修改部门
        bool RemoveDepartment(int departmentID);//删除部门
    }
    
   
}
