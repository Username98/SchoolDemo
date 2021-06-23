using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolDemo.Models
{
    public class Class
    {
        public int Id { get; set; }
        [RegularExpression(@"^([1-9]|1[01])[А-ЩЫЭ-Я]$", ErrorMessage = "Не соотвествует формату имени класса")]
        [Display(Name = "Имя класса")]
        [MaxLength(3, ErrorMessage = "Превышена максимальная длина записи")]
        public string ClassName { get; set; }
        [Display(Name = "Описание")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Description { get; set; }
    }
}