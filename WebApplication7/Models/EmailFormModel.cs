using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class EmailFormModel
    {
        [Required(ErrorMessage = "Your name is required!")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "Your e-mail is required!")]
        [EmailAddress(ErrorMessage = "This is not a valid e-mail address!")]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Please enter a comment!")]
        public string Message { get; set; }
    }
}