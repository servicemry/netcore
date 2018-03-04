using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace lotteryadmin.Models{
    public class Manager{
        [Key]
        public int UserId{get;set;}
        [Required(ErrorMessage = "用户名不能为空。")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空。")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public int IsDelete { get; set; }
        public int Enable { get; set; }
        public string RegIp { get; set; }
        public string RegTime { get; set; }
        public string LastLoginIp{ get; set; }
        public string LastLoginTime { get; set; }
        public int ParentId { get; set; }   
    }
}