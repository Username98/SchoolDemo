using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolDemo.Models
{
    public class EmployeeAndClass
    {
        public int Id { get; set; }
        [Display(Name = "Название Класса")]
        public int ClassId { get; set; }
        public Class c { get; set; }
        [Display(Name = "Имя сотрудника")]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}