using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Brand is required!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Display(Name = "Price (USD)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Engine volume is required!")]
        public int Volume { get; set; }
    }
}