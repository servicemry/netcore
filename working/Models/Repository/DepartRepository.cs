using System;
using System.Collections.Generic;
using System.Data;
using working.Models.DataModel;
using Dapper;

namespace working.Models.Repository
{
    /// <summary>
    /// 部门仓储类
    /// </summary>
    public class DepartRepository:IDepartRepository
    {
        /// <summary>
        /// 链接对象
        /// </summary>
        IDbConnection _con;
        /// <summary>
        /// 构造方法中初始化链接对象
        /// </summary>
        /// <param name="con">链接对象</param>
        /// <param name="conStr">链接字符串</param>
        public DepartRepository(IDbConnection con)
        {
            _con = con;

        }
        /// <summary>
        /// 查询所有有上级部门的部门
        /// </summary>
        /// <returns>The all department.</returns>
        public List<FullDepartment> GetPDepartment()
        {
            return _con.Query<FullDepartment>("select d.*,pd.departmentname as pdepartmentname from departments d join departments pd on d.id=pd.pdepartmentid").AsList();
        }
        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <returns>The ALLD epartment.</returns>
        public List<FullDepartment> GetALLDepartment()
        {
            return _con.Query<FullDepartment>("select * from departments ").AsList();
        }

        public bool AddDepartment(Department department)
        {
            return _con.Execute("insert into departments (departmentname,pdepartmentid) values(@departmentname,@pdepartmentid)",
            new {departmentname=department.DepartmentName,pdepartmentid=department.PDepartmentID})>0;
            
        }

        public bool ModifyDepartment(Department department)
        {
            return _con.Execute("update  departments set departmentname=@department,pdepartmentid=@pdepartmentid where id=@id",
            new {departmentname=department.DepartmentName,pdepartmentid=department.PDepartmentID,id=department.ID})>0;
        }

        public bool RemoveDepartment(int departmentID)
        {
           return _con.Execute("delete from  departments  where id=@id",new {id=departmentID})>0;
        }
    }
}
