using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }


        [Display(Name = "Введите имя")]
        [StringLength(15)]
        [Required(ErrorMessage = "Вы не ввели имя!")]
        public string Name { get; set; }


        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [Required(ErrorMessage = "Вы не ввели фамилию!")]
        public string Surname { get; set; }


        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Вы не ввели адрес!")]
        public string Adress { get; set; }


        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(40)]
        [Required(ErrorMessage = "Вы не ввели телефон!")]
        public string Phone { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Вы не ввели эл.почту!")]
        public string Email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}