using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Вашу фамилию и имя!")]
        [Display(Name = "ФИО")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Введите Вашу Должность!")]
        [Display(Name = "Должность")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Введите Вашу адрес!")]
        [Display(Name = "Домашний адрес")]
        [MaxLength(150, ErrorMessage = "Превышена максимальная длина записи")]
        public string HomeAdress { get; set; }

        [Display(Name = "Категория")]
        [MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        public string Category { get; set; }

    }
}