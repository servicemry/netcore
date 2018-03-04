using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace lotteryadmin.Models
{
    public class CPType
    {
        [Key]
        public int Id { get; set; } 
        public int Type { get; set; }
        public int Enable { get; set; } 
        public int IsDelete { get; set; }
        public int Sort { get; set; }   
        public string Name { get; set; }
        public string CodeList { get; set; }    
        public string Title { get; set; }   
        public string ShortName { get; set; }   
        public string Info { get; set; }  
        public string OnGetNode { get; set; } 
        public int BetStopTime { get; set; }
        public int DefaultShowGroup { get; set; }   
        public int Android { get; set; }
        public int Num { get; set; }  
    }
}