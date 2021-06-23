using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolDemo.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Введите Вашу фамилию и имя!")]
        [Display(Name = "ФИО")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Класс")]
        public int? ClassId { get; set; }
     
        [MaxLength(150, ErrorMessage = "Превышена максимальная длина записи")]
        [Display(Name = "Домашний адрес")]
        [Required(ErrorMessage = "Поле недолжно быть пустым!")]
        public string HomeAdress { get; set; }
        public Class c { get; set; }

    }
}